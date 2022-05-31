Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Public Class Ticket
    Private mintTicketID As Integer
    Private mstrBezeichnung As String
    Private mdblPreis As Double

    Sub New()
        mintTicketID = Nothing
        mstrBezeichnung = String.Empty
        mdblPreis = Nothing
    End Sub

    Sub New(pintTicketID As Integer, pstrBezeichnung As String, pdblPreis As Double)
        mintTicketID = pintTicketID
        mstrBezeichnung = pstrBezeichnung
        mdblPreis = pdblPreis
    End Sub

    Public Property TicketID As Integer
        Get
            Return mintTicketID
        End Get
        Set(value As Integer)
            mintTicketID = value
        End Set
    End Property

    Public Property Bezeichnung As String
        Get
            Return mstrBezeichnung
        End Get
        Set(value As String)
            mstrBezeichnung = value
        End Set
    End Property

    Public Property Preis As Double
        Get
            Return mdblPreis
        End Get
        Set(value As Double)
            mdblPreis = value
        End Set
    End Property

    'Konstruktor Entity
    'gibEntity
End Class
