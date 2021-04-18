<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CivopApp.ProductPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:HiddenField ID="hdnProductId" runat="server" />
    <div class="form-group">
        <asp:Label runat="server" Text="Kód" AssociatedControlID="txtCode"></asp:Label>
        <asp:TextBox ID="txtCode" runat="server" ></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Název" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Cena" AssociatedControlID="txtPrice"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" ></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Uložit" OnClick="btnSubmit_OnClick" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnDelete" runat="server" Text="Smazat ..." OnClick="btnSubmit_Delete" OnClientClick="return confirm('Opravdu chcete smazat tento produkt z databáze?')" />
    </div>

</asp:Content>