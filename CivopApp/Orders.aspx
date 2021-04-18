<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.cs" Inherits="CivopApp.Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="CustomerName" HeaderText="Zákazník"></asp:BoundField>
            <asp:BoundField DataField="CustomerPostAddress" HeaderText="Adresa"></asp:BoundField>
            <asp:BoundField DataField="UtcDateCreated" HeaderText="Datum a čas"></asp:BoundField>
            <asp:BoundField DataField="ProductsCount" HeaderText="Produktů"></asp:BoundField>
            <asp:BoundField DataField="TotalPrice" HeaderText="Cena celkem"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="OrderPage?orderId=<%# Eval("Id") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p><a runat="server" href="~/OrderPage">Vytvořit objednávku</a></p>
</asp:Content>
