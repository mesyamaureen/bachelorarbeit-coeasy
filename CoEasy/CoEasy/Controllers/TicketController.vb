Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        'Public Shared mEinkaufsliste As Einkaufsliste

        'GET: /Ticket/Bearbeiten
        <HttpGet>
        Function Bearbeiten(ID As Integer) As ActionResult
            Dim ticket As Ticket
            Dim ticketEntity As TicketEntity = db.tblTicket.Find(ID)
            Dim vmTicket As TicketViewModel = New TicketViewModel
            If ticketEntity Is Nothing Then
                Return New HttpNotFoundResult("Ticket mit der ID " & ID & " wurde nicht gefunden")
            End If
            db.Entry(ticketEntity).State = EntityState.Detached
            ticket = New Ticket(ticketEntity)
            vmTicket.Ticket = ticket
            Return View(vmTicket)
        End Function

        'POST: /Ticket/Bearbeiten
        <HttpPost>
        Function Bearbeiten(pvmTicket As TicketViewModel) As ActionResult
            Dim ticket As Ticket = pvmTicket.Ticket
            Dim ticketEntity As TicketEntity = ticket.gibAlsTicketEntity
            db.tblTicket.Attach(ticketEntity)
            db.Entry(ticketEntity).State = EntityState.Modified
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Bearbeiten war nicht erfolgreich.")
            End Try
            Return RedirectToAction("Bearbeiten")
        End Function

        'GET: /Ticket/Loeschen
        Function Loeschen(ID As Integer) As ActionResult
            Dim tick As Ticket
            Dim tickEntity As TicketEntity
            tickEntity = db.tblTicket.Find(ID)

            If tickEntity Is Nothing Then
                Return New HttpNotFoundResult("Ticket mit der ID " & ID & " wurde nicht gefunden.")
            End If

            db.Entry(tickEntity).State = EntityState.Detached

            tick = New Ticket(tickEntity)
            Return View(tick)
        End Function

        'POST: /Ticket/Loeschen
        <HttpPost>
        Function Loeschen(pTicket As Ticket) As ActionResult
            Dim tickEntity As TicketEntity
            tickEntity = pTicket.gibAlsTicketEntity
            'Speichern vorbereiten
            db.tblTicket.Attach(tickEntity)
            db.Entry(tickEntity).State = EntityState.Deleted
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Löschen war nicht erfolgreich.")
            End Try

            Return RedirectToAction("AlleTickets", "AlleTickets")
        End Function

        'GET: /Ticket/Neu
        Function Neu() As ActionResult
            Dim ticket As Ticket
            Dim vmTicket As TicketViewModel

            ticket = New Ticket

            'ViewModel vorbereiten
            vmTicket = New TicketViewModel
            vmTicket.Ticket = ticket
            Return View(vmTicket)
        End Function

        'POST: /Ticket/Neu
        <HttpPost>
        Function Neu(pvmCow As CoworkerViewModel) As ActionResult
            Dim cow As Coworker
            Dim cowEntity As CoworkerEntity
            cow = pvmCow.Coworker
            cowEntity = cow.gibAlsCowEntity
            'speichern vorbereiten
            db.tblCoworker.Attach(cowEntity)
            db.Entry(cowEntity).State = EntityState.Added 'als Hinzugefügt markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Hinzufügen war nicht erfolgreich.")
            End Try
            Return RedirectToAction("AlleCoworkers", "AlleCoworkers")
        End Function

    End Class
End Namespace