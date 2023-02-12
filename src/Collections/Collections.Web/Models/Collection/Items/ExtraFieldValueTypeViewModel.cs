using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class ExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueType>
{
    public string Id { get; set; }
    
    public string ValueType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, ExtraFieldValueTypeViewModel>();
    }
}