Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        'Public Shared mEinkaufsliste As Einkaufsliste

        'GET: /Ticket/Bearbeiten
        <HttpGet>
        Function Bearbeiten(ID As Integer) As ActionResult
            'Deklaration
            Dim ticket As Ticket
            Dim ticketEntity As TicketEntity
            Dim vmTicket As TicketViewModel

            'Datenbankzugriff über Entity Framework
            ticketEntity = db.tblTicket.Find(ID) 'Datensatz mit diesem Primärschlüssel in tblJobanzeige nachschlagen

            If ticketEntity Is Nothing Then
                Return New HttpNotFoundResult("Ticket mit der ID " & ID & " wurde nicht gefunden") 'wenn keine Jobanzeige gefunden, laden
            End If
            'Gefundenen Datensatz aus der Datenbank loslösen
            db.Entry(ticketEntity).State = EntityState.Detached
            'Umwandeln in ein Objekt der Model-Klasse
            ticket = New Ticket(ticketEntity)

            'Vorbereitung des View-Models
            vmTicket = New TicketViewModel
            vmTicket.Ticket = ticket

            Return View(vmTicket) 'ViewModel mit Jobanzeige und allen Branchen an die View zur Bearbeitung geben
        End Function

        'POST: /Jobanzeige/Bearbeiten
        <HttpPost>
        Function Bearbeiten(pvmTicket As TicketViewModel) As ActionResult
            Dim ticket As Ticket
            Dim ticketEntity As TicketEntity

            'If Not (ModelState.IsValid) Then

            '    'Wenn nicht, dann zurück an die View
            '    Return View(pvmJobanzeige)
            'End If

            'Jobanzeige aus dem ViewModel holen und in JobanzeigeEntity umwandeln
            ticket = pvmTicket.Ticket
            ticketEntity = ticket.gibAlsTicketEntity
            'Speichern vorbereiten
            db.tblTicket.Attach(ticketEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(ticketEntity).State = EntityState.Modified 'als Geändert markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Bearbeiten war nicht erfolgreich.")
            End Try

            Return RedirectToAction("Bearbeiten") 'Zurück zur Übersicht über alle Jobanzeigen
        End Function
    End Class
End Namespace