using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DateMustBeAfterAttribute : ValidationAttribute
{
    public DateMustBeAfterAttribute(string targetPropertyName)
        => TargetPropertyName = targetPropertyName;

    public string TargetPropertyName { get; }

    public string GetErrorMessage() =>"Время окончания должно быть больше времени начала";

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var targetValue = validationContext.ObjectInstance
            .GetType()
            .GetProperty(TargetPropertyName)
            ?.GetValue(validationContext.ObjectInstance, null);

        if ((DateTime?)value < (DateTime?)targetValue)
        {
            var propertyName = validationContext.MemberName ?? string.Empty;
            return new ValidationResult(GetErrorMessage(), [propertyName]);
        }

        return ValidationResult.Success;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DateMustBeBeforeAttribute : ValidationAttribute
{
    public DateMustBeBeforeAttribute(string targetPropertyName)
        => TargetPropertyName = targetPropertyName;

    public string TargetPropertyName { get; }

    public string GetErrorMessage() =>
        "Время начала должно быть меньше времени окончания";

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        var targetValue = validationContext.ObjectInstance
            .GetType()
            .GetProperty(TargetPropertyName)
            ?.GetValue(validationContext.ObjectInstance, null);

        if ((DateTime?)value > (DateTime?)targetValue)
        {
            var propertyName = validationContext.MemberName ?? string.Empty;
            return new ValidationResult(GetErrorMessage(), [propertyName]);
        }

        return ValidationResult.Success;
    }
}