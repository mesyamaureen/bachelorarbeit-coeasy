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
            Dim einkposEntity As EinkaufspositionEntity
            Dim einkEntity As EinkaufEntity
            Dim eink As Einkauf = New Einkauf()
            Dim wlan As WLAN
            Dim wlanEntity As WLANEntity = New WLANEntity()
            Dim ticket As Ticket
            Dim wlanCode As String = ""

            Dim vmEinkPos As EinkaufspositionViewModel

            ''prüfen Attribute AnzahlWLAN Attribut in Einkaufsposition
            'wer ist der angemeldete Benutzer?
            Dim angemeldeterCoworker = Web.HttpContext.Current.Session("BenutzerID")
            'welcher Einkauf dari coworker mana? 
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
            Next 'ergebnis = list Einkauf
            Dim einkId As Integer = lstEinkauf.ElementAt(0).EinkaufID

            'Anzahl in Einkaufsposition?
            'find out ID Einkaufsposition
            Dim lstEinkaufsposition As List(Of Einkaufsposition) = New List(Of Einkaufsposition)
            For Each einkposEntity In db.tblEinkaufsposition.ToList
                If einkposEntity.EinkaufIdFk = einkId Then
                    einkPos = New Einkaufsposition(einkposEntity)
                    lstEinkaufsposition.Add(einkPos)
                End If
            Next 'ergebnis = listeinkaufsposition
            Dim anzahlWLAN As Integer = lstEinkaufsposition.ElementAt(0).AnzahlWLAN 'zugriff to Attribute AnzahlWLAN
            ''wenn > 0, nimm ein Datensatz WLAN von DB
            If anzahlWLAN > 0 Then
                wlanEntity = db.tblWLAN.ToList.ElementAt(0)
            End If

            If wlanEntity IsNot Nothing Then
                wlanCode = wlanEntity.WlanCode
            End If
            ''speichern als ein Variabel für View
            ''löschen Datensatz in DB
            ''gib das Variabel an View weiter

            ''wenn = 0, Meldungbox


            vmEinkPos = New EinkaufspositionViewModel()
            vmEinkPos.WlanCode = wlanCode
            db.Entry(wlanEntity).State = EntityState.Detached
            'vmEinkPos.Wlan.WlanCode = wlanCode
            'vmEinkPos.EinkaufID = queryEinkaufID.FirstOrDefault.EinkaufID

            'vmJob = New JobanzeigeViewModel
            'vmJob.Jobanzeige = job
            'vmJob.ListeBranche = lstBranche
            Return View(vmEinkPos) 'Neue Jobanzeige und Liste aller 
        End Function

        <HttpPost>
        Function NeuWLAN(pWlan As WLAN) As ActionResult
            Dim wlanEntity As WLANEntity

            ' Jobanzeige in JobanzeigeEntity umwandeln
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

            Return RedirectToAction("MeineEinkaeufe", "CoEasyCoworker")
        End Function
    End Class
End Namespace