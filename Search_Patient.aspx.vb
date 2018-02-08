
Imports System.Data

Partial Class Search_Patient
    Inherits System.Web.UI.Page

    Protected Const PagePatientTable As String = "PatientSearch"
    Protected Const PatientID As String = "ID" 'Change with Table

    Public Property sortPatient() As String
        Get
            Return CStr(ViewState("sortPatient"))
        End Get
        Set(ByVal Value As String)
            ViewState("sortPatient") = Value
        End Set
    End Property

    Private Sub grdSearchedPatient_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdSearchedPatient.Sorting
        SortPatientRecords(e.SortExpression)
    End Sub

    Private Sub SortPatientRecords(sortExpression As String)
        'Sorts the 
        Dim source As DataView
        Dim oldSortExpression As String

        oldSortExpression = CType(ViewState("oldPatientSortExpression"), String)

        If oldSortExpression = sortExpression And Me.sortPatient = "asc" Then
            Me.sortPatient = "desc" 'only descending if same expression and was ascending
        Else
            Me.sortPatient = "asc"
        End If

        ViewState("oldPatientSortExpression") = sortExpression

        source = CType(Cache(PagePatientTable), DataView)

        Dim viewRowCount As Int32 = source.Count
        If viewRowCount > 1 Then
            source.Sort = (" " + sortExpression + " " + Me.sortPatient)

            grdSearchedPatient.DataSource = source
            grdSearchedPatient.DataBind()

            Cache.Insert(PagePatientTable, source, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            reBindPatientGrid()
        End If
    End Sub

    Protected Sub btnSearchPatient_Click(sender As Object, e As EventArgs) Handles btnSearchPatient.Click
        'Optionally prevent valueless searches
        loadPatientSearch()
        grdSearchedPatient.PageIndex = 0
        reBindPatientGrid()
    End Sub

    Private Sub loadPatientSearch()
        'Create dataTier
        Dim aDataTier As New patientDataTier
        Dim aDataSet As DataSet
        Dim aDataView As DataView
        Dim DOBStart, DOBStop As Date
        Dim patientName As String
        Dim patientID As Integer

        Try
            patientName = txtPatientName.Text.Trim
            'possible replace with validation no default
            Try
                PatientID = CType(txtPatientID.Text.Trim, Integer)
            Catch ex As Exception
                PatientID = Nothing
            End Try

            Try
                DOBStart = CType(txtPatientDOBStart.Text, Date)
            Catch ex As Exception
                DOBStart = Nothing
            End Try

            Try
                DOBStop = CType(txtPatientDOBStop.Text, Date)
            Catch ex As Exception
                DOBStop = Nothing
            End Try
            aDataSet = aDataTier.searchPatient(DOBStart, DOBStop, patientName, patientID) 'optional parameter synatx when out of order
            aDataView = aDataSet.Tables(0).DefaultView
            Cache.Insert(PagePatientTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedPatient_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedPatient.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        Paging(pageNum)
        reBindPatientGrid()
    End Sub

    Private Sub Paging(pageNum As Integer)
        grdSearchedPatient.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedPatient_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedPatient.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAllPatientID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Private Sub reBindPatientGrid()
        grdSearchedPatient.DataSource = CType(Cache(PagePatientTable), DataView)
        grdSearchedPatient.DataBind()
    End Sub
End Class
