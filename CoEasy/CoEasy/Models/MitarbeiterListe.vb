Public Class MitarbeiterListe
    Private mlstMitarbeiter As List(Of Mitarbeiter)

    Public Sub New()
        mlstMitarbeiter = New List(Of Mitarbeiter)
    End Sub

    Public Sub New(plstMitarbeiter As List(Of Mitarbeiter))
        mlstMitarbeiter = plstMitarbeiter
    End Sub

    Public Property Mitarbeiter As List(Of Mitarbeiter)
        Get
            Return mlstMitarbeiter
        End Get
        Set(value As List(Of Mitarbeiter))
            mlstMitarbeiter = value
        End Set
    End Property
End Class
