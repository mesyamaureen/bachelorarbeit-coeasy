Imports System.Web.Mvc
Imports System.Data.Entity

Namespace Controllers
    Public Class CoworkerController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: /MeineEinkaeufe
        Function Oeffnen(ID As Integer) As ActionResult
            Dim cow As Coworker
            Dim cowEntity As CoworkerEntity
            Dim vmCow As CoworkerViewModel
            cowEntity = db.tblCoworker.Find(ID)

            If cowEntity Is Nothing Then
                Return New HttpNotFoundResult("Coworker mit der ID " & ID & " wurde nicht gefunden")
            End If
            db.Entry(cowEntity).State = EntityState.Detached
            cow = New Coworker(cowEntity)
            vmCow = New CoworkerViewModel
            vmCow.Coworker = cow
            Return View(vmCow)
        End Function

        'GET: /Jobanzeige/Hinzufuegen
        Function Neu() As ActionResult
            Dim cow As Coworker
            Dim vmCow As CoworkerViewModel
            cow = New Coworker
            vmCow = New CoworkerViewModel
            vmCow.Coworker = cow
            Return View(vmCow)
        End Function

        'POST: /Jobanzeige/Hinzufuegen
        <HttpPost>
        Function Neu(pvmCow As CoworkerViewModel) As ActionResult
            Dim cow As Coworker
            Dim cowEntity As CoworkerEntity
            cow = pvmCow.Coworker
            cowEntity = cow.gibAlsCowEntity
            db.tblCoworker.Attach(cowEntity)
            db.Entry(cowEntity).State = EntityState.Added
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Hinzufügen war nicht erfolgreich.")
            End Try
            Return RedirectToAction("AlleCoworkers", "AlleCoworkers")
        End Function
    End Class
End Namespace