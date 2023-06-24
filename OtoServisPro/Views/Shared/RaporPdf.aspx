<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaporPdf.aspx.cs" Inherits="OtoServisPro.Views.Shared.RaporPdf" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" Width="100%" AsyncRendering="false" runat="server">

                </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
