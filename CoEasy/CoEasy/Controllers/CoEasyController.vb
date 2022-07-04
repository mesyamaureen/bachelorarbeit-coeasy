Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyController
        Inherits Controller
        Private db As CoEasy_DB = New CoEasy_DB
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

        '' GET: CoEasy
        'Function Startseite() As ActionResult
        '    Return View()
        'End Function

        'laden alle Einkäufe
        ' GET: /Startseite
        Function Einkaeufe() As ActionResult
            ' Deklaration
            Dim eEinkauf As Einkauf
            Dim eEntity As EinkaufEntity
            Dim eListe As Einkaufsliste

            ' Leere Liste initialisieren
            eListe = New Einkaufsliste()

            ' Alle Jobanzeigen aus der Datenbank holen
            For Each eEntity In db.tblEinkauf.ToList
                ' Objekt der Entity-Klasse in Objekt der Model-Klasse umwandeln
                eEinkauf = New Einkauf(eEntity)

                ' Objekt der Model-Klasse zur Liste hinzufügen
                eListe.Einkauf.Add(eEinkauf)
            Next

            ' Gesamte list anzeigen
            Return View(eListe)
        End Function

    End Class
End Namespace