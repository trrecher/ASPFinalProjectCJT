
Partial Class Add_Physician
    Inherits System.Web.UI.Page

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim outcome As Int32
        Dim aDataTier As New PhysicianDataTier
        Dim fName, lNAme, MidInit, Gender, wPhone, email, specialty, streetAddr, City, State, Zip As String
        Dim DOB As Date
        Dim salary As Decimal

        fName = txtFName.Text.Trim
        lNAme = txtLName.Text.Trim
        MidInit = txtMiddleInitial.Text.Trim
        Gender = ddlGender.SelectedValue
        specialty = txtSpecialty.Text.Trim
        wPhone = txtCellPhone.Text.Trim
        email = txtEmail.Text.Trim
        streetAddr = txtStreetAddress.Text.Trim
        City = txtCity.Text.Trim
        State = ddlState.SelectedValue
        Zip = txtZip.Text.Trim

        Try
            DOB = CType(txtDOB.Text, Date)
            salary = CType(txtSalary.Text, Decimal)
            outcome = aDataTier.addPhysician(fName, lNAme, DOB, Gender, salary, MidInit, specialty, wPhone, streetAddr, City, State, Zip, email)
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
