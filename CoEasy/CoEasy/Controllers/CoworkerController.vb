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
    End Class
End Namespace