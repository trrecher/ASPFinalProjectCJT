
Imports System.Data

Partial Class Add_Prescription
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
                patientID = CType(txtPatientID.Text.Trim, Integer)
            Catch ex As Exception
                patientID = Nothing
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

            If aDataSet IsNot Nothing Then
                aDataView = aDataSet.Tables(0).DefaultView
                Cache.Insert(PagePatientTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedPatient_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedPatient.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        PagingPatient(pageNum)
        reBindPatientGrid()
    End Sub

    Private Sub PagingPatient(pageNum As Integer)
        grdSearchedPatient.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedPatient_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedPatient.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("ondblclick", "javascript:patientIDSelect(this)")
        End If

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("cbSelectAllPatientID"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll(this.id)")
        End If
    End Sub

    Private Sub reBindPatientGrid()
        grdSearchedPatient.DataSource = CType(Cache(PagePatientTable), DataView)
        grdSearchedPatient.DataBind()
    End Sub

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

            If aDataSet IsNot Nothing Then
                aDataView = aDataSet.Tables(0).DefaultView
                Cache.Insert(PagePhysicianTable, aDataView, Nothing, Caching.Cache.NoAbsoluteExpiration, System.TimeSpan.FromMinutes(10), Caching.CacheItemPriority.Default, Nothing)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub grdSearchedPhysician_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchedPhysician.PageIndexChanging
        Dim pageNum As Int32 = e.NewPageIndex

        PagingPhysician(pageNum)
        reBindPhysicianGrid()
    End Sub

    Private Sub PagingPhysician(pageNum As Integer)
        grdSearchedPhysician.PageIndex = pageNum
    End Sub

    Private Sub grdSearchedPhysician_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSearchedPhysician.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("ondblclick", "javascript:physicianIDSelect(this)")
        End If

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

    Protected Sub btnPatientID_Click(sender As Object, e As EventArgs) Handles btnPatientID.Click
        patientDiv.Visible = Not patientDiv.Visible
        physicianDiv.Visible = False
    End Sub
    Protected Sub btnPhysicianID_Click(sender As Object, e As EventArgs) Handles btnPhysicianID.Click
        patientDiv.Visible = False
        physicianDiv.Visible = Not physicianDiv.Visible
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim outcome, patientID, physicianID, maxRefill As Int32
        Dim aDataTier As New prescriptionDataTier
        Dim MedicineName, Description, Frequency, Intake, Dosage As String
        Dim prescibedDate, expirationDate As Date

        MedicineName = txtMName.Text.Trim
        Description = txtMDescription.Text.Trim
        Frequency = txtFrequency.Text.Trim
        Intake = txtIntake.Text.Trim
        Dosage = txtDosage.Text.Trim

        Try
            prescibedDate = CType(txtPrescribedDate.Text, Date)
            expirationDate = CType(txtExpirationDate.Text, Date)
            patientID = CType(txtPatientID.Text, Int32)
            physicianID = CType(txtPhysicianID.Text, Int32)
            Try
                maxRefill = CType(txtRefills.Text, Int32)
            Catch ex As Exception
                maxRefill = Nothing
            End Try

            outcome = aDataTier.addPrescription(patientID, physicianID, MedicineName, expirationDate, prescibedDate, Description, Dosage, Intake, Frequency, maxRefill)
        Catch ex As Exception

        End Try


        If outcome = 1 Then
            lblError.Text = "Record Added"
        ElseIf outcome = 0 Then
            lblError.Text = "Input Error"
        Else
            lblError.Text = "Problem Connecting to Database"
        End If
    End Sub
End Class
