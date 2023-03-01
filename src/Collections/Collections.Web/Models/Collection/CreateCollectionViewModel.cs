using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Collections.Web.Models.ExtraFieldValueTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Collection;

public class CreateCollectionViewModel
{
    [Required]
    [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [Required]
    [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.MultilineText)]
    [DisplayName("Description")]
    public string Description { get; set; }
    
    [DisplayName("Image")]
    public IFormFile? Image { get; set; }
    public string? ImageSource { get; set; }
    
    public string? ImageName { get; set; }
    
    public int UserProfileId { get; set; }
    
    [Required]
    [DisplayName("Theme")]
    public int SelectedThemeId { get; set; }
    
    public SelectList? Themes { get; set; }

    public IEnumerable<CreateExtraFieldValueTypeViewModel>? ExtraFieldValueTypes { get; set; }
}