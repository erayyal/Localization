using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Localization.Models;
using Localization.Services;
using Microsoft.AspNetCore.Localization;

namespace Localization.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private LanguageService _localization;

    public HomeController(ILogger<HomeController> logger, LanguageService localization)
    {
        _logger = logger;
        _localization = localization;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
        return Redirect(Request.Headers["Referer"].ToString());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}