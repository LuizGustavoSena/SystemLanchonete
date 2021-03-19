<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lanchonete.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 122px;
        }
        .auto-style3 {
            height: 26px;
            width: 122px;
        }
        .auto-style4 {
            width: 122px;
            height: 33px;
        }
        .auto-style5 {
            height: 33px;
        }
        .auto-style6 {
            width: 311px;
        }
        .auto-style7 {
            height: 26px;
            width: 311px;
        }
        .auto-style8 {
            height: 33px;
            width: 311px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição: "></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtDescricao" runat="server" Width="266px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblValor" runat="server" Text="Valor: "></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtValor" runat="server" Width="103px"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style8">
                    <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnLog" runat="server" OnClick="btnLog_Click" Text="Logs" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label1" runat="server" Text="Pizzas:"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Logs:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:GridView ID="gvPizza" runat="server">
                    </asp:GridView>
                </td>
                <td class="auto-style5">
                    <asp:GridView ID="gvLog" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
