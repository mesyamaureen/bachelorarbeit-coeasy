Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        'GET: /Einkaeufe/Oeffnen
        Function Oeffnen(ID As Integer) As ActionResult
            Dim eink As Einkauf
            Dim einkEntity As EinkaufEntity
            Dim vmEink As EinkaufViewModel = New EinkaufViewModel
            'Datenbankzugriff über Entity Framework
            einkEntity = db.tblEinkauf.Find(ID) 'Datensatz mit diesem Primärschlüssel in tblEinkauf nachschlagen

            'gefundenen Datensatz aus der Datenbank loslösen
            db.Entry(einkEntity).State = EntityState.Detached
            'umwandeln in ein Objekt der Model-Klasse
            eink = New Einkauf(einkEntity)

            'vorbereitung des View-Models
            vmEink.Einkauf = eink

            Return View(vmEink) 'ViewModel mit Einkauf an die View zur Bearbeitung geben
        End Function

        'POST: Einkauf/Stornieren
        <HttpPost>
        Function Stornieren(pEink As Einkauf) As ActionResult
            Dim einkEntity As EinkaufEntity = pEink.gibAlsEinkaufEntity 'einkauf in einkaufentity umwandeln
            db.tblEinkauf.Attach(einkEntity) 'speichern vorbereiten
            db.Entry(einkEntity).State = EntityState.Deleted 'als gelöscht markieren
            Try 'vorsichtig Änderungen speichern
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Stornierung war nicht erfolgreich.")
            End Try
            Return RedirectToAction("Einkaeufe", "CoEasy") 'zurück zur Übersicht Einkäufe
        End Function

        Function Neu() As ActionResult
            Dim eink As Einkauf
            Dim ticket As Ticket
            Dim lstTickets As List(Of Ticket)
            Dim vmEink As EinkaufViewModel

            eink = New Einkauf 'Neue leere Jobanzeige erzeugen

            'Alle Branche aus Datenbank laden
            lstTickets = New List(Of Ticket)
            For Each ticketEntity In db.tblTicket.ToList
                ticket = New Ticket(ticketEntity)
                lstTickets.Add(ticket)
            Next

            'ViewModel vorbereiten
            vmEink = New EinkaufViewModel
            vmEink.Einkauf = eink
            vmEink.ListeTickets = lstTickets
            Return View(vmEink) 'Neue Jobanzeige und Liste aller 
            'branche als ViewModel an die View übergeben
        End Function

        'POST: /Jobanzeige/Hinzufuegen
        <HttpPost>
        Function Neu(pvmEink As EinkaufViewModel) As ActionResult
            Dim eink As Einkauf
            Dim einkEntity As EinkaufEntity
            Dim ticket As Ticket
            Dim lstTickets As List(Of Ticket)

            If Not ModelState.IsValid Then
                lstTickets = New List(Of Ticket) 'Alle Branche aus Datenbank laden

                For Each ticketEntity In db.tblTicket.ToList
                    ticket = New Ticket(ticketEntity)
                    lstTickets.Add(ticket)
                Next
                pvmEink.ListeTickets = lstTickets
                Return View(pvmEink)
            End If

            'Jobanzeige aus dem ViewModel holen und in Jobanzeige entity umwandeln
            eink = pvmEink.Einkauf
            'job.UnternehmerID = Web.HttpContext.Current.Session("BenutzerID")
            einkEntity = eink.gibAlsEinkaufEntity
            'speichern vorbereiten
            db.tblEinkauf.Attach(einkEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(einkEntity).State = EntityState.Added 'als Hinzugefügt markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Hinzufügen war nicht erfolgreich.")
            End Try
            Return RedirectToAction("Einkaeufe", "CoEasy") 'Zurück zur Übersicht über alle Jobanzeigen
        End Function

    End Class
End Namespace