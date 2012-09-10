<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewInvoiceAfterOrder.aspx.cs" Inherits="Int.ViewInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Order Date</td>
            <td><asp:Label ID="lblOrderDate" runat="server" Text="Label"></asp:Label></td>            
        </tr>
        <tr>
            <td>Invoice No.</td>
            <td><asp:Label ID="lblInvoiceId" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Discount</td>
            <td><asp:Label ID="lblDiscount" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Total Amount</td>
            <td><asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Due Amount</td>
            <td><asp:Label ID="lblDueAmount" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>    
</asp:Content>
