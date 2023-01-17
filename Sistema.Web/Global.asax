<%@ Application Language="C#" %>

<script runat="server">
    void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
        DevExpress.Web.ASPxWebControl.GlobalTheme = Utils.GetCurrentTheme(Request);
    }
</script>
