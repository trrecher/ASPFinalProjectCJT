﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Search_Refill.aspx.vb" Inherits="Search_Refill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-bottom: 0px;
        }
        </style>

    <script type="text/javascript">

        function SelectAll(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= grdSearchedRefill.ClientID %>");
            //variable to contain the cell of the grid
            var cell;

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 1; i < grid.rows.length; i++) {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];

                    //loop according to the number of childNodes in the cell
                    for (j = 0; j < cell.childNodes.length; j++) {
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type == "checkbox") {
                            //assign the status of the Select All checkbox to the cell checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="auto-style2"> 
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanelRefill" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <table class="auto-style1">
                        <tr>
                            <td>
                                Patient Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPatientName" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPatientName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Prescribed Date Range Start:</td>
                            <td>

                                <asp:TextBox ID="txtPrescribedStart" runat="server" TextMode="Date"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>Physician Name:</td>
                            <td>
                                <asp:TextBox ID="txtPhysicianName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhysicianName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Prescribed Date Range Stop:</td>
                            <td>
                                <asp:TextBox ID="txtPrescribedStop" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Drug Name: </td>
                            <td>
                                <asp:TextBox ID="txtDrugName" runat="server"></asp:TextBox>
                            </td>
                            <td>Refill Date Range Start:</td>
                            <td>
                                <asp:TextBox ID="txtRefillStart" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Refill ID: </td>
                            <td>
                                <asp:TextBox ID="txtRefillID" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRefillID" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </td>
                            <td>Refill Date Range Stop:</td>
                            <td>
                                <asp:TextBox ID="txtRefillStop" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearchRefill" runat="server" Text="Search" OnClick="btnSearchRefill_Click"  />
                            </td>
                            <td>
                                RxNumber:</td>
                            <td>
                                <asp:TextBox ID="txtRxNumber" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRxNumber" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                      <asp:GridView ID="grdSearchedRefill" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" Pagesize="2" Width="100%">
                            <PagerSettings FirstPageText="Go To First Page" LastPageText="Go To Last Page" Mode="NextPreviousFirstLast" Position="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Refill ID">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAllRefillID" runat="server" />
                                        <%--<asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="<%#Eval(RefillID) %>" CommandName="lbtnDelete" OnCommand="Delete_Click">Delete</asp:LinkButton>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRecordRefillID" runat="server" AutoPostBack="false" />
                                        <asp:Label ID="hidRefillID" runat="server" Text="<%#Eval(RefillID) %>" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Refill ID" HeaderText="Refill ID" SortExpression="Refill ID" />
                                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                                <asp:BoundField DataField="Physician Name" HeaderText="Physician Name" SortExpression="Physician Name" />
                                <asp:BoundField DataField="RxNumber" HeaderText="RxNumber" SortExpression="RxNumber" />
                                <asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Display.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(RefillID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(RefillID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.jpg" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(RefillID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Records Found Matching Your Search!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
             </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSearchRefill" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
        </div>
</asp:Content>

