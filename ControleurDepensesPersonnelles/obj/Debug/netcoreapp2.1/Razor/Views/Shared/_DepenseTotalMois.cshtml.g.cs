#pragma checksum "C:\Users\josel\Source\Repos\petites-exemples\ControleurDepensesPersonnelles\Views\Shared\_DepenseTotalMois.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0811956755e910acfe3000b862c687d7072d9fa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DepenseTotalMois), @"mvc.1.0.view", @"/Views/Shared/_DepenseTotalMois.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_DepenseTotalMois.cshtml", typeof(AspNetCore.Views_Shared__DepenseTotalMois))]
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
#line 1 "C:\Users\josel\Source\Repos\petites-exemples\ControleurDepensesPersonnelles\Views\_ViewImports.cshtml"
using ControleurDepensesPersonnelles;

#line default
#line hidden
#line 2 "C:\Users\josel\Source\Repos\petites-exemples\ControleurDepensesPersonnelles\Views\_ViewImports.cshtml"
using ControleurDepensesPersonnelles.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0811956755e910acfe3000b862c687d7072d9fa9", @"/Views/Shared/_DepenseTotalMois.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"055c0fdc7dd5436c2578460d769fb5201251d8f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__DepenseTotalMois : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 130, true);
            WriteLiteral("<div class=\"divDepenseTotalMois\">\r\n    <canvas id=\"GraphiqueDepenseTotalMois\" style=\"width:400px; height:400px;\"></canvas>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591