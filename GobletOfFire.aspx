﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GobletOfFire.aspx.cs" Inherits="GobletOfFire" %>


<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
      <div id ="ProductImg">
           <img src="App_Themes/Theme1/Image/Paperpack goblet.jpg" alt="Home"/>
    </div>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
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
        <asp:Button ID="btnAddToCart" runat="server" OnClick="btnAddToCart_Click" Text="Voeg toe aan winkelwagen" />
    </div>
    <div id ="Aanbevolen">
        <h4 id ="aanbevolenTitel">
            <asp:Label ID="lbAanbevolenTitel" runat="server" Text="Label"></asp:Label>
            <asp:hyperlink ID="lbAanbevolenPrijs" runat="server" NavigateUrl="VforVendetta.aspx"></asp:hyperlink>
        </h4>
    </div>
    </asp:Content>



     
