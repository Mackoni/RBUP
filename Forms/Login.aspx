<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Forms/Login.Master" Inherits="RBUP.Forms.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/js/jquery-1.5.1.min.js"></script>
    <script src="../../../Scripts/js/jquery-ui-1.8.11.custom.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h2>Years</h2>--%>
    <%--    <asp:HiddenField ID="hfSelectedIndex" runat="server" />--%>
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblQLID" runat="server" Text="QLID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQLID" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbRemember" runat="server" Text="Remember me" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

