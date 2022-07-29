Public Class TicketViewModel
    Private mTicket As Ticket

    Public Property Ticket As Ticket
        Get
            Return mTicket
        End Get
        Set(value As Ticket)
            mTicket = value
        End Set
    End Property
End Class
