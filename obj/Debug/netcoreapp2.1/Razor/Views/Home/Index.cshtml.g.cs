#pragma checksum "D:\dipen\Project\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d1859e95fb24d0bd28fdbfbf853259efc46ac20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d1859e95fb24d0bd28fdbfbf853259efc46ac20", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e31fbbec8fb4222cf117a26f28137c5b00e63f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 3 "D:\dipen\Project\Views\Home\Index.cshtml"
 if(TempData["x"]!=null || TempData["y"]!=null)
{

#line default
#line hidden
            BeginContext(56, 153, true);
            WriteLiteral("<div class=\"col-lg-12\"></div>\r\n            <div class=\"alert alert-danger alert-dismissible fade show\" role=\"alert\">\r\n  <strong>Holy guacamole!</strong> ");
            EndContext();
            BeginContext(210, 13, false);
#line 7 "D:\dipen\Project\Views\Home\Index.cshtml"
                              Write(TempData["x"]);

#line default
#line hidden
            EndContext();
            BeginContext(223, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(225, 13, false);
#line 7 "D:\dipen\Project\Views\Home\Index.cshtml"
                                             Write(TempData["y"]);

#line default
#line hidden
            EndContext();
            BeginContext(238, 149, true);
            WriteLiteral("\r\n  <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n    <span aria-hidden=\"true\">&times;</span>\r\n  </button>\r\n</div> \r\n");
            EndContext();
#line 12 "D:\dipen\Project\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(390, 106, true);
            WriteLiteral("            <!-- /.row -->\r\n<div class=\"row container-fluid\">\r\n   <!-- Earnings (Daily) Card Example -->\r\n");
            EndContext();
#line 16 "D:\dipen\Project\Views\Home\Index.cshtml"
         if(@ViewBag.ProfitLoss !=null){

#line default
#line hidden
            BeginContext(538, 469, true);
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6 mb-4"">
              <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                  <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                      <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">Earnings (Daily)</div>
                      <div class=""h5 mb-0 font-weight-bold text-gray-800"">Rs. ");
            EndContext();
            BeginContext(1008, 35, false);
#line 23 "D:\dipen\Project\Views\Home\Index.cshtml"
                                                                         Write(ViewBag.ProfitLoss.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(1043, 275, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                      <i class=""fas fa-calendar fa-2x text-gray-300""></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
");
            EndContext();
#line 32 "D:\dipen\Project\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1329, 521, true);
            WriteLiteral(@"    <!-- Earnings (Monthly) Card Example -->
  
            <div class=""col-xl-3 col-md-6 mb-4"">
              <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                  <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                      <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">Earnings (Monthly)</div>
                      <div class=""h5 mb-0 font-weight-bold text-gray-800"">Rs. ");
            EndContext();
            BeginContext(1851, 36, false);
#line 41 "D:\dipen\Project\Views\Home\Index.cshtml"
                                                                         Write(ViewBag.monthlyData.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(1887, 1008, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                      <i class=""fas fa-calendar fa-2x text-gray-300""></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
</div>
 
     <div class=""row"">          
            <div class=""col-lg-6"">
                    <div class=""panel panel-default"">
                        <div class=""panel-heading"">
                            <i class=""fa fa-bar-chart-o fa-fw""></i> Doughnut Chart 
                        </div>
                        <div class=""panel-body"">
                           <canvas id=""myChart"" width=""400"" height=""400""></canvas>
                            <a href=""#"" class=""btn btn-default btn-block"">View Details</a>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                </div>
                <!-- /.col-lg-6 -->
    </div>
  </div>
 
</div>
");
            EndContext();
            BeginContext(3609, 2, true);
            WriteLiteral(" }");
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
