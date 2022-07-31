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
            tickEntity = db.tblTicket.Find(ID) 'Jobanzeige in Datenbank finden

            If tickEntity Is Nothing Then
                Return New HttpNotFoundResult("Ticket mit der ID " & ID & " wurde nicht gefunden.")
            End If

            db.Entry(tickEntity).State = EntityState.Detached

            tick = New Ticket(tickEntity)
            Return View(tick) 'An die View geben, damit dort das Löschen bestätigt werden soll
        End Function

        'POST: /Ticket/Loeschen
        <HttpPost>
        Function Loeschen(pTicket As Ticket) As ActionResult
            Dim tickEntity As TicketEntity

            ' Jobanzeige in JobanzeigeEntity umwandeln
            tickEntity = pTicket.gibAlsTicketEntity
            'Speichern vorbereiten
            db.tblTicket.Attach(tickEntity)
            db.Entry(tickEntity).State = EntityState.Deleted 'als Gelöscht markieren
            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Löschen war nicht erfolgreich.")
            End Try

            Return RedirectToAction("AlleTickets", "AlleTickets") 'Zurück zur Übersicht über alle Jobanzeigen
        End Function

    End Class
End Namespace