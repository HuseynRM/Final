#pragma checksum "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f10366a0a1061b68e89488fae6983d7b2b7fb4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 2 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\_ViewImports.cshtml"
using Tomato_BackEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\_ViewImports.cshtml"
using Tomato_BackEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\_ViewImports.cshtml"
using Tomato_BackEnd.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f10366a0a1061b68e89488fae6983d7b2b7fb4f", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cc67ef191cb64e1f19139e941aa69cddecf0013", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("About image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("center-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("cooker image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/quote.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("quote image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""page-header"">
    <div class=""container-fluid"">
        <div class=""row text-center"">
            <div class=""col-md"">
                <h2 class=""heading-1"">about</h2>
                <p class=""text-1"">Read our Story, How we started and about the Team</p>
            </div>
        </div>
    </div>
</section>

<section class=""about2"" id=""about2"">
    <div class=""container"">
        <div class=""row grid grid-lg"">
            <div class=""col"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f10366a0a1061b68e89488fae6983d7b2b7fb4f6604", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 609, "~/uploads/story/", 609, 16, true);
#nullable restore
#line 21 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 625, Model.AboutStory.StoryImg, 625, 26, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col-pd\">\r\n                <h2 class=\"heading-2 text-left\">Our story</h2>\r\n\r\n                <p>\r\n                    ");
#nullable restore
#line 28 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
               Write(Model.AboutStory.StoryContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </p>
                <a href=""#"" class=""btn btn-primary btn-sm"">see our menu</a>
            </div>
        </div>
    </div>
</section>

<!-- Services section -->
<section class=""services"" id=""services"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col"">
                <div class=""section-header pt-5"">
                    <h1 class=""heading-2 text-white"">Special service</h1>
                    <p class=""text-2 text-white"">What Special services we are offering now</p>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""slick-slider services-slider"">
");
#nullable restore
#line 50 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                 foreach (var item in Model.SpecialServices)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"services-content\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f10366a0a1061b68e89488fae6983d7b2b7fb4f9820", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1739, "~/uploads/testimonial/", 1739, 22, true);
#nullable restore
#line 53 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 1761, item.ServiceIMg, 1761, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <h4");
            BeginWriteAttribute("class", " class=\"", 1838, "\"", 1846, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 54 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                                Write(item.ServiceTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p>");
#nullable restore
#line 55 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                      Write(item.ServiceDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 57 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</section>

<!-- team section -->
<section class=""team"" id=""team"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col"">
                <div class=""section-header"">
                    <h1 class=""heading-2"">our team</h1>
                    <p class=""text-2"">The Hardworking Team behind the restaurant</p>
                </div>
            </div>
        </div>
        <!-- cards -->
        <div class=""row grid grid-md"">
");
#nullable restore
#line 76 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
             foreach (var team in Model.AboutTeams)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col text-center\">\r\n                    <div class=\"team-stuff\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f10366a0a1061b68e89488fae6983d7b2b7fb4f13458", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2684, "~/uploads/ourteam/", 2684, 18, true);
#nullable restore
#line 80 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 2702, team.TeamImg, 2702, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <h4>");
#nullable restore
#line 81 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                       Write(team.CookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p>");
#nullable restore
#line 82 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                      Write(team.Designation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <ul class=\"team-social\">\r\n                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2978, "\"", 2999, 1);
#nullable restore
#line 85 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
WriteAttributeValue("", 2985, team.Facebook, 2985, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"fab fa-facebook\"></i>\r\n                                </a>\r\n                            </li>\r\n                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3213, "\"", 3232, 1);
#nullable restore
#line 90 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
WriteAttributeValue("", 3220, team.Twiter, 3220, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fab fa-twitter\"></i></a>\r\n                            </li>\r\n                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3373, "\"", 3392, 1);
#nullable restore
#line 93 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
WriteAttributeValue("", 3380, team.Google, 3380, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fab fa-google-plus\"></i></a>\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 98 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n<!-- User testimonials -->\r\n<div class=\"trusted\" id=\"trusted\">\r\n    <div class=\"trusted-quote\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"trusted-slider\">\r\n");
#nullable restore
#line 108 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                     foreach (var testimonial in Model.AboutTestimonials)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"trusted-content\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f10366a0a1061b68e89488fae6983d7b2b7fb4f18455", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <p class=\"quote-body\">\r\n                                ");
#nullable restore
#line 113 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                           Write(testimonial.QuoteBody);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                            <p class=\"quote-author\">\r\n                                ");
#nullable restore
#line 116 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                           Write(Html.Raw(testimonial.QuoteAuthor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n");
#nullable restore
#line 119 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\About\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
