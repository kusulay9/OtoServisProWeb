﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaporPdf.aspx.cs" Inherits="OtoServisPro.Views.Shared.RaporPdf" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" Width="59%" AsyncRendering="false" runat="server">

                </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>