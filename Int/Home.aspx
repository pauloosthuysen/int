<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Int.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>

    !<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id">
        <Columns>
            <asp:TemplateField HeaderText="Add To Cart">
                <ItemTemplate>
                    <asp:CheckBox ID="AddToCart" runat="server" />
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
            <table>
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>SubTotal</th>
                </tr>
                <% decimal totalAmount = 0;
                   foreach (string s in (List<string>)Session["Cart"])
                   {
                       int pId = Int32.Parse(s.Split('|')[0]);
                       int pQu = Int32.Parse(s.Split('|')[1]);
                       Int.Product prod = ws.GetProduct(pId);
                       totalAmount += prod.Price * pQu;
                       %>
                       <tr>
                            <td><%= prod.Name %></td>
                            <td><%= prod.Price %></td>
                            <td><%= pQu %></td>
                            <td style="text-align: right;"><%= prod.Price * pQu %></td>
                       </tr>
                <% } %>
                <tr>
                    <td colspan="4" style="text-align: right;font-weight: bold;">Total: <%= totalAmount %></td>
                </tr>
            </table>
    <% } %>
    <br />
</asp:Content>
