<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OrderPage.aspx.cs" Inherits="CivopApp.OrderPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:HiddenField ID="hdnOrderId" runat="server" />
    <div class="form-group">
        <asp:Label runat="server" Text="Zákazník" AssociatedControlID="txtCustomerName"></asp:Label>
        <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Adresa" AssociatedControlID="txtCustomerPostAddress"></asp:Label>
        <asp:TextBox ID="txtCustomerPostAddress" runat="server"></asp:TextBox>
    </div>
    <hr/>
    <div class="products">
        <h3>Položky objednávky</h3>

        <div class="row">
            <div class="form-group">
                <asp:Label runat="server" Text="Připojit produkt" AssociatedControlID="dropdownProduct"></asp:Label>
                <asp:DropDownList runat="server" ID="dropdownProduct" DataTextField="Name" DataValueField="Id" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtProductQty" Text="Množství ks"></asp:Label>
                <asp:TextBox runat="server" ID="txtProductQty" Width="30"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnAddProduct" OnClick="btnAddProduct_OnClick" Text="Přidat"/>
            </div>
        </div>

    </div>
    
    <hr/>

    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Uložit" OnClick="btnSubmit_OnClick" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnDelete" runat="server" Text="Smazat ..." OnClick="btnSubmit_Delete" OnClientClick="return confirm('Opravdu chcete smazat tuto objednávku z databáze?')" />
    </div>

</asp:Content>
