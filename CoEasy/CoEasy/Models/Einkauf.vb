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
    Private mCoworker As Coworker
    Private mEinkaufsposition As Einkaufsposition
    Private mEinkaufspositionID As Integer
    Private mintCowID As Integer

    Sub New()
        mintEinkaufID = -1
        mdblTotalpreis = -1
        mstrStatus = String.Empty
        mdatErstelldatum = Nothing
        mintCowID = -1
        'mCoworker = New Coworker()
    End Sub

    Sub New(pintEinkaufID As Integer, pdblTotalpreis As Double, pstrStatus As String, pdatErstelldatum As Date, pintCowId As Integer) ', pCoworker As Coworker)
        mintEinkaufID = pintEinkaufID
        mdblTotalpreis = pdblTotalpreis
        mstrStatus = pstrStatus
        mdatErstelldatum = pdatErstelldatum
        mintCowID = pintCowId
        'mCoworker = pCoworker
    End Sub

    'Konstruktor: Entity
    Sub New(peinkEntity As EinkaufEntity)
        mintEinkaufID = peinkEntity.EinkaufIdPk
        mdblTotalpreis = peinkEntity.Totalpreis
        mstrStatus = peinkEntity.Status
        mdatErstelldatum = peinkEntity.Erstelldatum
        mintCowID = peinkEntity.CoworkerIdFk
        'mCoworker = New Coworker("", "", "", "", "", peinkEntity.CoworkerIdFk, "", "", "")
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

    'Public Property Coworker As Coworker
    '    Get
    '        Return mCoworker
    '    End Get
    '    Set(value As Coworker)
    '        mCoworker = value
    '    End Set
    'End Property

    Public Property CoworkerID As Integer
        Get
            Return mintCowID
        End Get
        Set(value As Integer)
            mintCowID = value
        End Set
    End Property

    'gibEntity
    Public Function gibAlsEinkaufEntity() As EinkaufEntity
        Dim einkE As EinkaufEntity
        einkE = New EinkaufEntity

        einkE.EinkaufIdPk = mintEinkaufID
        einkE.Erstelldatum = mdatErstelldatum
        einkE.Status = mstrStatus
        einkE.Totalpreis = mdblTotalpreis
        einkE.CoworkerIdFk = mintCowID
        'einkE.CoworkerIdFk = mCoworker.BenutzerID
        'If mCoworker IsNot Nothing Then
        '    jobE.JaBrIdFk = mbrBranche.BrancheID
        'End If
        Return einkE
    End Function

End Class
