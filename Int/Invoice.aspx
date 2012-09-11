<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Int.Invoice1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Invoice No.</td>
            <td>
                <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
