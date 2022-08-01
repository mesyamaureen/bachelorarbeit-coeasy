Imports System.Web.Mvc
Imports System.Data.Entity

Namespace Controllers
    Public Class CoworkerController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe
        Function Oeffnen(ID As Integer) As ActionResult
            Dim cow As Coworker
            Dim cowEntity As CoworkerEntity
            Dim vmCow As CoworkerViewModel

            'Datenbankzugriff über Entity Framework
            cowEntity = db.tblCoworker.Find(ID) 'Datensatz mit diesem Primärschlüssel in tblInfluencer nachschlagen

            If cowEntity Is Nothing Then
                Return New HttpNotFoundResult("Coworker mit der ID " & ID & " wurde nicht gefunden") 'wenn kein Coworker gefunden, laden
            End If
            'Gefundenen Datensatz aus der Datenbank loslösen
            db.Entry(cowEntity).State = EntityState.Detached
            'Umwandeln in ein Objekt der Model-Klasse
            cow = New Coworker(cowEntity)

            'Vorbereitung des View-Models
            vmCow = New CoworkerViewModel
            vmCow.Coworker = cow
            Return View(vmCow)
        End Function

        'GET: /Jobanzeige/Hinzufuegen
        Function Neu() As ActionResult
            Dim cow As Coworker
            Dim vmCow As CoworkerViewModel

            cow = New Coworker 'Neue leere Jobanzeige erzeugen

            'ViewModel vorbereiten
            vmCow = New CoworkerViewModel
            vmCow.Coworker = cow
            Return View(vmCow) 'Neue Jobanzeige und Liste aller 
        End Function

        'POST: /Jobanzeige/Hinzufuegen
        <HttpPost>
        Function Neu(pvmCow As CoworkerViewModel) As ActionResult
            Dim cow As Coworker
            Dim cowEntity As CoworkerEntity

            'Jobanzeige aus dem ViewModel holen und in Jobanzeige entity umwandeln
            cow = pvmCow.Coworker
            cowEntity = cow.gibAlsCowEntity
            'speichern vorbereiten
            db.tblCoworker.Attach(cowEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(cowEntity).State = EntityState.Added 'als Hinzugefügt markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Hinzufügen war nicht erfolgreich.")
            End Try
            Return RedirectToAction("AlleCoworkers", "AlleCoworkers") 'Zurück zur Übersicht über alle Jobanzeigen
        End Function
    End Class
End Namespace