<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ImageWebsite.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 424px;
        }
        .auto-style2 {
            width: 221px;
        }
        .auto-style3 {
            font-size: x-large;
            font-weight: bold;
            text-align: center;
        }
        .auto-style4 {
            width: 424px;
            text-align: center;
        }
        .auto-style5 {
            color: #FF0000;
            font-style: italic;
        }
        .auto-style6 {
            width: 390px;
            height: 222px;
            margin-right: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style3">
            <p style="margin-right: 0px">
                <img alt="" class="auto-style6" longdesc="https://localhost:44362/LoginPage.aspx" src="images/Isithombe.jpg" /></p>
            PHOTO WEB
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style4">Username :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" CssClass="auto-style5" ErrorMessage="Please enter username!!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Password :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" CssClass="auto-style5" ErrorMessage="Please enter Password!!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login" Width="93px" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btn_LogOut" runat="server" OnClick="btn_LogOut_Click" Text="LogOut" Width="89px" />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sign-In.aspx">Register Here!</asp:HyperLink>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
