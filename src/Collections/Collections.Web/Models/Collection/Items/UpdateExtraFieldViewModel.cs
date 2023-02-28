using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using AutoMapper;
using Collections.ApplicationCore.Dtos;

namespace Collections.Web.Models.Collection.Items;

public class UpdateExtraFieldViewModel : IMapWith<ExtraField>, IMapWith<UpdateExtraFieldDto>
{
	public int Id { get; set; }

    [MinLength(1)]
    public string Value { get; set; }

    public ExtraFieldValueTypeViewModel ExtraFieldValueType { get; set; }

    public int ExtraFieldValueTypeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraField, UpdateExtraFieldViewModel>();
        profile.CreateMap<UpdateExtraFieldDto, UpdateExtraFieldViewModel>()
            .ReverseMap();
    }
}


