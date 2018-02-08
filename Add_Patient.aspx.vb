
Imports StateManager

Partial Class Add_Patient
    Inherits System.Web.UI.Page

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim outcome As Int32
        Dim aDataTier As New patientDataTier
        Dim fName, lNAme, MidInit, Gender, hPhone, cPhone, email, streetAddr, City, State, Zip As String
        Dim DOB As Date

        fName = txtFName.Text.Trim
        lNAme = txtLName.Text.Trim
        MidInit = txtMiddleInitial.Text.Trim
        Gender = ddlGender.SelectedValue
        hPhone = txtHomePhone.Text.Trim
        cPhone = txtCellPhone.Text.Trim
        email = txtEmail.Text.Trim
        streetAddr = txtStreetAddress.Text.Trim
        City = txtCity.Text.Trim
        State = ddlState.SelectedValue
        Zip = txtZip.Text.Trim

        Try
            DOB = CType(txtDOB.Text, Date)
            outcome = aDataTier.addPatient(fName, lNAme, DOB, Gender, MidInit, hPhone, cPhone, streetAddr, City, State, Zip, email)
        Catch ex As Exception

        End Try


        If outcome = 1 Then
            lblError.Text = "Record Added"
            With Me
                txtFName.Text = ""
                txtLName.Text = ""
                txtMiddleInitial.Text = ""
                'txtDOB.
                ddlGender.SelectedIndex = 0
                txtHomePhone.Text = ""
                txtCellPhone.Text = ""
                txtEmail.Text = ""
                txtStreetAddress.Text = ""
                txtCity.Text = ""
                ddlState.SelectedIndex = 0
                txtZip.Text = ""


            End With
        ElseIf outcome = 0 Then
            lblError.Text = "Input Error"
        Else
            lblError.Text = "Problem Connecting to Database"
        End If
    End Sub

    Private Sub Add_Patient_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim aState As state() = getStates()
            ddlState.DataSource = aState
            ddlState.DataValueField = "Abbreviation"
            ddlState.DataTextField = "Name"
            ddlState.DataBind()
        End If
    End Sub
End Class
