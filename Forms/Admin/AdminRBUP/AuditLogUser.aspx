<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AuditLogUser.aspx.cs" Inherits="RBUP.Forms.Admin.AuditLogUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="~/Scripts/js/jquery-1.5.1.min.js"></script>
    <script src="~/Scripts/js/jquery-ui-1.8.11.custom.min.js"></script>
    <script src="~/Forms/Admin/AdminRBUP/AuditLogUser.js"></script>
    <script src="~/Scripts/Cekaj.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Audit logs</h2>
    <%--<asp:HiddenField ID="hfSelectedIndex" runat="server" />--%>
    <div class="ui-widget-content">
        <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblQLID" CssClass="label" runat="server" Text="QLID" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtQLID" runat="server" />
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblSF" CssClass="label" runat="server" Text="S/F" /></td>
                    <td>
                        <asp:DropDownList ID="ddlSF" runat="server">
                            <asp:ListItem Text="- - - - - - - - - - -" Value="" />
                            <asp:ListItem Text="Successful" Value="1" />
                            <asp:ListItem Text="Failed" Value="2" />
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="lblAction" CssClass="label" runat="server" Text="Action" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAction" runat="server" />
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblDate" CssClass="label" runat="server" Text="Action date" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" />
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
                        <asp:Button ID="btnFindAudit" runat="server" Text="Search" ClientIDMode="Static" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <br />
    <asp:Panel ID="Panel3" runat="server" CssClass="panelH">
        <div class="ui-widget-content">
            <div class="ui-accordion-content" style="font-family: Tahoma">
                <asp:Panel ID="Panel4" runat="server">
                    <table>
                        <tr>
                            <td>
                                <%--<asp:Button ID="btnExportExcel" ClientIDMode="Static" runat="server" Text="Export u Excel" OnClick="btnExportExcel_Click" />--%>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel5" runat="server">
                    <table>
                        <thead>
                            <tr style="background-color: #dfdfdf; font-weight: bold; font-size: 10pt">
                                <td id="sel" style="width: 20px">
                                    <input type="checkbox" value="-1" id="selall" />
                                </td>
                                <td id="ID" style="width: 20px;">ID</td>
                                <td id="QLID" style="width: 200px;">QLID</td>
                                <td id="S_F" style="width: 200px;">S/F</td>
                                <td id="Action" style="width: 200px;">Action</td>
                                <td id="Date" style="width: 200px;">Date</td>
                                <td id="PID" style="width: 200px;">PID</td>
                            </tr>
                        </thead>
                        <tbody id="tby" style="font-size: 10pt"></tbody>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </asp:Panel>
    <div id="cekanje" style="display: none">
        <div id="cekaj" style="position: absolute; top: 0px; width: 100%; opacity: 0.2; vertical-align: middle; filter: alpha(opacity=20); font-size: 20pt; text-align: center; background-color: Gray"></div>
        <div id="puz" style="position: absolute; top: 220px; width: 100%; vertical-align: middle; filter: alpha(opacity=20); text-align: center;">
            <img src="~/images/ajax-loader.gif" />
        </div>
    </div>
    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
</asp:Content>
