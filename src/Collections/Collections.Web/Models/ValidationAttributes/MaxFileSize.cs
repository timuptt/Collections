using System.ComponentModel.DataAnnotations;

namespace Collections.Web.Models.ValidationAttributes;

public class MaxFileSize : ValidationAttribute
{
    private readonly int _maxFileSize;
    public MaxFileSize(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file) return ValidationResult.Success;
        return file.Length > _maxFileSize ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        return $"Maximum allowed file size is { _maxFileSize} bytes.";
    }
}