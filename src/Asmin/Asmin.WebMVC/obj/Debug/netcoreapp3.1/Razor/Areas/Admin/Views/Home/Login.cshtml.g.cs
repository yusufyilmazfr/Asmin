#pragma checksum "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98216d8c96439c9f5270158f00c1c1dc2dfdb2db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Login), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Login.cshtml")]
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
#line 1 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\_ViewImports.cshtml"
using Asmin.WebMVC;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98216d8c96439c9f5270158f00c1c1dc2dfdb2db", @"/Areas/Admin/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4aa6dd8791b426bf85d14725cecca62b2e5b02", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Asmin.Entities.DTO.UserLoginDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("120"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/site/img/asmin/asmi-logo-transparent.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
   
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html class=\"no-js\" lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98216d8c96439c9f5270158f00c1c1dc2dfdb2db4847", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
    <title>Asmin - Dashboard</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""shortcut icon"" type=""image/png"" href=""/favicon.ico"">
    <link rel=""stylesheet"" href=""/assets/admin/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/themify-icons.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/metisMenu.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/owl.carousel.min.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/slicknav.min.css"">

    <!-- amchart css -->
    <link rel=""stylesheet"" href=""https://www.amcharts.com/lib/3/plugins/export/export.css"" type=""text/css"" media=""all"" />

    <!-- others css -->
    <link rel=""stylesheet"" href=""/assets/admin/css/typography.css"">
    <link rel=""stylesheet"" href=""/assets/admin/css/default-css.css"">
    ");
                WriteLiteral("<link rel=\"stylesheet\" href=\"/assets/admin/css/styles.css\">\r\n    <link rel=\"stylesheet\" href=\"/assets/admin/css/responsive.css\">\r\n    <!-- modernizr css -->\r\n    <script src=\"/assets/admin/js/vendor/modernizr-2.8.3.min.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98216d8c96439c9f5270158f00c1c1dc2dfdb2db7181", async() => {
                WriteLiteral("\r\n\r\n    <!-- login area start -->\r\n    <div class=\"login-area\">\r\n        <div class=\"container\">\r\n            <div class=\"login-box ptb--100\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98216d8c96439c9f5270158f00c1c1dc2dfdb2db7613", async() => {
                    WriteLiteral("\r\n                    <div class=\"login-form-head\" style=\"background:blue\">\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98216d8c96439c9f5270158f00c1c1dc2dfdb2db7984", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        <h4>Sign In</h4>\r\n                        <p>Hello there, Sign in and start managing your operations.</p>\r\n                    </div>\r\n\r\n                    <div class=\"login-form-body\">\r\n\r\n");
#nullable restore
#line 48 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
                          
                            if (ViewData.ModelState.ErrorCount > 0)
                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                <div class=\"alert alert-warning\">\r\n                                    ");
#nullable restore
#line 52 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
                               Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                </div>\r\n");
#nullable restore
#line 54 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n");
#nullable restore
#line 57 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
                          
                            #region Old

                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\Program Files\GitHub\Asmin\src\Asmin\Asmin.WebMVC\Areas\Admin\Views\Home\Login.cshtml"
                                   

                            #endregion
                        

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                        <div class=""form-gp"">
                            <label for=""exampleInputEmail1"">Email address</label>
                            <input type=""email"" name=""Email"" id=""exampleInputEmail1"" required>
                            <i class=""ti-email""></i>
                            <div class=""text-danger""></div>
                        </div>
                        <div class=""form-gp"">
                            <label for=""exampleInputPassword1"">Password</label>
                            <input type=""password"" name=""Password"" id=""exampleInputPassword1"" required>
                            <i class=""ti-lock""></i>
                            <div class=""text-danger""></div>
                        </div>
                        <div class=""row mb-4 rmber-area"">
                            <div class=""col-6"">
                                <div class=""custom-control custom-checkbox mr-sm-2"">
                                    <input type=""checkbox"" class=""custom-con");
                    WriteLiteral(@"trol-input"" id=""customControlAutosizing"">
                                    <label class=""custom-control-label"" for=""customControlAutosizing"">Remember Me</label>
                                </div>
                            </div>
                            <div class=""col-6 text-right"">
                                <a href=""#"">Forgot Password?</a>
                            </div>
                        </div>

                        <div class=""submit-btn-area"">
                            <button id=""form_submit"" type=""submit"">Login <i class=""ti-arrow-right""></i></button>
                        </div>
                    </div>
                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
        </div>
    </div>
    <!-- login area end -->
    <!-- jquery latest version -->
    <script src=""/assets/admin/js/vendor/jquery-2.2.4.min.js""></script>
    <!-- bootstrap 4 js -->
    <script src=""/assets/admin/js/popper.min.js""></script>
    <script src=""/assets/admin/js/bootstrap.min.js""></script>
    <script src=""/assets/admin/js/owl.carousel.min.js""></script>
    <script src=""/assets/admin/js/metisMenu.min.js""></script>
    <script src=""/assets/admin/js/jquery.slimscroll.min.js""></script>
    <script src=""/assets/admin/js/jquery.slicknav.min.js""></script>
    <!-- others plugins -->
    <script src=""/assets/admin/js/plugins.js""></script>
    <script src=""/assets/admin/js/scripts.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Asmin.Entities.DTO.UserLoginDto> Html { get; private set; }
    }
}
#pragma warning restore 1591