Imports Microsoft.VisualBasic

Public Class state
    Private nameString As String
    Private abbreviationString As String

    Public Sub New(ByRef nameArg As String, _
                       ByRef abbreviationArg As String)

        abbreviationString = abbreviationArg
        nameString = nameArg

    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return nameString
        End Get
    End Property

    Public ReadOnly Property Abbreviation() As String
        Get
            Return abbreviationString
        End Get
    End Property

    Public ReadOnly Property FullAndAbbrev() As String
        Get
            Return nameString & " (" & abbreviationString & ")"
        End Get
    End Property

End Class
