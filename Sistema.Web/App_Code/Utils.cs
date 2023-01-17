using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DevExpress.Web.Internal;

public static class Utils {

    public static void ApplyTheme(Page page) {
        page.Theme = GetCurrentTheme(page.Request);
    }

    public static string GetCurrentTheme(HttpRequest request) {
        var themeCookie = request.Cookies["MailDemoCurrentTheme"];
        return themeCookie == null ? "Office2010Blue" : HttpUtility.UrlDecode(themeCookie.Value);
    }

    public static bool IsIE7 {
        get { return RenderUtils.Browser.IsIE && RenderUtils.Browser.Version < 8; }
    }

}
