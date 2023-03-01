using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.Web.Models.ExtraFieldValueTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Collections.Web.Models.ExtraFields;

public class CreateExtraFieldViewModel : IMapWith<ExtraFieldDto>
{
    [StringLength(512, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
    public string Value { get; set; }
    
    public int ExtraFieldValueTypeId { get; set; }

    [ValidateNever]
    public ExtraFieldValueTypeViewModel? ExtraFieldValueType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExtraFieldViewModel, ExtraFieldDto>();
    }
}