﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorSamples.TagHelpers
{
    public class WebsiteInformationTagHelper : TagHelper
    {
        public WebSiteContext Info { get; set; } = default!; //wird in unserem <WebsiteInformation Info=""    />

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";

            output.Content.SetHtmlContent(
        $@"<ul><li><strong>Version:</strong> {Info.Version}</li>
                <li><strong>Copyright Year:</strong> {Info.CopyrightYear}</li>
                <li><strong>Approved:</strong> {Info.Approved}</li>
                <li><strong>Number of tags to show:</strong> {Info.TagsToShow}</li></ul>");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }




    public class WebSiteContext
    {
        public Version Version { get; set; } = default!;
        public int CopyrightYear { get; set; }
        public bool Approved { get; set; }
        public int TagsToShow { get; set; }
    }
}
