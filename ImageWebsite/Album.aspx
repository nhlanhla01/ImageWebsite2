<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="ImageWebsite.Album" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" Width="91px" />
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="Dashed" Width="440px">
        </asp:Panel>
    </form>
</body>
</html>
