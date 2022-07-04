Imports System.Web.Mvc

Namespace Controllers
    Public Class CoworkerController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe

    End Class
End Namespace