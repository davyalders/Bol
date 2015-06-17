<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VforVendetta.aspx.cs" Inherits="VforVendetta" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH1" Runat="Server">
    <div id ="ProductImg">
           <img src="App_Themes/Theme1/Image/V for Vendetta.jpg" alt="Home"/>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH2" Runat="Server">
    <div id ="Beschrijving">
        <h2 id ="Titel">
          <asp:Label ID="lbTitel" runat="server" Text="Label"></asp:Label>       
        </h2>
        <p>
             <asp:Label ID="lbBeschrijving" runat="server" Text="Label"></asp:Label>
        </p>
    </div>
    <div id ="Prijs">
        <asp:Label ID="lbPrijs" runat="server" Text="Label"></asp:Label>
    </div>
    <div id ="Aanbevolen">
        <h4 id ="aanbevolenTitel">
            <asp:Label ID="lbAanbevolenTitel" runat="server" Text="Label"></asp:Label>
            <asp:hyperlink ID="lbAanbevolenPrijs" runat="server" NavigateUrl="GobletOfFire.aspx"></asp:hyperlink>
        </h4>
    </div>
</asp:Content>

