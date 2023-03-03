using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.Web.Models.ExtraFieldValueTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Collections.Web.Models.ExtraFields;

public class CreateExtraFieldViewModel : IMapWith<ExtraFieldDto>
{
    public string? Value { get; set; }
    
    public int ExtraFieldValueTypeId { get; set; }

    [ValidateNever]
    public ExtraFieldValueTypeViewModel? ExtraFieldValueType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExtraFieldViewModel, ExtraFieldDto>();
    }
}