using Collections.Web.Interfaces;
using Microsoft.Extensions.Options;

namespace Collections.Web.Services;

public class LocalizationOptionsProvider : ILocalisationOptionsProvider
{
    private readonly IOptions<RequestLocalizationOptions> _options;

    public LocalizationOptionsProvider(IOptions<RequestLocalizationOptions> options)
    {
        _options = options;
    }

    public RequestLocalizationOptions GetOptions()
    {
        return _options.Value;
    }
}