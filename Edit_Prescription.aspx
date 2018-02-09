<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Edit_Prescription.aspx.vb" Inherits="Edit_Prescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="formLayout.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            /*width: 100%*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="SideForm">
       <table class="auto-style1">
        <tr>
            <td>RxNumber</td>
            <td>
                <asp:TextBox ID="txtRxNumber" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRxNumber" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Medicine Description:</td>
            <td>
                <asp:TextBox ID="txtMDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Dosage:</td>
            <td>
                <asp:TextBox ID="txtDosage" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Frequency of use:</td>
            <td>
                <asp:TextBox ID="txtFrequency" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Method of Intake:</td>
            <td>
                <asp:TextBox ID="txtIntake" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Number of Refills:</td>
            <td>
                <asp:TextBox ID="txtRefills" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
           <tr>
               <td colspan="2">
                   <asp:Button ID="btnPresciptionEdit" runat="server" Text="Edit Prescription" style="height:50px"/>
                   <asp:Label ID="lblError" runat="server" Font-Size="X-Large"></asp:Label>
               </td>
           </tr>
    </table>
   </div>

</asp:Content>

