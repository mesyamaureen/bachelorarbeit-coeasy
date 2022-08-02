Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class EinkaufspositionController
        Inherits Controller
        Private db As CoEasy_Database = New CoEasy_Database
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        ' GET: NeuWLAN
        Function NeuWLAN() As ActionResult
            Dim einkPos As Einkaufsposition
            Dim einkposEntity As EinkaufspositionEntity = New EinkaufspositionEntity()
            Dim einkposChosenEntity As EinkaufspositionEntity = New EinkaufspositionEntity()
            Dim einkEntity As EinkaufEntity
            Dim eink As Einkauf = New Einkauf()
            Dim wlanEntity As WLANEntity = New WLANEntity()
            Dim wlanCode As String = ""
            Dim wlanId As Integer = Nothing
            Dim vmEinkPos As EinkaufspositionViewModel
            'ermitteln zu welchem Coworker
            Dim angemeldeterCoworker = Web.HttpContext.Current.Session("BenutzerID")
            'ermitteln zu welchem Einkauf
            Dim lstEinkauf As List(Of Einkauf) = New List(Of Einkauf)
            For Each einkEntity In db.tblEinkauf.ToList
                If einkEntity.CoworkerIdFk = angemeldeterCoworker Then
                    eink = New Einkauf(einkEntity)
                    lstEinkauf.Add(eink)
                End If
            Next
            Dim einkId As Integer = lstEinkauf.ElementAt(0).EinkaufID
            'ermitteln ID Einkaufsposition
            Dim lstEinkaufsposition As List(Of Einkaufsposition) = New List(Of Einkaufsposition)
            For Each einkposEntity In db.tblEinkaufsposition.ToList
                If einkposEntity.EinkaufIdFk = einkId Then
                    einkPos = New Einkaufsposition(einkposEntity)
                    If lstEinkaufsposition.Count = 0 Then
                        einkposChosenEntity = einkposEntity
                    End If
                    lstEinkaufsposition.Add(einkPos)
                End If
            Next
            If lstEinkaufsposition.ElementAt(0).AnzahlWLAN > 0 Then
                wlanEntity = db.tblWLAN.ToList.ElementAt(0)
            End If

            If wlanEntity IsNot Nothing Then
                wlanCode = wlanEntity.WlanCode
                wlanId = wlanEntity.WlanIdPk
            End If

            vmEinkPos = New EinkaufspositionViewModel()
            vmEinkPos.WlanCode = wlanCode
            vmEinkPos.WlanID = wlanId
            vmEinkPos.Einkaufsposition = lstEinkaufsposition.ElementAt(0)
            'anzahl der WLAN vermindert
            vmEinkPos.Einkaufsposition.AnzahlWLAN = lstEinkaufsposition.ElementAt(0).AnzahlWLAN - 1
            db.Entry(wlanEntity).State = EntityState.Detached
            db.Entry(einkposChosenEntity).State = EntityState.Detached
            Return View(vmEinkPos)
        End Function

        <HttpPost>
        Function NeuWLAN(pWlan As WLAN, pvmEinkpos As EinkaufspositionViewModel) As ActionResult
            Dim wlanEntity As WLANEntity
            Dim pEinkpos As Einkaufsposition
            Dim einkposEntity As EinkaufspositionEntity
            ' Wlan in WlanEntity umwandeln
            wlanEntity = pWlan.gibAlsWlanEntity()
            'Speichern vorbereiten
            db.tblWLAN.Attach(wlanEntity)
            db.Entry(wlanEntity).State = EntityState.Deleted 'als Gelöscht markieren
            'Vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                ModelState.AddModelError(String.Empty, "Löschen war nicht erfolgreich.")
            End Try

            'Einkaufspos in EinkaufsposEntity umwandeln
            pEinkpos = pvmEinkpos.Einkaufsposition
            einkposEntity = pEinkpos.gibAlsEinkPositionEntity()
            db.tblEinkaufsposition.Attach(einkposEntity) 'Objekt der Entity-Klasse wieder mit Datenbank bekannt machen
            db.Entry(einkposEntity).State = EntityState.Modified 'als geändert markieren
            'vorsichtig Änderungen speichern
            Try
                db.SaveChanges()
            Catch ex As Exception
                'Im Fehlerfall wird der Fehler im ViewModel vermerkt
                ModelState.AddModelError(String.Empty, "Bearbeiten war nicht erfolgreich.")
            End Try

            Return RedirectToAction("MeineEinkaeufe", "CoEasyCoworker")
        End Function
    End Class
End Namespace