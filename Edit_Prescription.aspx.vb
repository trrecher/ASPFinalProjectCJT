Imports System.Data


Partial Class Edit_Prescription
    Inherits System.Web.UI.Page



    Protected Sub btnPresciptionEdit_Click(sender As Object, e As EventArgs) Handles btnPresciptionEdit.Click
        Dim RxNumber, maxRefills, outcome As Int32
        Dim Description, Intake, Dosage, Frequency As String
        Dim aDataTier As New prescriptionDataTier

        Try
            RxNumber = CType(txtRxNumber.Text, Int32)
            maxRefills = CType(txtRefills.Text, Int32)

            Description = txtMDescription.Text.Trim
            Intake = txtIntake.Text.Trim
            Dosage = txtDosage.Text.Trim
            Frequency = txtFrequency.Text.Trim

            If RxNumber <> Nothing Then
                outcome = aDataTier.updatePrescription(RxNumber, Description, Dosage, Frequency, Intake, maxRefills)
            End If

            If outcome = 1 Then
                lblError.Text = "Prescription Edited Successfully"
            ElseIf outcome = 0 Then
                lblError.Text = "There was an input error"
            Else
                lblError.Text = "There was trouble connecting to the database"

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Edit_Prescription_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack And Request.QueryString("RxNumber") <> Nothing Then
            'txtRxNumber.Text = Request.QueryString("RxNumber")
            Dim aDataTier As New prescriptionDataTier
            Dim aDataset As DataSet
            Dim RxNumber As Integer
            Try
                RxNumber = CType(Request.QueryString("RxNumber"), Int32)

                aDataset = aDataTier.searchPrescription(RxNumber:=RxNumber)

                txtRefills.Text = aDataset.Tables(0).Rows(0).Item("Max Refills")
                txtRxNumber.Text = CType(aDataset.Tables(0).Rows(0).Item("RxNumber"), String)
                txtDosage.Text = aDataset.Tables(0).Rows(0).Item("Dosage")
                txtMDescription.Text = aDataset.Tables(0).Rows(0).Item("Description")
                txtFrequency.Text = aDataset.Tables(0).Rows(0).Item("Frequency")
                txtIntake.Text = aDataset.Tables(0).Rows(0).Item("Intake")
            Catch ex As Exception
                lblError.Text = "Error connecting to Database check RxNumber"
            End Try
        End If
    End Sub
End Class
