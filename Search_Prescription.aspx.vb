
Imports System.Data


Partial Class Search_Prescription
    Inherits System.Web.UI.Page

    Protected Const PagePrescriptionTable As String = "PrescriptionSearch"
    Protected Const PrescriptionID As String = "RxNumber" 'Change with Table

    Public Property sortPrescription() As String
        Get
            Return CStr(ViewState("sortPrescription"))
        End Get
        Set(ByVal Value As String)
            ViewState("sortPrescription") = Value
        End Set
    End Property

    Private Sub grdSearchedPrescription_Sorting(sender As Object, e As GridViewSortEventArgs) Handles grdSearchedPrescription.Sorting
        SortPrescriptionRecords(e.SortExpression)
    End Sub

    Private Sub SortPrescriptionRecords(sortExpression As String)
        'Sorts the 
        Dim source As DataView
        Dim oldSortExpression As String

        oldSortExpression = CType(ViewState("oldPrescriptionSortExpression"), String)

        If oldSortExpression = sortExpression And Me.sortPrescription = "asc" Then
            Me.sortPrescription = "desc" 'only descending if same expression and was ascending
        Else
            Me.sortPrescription = "asc"
        End If

        ViewState("oldPrescriptionSortExpression") = sortExpression

        source = CType(Cache(PagePrescriptionTable), DataView)

        Dim viewRowCount As Int32 = source.Count
        If viewRowCount > 1 Then
            source.Sort = (" " + sortExpression + " " + Me.sortPrescription)

            grdSearchedPrescription.DataSource = source
            grdSearchedPrescription.DataBind()

            Cache.Insert(PagePrescriptionTable, source, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            reBindPrescriptionGrid()
        End If
    End Sub

    Protected Sub btnSearchPrescription_Click(sender As Object, e As EventArgs) Handles btnSearchPrescription.Click
        'Optionally prevent valueless searches
        loadPrescriptionSearch()
        grdSearchedPrescription.PageIndex = 0
        reBindPrescriptionGrid()
    End Sub

    Private Sub loadPrescriptionSearch()
        'Create dataTier
        Dim aDataTier As New prescriptionDataTier
        Dim aDataSet As DataSet
        Dim aDataView As DataView
        Dim patient, physician, drugName As String
        Dim DateStart, DateStop As Date
        Dim RxNumber As Integer

        Try
            patient = txtPatientName.Text.Trim
            physician = txtPhysicianName.Text.Trim
            drugName = txtDrugName.Text.Trim
            'possible replace with validation no default
            Try
                RxNumber = CType(txtRxNumber.Text.Trim, Integer)
            Catch ex As Exception
                RxNumber = Nothing
            End Try

            Try
                DateStart = CType(txtPrescribedDateStart.Text, Date)
            Catch ex As Exception
                DateStart = Nothing
            End Try

            Try
                DateStop = CType(txtPrescribedDateStop.Text, Date)
            Catch ex As Exception
                DateStop = Nothing
            End Try

            aDataSet = aDataTier.searchPrescription(patient, physician, drugName, DateStart, DateStop, RxNumber)
            aDataView = aDataSet.Tables(0).DefaultView
            Cache.Insert(PagePrescriptionTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedPrescription_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedPrescription.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        Paging(pageNum)
        reBindPrescriptionGrid()
    End Sub

    Private Sub Paging(pageNum As Integer)
        grdSearchedPrescription.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedPrescription_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedPrescription.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAllPrescriptionID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Private Sub reBindPrescriptionGrid()
        grdSearchedPrescription.DataSource = CType(Cache(PagePrescriptionTable), DataView)
        grdSearchedPrescription.DataBind()
    End Sub

    Public Sub Delete_Click(ByVal sender As Object, ByVal e As CommandEventArgs) Handles grdSearchedPrescription.SelectedIndexChanged

        Try

            Dim chk As CheckBox
            Dim lbl As Label
            Dim RxNumber As Integer
            Dim aDatatier As New prescriptionDataTier
            If grdSearchedPrescription.Rows.Count > 0 Then

                'For Each row
                For Each row As GridViewRow In grdSearchedPrescription.Rows
                    chk = CType(row.FindControl("chkRecordPrescriptionId"), CheckBox)

                    'is checkbox checked
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPrescriptionID"), Label)
                        RxNumber = CType(lbl.Text, Int32)
                        ''delete the record one at a time
                        aDatatier.deletePrescription(RxNumber)

                    End If
                Next

                'refresh datagrid
                loadPrescriptionSearch()
                reBindPrescriptionGrid()

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

            Response.Redirect("Edit_Prescription.aspx?RxNumber=" + recordToBeEdited, False)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try


    End Sub

    Friend Sub lbtnAddRefill_Click(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim recordToBeFilled As String

        Try
            'Get the record
            recordToBeFilled = Trim(e.CommandArgument)

            Response.Redirect("Add_Refill.aspx?RxNumber=" + recordToBeFilled, False)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Sub

End Class
