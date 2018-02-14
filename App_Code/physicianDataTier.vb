Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class PhysicianDataTier
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

    Public Function addPhysician(ByVal physicianFirstName As String,
                                 ByVal physicianLastName As String,
                                 ByVal physicianDOB As String,
                                 ByVal physicianGender As String,
                                 ByVal physicianSalary As Decimal,
                                 Optional ByVal physicianMiddleInitial As String = Nothing,
                                 Optional ByVal physicianSpecialty As String = Nothing,
                                 Optional ByVal physicianWorkPhone As String = Nothing,
                                 Optional ByVal physicianAddress As String = Nothing,
                                 Optional ByVal physicianCity As String = Nothing,
                                 Optional ByVal physicianState As String = Nothing,
                                 Optional ByVal physicianZipCode As String = Nothing,
                                 Optional ByVal physicianEmailAddress As String = Nothing
                                 ) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "ADD_PHYSICIAN" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@fName", SqlDbType.VarChar, 25).Value = physicianFirstName
                .Parameters.Add("@lName", SqlDbType.VarChar, 25).Value = physicianLastName
                .Parameters.Add("@mInitial", SqlDbType.Char, 1).Value = physicianMiddleInitial
                .Parameters.Add("@DOB", SqlDbType.Date).Value = physicianDOB
                .Parameters.Add("@gender", SqlDbType.Char, 6).Value = physicianGender
                .Parameters.Add("@specialty", SqlDbType.VarChar, 40).Value = physicianSpecialty
                .Parameters.Add("@workPhone", SqlDbType.VarChar, 15).Value = physicianWorkPhone
                .Parameters.Add("@physicianAddress", SqlDbType.VarChar, 60).Value = physicianAddress
                .Parameters.Add("@city", SqlDbType.VarChar, 60).Value = physicianCity
                .Parameters.Add("@physicianState", SqlDbType.VarChar, 2).Value = physicianState
                .Parameters.Add("@zip", SqlDbType.VarChar, 5).Value = physicianZipCode
                .Parameters.Add("@email", SqlDbType.VarChar, 80).Value = physicianEmailAddress
                .Parameters.Add("@salary", SqlDbType.Decimal, 8, 2).Value = physicianSalary
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

    Public Function searchPhysician(
                                   Optional ByVal DOBstartBound As Date = Nothing,
                                   Optional ByVal DOBstopBound As Date = Nothing,
                                   Optional ByVal physicianName As String = Nothing,
                                   Optional ByVal physicianspecialty As String = Nothing,
                                   Optional ByVal physicianID As Int32 = Nothing
                                   ) As DataSet
        Try
            cmdStringConfig()

            Dim aDataSet As New DataSet

            With cmdString 'specifying SQL

                If DOBstartBound.Date <> Nothing Or
                        DOBstopBound.Date <> Nothing Or
                        physicianName <> "" Or
                        physicianspecialty <> "" Or
                        physicianID <> 0 Then
                    .CommandText = "SEARCH_PHYSICIAN" 'SQL stored procedure

                    'how to package values from app to SQL language
                    'what in SQL is = to variable in app

                    If DOBstartBound.Date <> Nothing Then
                        .Parameters.Add("@DOBstartBound", SqlDbType.Date).Value = DOBstartBound
                    End If

                    If DOBstopBound.Date <> Nothing Then
                        .Parameters.Add("@DOBstopBound", SqlDbType.Date).Value = DOBstopBound
                    End If

                    .Parameters.Add("@physicianName", SqlDbType.VarChar, 51).Value = physicianName
                    .Parameters.Add("@physicianSpecialty", SqlDbType.VarChar, 40).Value = physicianspecialty
                    If physicianID <> 0 Then
                        .Parameters.Add("@physicianID", SqlDbType.Int).Value = physicianID
                    End If



                    Dim aAdapter As New SqlClient.SqlDataAdapter
                    aAdapter.SelectCommand = cmdString

                    'fill adapater
                    aAdapter.Fill(aDataSet)

                Else
                    aDataSet = Nothing
                End If

                'return dataSet
                Return aDataSet
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

End Class
