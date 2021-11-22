<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPhoto.aspx.cs" Inherits="ImageWebsite.UploadPhoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <asp:Button ID="Button_submit" runat="server" OnClick="Button_submit_Click" Text="Upload" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Done" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="181px" Width="401px">
            <Columns>
                <asp:BoundField DataField="text" HeaderText="Name" />
                <asp:ImageField DataImageUrlField="Value" HeaderText="Preview">
                    <ControlStyle Height="100px" Width="100px" />
                </asp:ImageField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick ="DownloadFile">Download</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
