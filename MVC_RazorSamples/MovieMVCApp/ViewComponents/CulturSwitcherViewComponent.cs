using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMVCApp.ViewComponents
{
    public class CulturSwitcherViewComponent : ViewComponent
    {
        private IOptions<RequestLocalizationOptions> _localizationOptions;

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

            return View(model);
        }
    }
}
