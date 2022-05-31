Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Public Class TicketListe
    Private mlstTickets As List(Of Ticket)

    Public Sub New()
        mlstTickets = New List(Of Ticket)
    End Sub

    Public Sub New(plstTickets As List(Of Ticket))
        mlstTickets = plstTickets
    End Sub

    Public Property Tickets As List(Of Ticket)
        Get
            Return mlstTickets
        End Get
        Set(value As List(Of Ticket))
            mlstTickets = value
        End Set
    End Property
End Class
