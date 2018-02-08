Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.SqlClient


Public Class prescriptionDataTier

    Dim connString As New SqlConnection(ConnectionStrings("connString").ConnectionString)
    Dim cmdString As New SqlCommand


    Public Sub cmdStringConfig()
        'handles the db setup except
        '(parameters, .CommandText, Adapters, and datasets)
        ''must be called in try statement
        connString.Open()
        cmdString.Parameters.Clear()

        With cmdString
            .Connection = connString
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 120

        End With
    End Sub

    Public Function addPrescription(
                                   ByVal patientID As String,
                                   ByVal physicianID As String,
                                   ByVal drugName As String,
                                   ByVal expireDate As Date,
                                   Optional ByVal prescribedDate As Date = Nothing,
                                   Optional ByVal drugDescription As String = Nothing,
                                   Optional ByVal drugDoseage As String = Nothing,
                                   Optional ByVal intakeMethod As String = Nothing,
                                   Optional ByVal drugFrequency As String = Nothing,
                                   Optional ByVal maxRefills As String = Nothing
                                    ) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "ADD_PRESCRIPTION" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@patientID", SqlDbType.Int).Value = patientID
                .Parameters.Add("@physicianID", SqlDbType.Int).Value = physicianID
                .Parameters.Add("@drugName", SqlDbType.VarChar, 60).Value = drugName
                .Parameters.Add("@drugDescription", SqlDbType.VarChar, 60).Value = drugDescription
                .Parameters.Add("@expireDate", SqlDbType.Date).Value = expireDate
                .Parameters.Add("@DRUGDOSAGE", SqlDbType.VarChar, 40).Value = drugDoseage
                .Parameters.Add("@intakeMethod", SqlDbType.VarChar, 50).Value = intakeMethod
                .Parameters.Add("@drugFrequency", SqlDbType.VarChar, 50).Value = drugFrequency
                If maxRefills <> Nothing Then
                    .Parameters.Add("@maxRefills", SqlDbType.Int).Value = maxRefills
                End If
                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                .ExecuteNonQuery()
                Return 1
            End With
        Catch ex As Exception
            Return -1
            Throw New Exception(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

    Public Function deletePrescription(rxNumber As String) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "DELETE_PRESCRIPTION" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@rxNumber", SqlDbType.Int).Value = rxNumber


                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                .ExecuteReader()
                Return 1
            End With
        Catch ex As Exception
            Return -1
            Throw New Exception(ex.Message)

        Finally
            connString.Close()

        End Try
    End Function

    Public Function searchPrescription(
                                      Optional ByVal patientName As String = Nothing,
                                      Optional ByVal physicianName As String = Nothing,
                                      Optional ByVal drugName As String = Nothing,
                                      Optional ByVal prescribedStartDateBound As Date = Nothing,
                                      Optional ByVal prescribedStopDateBound As Date = Nothing,
                                      Optional ByVal RxNumber As Int32 = Nothing
                                      ) As DataSet
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "SEARCH_PRESCRIPTION" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app

                .Parameters.Add("@patientName", SqlDbType.VarChar, 51).Value = patientName
                .Parameters.Add("@physicianName", SqlDbType.VarChar, 51).Value = physicianName
                .Parameters.Add("@drugName", SqlDbType.VarChar, 60).Value = physicianName
                If prescribedStartDateBound.Date <> Nothing Then
                    .Parameters.Add("@prescribedStartDateBound", SqlDbType.Date).Value = prescribedStartDateBound
                End If

                If prescribedStopDateBound.Date <> Nothing Then
                    .Parameters.Add("@prescribedStopDateBound", SqlDbType.Date).Value = prescribedStopDateBound
                End If

                If RxNumber <> 0 Then
                    .Parameters.Add("@RxNumber", SqlDbType.Int).Value = RxNumber
                End If



                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                Dim aAdapter As New SqlClient.SqlDataAdapter
                aAdapter.SelectCommand = cmdString
                Dim aDataSet As New DataSet

                'fill adapater
                aAdapter.Fill(aDataSet)

                'return dataSet
                Return aDataSet
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            connString.Close()

        End Try
    End Function

    Public Function updatePrescription(
                                      Optional ByVal rxNumber As Int32 = Nothing,
                                      Optional ByVal drugDescription As String = Nothing,
                                      Optional ByVal drugDosage As String = Nothing,
                                      Optional ByVal drugFrequency As String = Nothing,
                                      Optional ByVal intakeMethod As String = Nothing,
                                      Optional ByVal maxRefills As Int32 = Nothing
                                      ) As Integer
        Try
            cmdStringConfig()
            Dim outcome As Int32
            With cmdString 'specifying SQL

                .CommandText = "UPDATE_PRESCRIPTION" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app

                .Parameters.Add("@rxNumber", SqlDbType.Int).Value = rxNumber
                .Parameters.Add("@DrugDescription", SqlDbType.VarChar, 60).Value = drugDescription
                .Parameters.Add("@DRUGDOSAGE", SqlDbType.VarChar, 40).Value = drugDosage
                .Parameters.Add("@drugFrequency", SqlDbType.VarChar, 50).Value = drugFrequency
                .Parameters.Add("@intakeMethod", SqlDbType.VarChar, 50).Value = intakeMethod
                .Parameters.Add("@maxRefills", SqlDbType.Int).Value = maxRefills




                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                outcome = .ExecuteScalar()
                Return outcome
            End With
        Catch ex As Exception
            Return -1
            Throw New Exception(ex.Message)

        Finally
            connString.Close()

        End Try
    End Function

End Class
