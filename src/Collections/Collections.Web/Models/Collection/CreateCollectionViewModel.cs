using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.Web.Models.ExtraFieldValueTypes;
using Collections.Web.Models.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Collection;

public class CreateCollectionViewModel : IMapWith<CreateUserCollectionDto>
{
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.MultilineText)]
    [DisplayName("Description")]
    public string Description { get; set; }
    
    [DisplayName("Image")]
    [AllowedExtensions(new [] {".jpg", ".jpeg", ".png"})]
    [MaxFileSize(5 * 1024 * 1024)]
    public IFormFile? Image { get; set; }
    public string? ImageSource { get; set; }
    
    public string? ImageName { get; set; }
    
    public int UserProfileId { get; set; }
    
    [Required]
    [DisplayName("Theme")]
    public int SelectedThemeId { get; set; }
    
    public SelectList? Themes { get; set; }

    public IEnumerable<CreateExtraFieldValueTypeViewModel>? ExtraFieldValueTypes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCollectionViewModel, CreateUserCollectionDto>()
            .ForMember(collection => collection.UserCollectionThemeId, opt => 
                opt.MapFrom(collectionVm => collectionVm.SelectedThemeId));
    }
}