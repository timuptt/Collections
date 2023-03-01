using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.ExtraFields;

namespace Collections.Web.Models.Items;

public class UpdateItemViewModel : IMapWith<Item>, IMapWith<UpdateItemDto>
{
	public int Id { get; set; }

	public string Title { get; set; }

	public IList<UpdateExtraFieldViewModel> ExtraFields { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Item, UpdateItemViewModel>();
		profile.CreateMap<UpdateItemDto, UpdateItemViewModel>()
			.ReverseMap();
	}
}

