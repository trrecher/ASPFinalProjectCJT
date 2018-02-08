Imports System.Data

Partial Class AjaxGridTemplate
    Inherits System.Web.UI.Page

    Protected Const PageTable As String = "PrescriptionSearch"
    Protected Const ItemID As String = "RxNumber" 'Change with Table

    Public Property sortDir() As String
        Get
            Return CStr(ViewState("sortDir"))
        End Get
        Set(ByVal Value As String)
            ViewState("sortDir") = Value
        End Set
    End Property

    Private Sub grdSearchedTable_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdSearchedTable.Sorting
        SortRecords(e.SortExpression)
    End Sub

    Private Sub SortRecords(sortExpression As String)
        'Sorts the 
        Dim source As DataView
        Dim oldSortExpression As String

        oldSortExpression = CType(ViewState("oldSortExpression"), String)

        If oldSortExpression = sortExpression And Me.sortDir = "asc" Then
            Me.sortDir = "desc" 'only descending if same expression and was ascending
        Else
            Me.sortDir = "asc"
        End If

        ViewState("oldSortExpression") = sortExpression

        source = CType(Cache(PageTable), DataView)

        Dim viewRowCount As Int32 = source.Count
        If viewRowCount > 1 Then
            source.Sort = (" " + sortExpression + " " + Me.sortDir)

            grdSearchedTable.DataSource = source
            grdSearchedTable.DataBind()

            Cache.Insert(PageTable, source, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            reBindGrid()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Optionally prevent valueless searches
        loadSearch()
        grdSearchedTable.PageIndex = 0
        reBindGrid()
    End Sub

    Private Sub loadSearch()
        'Create dataTier
        Dim aDataTier As New prescriptionDataTier
        Dim aDataSet As DataSet
        Dim aDataView As DataView
        Dim patient, physician As String
        Dim RxNumber As Integer

        Try
            patient = txtPatientName.Text.Trim
            physician = txtPhysicianName.Text.Trim
            'possible replace with validation no default
            Try
                RxNumber = CType(txtRxNumber.Text.Trim, Integer)
            Catch ex As Exception
                RxNumber = Nothing
            End Try
            aDataSet = aDataTier.searchPrescription(patient, physician, RxNumber:=RxNumber) 'optional parameter synatx when out of order
            aDataView = aDataSet.Tables(0).DefaultView
            Cache.Insert(PageTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedTable_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedTable.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        Paging(pageNum)
        reBindGrid()
    End Sub

    Private Sub Paging(pageNum As Integer)
        grdSearchedTable.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedTable_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedTable.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAll"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Public Sub lbtnEdit_Click()

    End Sub

    Public Sub Delete_Click()

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'This Procedure will bind the data after any changes made by the control postback
        'If Cache(PageTable) IsNot Nothing Then
        '    reBindGrid()
        'End If
    End Sub

    Private Sub reBindGrid()
        grdSearchedTable.DataSource = CType(Cache(PageTable), DataView)
        grdSearchedTable.DataBind()
    End Sub
    Protected Sub btnSearch_Click1(sender As Object, e As EventArgs)

    End Sub
End Class
