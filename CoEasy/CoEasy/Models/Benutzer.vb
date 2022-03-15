Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Benutzer
    'Attribute der Benutzer
    Private mstrBenutzername As String
    Private mstrPasswort As String
    Private mstrVorname As String
    Private mstrName As String
    Private mstrEmail As String
    Private mintBenutzerID As Integer

    'Parameterloser Konstruktor
    Sub New()
        mstrBenutzername = String.Empty
        mstrPasswort = String.Empty
        mstrVorname = String.Empty
        mstrName = String.Empty
        mstrEmail = String.Empty
        mintBenutzerID = Nothing
    End Sub
    'Konstruktor mit Parameter
    Sub New(pstrBenutzername As String, pstrPasswort As String, pstrVorname As String, pstrName As String, pstrEmail As String, pintBenutzerID As Integer)
        mstrBenutzername = pstrBenutzername
        mstrPasswort = pstrPasswort
        mstrVorname = pstrVorname
        mstrName = pstrName
        mstrEmail = pstrEmail
        mintBenutzerID = pintBenutzerID
    End Sub

    'Properties
    Public Property Benutzername As String
        Get
            Return mstrBenutzername
        End Get
        Set(value As String)
            mstrBenutzername = value
        End Set
    End Property
    Public Property Vorname As String
        Get
            Return mstrVorname
        End Get
        Set(value As String)
            mstrVorname = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return mstrName
        End Get
        Set(value As String)
            mstrName = value
        End Set
    End Property
    Public Property Passwort As String
        Get
            Return mstrPasswort
        End Get
        Set(value As String)
            mstrPasswort = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return mstrEmail
        End Get
        Set(value As String)
            mstrEmail = value
        End Set
    End Property
    Public Property BenutzerID As Integer
        Get
            Return mintBenutzerID
        End Get
        Set(value As Integer)
            mintBenutzerID = value
        End Set
    End Property

    'gibEntity

End Class
