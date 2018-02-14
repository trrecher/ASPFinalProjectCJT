Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.SqlClient



Public Class patientDataTier
    'create connection
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

    Public Function addPatient(
                              ByVal patientFirstName As String,
                              ByVal patientLastName As String,
                              ByVal patientDOB As String,
                              ByVal patientGender As String,
                              Optional ByVal patientMiddleInitial As String = Nothing,
                              Optional ByVal patientHomePhone As String = Nothing,
                              Optional ByVal patientCellPhone As String = Nothing,
                              Optional ByVal patientAddress As String = Nothing,
                              Optional ByVal patientCity As String = Nothing,
                              Optional ByVal patientState As String = Nothing,
                              Optional ByVal patientZipCode As String = Nothing,
                              Optional ByVal patientEmailAddress As String = Nothing
                              ) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "ADD_PATIENT" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@fName", SqlDbType.VarChar, 25).Value = patientFirstName
                .Parameters.Add("@lName", SqlDbType.VarChar, 25).Value = patientLastName
                .Parameters.Add("@mInitial", SqlDbType.Char, 1).Value = patientMiddleInitial
                .Parameters.Add("@DOB", SqlDbType.Date).Value = patientDOB
                .Parameters.Add("@gender", SqlDbType.Char, 6).Value = patientGender
                .Parameters.Add("@homePhone", SqlDbType.VarChar, 15).Value = patientHomePhone
                .Parameters.Add("@cellPhone", SqlDbType.VarChar, 15).Value = patientCellPhone
                .Parameters.Add("@patientAddress", SqlDbType.VarChar, 60).Value = patientAddress
                .Parameters.Add("@city", SqlDbType.VarChar, 60).Value = patientCity
                .Parameters.Add("@patientState", SqlDbType.VarChar, 2).Value = patientState
                .Parameters.Add("@zip", SqlDbType.VarChar, 5).Value = patientZipCode
                .Parameters.Add("@email", SqlDbType.VarChar, 80).Value = patientEmailAddress

                '.Parameters.Add("@patient_ID", SqlDbType.VarChar, 5).Value = patientID


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


    Public Function searchPatient(
                                  Optional ByVal patientDOBStartBound As Date = Nothing,
                                  Optional ByVal patientDOBStopBound As Date = Nothing,
                                  Optional ByVal patientName As String = Nothing,
                                  Optional ByVal patientID As Int32 = Nothing
                                  ) As DataSet
        cmdStringConfig()

        Dim aDataSet As New DataSet
        Try
            With cmdString 'specifying SQL
                If patientDOBStartBound.Date <> Nothing Or
                        patientDOBStopBound.Date <> Nothing Or
                        patientName <> "" Or
                        patientID <> 0 Then
                    .CommandText = "SEARCH_PATIENT" 'SQL stored procedure

                    'how to package values from app to SQL language
                    'what in SQL is = to variable in app
                    If patientID <> 0 Then
                        .Parameters.Add("@patientID", SqlDbType.Int).Value = patientID
                    End If

                    If patientDOBStartBound.Date <> Nothing Then
                        .Parameters.Add("@DOBstartBound", SqlDbType.Date).Value = patientDOBStartBound
                    End If

                    If patientDOBStopBound.Date <> Nothing Then
                        .Parameters.Add("@DOBstopBound", SqlDbType.Date).Value = patientDOBStopBound
                    End If

                    .Parameters.Add("@patientName", SqlDbType.VarChar, 51).Value = patientName

                    Dim aAdapter As New SqlClient.SqlDataAdapter
                    aAdapter.SelectCommand = cmdString

                    'fill adapater
                    aAdapter.Fill(aDataSet)

                    'return dataSet

                Else
                    aDataSet = Nothing
                End If

                Return aDataSet
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)


        Finally
            connString.Close()

        End Try
    End Function
End Class
