#pragma checksum "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\FPersons\GetInfoPers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8189f6ab2c3e2e1716ea283223ca63ff8115e613"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FPersons_GetInfoPers), @"mvc.1.0.view", @"/Views/FPersons/GetInfoPers.cshtml")]
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
#line 1 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\_ViewImports.cshtml"
using EntityFramework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\_ViewImports.cshtml"
using EntityFramework.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8189f6ab2c3e2e1716ea283223ca63ff8115e613", @"/Views/FPersons/GetInfoPers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae561b26753b5618ffe60c4b17e35311373f7dfb", @"/Views/_ViewImports.cshtml")]
    public class Views_FPersons_GetInfoPers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TestEntityFramework.Models.LComissionPerson>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\FPersons\GetInfoPers.cshtml"
      
    ViewData["Title"] = "GetInfoPers";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h1>Details</h1>\r\n    <div>\r\n        <h4>FPerson</h4>\r\n        <hr />\r\n        <dl class=\"row\">\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\FPersons\GetInfoPers.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd class=\"col-sm-10\">\r\n                <span> ");
#nullable restore
#line 16 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\FPersons\GetInfoPers.cshtml"
                  Write(item.FComissionNavigation.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n            </dd>\r\n");
#nullable restore
#line 18 "C:\Users\Evgenii\source\repos\TestEntityFramework\EntityFramework.Web\Views\FPersons\GetInfoPers.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n    </div>\r\n    <div>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8189f6ab2c3e2e1716ea283223ca63ff8115e6134835", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TestEntityFramework.Models.LComissionPerson>> Html { get; private set; }
    }
}
#pragma warning restore 1591
