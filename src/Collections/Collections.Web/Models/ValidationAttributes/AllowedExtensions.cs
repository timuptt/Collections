using System.ComponentModel.DataAnnotations;

namespace Collections.Web.Models.ValidationAttributes;

public class AllowedExtensions : ValidationAttribute
{
    private readonly string[] _extensions;
    
    public AllowedExtensions(string[] extensions)
    {
        _extensions = extensions;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        return $"Only {string.Join(", ", _extensions)} extensions allowed";
    }
}