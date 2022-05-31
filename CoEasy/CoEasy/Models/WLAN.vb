Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Public Class WLAN
    Private mintWlanID As Integer
    Private mstrWlanCode As String

    Sub New()
        mintWlanID = Nothing
        mstrWlanCode = String.Empty
    End Sub

    Sub New(pintWlanID As Integer, pstrWlanCode As String)
        mintWlanID = pintWlanID
        mstrWlanCode = pstrWlanCode
    End Sub

    Public Property WlanID As Integer
        Get
            Return mintWlanID
        End Get
        Set(value As Integer)
            mintWlanID = value
        End Set
    End Property

    Public Property WlanCode As String
        Get
            Return mstrWlanCode
        End Get
        Set(value As String)
            mstrWlanCode = value
        End Set
    End Property
End Class
