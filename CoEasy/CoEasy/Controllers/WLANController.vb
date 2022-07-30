Imports System.Web.Mvc

Namespace Controllers
    Public Class WLANController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

    End Class
End Namespace