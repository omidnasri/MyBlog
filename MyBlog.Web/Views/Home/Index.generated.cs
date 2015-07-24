﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
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
    
    #line 2 "..\..\Views\Home\Index.cshtml"
    using MyBlog.Common.Extensions;
    
    #line default
    #line hidden
    using MyBlog.Common.Helpers;
    using MyBlog.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class _Views_Home_Index_cshtml : System.Web.Mvc.WebViewPage<MyBlog.Web.Models.HomeViewModel>
    {
        public _Views_Home_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

DefineSection("header", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\Home\Index.cshtml"
Write(Html.GenerateMetaTag(
        "محسن اسماعیل پور, Mohsen Esmailpour, بلاگ من, .net, c#, asp.net mvc, entity framework, javascript, jquery, web api",
                "I'm newbie software developer with a particular interest in web technologies and creating web application with Microsoft technologies.",
        true, true, "محسن اسماعیل پور (http://www.mohsen.es)"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

            
            #line 10 "..\..\Views\Home\Index.cshtml"
  
    ViewBag.Title = "صفحه اصلی";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"col-lg-3 col-md-2 \"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"tagList\"");

WriteLiteral(">\r\n        <h3>تگها</h3>\r\n        <ul>\r\n");

            
            #line 18 "..\..\Views\Home\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Home\Index.cshtml"
             foreach (var tag in Model.Tags)
            {

            
            #line default
            #line hidden
WriteLiteral("                <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 692), Tuple.Create("\"", 755)
            
            #line 20 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 699), Tuple.Create<System.Object, System.Int32>(Url.Action("PostsByTag", "Post", new {slug = tag.Slug})
            
            #line default
            #line hidden
, 699), false)
);

WriteLiteral(">");

            
            #line 20 "..\..\Views\Home\Index.cshtml"
                                                                                  Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 21 "..\..\Views\Home\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"col-lg-8 col-lg-offset-0 col-md-9 col-md-offset-0\"");

WriteLiteral(">\r\n");

            
            #line 27 "..\..\Views\Home\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Home\Index.cshtml"
     foreach (var post in Model.Posts)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"post-preview\"");

WriteLiteral(">\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 991), Tuple.Create("\"", 1071)
            
            #line 30 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 998), Tuple.Create<System.Object, System.Int32>(Url.Action("PostDetail", "Post", new { id = post.Id, slug = post.Slug })
            
            #line default
            #line hidden
, 998), false)
);

WriteLiteral(">\r\n                <h2");

WriteLiteral(" class=\"post-title\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\Home\Index.cshtml"
               Write(post.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </h2>\r\n                <div");

WriteLiteral(" class=\"post-subtitle\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Views\Home\Index.cshtml"
               Write(Html.Raw(post.Content.TruncateHtml(350, "...")));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </a>\r\n            <p");

WriteLiteral(" class=\"post-meta\"");

WriteLiteral(">\r\n                <a><i");

WriteLiteral(" class=\"glyphicon glyphicon-calendar\"");

WriteLiteral("></i></a>&nbsp;<span");

WriteLiteral(" class=\"date\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Home\Index.cshtml"
                                                                                       Write(post.CreateDate.ToJalaliDateTimeFullString().ToPersianDigits());

            
            #line default
            #line hidden
WriteLiteral("</span> <span");

WriteLiteral(" class=\"divider-vertical\"");

WriteLiteral("></span>\r\n                <a><i");

WriteLiteral(" class=\"glyphicon glyphicon-comment\"");

WriteLiteral("></i></a>&nbsp;&nbsp;<span");

WriteLiteral(" class=\"disqus-comment-count\"");

WriteLiteral(" data-disqus-identifier=\"");

            
            #line 40 "..\..\Views\Home\Index.cshtml"
                                                                                                                                    Write(post.Id);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("></span> <span");

WriteLiteral(" class=\"divider-vertical\"");

WriteLiteral("></span>\r\n                <a> <i");

WriteLiteral(" class=\"glyphicon glyphicon-tag\"");

WriteLiteral("></i></a>&nbsp;\r\n                ");

WriteLiteral("\r\n                <span>\r\n");

            
            #line 44 "..\..\Views\Home\Index.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Home\Index.cshtml"
                     foreach (var tag in post.Tags)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2095), Tuple.Create("\"", 2160)
            
            #line 46 "..\..\Views\Home\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2102), Tuple.Create<System.Object, System.Int32>(Url.Action("PostsByTag", "Post", new { slug = tag.Slug })
            
            #line default
            #line hidden
, 2102), false)
);

WriteLiteral(">");

            
            #line 46 "..\..\Views\Home\Index.cshtml"
                                                                                        Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>");

WriteLiteral("&nbsp;");

WriteLiteral("\r\n");

            
            #line 47 "..\..\Views\Home\Index.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </span>\r\n            </p>\r\n        </div>\r\n");

WriteLiteral("        <hr />\r\n");

            
            #line 52 "..\..\Views\Home\Index.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <!-- Pager -->\r\n    ");

WriteLiteral("\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
        var disqus_shortname = 'mohsenes'; // required: replace example with your forum shortname

        /* * * DON'T EDIT BELOW THIS LINE * * */
        (function () {
            var s = document.createElement('script'); s.async = true;
            s.type = 'text/javascript';
            s.src = '//' + disqus_shortname + '.disqus.com/count.js';
            (document.getElementsByTagName('HEAD')[0] || document.getElementsByTagName('BODY')[0]).appendChild(s);
        }());
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
