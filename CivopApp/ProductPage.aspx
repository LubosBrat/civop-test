<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="CivopApp.ProductPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnProductId" runat="server" />
    <div class="form-group">
        <asp:Label runat="server" Text="Kód" AssociatedControlID="txtCode"></asp:Label>
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Název" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Cena" AssociatedControlID="txtPrice"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Uložit" OnClick="btnSubmit_OnClick" />
    </div>
</asp:Content>