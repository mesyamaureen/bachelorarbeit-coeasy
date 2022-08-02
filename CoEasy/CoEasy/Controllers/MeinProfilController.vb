Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class MeinProfilController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        ' GET: MeinProfil/Profil
        Function Profil(Optional ID As Integer = -1) As ActionResult
            'Deklaration
            If ID = -1 Then
                ID = Int(Web.HttpContext.Current.Session("BenutzerID"))
            End If
            Dim mit As Mitarbeiter
            Dim mitEntity As MitarbeiterEntity
            Dim vmMit As MitarbeiterViewModel

            mitEntity = db.tblMitarbeiter.Find(ID) 'Datensatz mit diesem Primärschlüssel in tblMitarbeiter nachschlagen

            If mitEntity Is Nothing Then
                Return New HttpNotFoundResult("Mitarbeiter mit der ID " & ID & " wurde nicht gefunden")
            End If
            'Gefundenen Datensatz aus der Datenbank loslösen
            db.Entry(mitEntity).State = EntityState.Detached
            'Umwandeln in ein Objekt der Model-Klasse
            mit = New Mitarbeiter(mitEntity)

            'Vorbereitung des View-Models
            vmMit = New MitarbeiterViewModel
            vmMit.Mitarbeiter = mit

            Return View(vmMit) 'ViewModel mit Mitarbeiter an die View zur Bearbeitung geben
        End Function

        <HttpPost>
        Function Profil(pvmMit As MitarbeiterViewModel) As ActionResult
            Dim mit As Mitarbeiter
            Dim mitEntity As MitarbeiterEntity

            If Not (ModelState.IsValid) Then
                'lstBranche = New List(Of Branche) 'alle Branche aus Datenbank laden
                'For Each brEntity In db.tblBranchen.ToList
                '    branche = New Branche(brEntity)
                '    lstBranche.Add(branche)
                'Next

                'Wenn nicht, dann zurück an die View
                Return View(pvmMit)
            End If

            mit = pvmMit.Mitarbeiter
            mitEntity = mit.gibMitarbeiterEntity
            'Speichern vorbereiten
            db.tblMitarbeiter.Attach(mitEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(mitEntity).State = EntityState.Modified 'als Geändert markieren

            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Bearbeiten war nicht erfolgreich.")
            End Try
            Return View(pvmMit)
        End Function
    End Class
End Namespace