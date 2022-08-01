Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Einkaufsposition
    Private mintEinkaufspositionID As Integer
    Private mintAnzahlWLAN As Integer
    Private mdblTotalpreis As Double
    Private mTicket As Ticket
    Private mWlan As WLAN
    Private mlstEinkaufspositionliste As List(Of Einkaufsposition)
    Private mEinkauf As Einkauf
    Private mEinkaeufe As List(Of Einkauf)
    Private mintEinkaufId As Integer
    Private mintTicketId As Integer

    Sub New()
        mintEinkaufspositionID = -1
        mintAnzahlWLAN = Nothing
        mdblTotalpreis = Nothing
        'mTicket = Nothing
        'mstrTicket = String.Empty
        'mTicket = New Ticket()
        'mEinkauf = New Einkauf()
        mintEinkaufId = -1
        mintTicketId = -1
    End Sub

    Sub New(pintEinkaufspositionID As Integer, pintAnzahlWLAN As Integer, pdblTotalpreis As Double, pintEinkaufId As Integer, pintTicketId As Integer) 'pTicket As Ticket, pEinkauf As Einkauf) 'pstrTicket As String
        mintEinkaufspositionID = pintEinkaufspositionID
        mintAnzahlWLAN = pintAnzahlWLAN
        mdblTotalpreis = pdblTotalpreis
        'mTicket = pTicket
        mintEinkaufId = pintEinkaufId
        mintTicketId = pintTicketId
        'mEinkauf = pEinkauf
    End Sub

    'Konstruktor Entity
    Sub New(peinkposEntity As EinkaufspositionEntity) 'einkaufspositionIdFk As Object, 
        mintEinkaufspositionID = peinkposEntity.EinkaufspositionIdPk
        mintAnzahlWLAN = peinkposEntity.Anzahl
        mdblTotalpreis = peinkposEntity.Totalpreis
        'mTicket.TicketID = peinkposEntity.TicketIdFk
        'mEinkauf = New Einkauf(peinkposEntity.EinkaufIdFk, Nothing, "", Nothing, Nothing)
        mintEinkaufId = peinkposEntity.EinkaufIdFk
        mintTicketId = peinkposEntity.TicketIdFk
        'mTicket = New Ticket(peinkposEntity.TicketIdFk, "", Nothing)
    End Sub

    Public Property EinkaufspositionID As Integer
        Get
            Return mintEinkaufspositionID
        End Get
        Set(value As Integer)
            mintEinkaufspositionID = value
        End Set
    End Property
    Public Property AnzahlWLAN As Integer
        Get
            Return mintAnzahlWLAN
        End Get
        Set(value As Integer)
            mintAnzahlWLAN = value
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
            Return mintEinkaufId
        End Get
        Set(value As Integer)
            mintEinkaufId = value
        End Set
    End Property

    Public Property TicketID As Integer
        Get
            Return mintTicketId
        End Get
        Set(value As Integer)
            mintTicketId = value
        End Set
    End Property

    'Public Property Einkaeufe As List(Of Einkauf)
    '    Get
    '        Return mEinkaeufe
    '    End Get
    '    Set(value As List(Of Einkauf))
    '        mEinkaeufe = value
    '    End Set
    'End Property

    Public Property Einkauf As Einkauf
        Get
            Return mEinkauf
        End Get
        Set(value As Einkauf)
            mEinkauf = value
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

    'gibEntity
    Public Function gibAlsEinkPositionEntity() As EinkaufspositionEntity
        Dim einkPosEntity As EinkaufspositionEntity
        einkPosEntity = New EinkaufspositionEntity

        einkPosEntity.EinkaufspositionIdPk = mintEinkaufspositionID
        einkPosEntity.Anzahl = mintAnzahlWLAN
        'einkPosEntity.TicketIdFk = mTicket.TicketID
        einkPosEntity.Totalpreis = mdblTotalpreis

        'If mEinkauf IsNot Nothing And mTicket IsNot Nothing Then
        '    einkPosEntity.EinkaufIdFk = mEinkauf.EinkaufID
        '    einkPosEntity.TicketIdFk = mTicket.TicketID
        'End If
        einkPosEntity.EinkaufIdFk = mintEinkaufId
        einkPosEntity.TicketIdFk = mintTicketId
        'einkPosEntity.EinkaufIdFk = mEinkauf.EinkaufID
        'einkPosEntity.TicketIdFk = mTicket.TicketID
        Return einkPosEntity
    End Function
End Class
