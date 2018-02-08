
Imports System.Data

Partial Class Edit_Refill
    Inherits System.Web.UI.Page

    Protected Sub btnRefillEdit_Click(sender As Object, e As EventArgs) Handles btnRefillEdit.Click
        Dim refillTime As DateTime
        Dim refillID, outcome As Int32
        Dim aDataTier As New RefillDataTier

        Try
            refillID = CType(txtRefillID.Text, Int32)
            refillTime = CType(txtRefillDateTime.Text, DateTime)
            If refillTime.Date <> Nothing And refillID <> Nothing Then
                outcome = aDataTier.updateRefill(refillID, refillTime)
            End If

            If outcome = 1 Then
                lblError.Text = "Refill Edited Successfully"
            ElseIf outcome = 0 Then
                lblError.Text = "There was a input error"
            Else
                lblError.Text = "There was trouble connecting to the database"

            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack And Request.QueryString("RefillID") <> Nothing Then
            txtRefillID.Text = Request.QueryString("RefillID")

            Dim aDataTier As New RefillDataTier
            Dim aDataSet As DataSet
            Dim RefillID As Int32

            Try
                RefillID = Request.QueryString("RefillID")
                aDataSet = aDataTier.searchRefill(RefillID)
                txtRefillDateTime.Text = CType(aDataSet.Tables(0).Rows(0).Item("Date Filled"), String)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
