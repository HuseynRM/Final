#pragma checksum "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4530eb81da46dbc4f60bc99b554f36860c974833"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductList_Index), @"mvc.1.0.view", @"/Views/ProductList/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4530eb81da46dbc4f60bc99b554f36860c974833", @"/Views/ProductList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cc67ef191cb64e1f19139e941aa69cddecf0013", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ProductList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    //int count;
    //if (ViewBag.SelectedPage == 1)
    //{
    //    count = 0;
    //}
    //else
    //{
    //    count = (int)(ViewBag.SelectedPage - 1) * 8;
    //}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""page-header"">
    <div class=""container"">
        <div class=""row text-center"">
            <div class=""col-md"">
                <h2 class=""heading-1"">Shop List</h2>
                <p class=""text-1"">Tomato is a delicious restaurant website template</p>
            </div>
        </div>
    </div>
</section>

<div class=""shop-content"">
    <div class=""container"">
        <div class=""row"">
            <aside class=""col-lg-3"">
                <div class=""side-widget"">
                    <h5>Our Food</h5>
                    <ul class=""shop-cat"">
");
#nullable restore
#line 37 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                         foreach (var catagory in Model.ShopShopCatagorys)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4530eb81da46dbc4f60bc99b554f36860c9748335961", async() => {
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 41 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                               Write(catagory.CName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (");
#nullable restore
#line 41 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                                                Write(catagory.ShopLists.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(")\r\n                                    <i class=\"fa fa-caret-right\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                                                                                     WriteLiteral(catagory.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 45 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </ul>
                </div>
            </aside>
            <div class=""col-lg-9"">
                <div class=""shop-grid grid-m-3 pb-3"">
                </div>
                <div class=""shop-products"">
                    <div class=""row"">
");
#nullable restore
#line 54 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                         foreach (var Food in Model.ShopLists)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col\">\r\n                                <div class=\"product-info\">\r\n                                    <div class=\"product-img\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4530eb81da46dbc4f60bc99b554f36860c97483310222", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2077, "~/images/", 2077, 9, true);
#nullable restore
#line 59 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
AddHtmlAttributeValue("", 2086, Food.Img, 2086, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n\r\n                                    <h4>\r\n                                        <a href=\"#\">");
#nullable restore
#line 63 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                                               Write(Food.FName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </h4>\r\n\r\n                                    <div class=\"product-price\">$");
#nullable restore
#line 66 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                                                           Write(Food.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n                                    <div class=\"shop-meta\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2511, "\"", 2518, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""fa fa-shopping-cart""></i> Add to cart
                                        </a>
                                    </div>
                                </div>
                            </div>
");
#nullable restore
#line 75 "C:\Users\ASUS\OneDrive\Рабочий стол\Final\tomato-web-BackEnd\Tomato BackEnd\Views\ProductList\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <a href=\"home.html\" class=\"btn btn-primary btn-load\">Load more</a>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
