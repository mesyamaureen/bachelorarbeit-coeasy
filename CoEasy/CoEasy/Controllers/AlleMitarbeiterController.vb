Imports System.Web.Mvc

Namespace Controllers
    Public Class AlleMitarbeiterController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: AlleMitarbeiter
        Function AlleMitarbeiter() As ActionResult
            Dim listeMitarbeiter As MitarbeiterListe = New MitarbeiterListe()
            Dim einzMitarbeiter As Mitarbeiter
            Dim entityMitarbeiter As MitarbeiterEntity
            For Each entityMitarbeiter In db.tblMitarbeiter.ToList
                einzMitarbeiter = New Mitarbeiter(entityMitarbeiter)
                listeMitarbeiter.Mitarbeiter.Add(einzMitarbeiter)
            Next
            Return View(listeMitarbeiter)
        End Function
    End Class
End Namespace