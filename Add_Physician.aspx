﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Add_Physician.aspx.vb" Inherits="Add_Physician" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div> 
        <table class="auto-style1">
                <tr>
                    <td style="text-align: right" class="auto-style2">First Name:</td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid first name!" ControlToValidate="txtFName" ValidationExpression="^[a-zA-Z''-'\s]{1,25}$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server" MaxLength="25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter a valid last name!" ControlToValidate="txtLName" ValidationExpression="^[a-zA-Z''-'\s]{1,25}$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Middle Initial:</td>
                    <td>
                        <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter a valid middle initial!" ControlToValidate="txtMiddleInitial" ValidationExpression="^[a-zA-Z''-'\s]{1}$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Date of Birth:</td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Gender:</td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Value="MALE">Male</asp:ListItem>
                            <asp:ListItem Value="FEMALE">Female</asp:ListItem>
                            <asp:ListItem>NA</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGender" ErrorMessage="Please select a gender!">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter a valid gender!" ControlToValidate="ddlGender" ValidationExpression="^[a-zA-Z''-'\s]{1,6}$" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Specialty:</td>
                    <td>
                        <asp:TextBox ID="txtSpecialty" runat="server" TextMode="Phone" Width="160px" MaxLength="15"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Enter a valid specialty!" ControlToValidate="txtSpecialty" ValidationExpression="^[#.0-9a-zA-Z\s,-]{1,40}$" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align: right" class="auto-style2">Salary:</td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server" MaxLength="11"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSalary" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Enter a valid decimal!" ControlToValidate="txtSalary" ValidationExpression="^\d{1,8}\.\d{1,2}" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Work Phone:</td>
                    <td>
                        <asp:TextBox ID="txtCellPhone" runat="server" MaxLength="15"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="xxx-xxx-xxxx" ControlToValidate="txtCellPhone" ValidationExpression="^(?=(?:\D*\d){10,15}\D*$)\+?[0-9]{1,3}[\s-]?(?:\(0?[0-9]{1,5}\)|[0-9]{1,5})[-\s]?[0-9][\d\s-]{5,7}\s?(?:x[\d-]{0,4})?$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" MaxLength="80"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter a valid email!" ControlToValidate="txtEmail" ValidationExpression="^(?!.{81})([a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Street Address:</td>
                    <td>
                        <asp:TextBox ID="txtStreetAddress" runat="server" MaxLength="60"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter valid Address!" ControlToValidate="txtStreetAddress" ValidationExpression="^[#.0-9a-zA-Z\s,-]{1,60}$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">City:</td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="60"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Enter valid city!" ControlToValidate="txtCity" ValidationExpression="^[a-zA-Z''-'\s]{1,60}$" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">State:</td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">Postal Code:</td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server" MaxLength="5"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Enter valid ZIP code!" ControlToValidate="txtZip" ValidationExpression="\d{5}" ></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style2">
                        
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add Record" style="height:50px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblError" runat="server" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>

