﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="true" CodeFile="Search_Prescription.aspx.vb" Inherits="Search_Prescription" %>

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
            var grid = document.getElementById("<%= grdSearchedPrescription.ClientID %>");
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
           <asp:UpdatePanel ID="UpdatePanelPrescription" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblPrescriptionID" runat="server" Text="RxNumber: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRxNumber" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                            <td>
                                Drug Name:
                            </td>
                            <td>

                                <asp:TextBox ID="txtDrugName" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>Patient Name:</td>
                            <td>
                                <asp:TextBox ID="txtPatientName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Prescribed Date Range Start: </td>
                            <td>
                                <asp:TextBox ID="txtPrescribedDateStart" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Physician Name: </td>
                            <td>
                                <asp:TextBox ID="txtPhysicianName" runat="server"></asp:TextBox>
                            </td>
                            <td>Prescribed Date Range Stop: </td>
                            <td>
                                <asp:TextBox ID="txtPrescribedDateStop" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearchPrescription" runat="server" Text="Search" OnClick="btnSearchPrescription_Click"  />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                      <asp:GridView ID="grdSearchedPrescription" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" Pagesize="2" Width="100%">
                            <PagerSettings FirstPageText="Go To First Page" LastPageText="Go To Last Page" Mode="NextPreviousFirstLast" Position="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Prescription ID">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAllPrescriptionID" runat="server" />
                                        <%--<asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="<%#Eval(PrescriptionID) %>" CommandName="lbtnDelete" OnCommand="Delete_Click">Delete</asp:LinkButton>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRecordPrescriptionID" runat="server" AutoPostBack="false" />
                                        <asp:Label ID="hidPrescriptionID" runat="server" Text="<%#Eval(PrescriptionID) %>" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                                <asp:BoundField DataField="Physician Name" HeaderText="Physician Name" SortExpression="Physician Name" />
                                <asp:BoundField DataField="RxNumber" HeaderText="RxNumber" SortExpression="RxNumber" />
                                <asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Search_Refill.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(PrescriptionID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PrescriptionID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.png" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PrescriptionID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgAddRefill" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PrescriptionID) %>" CommandName="lbtnAddRefill" Height="30" ImageUrl="~/images/plus.png" OnCommand="lbtnAddRefill_Click" Width="30" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Records Found Matching Your Search!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    <td>
                     
                            &nbsp;</td>
                    <td>
                     
                            &nbsp;</td>
                </tr>
            </table>
             </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSearchPrescription" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
        </div>
</asp:Content>

