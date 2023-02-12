using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Collection;

public class CreateCollectionViewModel
{
    [Required]
    [MaxLength(40)]
    [MinLength(2)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(1000)]
    [MinLength(2)]
    [DataType(DataType.MultilineText)]
    [DisplayName("Description")]
    public string Description { get; set; }
    
    public string? ImageSource { get; set; }
    
    [Required]
    [DisplayName("Theme")]
    public int SelectedThemeId { get; set; }
    
    public SelectList? Themes { get; set; }

    public IEnumerable<ExtraFieldValueTypeViewModel>? ExtraFieldValueTypes { get; set; }

    
}