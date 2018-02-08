<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Add_Refill.aspx.vb" Inherits="Add_Refill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="formLayout.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            /*width: 100%*/
        }
    </style>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js"></script>
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
        };

        function RxSelect(tr) {
            var data = tr.getElementsByTagName("span")[0].innerHTML;
            var input = document.getElementById("<%= txtRxNumber.ClientID%>");
            input.value = data;
        };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="SideForm">
       <table class="auto-style1">
        <tr>
            <td>RxNumber:</td>
            <td>
                <asp:TextBox ID="txtRxNumber" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Button ID="btnRxNumber" runat="server" Text="..." />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRxNumber" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Datetime of Refill:</td>
            <td>
                <asp:TextBox ID="txtDatetimeRefill" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDatetimeRefill" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
           <tr>
               <td>
                   <asp:Label ID="lblError" runat="server"></asp:Label>
               </td>
               <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Record" />
               </td>
           </tr>
    </table>
   </div>
    <div class="SelectGridView">
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRxNumber" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPatientName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhysicianName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
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
                            <td colspan="4">
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
                                        <asp:Label ID="hidPrescriptionID" runat="server" Text="<%#Eval(PrescriptionID) %>" style="display:none"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                                <asp:BoundField DataField="Physician Name" HeaderText="Physician Name" SortExpression="Physician Name" />
                                <asp:BoundField DataField="RxNumber" HeaderText="RxNumber" SortExpression="RxNumber" />
                                <%--<asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Display.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>--%>
                                <%--<asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(PrescriptionID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PrescriptionID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.jpg" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PrescriptionID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
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
    </div>
</asp:Content>

