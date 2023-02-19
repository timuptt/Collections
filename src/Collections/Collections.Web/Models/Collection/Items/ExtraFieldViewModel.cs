using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Collections.Web.Models.Collection.Items;

public class ExtraFieldViewModel : IMapWith<ExtraField>
{
    public int Id { get; set; }
    public string Value { get; set; }
    
    [ValidateNever]
    public ExtraFieldValueTypeViewModel? ExtraFieldValueType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraField, ExtraFieldViewModel>();
    }
}