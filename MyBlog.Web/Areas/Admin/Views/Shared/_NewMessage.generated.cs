﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MyBlog.Common.Extensions;
    using MyBlog.Common.Helpers;
    using MyBlog.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Admin/Views/Shared/_NewMessage.cshtml")]
    public partial class _Areas_Admin_Views_Shared__NewMessage_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<MyBlog.Domain.ContactMessageEntity>>
    {
        public _Areas_Admin_Views_Shared__NewMessage_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">\r\n    <i");

WriteLiteral(" class=\"fa fa-envelope\"");

WriteLiteral("></i>\r\n");

            
            #line 5 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
     if (Model.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <span");

WriteLiteral(" class=\"label label-success\"");

WriteLiteral(">");

            
            #line 7 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                                     Write(Model.Count());

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 8 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n\r\n<ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
     if (Model.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <li>\r\n            <ul");

WriteLiteral(" class=\"menu\"");

WriteLiteral(">\r\n");

            
            #line 16 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                
            
            #line default
            #line hidden
            
            #line 16 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                 foreach (var message in Model)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <li>\r\n                        <!-- start message -->\r\n       " +
"                 <a");

WriteAttribute("href", Tuple.Create(" href=\"", 536), Tuple.Create("\"", 603)
            
            #line 20 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
, Tuple.Create(Tuple.Create("", 543), Tuple.Create<System.Object, System.Int32>(Url.Action("Detail", "ContactMessage", new {id=message.Id})
            
            #line default
            #line hidden
, 543), false)
);

WriteLiteral(">\r\n                            <h4>\r\n");

WriteLiteral("                                ");

            
            #line 22 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                           Write(message.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <small><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral("></i> ");

            
            #line 23 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                                                                Write(message.CreateDate.TimeAgo());

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n                            </h4>\r\n                            <p>");

            
            #line 25 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                          Write(message.Message.Truncate(50));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </a>\r\n                    </li>\r\n");

            
            #line 28 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </ul>\r\n        </li>\r\n");

            
            #line 31 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <li");

WriteLiteral(" class=\"header\"");

WriteLiteral(">هیچ پیام جدید وجود ندارد</li>\r\n");

            
            #line 35 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <li");

WriteLiteral(" class=\"footer\"");

WriteLiteral("><a");

WriteAttribute("href", Tuple.Create(" href=\"", 1121), Tuple.Create("\"", 1166)
            
            #line 36 "..\..\Areas\Admin\Views\Shared\_NewMessage.cshtml"
, Tuple.Create(Tuple.Create("", 1128), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "ContactMessage")
            
            #line default
            #line hidden
, 1128), false)
);

WriteLiteral(">مشاهده همه پیامها</a></li>\r\n</ul>");

        }
    }
}
#pragma warning restore 1591
