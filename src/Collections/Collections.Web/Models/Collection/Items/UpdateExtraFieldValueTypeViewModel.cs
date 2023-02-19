using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class UpdateExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueType>
{
    public int Id { get; set; }
    
    public ValueTypes ValueType { get; set; }
    
    [DisplayName("Name")]
    public string Name { get; set; }
    
    public bool IsRequired { get; set; }
    
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, UpdateExtraFieldValueTypeViewModel>()
            .ReverseMap();
        profile.CreateMap<UpdateExtraFieldValueTypeDto, UpdateExtraFieldValueTypeViewModel>()
            .ReverseMap();
    }
}