#pragma checksum "C:\Users\User\Documents\FinalProject\FinalProjectBack-Front\FinalProjectBack-Front\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0e1d391b8c9b36840d8bade4cd29459bdf8d84b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\User\Documents\FinalProject\FinalProjectBack-Front\FinalProjectBack-Front\Views\_ViewImports.cshtml"
using FinalProjectBack_Front;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\FinalProject\FinalProjectBack-Front\FinalProjectBack-Front\Views\_ViewImports.cshtml"
using FinalProjectBack_Front.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Documents\FinalProject\FinalProjectBack-Front\FinalProjectBack-Front\Views\_ViewImports.cshtml"
using FinalProjectBack_Front.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0e1d391b8c9b36840d8bade4cd29459bdf8d84b", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd602a1a8d4262724f19bec0e3f71ab3414a075d", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("contactForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Documents\FinalProject\FinalProjectBack-Front\FinalProjectBack-Front\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""contactEntrance"">
    <div class=""row contactRow"">
        <div class=""contactImage-Content"">
            <div style=""background-image: url(https://cdn.shopify.com/s/files/1/0437/1913/1293/files/about-bg_1950x.jpg?v=1600933977);""
                 class=""contactImage""><img");
            BeginWriteAttribute("alt", " alt=\"", 334, "\"", 340, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
            <div class=""contactContent"">
                <span>Contact Us</span>
            </div>
        </div>
    </div>
</section>
<section id=""contactUs"">
    <div class=""container"">
        <div class=""row message-infoRow"">
            <div class=""row messageRow col-lg-6"">
                <div class=""title"">
                    <span>DROP US A LINE</span>
                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0e1d391b8c9b36840d8bade4cd29459bdf8d84b5397", async() => {
                WriteLiteral(@"
                    <label for=""contactName"">Your Name (required)</label><br>
                    <input type=""text"" id=""contactName"" required><br><br>
                    <label for=""contactMail"">Your Email (required)</label><br>
                    <input type=""email"" id=""contactMail"" required><br><br>
                    <label for=""contactTel"">Your Phone Number</label><br>
                    <input type=""tel"" id=""contactTel""><br><br>
                    <label for=""contactTextArea"">Your Message</label><br>
                    <textarea");
                BeginWriteAttribute("name", " name=\"", 1359, "\"", 1366, 0);
                EndWriteAttribute();
                WriteLiteral(" id=\"contactTextArea\" cols=\"30\" rows=\"10\"></textarea><br><br>\r\n                    <button class=\"contactButton\">Send</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""row contactInfoRow col-lg-6"">
                <div class=""contactInfoTitle col-lg-3"">
                    <p>CONTACT INFORMATION</p>
                </div>
                <div class=""contactWrapper col-lg-3"">
                    <p class=""contactInfoDescription"">
                        We love to hear from you on our customer service,
                        merchandise, website or any topics you want to share with us. Your comments and
                        suggestions will be appreciated. Please complete the form below.
                    </p>
                    <p class=""contactInfoAdresss"">Baku,Nasimi,Jeyhun Salimov 7</p>
                    <p class=""contactInfoMail"">jamalaz@code.edu.az</p>
                    <p class=""contactInfoWorkTime"">Everyday 09:00-18:00</p>
                </div>
            </div>
        </div>
    </div>
</section>

");
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
