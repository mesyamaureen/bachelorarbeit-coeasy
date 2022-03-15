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

    Sub New()
        mintEinkaufID = Nothing
        mdblTotalpreis = Nothing
        mstrStatus = String.Empty
        mdatErstelldatum = Nothing
        mEinkaufsposition = Nothing
    End Sub

    Sub New(pintEinkaufID As Integer, pdblTotalpreis As Double, pstrStatus As String, pdatErstelldatum As Date, pEinkaufsposition As Einkaufsposition)
        mintEinkaufID = pintEinkaufID
        mdblTotalpreis = pdblTotalpreis
        mstrStatus = pstrStatus
        mdatErstelldatum = pdatErstelldatum
        mEinkaufsposition = pEinkaufsposition

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

    'Konstruktor: Entity
    Sub New(peinkEntity As EinkaufEntity)
        mintEinkaufID = peinkEntity.EinkaufIdPk
        mEinkaufsposition.EinkaufspositionID = peinkEntity.EinkaufspositionIdFk
        mdblTotalpreis = peinkEntity.Totalpreis
        mstrStatus = peinkEntity.Status
        mdatErstelldatum = peinkEntity.Erstelldatum
    End Sub

    'gibEntity
    Public Function gibAlsEinkaufEntity() As EinkaufEntity
        Dim einkE As EinkaufEntity
        einkE = New EinkaufEntity

        einkE.EinkaufIdPk = mintEinkaufID
        einkE.EinkaufspositionIdFk = mEinkaufsposition.EinkaufspositionID
        einkE.Erstelldatum = mdatErstelldatum
        einkE.Status = mstrStatus
        einkE.Totalpreis = mdblTotalpreis
        Return einkE
    End Function

End Class
