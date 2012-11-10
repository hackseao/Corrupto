<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnExecute" Text="Execute" runat="server" OnClick="btnExecute_Click" /><br />
        <br />
        <asp:Label ID="lblLastExecutionTime" runat="server" />
    </div>
    </form>
</body>
</html>
