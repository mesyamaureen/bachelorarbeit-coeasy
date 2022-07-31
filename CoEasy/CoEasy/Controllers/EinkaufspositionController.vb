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

            Dim angemeldeterCoworker = Web.HttpContext.Current.Session("BenutzerID")
            'Datenbank Zugriff über EF
            'Dim queryEinkaufID = (From e In db.tblEinkauf
            'Where e.CoworkerIdFk = angemeldeterCoworker
            'Select Case e.EinkaufIdPk).FirstOrDefault 'möglicher Nachteil: wenn Einkauf ausgenutzt ist, wird es trotzdem angenommen
            Dim lstEinkauf As List(Of Einkauf) = New List(Of Einkauf)
            For Each einkEntity In db.tblEinkauf.ToList
                If einkEntity.CoworkerIdFk = angemeldeterCoworker Then
                    eink = New Einkauf(einkEntity)
                    lstEinkauf.Add(eink)
                End If
            Next
            Dim einkId As Integer = lstEinkauf.ElementAt(0).EinkaufID

            'Anzahl in Einkaufsposition?
            'find out ID Einkaufsposition
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
            'Dim anzahlWLAN As Integer = lstEinkaufsposition.ElementAt(0).AnzahlWLAN 'zugriff to Attribute AnzahlWLAN
            ''wenn > 0, nimm ein Datensatz WLAN von DB
            If lstEinkaufsposition.ElementAt(0).AnzahlWLAN > 0 Then
                wlanEntity = db.tblWLAN.ToList.ElementAt(0)
            End If

            If wlanEntity IsNot Nothing Then
                wlanCode = wlanEntity.WlanCode
                wlanId = wlanEntity.WlanIdPk
            End If

            ''wenn = 0, Meldungbox


            vmEinkPos = New EinkaufspositionViewModel()
            vmEinkPos.WlanCode = wlanCode
            vmEinkPos.WlanID = wlanId
            vmEinkPos.Einkaufsposition = lstEinkaufsposition.ElementAt(0)
            vmEinkPos.Einkaufsposition.AnzahlWLAN = lstEinkaufsposition.ElementAt(0).AnzahlWLAN - 1
            db.Entry(wlanEntity).State = EntityState.Detached
            db.Entry(einkposChosenEntity).State = EntityState.Detached
            'vmEinkPos.Wlan.WlanCode = wlanCode
            'vmEinkPos.EinkaufID = queryEinkaufID.FirstOrDefault.EinkaufID

            'vmJob = New JobanzeigeViewModel
            'vmJob.Jobanzeige = job
            'vmJob.ListeBranche = lstBranche
            Return View(vmEinkPos) 'Neue Jobanzeige und Liste aller 
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
            'Dim intAnzahlWlan As Integer
            pEinkpos = pvmEinkpos.Einkaufsposition
            einkposEntity = pEinkpos.gibAlsEinkPositionEntity()
            'intAnzahlWlan = (einkposEntity.Anzahl) - 1
            'einkposEntity.Anzahl = intAnzahlWlan

            'speichern vorbereiten
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