using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace RazorSamples.TagHelpers
{
    public static class MyHTMLHelpers //Erweiterte Methoden müssen in einer static class festgehalten werden
    {
        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
        {
            return new HtmlString("<strong>Hello World</strong>");
        }

        public static string HelloWorldString(this IHtmlHelper htmlHelper)
        {
            return "<strong> Hello World </strong>";
        }

        public static IHtmlContent HelloWorld(this IHtmlHelper htmlHelper, string name)
        {
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml.Append("Hello, " + name + "!");

            var br = new TagBuilder("br") { TagRenderMode = TagRenderMode.SelfClosing };

            string result;

            using (var writer = new StringWriter())
            {
                span.WriteTo(writer, HtmlEncoder.Default);
                br.WriteTo(writer, HtmlEncoder.Default);
                result = writer.ToString();
            }

            return new HtmlString(result);
        }
    }
}
