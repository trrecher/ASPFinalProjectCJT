
Imports System.Data

Partial Class Search_Refill
    Inherits System.Web.UI.Page

    Protected Const PageRefillTable As String = "RefillSearch"
    Protected Const RefillID As String = "Refill ID" 'Change with Table

    Public Property sortRefill() As String
        Get
            Return CStr(ViewState("sortRefill"))
        End Get
        Set(ByVal Value As String)
            ViewState("sortRefill") = Value
        End Set
    End Property

    Private Sub grdSearchedRefill_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdSearchedRefill.Sorting
        SortRefillRecords(e.SortExpression)
    End Sub

    Private Sub SortRefillRecords(sortExpression As String)
        'Sorts the 
        Dim source As DataView
        Dim oldSortExpression As String

        oldSortExpression = CType(ViewState("oldRefillSortExpression"), String)

        If oldSortExpression = sortExpression And Me.sortRefill = "asc" Then
            Me.sortRefill = "desc" 'only descending if same expression and was ascending
        Else
            Me.sortRefill = "asc"
        End If

        ViewState("oldRefillSortExpression") = sortExpression

        source = CType(Cache(PageRefillTable), DataView)

        Dim viewRowCount As Int32 = source.Count
        If viewRowCount > 1 Then
            source.Sort = (" " + sortExpression + " " + Me.sortRefill)

            grdSearchedRefill.DataSource = source
            grdSearchedRefill.DataBind()

            Cache.Insert(PageRefillTable, source, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            reBindRefillGrid()
        End If
    End Sub

    Protected Sub btnSearchRefill_Click(sender As Object, e As EventArgs) Handles btnSearchRefill.Click
        'Optionally prevent valueless searches
        loadRefillSearch()
        grdSearchedRefill.PageIndex = 0
        reBindRefillGrid()
    End Sub

    Private Sub loadRefillSearch()
        'Create dataTier
        Dim aDataTier As New RefillDataTier
        Dim aDataSet As DataSet
        Dim aDataView As DataView
        Dim patient, physician, drugName As String
        Dim RefillID, RxNumber As Integer
        Dim pStart, pStop, rStart, rStop As Date

        Try
            patient = txtPatientName.Text.Trim
            physician = txtPhysicianName.Text.Trim
            drugName = txtDrugName.Text.Trim
            'possible replace with validation no default
            Try
                RefillID = CType(txtRefillID.Text.Trim, Integer)
            Catch ex As Exception
                RefillID = Nothing
            End Try

            'Enter a textbox and modify the procedure for Refill Rx Search
            Try
                RxNumber = CType(txtRxNumber.Text.Trim, Integer)
            Catch ex As Exception
                RxNumber = Nothing
            End Try

            Try
                pStart = CType(txtPrescribedStart.Text, Date)
            Catch ex As Exception
                pStart = Nothing
            End Try

            Try
                pStop = CType(txtPrescribedStop.Text, Date)
            Catch ex As Exception
                pStop = Nothing
            End Try

            Try
                rStart = CType(txtRefillStart.Text, Date)
            Catch ex As Exception
                rStart = Nothing
            End Try

            Try
                rStop = CType(txtRefillStart.Text, Date)
            Catch ex As Exception
                rStop = Nothing
            End Try

            aDataSet = aDataTier.searchRefill(RefillID, patient, physician, drugName, pStart, pStop, rStart, rStop, RxNumber) 'optional parameter synatx when out of order
            aDataView = aDataSet.Tables(0).DefaultView
            Cache.Insert(PageRefillTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedRefill_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedRefill.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        Paging(pageNum)
        reBindRefillGrid()
    End Sub

    Private Sub Paging(pageNum As Integer)
        grdSearchedRefill.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedRefill_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedRefill.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAllRefillID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Private Sub reBindRefillGrid()
        grdSearchedRefill.DataSource = CType(Cache(PageRefillTable), DataView)
        grdSearchedRefill.DataBind()
    End Sub

    Public Sub Delete_Click(ByVal sender As Object, ByVal e As CommandEventArgs) Handles grdSearchedRefill.SelectedIndexChanged

        Try

            Dim chk As CheckBox
            Dim lbl As Label
            Dim RefillID As Integer
            Dim aDatatier As New prescriptionDataTier
            If grdSearchedRefill.Rows.Count > 0 Then

                'For Each row
                For Each row As GridViewRow In grdSearchedRefill.Rows
                    chk = CType(row.FindControl("chkRecordRefillId"), CheckBox)

                    'is checkbox checked
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidRefillID"), Label)
                        RefillID = CType(lbl.Text, Int32)
                        ''delete the record one at a time
                        aDatatier.deletePrescription(RefillID)

                    End If
                Next

                'refresh datagrid
                loadRefillSearch()

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub lbtnEdit_Click(ByVal sender As Object, ByVal e As CommandEventArgs)

        Dim recordToBeEdited As String

        Try

            'Get the record
            recordToBeEdited = Trim(e.CommandArgument)

            Response.Redirect("Edit_Refill.aspx?RefillID=" + recordToBeEdited, False)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try


    End Sub

    Private Sub Search_Refill_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtRxNumber.Text = Request.QueryString("IDS")

            loadRefillSearch()
            reBindRefillGrid()
        End If
    End Sub
End Class
