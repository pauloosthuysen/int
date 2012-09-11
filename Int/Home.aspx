<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Int.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Products</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id">
        <Columns>
            <asp:TemplateField HeaderText="Add to Cart">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:ListBox ID="ListBox1" runat="server" Rows="1">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" 
        onclick="btnAddToCart_Click" />
    <% if (Session["cart"] != null)
       { %>
        <h1>Products in Cart</h1>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="PriceAsString" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="SubTotalAsString" HeaderText="SubTotal" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblCartItemsTotal" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" 
        onclick="btnCheckout_Click" />
        <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" 
            onclick="btnClearCart_Click" />
    <% } %>
    <hr />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" 
        onclick="btnLogout_Click" 
        onclientclick="return confirm('Are you sure you want to logout?');" />
</asp:Content>
