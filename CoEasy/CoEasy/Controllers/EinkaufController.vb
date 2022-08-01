Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        'Public Shared mEinkaufsliste As Einkaufsliste

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

        'GET: /Einkauf/Neu
        Function Neu() As ActionResult
            Dim eink As Einkauf
            Dim ticket As Ticket
            Dim coworker As Coworker
            Dim lstTickets As List(Of Ticket)
            Dim lstCoworkers As List(Of Coworker)
            Dim einkpos As Einkaufsposition
            Dim vmEink As EinkaufViewModel

            eink = New Einkauf 'Neue leere Modelle erzeugen
            einkpos = New Einkaufsposition

            'Alle Tickets aus Datenbank laden
            lstTickets = New List(Of Ticket)
            For Each ticketEntity In db.tblTicket.ToList
                ticket = New Ticket(ticketEntity)
                lstTickets.Add(ticket)
            Next

            'Alle Coworkers aus Datenbank laden
            lstCoworkers = New List(Of Coworker)
            For Each coworkerEntity In db.tblCoworker.ToList
                coworker = New Coworker(coworkerEntity)
                lstCoworkers.Add(coworker)
            Next

            'ViewModel vorbereiten
            vmEink = New EinkaufViewModel
            vmEink.Einkauf = eink
            vmEink.ListeTickets = lstTickets
            vmEink.ListeCoworkers = lstCoworkers
            vmEink.Einkaufsposition = einkpos
            Return View(vmEink) 'Neuer Einkauf und Liste aller 
            'Tickets und Coworkers als ViewModel an die View übergeben
        End Function

        'POST: /Einkauf/Neu
        <HttpPost>
        Function Neu(pvmEink As EinkaufViewModel) As ActionResult
            Dim eink As Einkauf
            Dim einkEntity As EinkaufEntity
            Dim ticket As Ticket
            Dim lstTickets As List(Of Ticket)
            Dim coworker As Coworker
            Dim lstCoworkers As List(Of Coworker)
            Dim einkpos As Einkaufsposition
            Dim einkposEntity As EinkaufspositionEntity

            If Not ModelState.IsValid Then
                lstTickets = New List(Of Ticket) 'Alle Tickets aus Datenbank laden
                lstCoworkers = New List(Of Coworker)
                einkpos = New Einkaufsposition

                For Each ticketEntity In db.tblTicket.ToList
                    ticket = New Ticket(ticketEntity)
                    lstTickets.Add(ticket)
                Next

                For Each coworkerEntity In db.tblCoworker.ToList
                    coworker = New Coworker(coworkerEntity)
                    lstCoworkers.Add(coworker)
                Next

                pvmEink.ListeTickets = lstTickets
                pvmEink.ListeCoworkers = lstCoworkers
                pvmEink.Einkaufsposition = einkpos
                Return View(pvmEink)
            End If

            'Einkauf und Einkausposition aus dem ViewModel holen
            eink = pvmEink.Einkauf
            einkpos = pvmEink.Einkaufsposition

            'Datenaustausch vor dem Speichern
            einkpos.Totalpreis = db.tblTicket.ToList.Find(Function(t) t.TicketIdPk = einkpos.TicketID).Preis
            eink.Totalpreis = einkpos.Totalpreis

            'in Entity umwandeln
            einkEntity = eink.gibAlsEinkaufEntity
            einkposEntity = einkpos.gibAlsEinkPositionEntity

            'speichern vorbereiten
            db.tblEinkauf.Attach(einkEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(einkEntity).State = EntityState.Added 'als Hinzugefügt markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Hinzufügen von Einkauf war nicht erfolgreich.")
            End Try

            'speichern von Einkaufsposition vorbereiten
            einkposEntity.EinkaufIdFk = db.tblEinkauf.ToList.Last.EinkaufIdPk 'Zuweisung von EinkaufID, da es erst nach dem Speichern veröffentlicht wurde
            db.tblEinkaufsposition.Attach(einkposEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(einkposEntity).State = EntityState.Added 'als Hinzugefügt markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Hinzufügen von Einkaufsposition war nicht erfolgreich.")
            End Try

            Return RedirectToAction("Einkaeufe", "CoEasy") 'Zurück zur Übersicht über alle Einkäufe
        End Function

    End Class
End Namespace