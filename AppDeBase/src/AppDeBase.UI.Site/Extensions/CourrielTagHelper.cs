using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AppDeBase.UI.Site.Extensions
{
    public class CourrielTagHelper : TagHelper
    {
        public string CourrielDomaine { get; set; } = "appdebase.com";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + CourrielDomaine;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}