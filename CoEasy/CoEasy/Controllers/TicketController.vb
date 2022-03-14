Imports System.Web.Mvc

Namespace Controllers
    Public Class TicketController
        Inherits Controller

        ' GET: Ticket
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace