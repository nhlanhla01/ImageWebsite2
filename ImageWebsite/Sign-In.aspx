<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign-In.aspx.cs" Inherits="ImageWebsite.Sign_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 357px;
            text-align: center;
        }
        .auto-style2 {
            width: 234px;
        }
        .auto-style3 {
            font-size: x-large;
            font-weight: bold;
            text-align: justify;
        }
        .auto-style4 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style3">
            Sign-In Page
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Username:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td><em>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="auto-style4" ErrorMessage="Username is required!"></asp:RequiredFieldValidator>
                    </em></td>
            </tr>
            <tr>
                <td class="auto-style1">Email:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td><em>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" CssClass="auto-style4" ErrorMessage="Email is required!"></asp:RequiredFieldValidator>
                    </em>
                    <br />
                    <em>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid e-mail!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </em></td>
            </tr>
            <tr>
                <td class="auto-style1">Password:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td><em>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPword" CssClass="auto-style4" ErrorMessage="Password is required!"></asp:RequiredFieldValidator>
                    </em></td>
            </tr>
            <tr>
                <td class="auto-style1">Confirm Password:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td><em>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirm" CssClass="auto-style4" ErrorMessage="Confirm Password is required!"></asp:RequiredFieldValidator>
                    </em>
                    <br />
                    <em>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPword" ControlToValidate="txtConfirm" ErrorMessage="Password must match!"></asp:CompareValidator>
                    </em></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
               
                <td class="auto-style2">
                    <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit" Width="77px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
