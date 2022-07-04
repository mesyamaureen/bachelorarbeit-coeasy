Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        'GET/Einkauf
        Function Oeffnen(ID As Integer) As ActionResult
            Return View()
        End Function
    End Class
End Namespace