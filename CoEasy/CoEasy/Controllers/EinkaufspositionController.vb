Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufspositionController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: Einkaufsposition
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace