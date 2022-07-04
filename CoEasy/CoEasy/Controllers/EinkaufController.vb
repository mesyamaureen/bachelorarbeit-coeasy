Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        'GET: /Einkaeufe/OeffnenEinkauf
        <HttpGet>
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

        'POST: /Einkaeufe/

    End Class
End Namespace