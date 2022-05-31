Public Class MitarbeiterViewModel
    Private mMitarbeiter As Mitarbeiter

    Public Property Mitarbeiter As Mitarbeiter
        Get
            Return mMitarbeiter
        End Get
        Set(value As Mitarbeiter)
            mMitarbeiter = value
        End Set
    End Property

End Class
