using System.Text;
using AcademiasAPI.Domain.Services;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.CrossCutting.Authentication;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AcademiasAPI.Infrastructure.Storage;
using AcademiasAPI.Infrastructure.Storage.Interfaces;
using AcademiasAPI.Presentation.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AcademiaContext>(options => options
    .UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
    .UseSnakeCaseNamingConvention()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddAuthentication().AddCookie(opts => {
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opts.Cookie.SameSite = SameSiteMode.None;
    opts.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opts.Cookie.HttpOnly = false;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://192.168.0.13:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

ConfigureServices(builder.Services);

builder.Services.AddAutoMapper(cfg =>
{
    
}, AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<HttpExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

var storageUrl = builder.Configuration.GetValue<string?>("FileStorage:StorageUrl") ?? Directory.GetCurrentDirectory();
var basePath = builder.Configuration.GetValue<string>("FileStorage:Path");
if (basePath is null)
{
    throw new Exception("Base path is empty");
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(storageUrl, basePath)),
    RequestPath = "/files"
});


// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseAcademiaProperty();
app.UseExceptionHandler();

app.Run();
return;

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IAcademiaRep,  AcademiaRep>();
    services.AddScoped<IAcademiaService, AcademiaService>();
    
    services.AddScoped<IMaquinaRep, MaquinaRep>();
    services.AddScoped<IMaquinaService, MaquinaService>();
    
    services.AddScoped<IExercicioService, ExercicioService>();
    services.AddScoped<IExercicioRep, ExercicioRep>();
    
    services.AddScoped<IArquivoStorage, ArquivoStorage>();
    
    services.AddScoped<IUsuarioService, UsuarioService>();
    services.AddScoped<IUsuarioRep, UsuarioRep>();
    
    services.AddScoped<ITreinoService, TreinoService>();
    services.AddScoped<ITreinoRep, TreinoRep>();
    
    services.AddScoped<ISerieService, SerieService>();
    services.AddScoped<ISerieRep, SerieRep>();
    
    services.AddScoped<IDireitoRep, DireitoRep>();
    
    services.AddScoped<IAuthService, AuthService>();

    services.AddScoped<UsuarioContext>();
}