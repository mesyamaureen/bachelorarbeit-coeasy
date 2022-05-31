Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Einkauf
    Private mintEinkaufID As Integer
    Private mdblTotalpreis As Double
    Private mstrStatus As String
    Private mdatErstelldatum As Date
    Private mlstEinkauf As List(Of Einkauf)
    Private mEinkaufsposition As Einkaufsposition
    Private mEinkaufspositionID As Integer

    Sub New()
        mintEinkaufID = Nothing
        mdblTotalpreis = Nothing
        mstrStatus = String.Empty
        mdatErstelldatum = Nothing
        'mEinkaufspositionID = Nothing
        'mEinkaufsposition.EinkaufspositionID = Nothing
        mEinkaufsposition = Nothing
    End Sub

    Sub New(pintEinkaufID As Integer, pdblTotalpreis As Double, pstrStatus As String, pdatErstelldatum As Date, pEinkaufsposition As Einkaufsposition) 'pEinkaufspositionID As Integer)
        mintEinkaufID = pintEinkaufID
        mdblTotalpreis = pdblTotalpreis
        mstrStatus = pstrStatus
        mdatErstelldatum = pdatErstelldatum
        'mEinkaufspositionID = pEinkaufspositionID
        'mEinkaufsposition.EinkaufspositionID = pEinkaufspositionID
        mEinkaufsposition = pEinkaufsposition
    End Sub

    'Konstruktor: Entity
    Sub New(peinkEntity As EinkaufEntity)
        mintEinkaufID = peinkEntity.EinkaufIdPk
        'mEinkaufspositionID = peinkEntity.EinkaufspositionIdFk
        mEinkaufsposition = New Einkaufsposition(peinkEntity.EinkaufspositionIdFk, peinkEntity.tblEinkaufsposition.Anzahl, peinkEntity.tblEinkaufsposition.Totalpreis, peinkEntity.tblEinkaufsposition.tblTicket.Bezeichnung, Nothing) '.EinkaufspositionID = peinkEntity.EinkaufspositionIdFk
        mdblTotalpreis = peinkEntity.Totalpreis
        mstrStatus = peinkEntity.Status
        mdatErstelldatum = peinkEntity.Erstelldatum
    End Sub


    Public Property EinkaufID As Integer
        Get
            Return mintEinkaufID
        End Get
        Set(value As Integer)
            mintEinkaufID = value
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
    Public Property Status As String
        Get
            Return mstrStatus
        End Get
        Set(value As String)
            mstrStatus = value
        End Set
    End Property

    Public Property Einkaufsposition As Einkaufsposition
        Get
            Return mEinkaufsposition
        End Get
        Set(value As Einkaufsposition)
            mEinkaufsposition = value
        End Set
    End Property
    'Public Property EinkaufspositionID As Integer
    '    Get
    '        Return mEinkaufspositionID
    '    End Get
    '    Set(value As Integer)
    '        mEinkaufspositionID = value
    '    End Set
    'End Property

    Public Property Erstelldatum As Date
        Get
            Return mdatErstelldatum
        End Get
        Set(value As Date)
            mdatErstelldatum = value
        End Set
    End Property

    Public Property EinkaufListe As List(Of Einkauf)
        Get
            Return mlstEinkauf
        End Get
        Set(value As List(Of Einkauf))
            mlstEinkauf = value
        End Set
    End Property

    'gibEntity
    Public Function gibAlsEinkaufEntity() As EinkaufEntity
        Dim einkE As EinkaufEntity
        einkE = New EinkaufEntity

        einkE.EinkaufIdPk = mintEinkaufID
        'einkE.EinkaufspositionIdFk = mEinkaufspositionID
        einkE.EinkaufspositionIdFk = mEinkaufsposition.EinkaufspositionID
        einkE.Erstelldatum = mdatErstelldatum
        einkE.Status = mstrStatus
        einkE.Totalpreis = mdblTotalpreis
        Return einkE
    End Function

End Class
