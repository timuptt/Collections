using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class CreateExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueTypeViewModel>
{
    public ValueTypes ValueType { get; set; }
    
    public string Name { get; set; }
    
    public bool IsRequired { get; set; }
    
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueTypeViewModel, CreateExtraFieldValueTypeViewModel>();
    }
}