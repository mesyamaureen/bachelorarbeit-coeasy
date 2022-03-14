Imports System.Web.Mvc

Namespace Controllers
    Public Class AnmeldungController
        Inherits Controller

        ' GET: Anmeldung
        Function Index() As ActionResult 'Index
            Return View()
        End Function
    End Class
End Namespace