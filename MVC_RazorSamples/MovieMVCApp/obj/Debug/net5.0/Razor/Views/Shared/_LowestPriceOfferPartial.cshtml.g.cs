#pragma checksum "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4c3d52fe10c83bd5c6eddea52a4a01786dac4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LowestPriceOfferPartial), @"mvc.1.0.view", @"/Views/Shared/_LowestPriceOfferPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\_ViewImports.cshtml"
using MovieMVCApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\_ViewImports.cshtml"
using MovieMVCApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\_ViewImports.cshtml"
using MovieMVCApp.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4c3d52fe10c83bd5c6eddea52a4a01786dac4cb", @"/Views/Shared/_LowestPriceOfferPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"210b973e1deef775f0ffa364009742e304e1c887", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LowestPriceOfferPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieMVCApp.Models.Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml"
   
    Movie movieWithTheLowestPrice = null;
    
    // Wir ermitteln hier den günstigen Film, der in der gefilterten Liste angezeigt wird
    if(Model.Any())
    {
        movieWithTheLowestPrice = Model.OrderBy(o => o.Price).First();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml"
 if (movieWithTheLowestPrice != null)
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Sonderangebot</p>\r\n");
            WriteLiteral("    <div class=\"card\" style=\"background-color:darkorange\">\r\n        <div class=\"card-body\">\r\n            <p>");
#nullable restore
#line 20 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml"
          Write(movieWithTheLowestPrice.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>");
#nullable restore
#line 21 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml"
          Write(movieWithTheLowestPrice.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Aktueller Kurs\MVCKurs_2022_KW1_ppedv\MVC_RazorSamples\MovieMVCApp\Views\Shared\_LowestPriceOfferPartial.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieMVCApp.Models.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591