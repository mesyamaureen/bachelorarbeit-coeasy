Imports System.Web.Mvc

Namespace Controllers
    Public Class AlleCoworkersController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mCoworkerListe As CoworkerListe

        ' GET: AlleCoworkers
        Function AlleCoworkers() As ActionResult
            Dim listeCoworkers As CoworkerListe = New CoworkerListe()
            Dim einzCoworker As Coworker
            Dim entityCoworker As CoworkerEntity
            For Each entityCoworker In db.tblCoworker.ToList
                einzCoworker = New Coworker(entityCoworker)
                listeCoworkers.Coworker.Add(einzCoworker)
            Next
            Return View(listeCoworkers)
        End Function
    End Class
End Namespace