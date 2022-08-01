Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyCoworkerController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe
        Function MeineEinkaeufe() As ActionResult
            ' Deklaration
            Dim eEinkauf As Einkauf
            Dim eEntity As EinkaufEntity
            Dim eListe As Einkaufsliste

            ' Leere Liste initialisieren
            eListe = New Einkaufsliste()

            ' Alle Jobanzeigen aus der Datenbank holen
            For Each eEntity In db.tblEinkauf.ToList
                'Überprüfen, ob der Entity zum angemeldeten Coworker gehört
                If eEntity.CoworkerIdFk.ToString() = System.Web.HttpContext.Current.Session("BenutzerID") Then
                    eEinkauf = New Einkauf(eEntity)
                    ' Objekt der Model-Klasse zur Liste hinzufügen
                    eListe.Einkauf.Add(eEinkauf)
                End If
            Next

            ' Gesamte list anzeigen
            Return View(eListe)
        End Function
    End Class
End Namespace