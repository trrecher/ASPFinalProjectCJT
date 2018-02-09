Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class RefillDataTier
    'DataTier template
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("connString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand

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

    Public Function addRefill(
                                   ByVal RxNumber As Integer
                                    ) As Integer
        Dim outcome As Int32
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "ADD_Refill" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@RxNumber", SqlDbType.Int).Value = RxNumber
                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                outcome = .ExecuteScalar()

                Return outcome
            End With
        Catch ex As Exception
            Return -2
            Throw New Exception(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

    Public Function deleteRefill(refillID As Integer) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "DELETE_REFILL" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app
                .Parameters.Add("@refillID", SqlDbType.Int).Value = refillID


                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                .ExecuteNonQuery()
            End With
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return -1
        Finally
            connString.Close()

        End Try
    End Function

    Public Function searchRefill(
                                Optional ByVal RefillID As Int32 = Nothing,
                                Optional ByVal patientName As String = Nothing,
                                Optional ByVal physicianName As String = Nothing,
                                Optional ByVal drugName As String = Nothing,
                                Optional ByVal prescribedStartDateBound As Date = Nothing,
                                Optional ByVal prescribedStopDateBound As Date = Nothing,
                                Optional ByVal refillStartDateBound As Date = Nothing,
                                Optional ByVal refillStopDateBound As Date = Nothing,
                                Optional ByVal RxNumber As Int32 = Nothing
                                ) As DataSet
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "SEARCH_REFILL" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app

                If RefillID <> 0 Then
                    .Parameters.Add("@refillID", SqlDbType.Int).Value = RefillID
                End If

                If RxNumber <> 0 Then
                    .Parameters.Add("@RxNumber", SqlDbType.Int).Value = RxNumber
                End If

                .Parameters.Add("@patientName", SqlDbType.VarChar, 51).Value = patientName
                .Parameters.Add("@physicianName", SqlDbType.VarChar, 51).Value = physicianName
                .Parameters.Add("@drugName", SqlDbType.VarChar, 60).Value = physicianName
                If prescribedStartDateBound.Date <> Nothing Then
                    .Parameters.Add("@prescribedStartDateBound", SqlDbType.Date).Value = prescribedStartDateBound
                End If

                If prescribedStopDateBound <> Nothing Then
                    .Parameters.Add("@prescribedStopDateBound", SqlDbType.Date).Value = prescribedStopDateBound
                End If

                If refillStartDateBound <> Nothing Then
                    .Parameters.Add("@refillStopDateBound", SqlDbType.Date).Value = refillStopDateBound
                End If

                If refillStopDateBound <> Nothing Then
                    .Parameters.Add("@refillStopDateBound", SqlDbType.Date).Value = refillStopDateBound
                End If

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

    Public Function updateRefill(refillID As String, refillDate As Date) As Integer
        Try
            cmdStringConfig()

            With cmdString 'specifying SQL

                .CommandText = "UPDATE_REFILL" 'SQL stored procedure

                'how to package values from app to SQL language
                'what in SQL is = to variable in app

                .Parameters.Add("@refillID", SqlDbType.Int).Value = refillID
                .Parameters.Add("@refillDate", SqlDbType.DateTime).Value = refillDate





                '.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID


                .ExecuteNonQuery()
            End With
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return -1

        Finally
            connString.Close()

        End Try
    End Function



End Class
