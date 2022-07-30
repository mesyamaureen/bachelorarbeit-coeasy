Imports System.Web.Mvc

Namespace Controllers
    Public Class CoworkerController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe

    End Class
End Namespace