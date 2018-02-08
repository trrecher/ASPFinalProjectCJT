<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Search_Physician.aspx.vb" Inherits="Search_Physician" %>

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
    <div class="auto-style2"> 
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanelPhysician" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblPhysicianID" runat="server" Text="Physician ID: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhysicianID" runat="server" TextMode="Number"></asp:TextBox>
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
                                        <asp:Label ID="hidPhysicianID" runat="server" Text="<%#Eval(PhysicianID) %>" Visible="false"></asp:Label>
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
             </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSearchPhysician" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
        </div>
</asp:Content>

