<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Add_Physician.aspx.vb" Inherits="Add_Physician" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div> 
        <table class="auto-style1">
                <tr>
                    <td style="text-align: right">First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Middle Initial:</td>
                    <td>
                        <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right">Date of Birth:</td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Gender:</td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right">Specialty:</td>
                    <td>
                        <asp:TextBox ID="txtSpecialty" runat="server" TextMode="Phone"></asp:TextBox>
                    </td>
                </tr>
            <tr>
                    <td style="text-align: right">Salary:</td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Work Phone:</td>
                    <td>
                        <asp:TextBox ID="txtCellPhone" runat="server" TextMode="Phone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right">Street Address:</td>
                    <td>
                        <asp:TextBox ID="txtStreetAddress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">City:</td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">State:</td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Postal Code:</td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add Record" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>

