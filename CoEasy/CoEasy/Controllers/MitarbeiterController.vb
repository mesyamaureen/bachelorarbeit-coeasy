Imports System.Web.Mvc

Namespace Controllers
    Public Class MitarbeiterController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: Mtiarbeiter
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace