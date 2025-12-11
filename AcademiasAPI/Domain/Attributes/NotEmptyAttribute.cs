using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Attributes;

[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, 
    AllowMultiple = false)]
public class NotEmptyAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = "O campo [{0}] é obrigatório";
    public NotEmptyAttribute() : base(DefaultErrorMessage) { }

    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return true;
        }

        switch (value)
        {
            case Guid guid:
                return guid != Guid.Empty;
            default:
                return true;
        }
    }
}
