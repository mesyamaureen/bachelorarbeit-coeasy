Public Class EinkaufViewModel
    Private mEinkauf As Einkauf
    Private mlstTickets As List(Of Ticket)
    Private mlstCoworkers As List(Of Coworker)
    Private mEinkaufspos As Einkaufsposition
    Private mlstEinkaufpos As List(Of Einkaufsposition)

    Public Property Einkauf As Einkauf
        Get
            Return mEinkauf
        End Get
        Set(value As Einkauf)
            mEinkauf = value
        End Set
    End Property

    Public Property ListeTickets As List(Of Ticket)
        Get
            Return mlstTickets
        End Get
        Set(value As List(Of Ticket))
            mlstTickets = value
        End Set
    End Property

    Public Property ListeCoworkers As List(Of Coworker)
        Get
            Return mlstCoworkers
        End Get
        Set(value As List(Of Coworker))
            mlstCoworkers = value
        End Set
    End Property

    Public Property Einkaufsposition As Einkaufsposition
        Get
            Return mEinkaufspos
        End Get
        Set(value As Einkaufsposition)
            mEinkaufspos = value
        End Set
    End Property
    Public Property ListeEinkaufpos As List(Of Einkaufsposition)
        Get
            Return mlstEinkaufpos
        End Get
        Set(value As List(Of Einkaufsposition))
            mlstEinkaufpos = value
        End Set
    End Property
End Class
