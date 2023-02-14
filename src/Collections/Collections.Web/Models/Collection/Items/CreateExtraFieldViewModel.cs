using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Collections.Web.Models.Collection.Items;

public class CreateExtraFieldViewModel
{
    public string Value { get; set; }
    
    public int ExtraFieldValueTypeId { get; set; }

    [ValidateNever]
    public ExtraFieldValueTypeViewModel? ExtraFieldValueType { get; set; }
}