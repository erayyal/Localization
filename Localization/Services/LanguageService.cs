using System.Reflection;
using Microsoft.Extensions.Localization;

namespace Localization.Services;

public class SharedResource
{
    
}
public class LanguageService
{
    private readonly IStringLocalizer _stringLocalizer;

    public LanguageService(IStringLocalizerFactory stringLocalizerFactory)
    {
        _stringLocalizer = stringLocalizerFactory.Create(nameof(SharedResource),"Localization");
    }

    public string GetKey(string key)
    {
        return _stringLocalizer[key].Value;   
    }
}