<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="AjaxGridTemplate.aspx.vb" Inherits="AjaxGridTemplate" %>

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
            var grid = document.getElementById("<%= grdSearchedTable.ClientID %>");
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
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="RxNumber: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRxNumber" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Patient Name:</td>
                            <td>
                                <asp:TextBox ID="txtPatientName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Physician Name:</td>
                            <td>
                                <asp:TextBox ID="txtPhysicianName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                      <asp:GridView ID="grdSearchedTable" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridView" Pagesize="2" Width="100%">
                            <PagerSettings FirstPageText="Go To First Page" LastPageText="Go To Last Page" Mode="NextPreviousFirstLast" Position="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Customer ID">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" />
                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="<%#Eval(ItemID) %>" CommandName="lbtnDelete" OnCommand="Delete_Click">Delete</asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRecordID" runat="server" AutoPostBack="false" />
                                        <asp:Label ID="hidItemID" runat="server" Text="<%#Eval(ItemID) %>" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" SortExpression="Patient Name" />
                                <asp:BoundField DataField="Physician Name" HeaderText="Physician Name" SortExpression="Physician Name" />
                                <asp:BoundField DataField="RxNumber" HeaderText="RxNumber" SortExpression="RxNumber" />
                                <asp:HyperLinkField DataNavigateUrlFields="RxNumber" DataNavigateUrlFormatString="Display.aspx?IDS={0}" HeaderText="View" Target="_blank" Text="View">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<% # Eval(ItemID)%>" CommandName="lbtnEdit" OnCommand="lbtnEdit_Click">Edit</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="false" CommandArgument="<% # Eval(ItemID)%>" CommandName="lbtnDelete" Height="30" ImageUrl="~/images/delete.jpg" OnCommand="Delete_Click" Width="30" />
                                        ||
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="false" CommandArgument="<% # Eval(ItemID) %>" CommandName="lbtnEdit" Height="30" ImageUrl="~/images/edit.jpg" OnCommand="lbtnEdit_Click" Width="30" />
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
                   <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
               </Triggers>
            </asp:UpdatePanel>
        </div>
</asp:Content>

