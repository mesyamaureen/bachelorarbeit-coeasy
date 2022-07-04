Public Class EinkaufViewModel
    Private mEinkauf As Einkauf

    Public Property Einkauf As Einkauf
        Get
            Return mEinkauf
        End Get
        Set(value As Einkauf)
            mEinkauf = value
        End Set
    End Property
End Class
