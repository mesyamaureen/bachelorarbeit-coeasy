Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
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

    End Class
End Namespace