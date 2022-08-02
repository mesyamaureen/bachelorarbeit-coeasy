Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        ' GET: /Startseite
        Function Einkaeufe() As ActionResult
            Dim eEinkauf As Einkauf
            Dim eEntity As EinkaufEntity
            Dim eListe As Einkaufsliste
            eListe = New Einkaufsliste()
            For Each eEntity In db.tblEinkauf.ToList
                eEinkauf = New Einkauf(eEntity)
                eListe.Einkauf.Add(eEinkauf)
            Next
            Return View(eListe)
        End Function

    End Class
End Namespace