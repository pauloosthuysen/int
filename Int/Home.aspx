<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Int.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function confirmLogout() {
            return confirm("Are you sure you want to logout?");
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>

    !<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id">
        <Columns>
            <asp:TemplateField HeaderText="Add To Cart">
                <ItemTemplate>
                    <div class="home_productSelect"><asp:CheckBox ID="AddToCart" runat="server" /></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:ListBox ID="ListBox1" runat="server" Rows="1">
                        <asp:ListItem Selected="True">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Add to Cart" />
    <br />
    <% if (Session["Cart"] != null)
       { %>
            <h2>Products in Cart</h2>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="PriceAsString" HeaderText="Price" SortExpression="PriceAsString" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="SubTotalAsString" HeaderText="SubTotal" SortExpression="SubTotalAsString" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" />
    <% } %>
    <hr />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" 
        onclientclick="return confirmLogout();" onclick="btnLogout_Click" />
</asp:Content>
