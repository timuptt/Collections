using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.Web.Models.ExtraFields;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Items;

public class CreateItemViewModel : IMapWith<ItemDto>
{
    public int UserCollectionId { get; set; }
    
    [DisplayName("Title")]
    [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.Text)]
    public string Title { get; set; }

    [DisplayName("Tags")]
    public MultiSelectList Tags { get; set; } = new SelectList(new List<SelectListItem>());

    [Required]
    [DisplayName("Tags")]
    public IEnumerable<string> SelectedTags { get; set; }

    public IList<CreateExtraFieldViewModel>? ExtraFields { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateItemViewModel, ItemDto>();
    }
}