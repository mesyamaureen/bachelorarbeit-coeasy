Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Einkaufsliste
    Private mlstEinkauf As List(Of Einkauf)

    Public Sub New()
        mlstEinkauf = New List(Of Einkauf)
    End Sub

    Public Sub New(plstEinkauf As List(Of Einkauf))
        mlstEinkauf = plstEinkauf
    End Sub

    Public Property Einkauf As List(Of Einkauf)
        Get
            Return mlstEinkauf
        End Get
        Set(value As List(Of Einkauf))
            mlstEinkauf = value
        End Set
    End Property
End Class
