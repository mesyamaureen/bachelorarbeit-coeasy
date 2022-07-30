Public Class EinkaufViewModel
    Private mEinkauf As Einkauf
    Private mlstTickets As List(Of Ticket)

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
End Class
