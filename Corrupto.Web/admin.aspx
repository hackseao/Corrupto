<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnStart" Text="Start" runat="server" OnClick="btnStart_Click" />
        <asp:Button ID="btnStop" Text="Stop" runat="server" OnClick="btnStop_Click" />
        <hr />
        <asp:Label ID="lblOutput" runat="server" />
    </div>
    </form>
</body>
</html>
