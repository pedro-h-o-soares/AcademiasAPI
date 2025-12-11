using System.Linq.Expressions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Models.Interfaces;
using AcademiasAPI.Infrastructure.CrossCutting.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AcademiasAPI.Infrastructure.Database;

public class AcademiaContext(DbContextOptions<AcademiaContext> options, UsuarioContext ctx) : DbContext(options)
{
    public DbSet<Academia> Academias { get; set; }
    public DbSet<Maquina> Maquinas { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Direito> Direitos { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<ExercicioSerie> ExerciciosSerie { get; set; }

    private Guid AcademiaId => ctx.RequireAcademiaId();
    private Guid UsuarioId => ctx.RequireUsuarioId();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        SetAcademiaTenantFilter(builder);
        
        builder.Entity<Exercicio>()
            .HasMany(e => e.Maquinas)
            .WithMany()
            .UsingEntity(
                "maquinas_exercicios",
                r => r.HasOne(typeof(Maquina))
                    .WithMany()
                    .HasForeignKey("maquina_id")
                    .HasPrincipalKey(nameof(Maquina.Id)),
                l => l.HasOne(typeof(Exercicio))
                    .WithMany()
                    .HasForeignKey("exercicio_id")
                    .HasPrincipalKey(nameof(Exercicio.Id)),
                j => j.HasKey("maquina_id", "exercicio_id"));
        
        builder.Entity<Usuario>()
            .HasMany(u => u.Direitos)
            .WithMany()
            .UsingEntity(
                "direitos_usuarios",
                r => r.HasOne(typeof(Direito))
                    .WithMany()
                    .HasForeignKey("direito_id")
                    .HasPrincipalKey(nameof(Direito.Id)),
                l => l.HasOne(typeof(Usuario))
                    .WithMany()
                    .HasForeignKey("usuario_id")
                    .HasPrincipalKey(nameof(Usuario.Id)),
                j => j.HasKey("direito_id", "usuario_id"));
        
        builder.Entity<Usuario>()
            .Navigation(u => u.Direitos)
            .AutoInclude();

        builder.Entity<Serie>()
            .HasMany(s => s.Exercicios)
            .WithOne()
            .HasForeignKey(e => e.SerieId);
        
        builder.Entity<ExercicioSerie>()
            .HasOne(e => e.Exercicio)
            .WithMany()
            .HasForeignKey(e => e.ExercicioId);
    }
    
    public override int SaveChanges()
    {
        SetAcademiaId();
        SetUsuarioId();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAcademiaId();
        SetUsuarioId();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAcademiaTenantFilter(ModelBuilder builder)
    {
        var clrTypes = builder.Model
            .GetEntityTypes()
            .Select(e => e.ClrType)
            .Where(t => typeof(Base).IsAssignableFrom(t))
            .ToArray();
        
            Expression<Func<IAcademiaTenant, bool>> academiaFilter = t => t.AcademiaId == AcademiaId;
            Expression<Func<IUsuarioTenant, bool>> usuarioFilter = t => t.UsuarioId == UsuarioId;

        foreach (var type in clrTypes)
        {
            var parameter = Expression.Parameter(type);
            if (typeof(IAcademiaTenant).IsAssignableFrom(type))
            {
                var body = ReplacingExpressionVisitor.Replace(
                    academiaFilter.Parameters.Single(), parameter, academiaFilter.Body
                );
                var lambda = Expression.Lambda(body, parameter);
                
                builder.Entity(type).HasQueryFilter(lambda);
            }
            else if (typeof(IUsuarioTenant).IsAssignableFrom(type))
            {
                var body = ReplacingExpressionVisitor.Replace(
                    usuarioFilter.Parameters.Single(), parameter, usuarioFilter.Body
                );
                var lambda = Expression.Lambda(body, parameter);
                
                builder.Entity(type).HasQueryFilter(lambda);
            }
        }
    }

    private void SetAcademiaId()
    {
        var entries = ChangeTracker.Entries<IAcademiaTenant>()
            .Where(e => e.State == EntityState.Added)
            .ToArray();

        foreach (var entry in entries)
        {
            entry.Entity.AcademiaId = AcademiaId;
        }
    }
    
    private void SetUsuarioId()
    {
        var entries = ChangeTracker.Entries<IUsuarioTenant>()
            .Where(e => e.State == EntityState.Added)
            .ToArray();

        foreach (var entry in entries)
        {
            entry.Entity.UsuarioId = UsuarioId;
        }
    }
}