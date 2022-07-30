Public Class WLANViewModel
    Private mWlan As WLAN

    Property Wlan As WLAN
        Get
            Return mWlan
        End Get
        Set(value As WLAN)
            mWlan = value
        End Set
    End Property

End Class
