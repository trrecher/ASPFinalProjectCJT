<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Edit_Refill.aspx.vb" Inherits="Edit_Refill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="auto-style1">
        <tr>
            <td>Refill ID:</td>
            <td>
                <asp:TextBox ID="txtRefillID" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Date of Refill:</td>
            <td>
                <asp:TextBox ID="txtRefillDateTime" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnRefillEdit" runat="server" Text="Edit" />
    <asp:Label ID="lblError" runat="server"></asp:Label>

</asp:Content>

