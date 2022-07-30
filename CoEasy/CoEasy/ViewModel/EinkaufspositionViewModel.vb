Public Class EinkaufspositionViewModel
    Private mWlan As WLAN
    Private einkID As Integer
    Private mstrWlan As String

    Property WlanCode As String
        Get
            Return mstrWlan
        End Get
        Set(value As String)
            mstrWlan = value
        End Set
    End Property

    Property EinkaufID As Integer
        Get
            Return einkID
        End Get
        Set(value As Integer)
            einkID = value
        End Set
    End Property

    Property Wlan As WLAN
        Get
            Return mWlan
        End Get
        Set(value As WLAN)
            mWlan = value
        End Set
    End Property

End Class
