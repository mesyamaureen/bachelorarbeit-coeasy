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
            Dim eink As Einkauf = New Einkauf
            Dim einkEntity As EinkaufEntity

            ''prüfen Attribute AnzahlWLAN Attribut in Einkaufsposition
            'wer ist der angemeldete Benutzer?
            'eink.Coworker.BenutzerID = Web.HttpContext.Current.Session("BenutzerID")
            'welcher Einkauf?
            'Anzahl in Einkaufsposition?

            ''wenn > 0, nimm ein Datensatz WLAN von DB
            ''speichern als ein Variabel für View
            ''löschen Datensatz in DB
            ''gib das Variabel an View weiter

            ''wenn = 0, Meldungbox



            Return View()
        End Function
    End Class
End Namespace