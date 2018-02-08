Imports System, System.Web.Caching, _
                System.Xml, Microsoft.VisualBasic

''' <summary>
''' Provides the functionality related to retrieving the list 
''' of states for a system; 
''' </summary>
Public Module StateManager
    ' Cache object that will be used to store and retrieve items from
    ' the cache and constants used within this object
    Private myCache As Cache = System.Web.HttpRuntime.Cache()
    Private stateKey As String = "StateKey"
    Public applicationConstantsFileName As String = _
       Replace(System.AppDomain.CurrentDomain.BaseDirectory & _
                    "State.xml", "/", "\")
    '"States.config", "/", "\")
    Private stateArray As State()
    Private errorList As ArrayList


    ' Tells you whether or not any errors have occurred w/in the module
    Public ReadOnly Property hasErrors() As Boolean
        Get
            If errorList Is Nothing OrElse errorList.Count = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property


    ' Retrieves an array list of Exception objects
    Public ReadOnly Property getErrors() As ArrayList
        Get
            Return errorList
        End Get
    End Property


    ' Private method used to add errors to the errorList
    Private Sub addError(ByRef e As Exception)
        If errorList Is Nothing Then errorList = New ArrayList
        errorList.Add(e)
    End Sub

    ''' <summary>
    ''' Gets all the states
    ''' </summary>
    ''' <returns>An array of State objects</returns>
    Public Function getStates() As State()
        If myCache(stateKey) Is Nothing Then
            PopulateCache()
        End If
        Return stateArray
    End Function


    ''' <summary>
    ''' Takes the abbreviation given and returns the full name
    ''' </summary>
    ''' <returns>The full name for the abbreviation in 
    ''' question</returns>
    Private Function convertAbbreviationToName(ByRef abbreviation _
                                                  As String) As String
        Dim xmlFile As New XmlDocument()

        Try
            xmlFile.Load(applicationConstantsFileName)
            Dim theNode As XmlNode = _
               xmlFile.SelectSingleNode("descendant::state[@abbreviation='" & _
                                         abbreviation & "']")

            If Not theNode Is Nothing Then _
               Return theNode.Attributes.GetNamedItem("name").Value

        Catch e As Exception
            addError(e)

        End Try

        Return vbNullString
    End Function


    ''' <summary>
    ''' Gets the state object based on the full name
    ''' </summary>
    ''' <param name="name">The full name of the state to 
    ''' retrieve</param>
    ''' <returns>A State object for the name given</returns>
    Public Function getStateByName(ByRef name As String) As State
        If myCache(stateKey & name) Is Nothing Then PopulateCache()
        Return myCache(stateKey & name)
    End Function


    ''' <summary>
    ''' Gets the state object based on the abbreviation
    ''' </summary>
    ''' <param name="abbreviation">The abbreviation of the state 
    ''' to retrieve</param>
    ''' <returns>A State object for the abbreviation 
    ''' given</returns>
    Public Function getStateByAbbreviation(ByRef abbreviation _
                                                     As String) As State
        Dim name As String = convertAbbreviationToName(abbreviation)
        If name <> vbNullString Then
            Return getStateByName(name)
        Else
            Return Nothing
        End If
    End Function


    '''<summary>The manager attempts to load the XML
    ''' file and store it in the cache with a dependency on the XML 
    ''' file itself.' This means that any time the XML file changes, it 
    ''' is removed from the cache.  When the methods that return State 
    ''' objects are called again, the XML file won't exist in memory 
    ''' and the PopulateCache will be re-called.
    ''' </summary>
    Private Sub PopulateCache()
        Dim xmlFile As New XmlDocument()
        'Dim theState As State
        Dim theNode As XmlNode
        Dim theName, theAbbreviation As String
        Dim i As Integer = 0

        Try
            xmlFile.Load(applicationConstantsFileName)

            'Attempt to find the element given the "key" for that tag
            Dim elementList As XmlNodeList = _
                       xmlFile.GetElementsByTagName("state")

            If Not elementList Is Nothing Then
                stateArray = Array.CreateInstance(GetType(State), _
                                                           elementList.Count)

                'Loop through each element that has the name we're looking for
                For i = 0 To elementList.Count - 1
                    theNode = elementList(i)

                    'Get the name for that tag
                    If Not theNode.Attributes.GetNamedItem("name") Is Nothing Then
                        theName = theNode.Attributes.GetNamedItem("name").Value
                    Else
                        theName = vbNullString
                    End If

                    'Get the abbreviation for that tag
                    If Not theNode.Attributes.GetNamedItem("abbreviation") _
                                                                  Is Nothing Then
                        theAbbreviation = _
                              theNode.Attributes.GetNamedItem("abbreviation").Value
                    Else
                        theAbbreviation = vbNullString
                    End If

                    'Populate that location in the array with the
                    ' values for the tag
                    stateArray(i) = New State(theName, theAbbreviation)

                    'Insert the state into cache
                    myCache.Insert(stateKey & theName, stateArray(i), _
                            New CacheDependency(applicationConstantsFileName))

                Next

                'Insert the state array into cache
                myCache.Insert(stateKey, stateArray, _
                           New CacheDependency(applicationConstantsFileName))

            End If

        Catch e As Exception
            addError(e)

        End Try
    End Sub
End Module


