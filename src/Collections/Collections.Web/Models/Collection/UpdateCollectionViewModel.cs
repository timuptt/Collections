using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;
using Collections.Web.Models.ExtraFieldValueTypes;
using Collections.Web.Models.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Collection;

public class UpdateCollectionViewModel : IMapWith<UserCollection>
{
    public int Id { get; set; }
    
    [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.Text)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.MultilineText)]
    [DisplayName("Description")]
    public string Description { get; set; }

    public string? ImageSource { get; set; }
    
    public string? ImageName { get; set; }
    
    [DisplayName("Image")]
    [AllowedExtensions(new [] {".jpg", ".jpeg", ".png"})]
    [MaxFileSize(5 * 1024 * 1024)]
    public IFormFile? Image { get; set; }
    
    [Required]
    [DisplayName("Theme")]
    public int SelectedThemeId { get; set; }
    
    public SelectList? Themes { get; set; }
    
    public IList<UpdateExtraFieldValueTypeViewModel>? ExtraFieldValueTypes { get; set; }
    
    public IList<CreateExtraFieldValueTypeViewModel>? NewExtraFieldValueTypes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollection, UpdateCollectionViewModel>()
            .ForMember(collectionVm => collectionVm.SelectedThemeId, opt =>
                opt.MapFrom(collection => collection.UserCollectionThemeId));
        profile.CreateMap<UpdateCollectionViewModel, UpdateUserCollectionDto>()
            .ForMember(collection => collection.UserCollectionThemeId, opt =>
                opt.MapFrom(collectionVm => collectionVm.SelectedThemeId));
    }
}