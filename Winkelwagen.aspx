<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Winkelwagen.aspx.cs" Inherits="Winkelwagen" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH1" Runat="Server">
    <div id="list">
    <asp:ListBox ID="lbProducten" runat="server"></asp:ListBox>
        <asp:Label ID="lbTotaal" runat="server" Text="Label"></asp:Label>
    <br />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH2" Runat="Server">
</asp:Content>

