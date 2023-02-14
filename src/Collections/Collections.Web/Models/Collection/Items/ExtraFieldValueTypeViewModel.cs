using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class ExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueType>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ValueTypes ValueType { get; set; }
    
    public bool IsVisible { get; set; }
    
    public bool IsRequired { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, ExtraFieldValueTypeViewModel>();
    }
}