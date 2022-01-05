using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieStoreSample.Models;

namespace MovieStoreSample.ViewComponents
{
    public class CulturSwitcherViewComponent : ViewComponent
    {
        private IOptions<RequestLocalizationOptions> _localizationOptions;

        //Dependency Injection wird unterstützt -> Konstruktur Injection
        public CulturSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            IRequestCultureFeature cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();

            CultureSwitcherModel model = new CultureSwitcherModel
            {
                SupportedCultures = _localizationOptions.Value.SupportedUICultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };

            return View(model); //View->Shared->Component->CultureSwichter->Default.cshtml
        }
    }
}
