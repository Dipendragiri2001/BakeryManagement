#pragma checksum "D:\dipen\Project\Views\MaterialStock\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c62cc37a3040264c470592125144c8f3d625eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MaterialStock_Index), @"mvc.1.0.view", @"/Views/MaterialStock/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MaterialStock/Index.cshtml", typeof(AspNetCore.Views_MaterialStock_Index))]
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
#line 1 "D:\dipen\Project\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#line 2 "D:\dipen\Project\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c62cc37a3040264c470592125144c8f3d625eca", @"/Views/MaterialStock/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e31fbbec8fb4222cf117a26f28137c5b00e63f", @"/Views/_ViewImports.cshtml")]
    public class Views_MaterialStock_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MaterialStock>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchByDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MaterialStock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 204, true);
            WriteLiteral("<br/>\r\n<div class=\"row\">\r\n  <div class=\"col-lg-12\">\r\n    <div class=\"panel panel-green\">\r\n      <div class=\"panel-heading\">Material Stock List</div>\r\n                        <div class=\"panel-body\">\r\n    ");
            EndContext();
            BeginContext(232, 409, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1cfc2d2096924e2ebb137ee79c84efd5", async() => {
                BeginContext(326, 129, true);
                WriteLiteral("\r\n      <div class=\"input-group\">\r\n        <input type=\"date\" id=\"date\" name=\"date\" class=\"form-control\" placeholder=\"Enter date\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 455, "\"", 481, 1);
#line 10 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
WriteAttributeValue("", 463, ViewBag.DateValue, 463, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(482, 152, true);
                WriteLiteral("/>\r\n        <span class=\"input-group-btn\">\r\n          <input type=\"submit\" class=\"btn btn-primary\" value=\"Search\"/>\r\n        </span>\r\n      </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(641, 412, true);
            WriteLiteral(@"
 
<br/>
  <hr>
<div class=""container col-lg-12"">          
  <table width=""100%"" class=""table table-striped table-bordered table-hover"" id=""dataTables-example"">
    <thead>
      <tr>
        <th>Material Name</th>
        <th>Stock Quantity</th>
        <th>Rate Per Kg</th>
        <th>Price</th>
        <th>Date</th>
        <th colspan=""2"">Action</th>
      </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 32 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
       foreach (var p in Model)
      {

#line default
#line hidden
            BeginContext(1095, 28, true);
            WriteLiteral("          <tr>\r\n        <td>");
            EndContext();
            BeginContext(1124, 13, false);
#line 35 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
       Write(p.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1137, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(1158, 10, false);
#line 36 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
        Write(p.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1172, 17, false);
#line 36 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
                      Write(p.MeasurementUnit);

#line default
#line hidden
            EndContext();
            BeginContext(1190, 24, true);
            WriteLiteral(" </td>\r\n        <td>Rs. ");
            EndContext();
            BeginContext(1215, 28, false);
#line 37 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
           Write(p.RatePerKg.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 24, true);
            WriteLiteral("</td> \r\n        <td>Rs. ");
            EndContext();
            BeginContext(1268, 30, false);
#line 38 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
           Write(p.TotalAmount.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(1298, 24, true);
            WriteLiteral("</td> \r\n        <td>Rs. ");
            EndContext();
            BeginContext(1323, 31, false);
#line 39 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
           Write(p.CreatedAt.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1354, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(1373, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7b54f477701473c9f2c067b63e20eff", async() => {
                BeginContext(1472, 6, true);
                WriteLiteral("Update");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 40 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
                                                                                            WriteLiteral(p.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1482, 114, true);
            WriteLiteral("</td>\r\n        <td><a class=\"btn btn-danger delete\" data-controller=\"MaterialStock\" data-action=\"Delete\" data-id=\"");
            EndContext();
            BeginContext(1597, 4, false);
#line 41 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
                                                                                                      Write(p.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1601, 54, true);
            WriteLiteral("\" data-body-message=\"Are You Sure Want To Delete This ");
            EndContext();
            BeginContext(1656, 13, false);
#line 41 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
                                                                                                                                                                 Write(p.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1669, 34, true);
            WriteLiteral("\">Delete</a></td>\r\n\r\n      </tr>\r\n");
            EndContext();
#line 44 "D:\dipen\Project\Views\MaterialStock\Index.cshtml"
      }  

#line default
#line hidden
            BeginContext(1714, 97, true);
            WriteLiteral("    </tbody>\r\n  </table>\r\n</div>\r\n                        </div>\r\n    </div>\r\n  </div> \r\n  </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MaterialStock>> Html { get; private set; }
    }
}
#pragma warning restore 1591
