Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Einkaufsliste
    Private mlstEinkaeufe As List(Of Einkauf)

    Public Sub New()
        mlstEinkaeufe = New List(Of Einkauf)
    End Sub

    Public Sub New(plstEinkauf As List(Of Einkauf))
        mlstEinkaeufe = plstEinkauf
    End Sub

    Public Property Einkauf As List(Of Einkauf)
        Get
            Return mlstEinkaeufe
        End Get
        Set(value As List(Of Einkauf))
            mlstEinkaeufe = value
        End Set
    End Property
End Class
