
Imports System.Data

Partial Class Add_Refill
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

            If aDataSet IsNot Nothing Then
                aDataView = aDataSet.Tables(0).DefaultView
                Cache.Insert(PagePrescriptionTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If
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
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("ondblclick", "javascript:RxSelect(this)")
        End If

        If e.Row.RowType = DataControlRowType.Header Then
                CType(e.Row.FindControl("cbSelectAllPrescriptionID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
            End If
    End Sub

    Private Sub reBindPrescriptionGrid()
        grdSearchedPrescription.DataSource = CType(Cache(PagePrescriptionTable), DataView)
        grdSearchedPrescription.DataBind()
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim outcome, RxNumber As Integer
        Dim aDataTier As New RefillDataTier

        Try
            RxNumber = CType(txtRxNumber.Text, Int32)

            outcome = aDataTier.addRefill(RxNumber)
        Catch ex As Exception
            outcome = -1
        End Try

        If outcome = 0 Then
            lblError.Text = "Record Added"
        ElseIf outcome = -1 Then
            lblError.Text = "input invalid"
        ElseIf outcome = -2 Then
            lblError.Text = "Refills Exceeded"
        Else
            lblError.Text = "Trouble connecting to Database"
        End If
    End Sub

    Private Sub Add_Refill_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack And Request.QueryString("RxNumber") <> Nothing Then
            txtRxNumber.Text = Request.QueryString("RxNumber")
        End If
    End Sub
End Class
