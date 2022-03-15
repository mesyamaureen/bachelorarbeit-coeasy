Public Class CoworkerListe
    Private mlstCoworker As List(Of Coworker)

    Public Sub New()
        mlstCoworker = New List(Of Coworker)
    End Sub

    Public Sub New(plstCoworker As List(Of Coworker))
        mlstCoworker = plstCoworker
    End Sub

    Public Property Coworker As List(Of Coworker)
        Get
            Return mlstCoworker
        End Get
        Set(value As List(Of Coworker))
            mlstCoworker = value
        End Set
    End Property
End Class
