var Judicial = {
    LoadPage: function () {
        TeUsuario.Focus();
        var v1 = TeUsuario.GetValue();
        var v2 = TePassword.GetValue();
        if (v1 || v2) {
            LBError.SetText("Error en los datos...");
        }
    },
    LoginButton_Click: function (s, e) {
        ASPxClientUtils.SetCookie("User", TeUsuario.GetValue() || "");
        ASPxClientUtils.SetCookie("Password", TePassword.GetValue() || "");
    },
    LogoutButton_Click: function (s, e) {
        TeUsuario.Focus();
        TeUsuario.SetText("");
        TePassword.SetText("");
        ASPxClientUtils.SetCookie("User", null);
        ASPxClientUtils.SetCookie("Password", null);
    },
    PendingCallbacks: {},
    DoCallback: function (sender, callback) {
        if (sender.InCallback()) {
            Judicial.PendingCallbacks[sender.name] = callback;
            sender.EndCallback.RemoveHandler(Judicial.DoEndCallback);
            sender.EndCallback.AddHandler(Judicial.DoEndCallback);
        } else {
            callback();
        }
    },
    DoEndCallback: function (s, e) {
        var pendingCallback = MailDemo.PendingCallbacks[s.name];
        if (pendingCallback) {
            pendingCallback();
            delete MailDemo.PendingCallbacks[s.name];
        }
    },
    ClientMailSplitter_PaneResized: function (s, e) {
        if (e.pane.name === "GridPane")
            ClientMailGrid.SetHeight(e.pane.GetClientHeight() - ClientMailMenu.GetMainElement().offsetHeight);
    },
    ClientThemeSelector_SelectedIndexChanged: function (s, e) {
        ASPxClientUtils.SetCookie("MailDemoCurrentTheme", s.GetValue() || "");
    },
    ClientMailGrid_Init: function (s, e) {
        s.Focus();
    },
    ClientMailGrid_EndCallback: function (s, e) {
        ClientMailSplitter.GetPaneByName("GridPane").RaiseResizedEvent();
    },
    ClientMailGrid_FocusedRowChanged: function (s, e) {
        var currentRow = s.GetFocusedRowIndex(),
            canReply = !!s.GetVisibleRowsOnPage() && !s.IsGroupRow(currentRow);

        Judicial.DoCallback(GVDetalles1, function () {
            GVDetalles1.PerformCallback(s.GetRowKey(currentRow));
            GVDetalles2.PerformCallback(s.GetRowKey(currentRow));
            ClientMailSplitter.GetPaneByName("PaneDetalle1").SetScrollTop(0);
            ClientMailSplitter.GetPaneByName("PaneDetalle2").SetScrollTop(0);
        });
    }
};