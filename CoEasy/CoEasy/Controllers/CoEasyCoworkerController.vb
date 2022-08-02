Imports System.Web.Mvc

Namespace Controllers
    Public Class CoEasyCoworkerController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe
        Function MeineEinkaeufe() As ActionResult
            Dim eEinkauf As Einkauf
            Dim eEntity As EinkaufEntity
            Dim eListe As Einkaufsliste
            eListe = New Einkaufsliste()
            For Each eEntity In db.tblEinkauf.ToList
                If eEntity.CoworkerIdFk.ToString() = System.Web.HttpContext.Current.Session("BenutzerID") Then
                    eEinkauf = New Einkauf(eEntity)
                    eListe.Einkauf.Add(eEinkauf)
                End If
            Next
            Return View(eListe)
        End Function
    End Class
End Namespace