Imports System.Web.Mvc

Namespace Controllers
    Public Class AlleTicketsController
        Inherits Controller

        ' GET: AlleTickets
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace