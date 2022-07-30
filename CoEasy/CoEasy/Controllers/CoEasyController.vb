﻿Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"
        Public Shared mEinkaufsliste As Einkaufsliste

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