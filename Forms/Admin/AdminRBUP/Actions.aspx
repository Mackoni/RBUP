﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Actions.aspx.cs" Inherits="RBUP.Forms.Admin.AdminRBUP.Actions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="~/Scripts/js/jquery-1.5.1.min.js"></script>
    <script src="~/Scripts/js/jquery-ui-1.8.11.custom.min.js"></script>
    <script src="~/Forms/Admin/AdminRBUP/Actions.js"></script>
    <script src="~/Scripts/Cekaj.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Years</h2>
    <%--    <asp:HiddenField ID="hfSelectedIndex" runat="server" />--%>
    <div class="ui-widget-content">
        <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblAction" CssClass="label" runat="server" Text="Action" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAction" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNewAction" runat="server" Text="New" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdateAction" runat="server" Text="Update" />
                    </td>
                    <td>
                        <asp:Button ID="btnFindAction" runat="server" Text="Search" ClientIDMode="Static" />
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
                                <td id="Name" style="width: 200px;">Name</td>
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
