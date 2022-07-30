Imports System.Web.Mvc

Namespace Controllers
    Public Class WLANController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: Neu
        Function Neu() As ActionResult
            Dim wlan As WLAN
            Dim wlanEntity As WLANEntity
            Dim eink As Einkauf
            Dim einkEntity As EinkaufEntity

            'prüfen Attribute Anzahl ticket

            Return View()
        End Function
    End Class
End Namespace