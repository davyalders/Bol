<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">
    <div id ="Login">
     
     <asp:Label ID="lbUsername" runat="server" Text="Gebruikersnaam"></asp:Label>
     &nbsp;<asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" ErrorMessage="Voeg een gebruikersnaam toe"></asp:RequiredFieldValidator>
     <br />
     <br />
     <asp:Label ID="lbPassword" runat="server" Text="Wachtwoord"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
     <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" ErrorMessage="Voeg een wachtwoord toe"></asp:RequiredFieldValidator>
     <br />
     <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="btnLogin" runat="server" Text="Log in" Width="63px" OnClick="btnLogin_Click" />
     
 </div>
</asp:Content>


