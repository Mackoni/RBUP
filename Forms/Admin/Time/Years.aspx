<%@ Page Title="" Language="C#" MasterPageFile="../Admin.Master" AutoEventWireup="true" CodeBehind="Years.aspx.cs" Inherits="RBUP.Forms.Admin.Years" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../Scripts/js/jquery-1.5.1.min.js"></script>
    <script src="../../../Scripts/js/jquery-ui-1.8.11.custom.min.js"></script>
    <script src="Years.js"></script>
    <script src="../../../Scripts/Cekaj.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Years</h2>
        <asp:HiddenField ID="hfSelectedIndex" runat="server" />
    <div class="ui-widget-content">
        <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblYear" CssClass="label" runat="server" Text="Year" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtYear" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNewYear" runat="server" Text="New" OnClick="btnNewYear_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdateYear" runat="server" Text="Update" OnClick="btnUpdateYear_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnFindYear" runat="server" Text="Search" ClientIDMode="Static" />
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
                                <td id="Years" style="width: 200px;">Year</td>
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
            <img src="../../../images/ajax-loader.gif" />
        </div>
    </div>
</asp:Content>
