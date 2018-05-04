using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateEmailLink(this HtmlHelper html, string Email)
        {
            return new MvcHtmlString(string.Format("<a href='mailto:{0}'>{0}</a>", Email));
        }
    }
}