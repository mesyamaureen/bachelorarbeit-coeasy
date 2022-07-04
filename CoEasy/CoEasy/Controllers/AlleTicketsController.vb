Imports System.Web.Mvc

Namespace Controllers
    Public Class AlleTicketsController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        ' GET: AlleTickets
        Function AlleTickets() As ActionResult
            'Platzhalter für die Liste erstellen
            Dim listeTickets As TicketListe
            Dim einzelnerTicket As Ticket
            Dim entityTicket As TicketEntity

            'entleeren der Platzhalter
            listeTickets = New TicketListe()
            'erstellen Verbindung zur Datenbank
            For Each entityTicket In db.tblTicket.ToList
                'Objekt der Entity-Klasse in Objekt der Model Klasse umwandeln
                einzelnerTicket = New Ticket(entityTicket)
                'Objekt der Model Klasse zur Liste hinzufügen
                listeTickets.Tickets.Add(einzelnerTicket)
            Next
            Return View(listeTickets)
        End Function
    End Class
End Namespace