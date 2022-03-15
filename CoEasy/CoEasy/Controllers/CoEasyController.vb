Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyController
        Inherits Controller

        ' GET: CoEasy
        Function Startseite() As ActionResult
            Return View()
        End Function

        'laden alle Einkäufe
        ' GET: /Startseite

    End Class
End Namespace