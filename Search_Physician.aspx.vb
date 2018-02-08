Imports System.Data


Partial Class Search_Physician
    Inherits System.Web.UI.Page

    Protected Const PagePhysicianTable As String = "PhysicianSearch"
    Protected Const PhysicianID As String = "ID" 'Change with Table

    Public Property sortPhysician() As String
        Get
            Return CStr(ViewState("sortPhysician"))
        End Get
        Set(ByVal Value As String)
            ViewState("sortPhysician") = Value
        End Set
    End Property

    Private Sub grdSearchedPhysician_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdSearchedPhysician.Sorting
        SortPhysicianRecords(e.SortExpression)
    End Sub

    Private Sub SortPhysicianRecords(sortExpression As String)
        'Sorts the 
        Dim source As DataView
        Dim oldSortExpression As String

        oldSortExpression = CType(ViewState("oldPhysicianSortExpression"), String)

        If oldSortExpression = sortExpression And Me.sortPhysician = "asc" Then
            Me.sortPhysician = "desc" 'only descending if same expression and was ascending
        Else
            Me.sortPhysician = "asc"
        End If

        ViewState("oldPhysicianSortExpression") = sortExpression

        source = CType(Cache(PagePhysicianTable), DataView)

        Dim viewRowCount As Int32 = source.Count
        If viewRowCount > 1 Then
            source.Sort = (" " + sortExpression + " " + Me.sortPhysician)

            grdSearchedPhysician.DataSource = source
            grdSearchedPhysician.DataBind()

            Cache.Insert(PagePhysicianTable, source, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            reBindPhysicianGrid()
        End If
    End Sub

    Protected Sub btnSearchPhysician_Click(sender As Object, e As EventArgs) Handles btnSearchPhysician.Click
        'Optionally prevent valueless searches
        loadPhysicianSearch()
        grdSearchedPhysician.PageIndex = 0
        reBindPhysicianGrid()
    End Sub

    Private Sub loadPhysicianSearch()
        'Create dataTier
        Dim aDataTier As New PhysicianDataTier
        Dim aDataSet As DataSet
        Dim aDataView As DataView
        Dim PhysicianName, Specialty As String
        Dim PhysicianID As Integer
        Dim DOBStop, DOBStart As Date

        Try
            PhysicianName = txtPhysicianName.Text.Trim
            Specialty = txtPhysicianSpecialty.Text.Trim
            'possible replace with validation no default
            Try
                PhysicianID = CType(txtPhysicianID.Text.Trim, Integer)
            Catch ex As Exception
                PhysicianID = Nothing
            End Try

            Try
                DOBStart = CType(txtPhysicianDOBStart.Text, Date)
            Catch ex As Exception
                DOBStart = Nothing
            End Try

            Try
                DOBStop = CType(txtPhysicianDOBStop.Text, Date)
            Catch ex As Exception
                DOBStop = Nothing
            End Try

            aDataSet = aDataTier.searchPhysician(DOBStart, DOBStop, PhysicianName, Specialty, PhysicianID) 'optional parameter synatx when out of order
            aDataView = aDataSet.Tables(0).DefaultView
            Cache.Insert(PagePhysicianTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedPhysician_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedPhysician.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        Paging(pageNum)
        reBindPhysicianGrid()
    End Sub

    Private Sub Paging(pageNum As Integer)
        grdSearchedPhysician.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedPhysician_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedPhysician.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAllPhysicianID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Private Sub reBindPhysicianGrid()
        grdSearchedPhysician.DataSource = CType(Cache(PagePhysicianTable), DataView)
        grdSearchedPhysician.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
