#pragma checksum "F:\PL\WebProjects\MemberShip\MemberShip\Views\Shared\Languages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2e6da2a3bd8ca01adfbdcc230346d8230e887ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Languages), @"mvc.1.0.view", @"/Views/Shared/Languages.cshtml")]
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
#line 1 "F:\PL\WebProjects\MemberShip\MemberShip\Views\_ViewImports.cshtml"
using MemberShip;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\PL\WebProjects\MemberShip\MemberShip\Views\_ViewImports.cshtml"
using MemberShip.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\PL\WebProjects\MemberShip\MemberShip\Views\_ViewImports.cshtml"
using MemberShip.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\PL\WebProjects\MemberShip\MemberShip\Views\_ViewImports.cshtml"
using DAL.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2e6da2a3bd8ca01adfbdcc230346d8230e887ae", @"/Views/Shared/Languages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f31dad402bc700f52c491c770362160b6abf4d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Languages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<li class=""lange""><a href=""#"" id=""changeLang"">En</a></li>

<script type=""text/javascript"">
    $(function () {
        $(""#changeLang"").click(function (e) {
            e.preventDefault();

            var culture = ""ar"";

            if (culture == ""ar"")
                culture = ""en"";
            else if (culture == ""en"")
                culture = ""ar"";

            SetCookie(""SiteCulture"", culture, 365);

            //window.location.reload();

            if (window.location.href.indexOf(""/ar/"") > -1) {
                window.location = window.location.href.replace(""/ar/"", ""/en/"");
            }
            else if (window.location.href.indexOf(""/en/"") > -1) {
                window.location = window.location.href.replace(""/en/"", ""/ar/"");
            }
            else {
                window.location = window.location.href.concat(""en/"");
            }
        })
    })
</script>");
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
