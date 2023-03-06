using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.ExtraFields;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Models.Items;

public class UpdateItemViewModel : IMapWith<Item>, IMapWith<UpdateItemDto>
{
	public int Id { get; set; }

	[DisplayName("Title")]
	[StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
	[DataType(DataType.Text)]
	public string Title { get; set; } = null!;
	
	public IList<Tag>? Tags { get; set; }

	[DisplayName("Tags")] 
	public ICollection<string>? SelectedTags { get; set; } = new List<string>();

	public IList<UpdateExtraFieldViewModel>? ExtraFields { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Item, UpdateItemViewModel>();
		profile.CreateMap<UpdateItemDto, UpdateItemViewModel>()
			.ReverseMap();
	}
}

