<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Add_Prescription.aspx.vb" Inherits="Add_Prescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="formLayout.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            /*width: 100%*/
        }
    </style>
    <script type="text/javascript">

        function SelectAll(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= grdSearchedPatient.ClientID %>");
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

        function patientIDSelect(tr) {
            var data = tr.getElementsByTagName("span")[0].innerHTML;
            var input = document.getElementById("<%= txtPatientID.ClientID%>");
            input.value = data;
        };

        function physicianIDSelect(tr) {
            var data = tr.getElementsByTagName("span")[0].innerHTML;
            var input = document.getElementById("<%= txtPhysicianID.ClientID%>");
            input.value = data;
        };
</script>
    <script type="text/javascript">

        function SelectAllPhysician(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= grdSearchedPhysician.ClientID %>");
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
    <div class="SideForm">
       <table class="auto-style1">
        <tr>
            <td>Patient&#39;s ID:</td>
            <td>
                <asp:TextBox ID="txtPatientID" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Button ID="btnPatientID" runat="server" Text="..." />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPatientID" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Physician&#39;s ID:</td>
            <td>
                <asp:TextBox ID="txtPhysicianID" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Button ID="btnPhysicianID" runat="server" Text="..." />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhysicianID" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Medicine Name:</td>
            <td>
                <asp:TextBox ID="txtMName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Medicine Description:</td>
            <td>
                <asp:TextBox ID="txtMDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Prescribed Date:</td>
            <td>
                <asp:TextBox ID="txtPrescribedDate" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrescribedDate" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Expiration Date :</td>
            <td>
                <asp:TextBox ID="txtExpirationDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanelPatient" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <div id="patientDiv" runat="server" visible="false">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblPatientID" runat="server" Text="Patient ID: "></asp:Label>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPatientID" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                            <td>
                                <asp:label id="lblPatientDOBStart" runat="server" Text="Date of Birth Range Start" />

                            </td>
                            <td>
                                <asp:textbox id="txtPatientDOBStart" runat="server" TextMode="Date" />
                            </td>
                        </tr>
                        <tr>
                            <td>Patient Name:</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPatientName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPatientName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:label id="lblPatientDOBStop" runat="server" Text="Date of Birth Range Start" />
                            </td>
                            <td>
                                <asp:textbox id="txtPatientDOBStop" runat="server" TextMode="Date" />
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearchPatient" runat="server" Text="Search" OnClick="btnSearchPatient_Click"  />
                            </td>
                            <td>
                                

                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                      <asp:GridView ID="grdSearchedPatient" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" Pagesize="2" Width="100%">
                            <PagerSettings FirstPageText="Go To First Page" LastPageText="Go To Last Page" Mode="NextPreviousFirstLast" Position="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Patient ID">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAllPatientID" runat="server" />
                                        <asp:LinkButton ID="lbtnDelete" runat="server" >Delete</asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRecordPatientID" runat="server" AutoPostBack="false" />
                                        <asp:Label ID="hidPatientID" runat="server" Text="<%#Eval(PatientID) %>" style="display:none"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" SortExpression="Date of Birth" />
                                <%--<asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Display.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Edit">
                                    <%--<ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(PatientID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PatientID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.jpg" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PatientID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
                                    </ItemTemplate>--%>
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
                        </div>
             </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSearchPatient" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnPatientID" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnPhysicianID" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
         <asp:UpdatePanel ID="UpdatePanelPhysician" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <div id="physicianDiv" runat="server" visible="false">
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblPhysicianID" runat="server" Text="Physician ID: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                            <td>
                                DOB Range Start:
                            </td>
                            <td>

                                <asp:TextBox ID="txtPhysicianDOBStart" runat="server" TextMode="Date"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>Physician Name:</td>
                            <td>
                                <asp:TextBox ID="txtPhysicianName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                DOB Range Stop:</td>
                            <td>
                                <asp:TextBox ID="txtPhysicianDOBStop" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearchPhysician" runat="server" Text="Search" OnClick="btnSearchPhysician_Click"  />
                            </td>
                            <td>
                                Physician Specialty:</td>
                            <td>
                                <asp:TextBox ID="txtPhysicianSpecialty" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                      <asp:GridView ID="grdSearchedPhysician" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" Pagesize="2" Width="100%">
                            <PagerSettings FirstPageText="Go To First Page" LastPageText="Go To Last Page" Mode="NextPreviousFirstLast" Position="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Physician ID">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAllPhysicianID" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRecordPhysicianID" runat="server" AutoPostBack="false" />
                                        <asp:Label ID="hidPhysicianID" runat="server" Text="<%#Eval(PhysicianID) %>" style="display:none"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Physician Name" HeaderText="Physician Name" SortExpression="Physician Name" />
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="Specialty" HeaderText="Specialty" SortExpression="Specialty" />
                                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" SortExpression="Date of Birth" />
                                <%--<asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Display.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Edit">
                                    <%--<ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(PhysicianID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PhysicianID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.jpg" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(PhysicianID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
                                    </ItemTemplate>--%>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Records Found Matching Your Search!
                            </EmptyDataTemplate>
                        </asp:GridView>
                </tr>
            </table>
                        </div>
             </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSearchPhysician" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnPatientID" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnPhysicianID" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
    </div>
</asp:Content>

