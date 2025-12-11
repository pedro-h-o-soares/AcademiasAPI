using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Models;

public class Base
{
    [Key]
    public Guid Id { get; set; }
}