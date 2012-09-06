<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Int.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td><p>Welcome to the Product Order System!<br /><br />To access the Order System, you need to 
                login first. Please make use of the login panel on the right.</p></td>
            <td class="default_rightCol">
                <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate">
                </asp:Login>
            </td>
        </tr>
    </table>
</asp:Content>
