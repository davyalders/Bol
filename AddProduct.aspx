<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>



<asp:Content ID="Content3" ContentPlaceHolderID="CPH1" Runat="Server">
    <div class ="AddProduct" runat="server">
    <asp:Label ID="lbProductNaam" runat="server" Text="Product"></asp:Label>
    <asp:TextBox ID="tbProductNaam" runat="server" Width="174px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbProductNaam">Voer een productnaam in</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbPrijs" runat="server" Text="Prijs"></asp:Label>
    <asp:TextBox ID="tbPrijs" runat="server" Width="174px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbPrijs">Voer een prijs in</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbBeschrijving" runat="server" Text="Beschrijving"></asp:Label>
    <asp:TextBox ID="tbBeschrijving" runat="server" Height="98px" Width="174px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbBeschrijving">Voer een Beschrijving in</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbGewicht" runat="server" Text="Gewicht in kilogram"></asp:Label>
    <asp:TextBox ID="tbGewicht" runat="server" Width="174px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbGewicht">Voer een gewicht in</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbCategorie" runat="server" Text="Categorie"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="174px">
        </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownList1">Selecteer een categorie</asp:RequiredFieldValidator>
        <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" Text="Submit" />
    <br />
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH2" Runat="Server">
</asp:Content>

