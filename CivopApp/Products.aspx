<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.cs" Inherits="CivopApp.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="GridView1" runat="server" >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>

