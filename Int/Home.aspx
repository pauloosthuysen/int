<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Int.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>

    !<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" DataSourceID="EntityDataSource1" 
        onrowcommand="GridView1_RowCommand" onrowcreated="GridView1_RowCreated">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                SortExpression="Id" />
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
            <asp:ButtonField ButtonType="Button" CommandName="AddToCart" 
                Text="Add to Cart" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=DataAccessContainer" 
        DefaultContainerName="DataAccessContainer" EnableFlattening="False" 
        EntitySetName="Products">
    </asp:EntityDataSource>
    <br />

</asp:Content>
