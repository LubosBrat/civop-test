<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.cs" Inherits="CivopApp.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="GridView1" runat="server" >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="Code" HeaderText="Kód"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Název"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Cena"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <p><a runat="server" href="~/ProductPage">Vytvořit produkt</a></p>
</asp:Content>

