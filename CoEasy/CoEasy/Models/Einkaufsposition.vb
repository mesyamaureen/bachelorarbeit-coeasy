Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Einkaufsposition
    Private mintEinkaufspositionID As Integer
    Private mintAnzahl As Integer
    Private mdblTotalpreis As Double
    Private mTicket As Ticket
    Private mWlan As WLAN
    Private mlstEinkaufspositionliste As List(Of Einkaufsposition)
    Private mstrTicket As String
    Private mEinkaufID As Integer
    Private mEinkaeufe As List(Of Einkauf)

    Sub New()
        mintEinkaufspositionID = Nothing
        mintAnzahl = Nothing
        mdblTotalpreis = Nothing
        'mTicket = Nothing
        mstrTicket = String.Empty
        mWlan = Nothing
        mEinkaufID = -1
    End Sub

    Sub New(pintEinkaufspositionID As Integer, pintAnzahl As Integer, pdblTotalpreis As Double, pstrTicket As String, pWlan As WLAN, pEinkaufID As Integer)
        mintEinkaufspositionID = pintEinkaufspositionID
        mintAnzahl = pintAnzahl
        mdblTotalpreis = pdblTotalpreis
        'mTicket = pTicket
        mstrTicket = pstrTicket
        mWlan = pWlan
        mEinkaufID = pEinkaufID
    End Sub

    'Konstruktor Entity
    Sub New(einkaufspositionIdFk As Object, peinkposEntity As EinkaufspositionEntity)
        mintEinkaufspositionID = peinkposEntity.EinkaufspositionIdPk
        mintAnzahl = peinkposEntity.Anzahl
        mdblTotalpreis = peinkposEntity.Totalpreis
        'mTicket.TicketID = peinkposEntity.TicketIdFk
        mstrTicket = peinkposEntity.tblTicket.Bezeichnung
        mWlan.WlanID = peinkposEntity.WlanIdFk
        mEinkaufID = peinkposEntity.EinkaufIdFk
    End Sub

    Public Property EinkaufspositionID As Integer
        Get
            Return mintEinkaufspositionID
        End Get
        Set(value As Integer)
            mintEinkaufspositionID = value
        End Set
    End Property
    Public Property Anzahl As Integer
        Get
            Return mintAnzahl
        End Get
        Set(value As Integer)
            mintAnzahl = value
        End Set
    End Property
    Public Property Totalpreis As Double
        Get
            Return mdblTotalpreis
        End Get
        Set(value As Double)
            mdblTotalpreis = value
        End Set
    End Property

    Public Property TicketBezeichnung As String
        Get
            Return mstrTicket
        End Get
        Set(value As String)
            mstrTicket = value
        End Set
    End Property

    Public Property Ticket As Ticket
        Get
            Return mTicket
        End Get
        Set(value As Ticket)
            mTicket = value
        End Set
    End Property
    Public Property Wlan As WLAN
        Get
            Return mWlan
        End Get
        Set(value As WLAN)
            mWlan = value
        End Set
    End Property
    Public Property EinkaufspositionListe As List(Of Einkaufsposition)
        Get
            Return mlstEinkaufspositionliste
        End Get
        Set(value As List(Of Einkaufsposition))
            mlstEinkaufspositionliste = value
        End Set
    End Property

    Public Property EinkaufID As Integer
        Get
            Return mEinkaufID
        End Get
        Set(value As Integer)
            mEinkaufID = value
        End Set
    End Property

    Public Property Einkaeufe As List(Of Einkauf)
        Get
            Return mEinkaeufe
        End Get
        Set(value As List(Of Einkauf))
            mEinkaeufe = value
        End Set
    End Property

    'gibEntity
    Public Function gibAlsEinkPositionEntity() As EinkaufspositionEntity
        Dim einkPosEntity As EinkaufspositionEntity
        einkPosEntity = New EinkaufspositionEntity

        einkPosEntity.EinkaufspositionIdPk = mintEinkaufspositionID
        einkPosEntity.Anzahl = mintAnzahl
        einkPosEntity.TicketIdFk = mTicket.TicketID
        einkPosEntity.Totalpreis = mdblTotalpreis
        einkPosEntity.WlanIdFk = mWlan.WlanID
        Return einkPosEntity
    End Function
End Class
