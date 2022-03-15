Public Class EinkaufspositionListe
    Private mlstEinkaufspositionen As List(Of Einkaufsposition)

    Public Sub New()
        mlstEinkaufspositionen = New List(Of Einkaufsposition)
    End Sub

    Public Sub New(plstEinkaufspositionen As List(Of Einkaufsposition))
        mlstEinkaufspositionen = plstEinkaufspositionen
    End Sub

    Public Property Einkaufspositionen As List(Of Einkaufsposition)
        Get
            Return mlstEinkaufspositionen
        End Get
        Set(value As List(Of Einkaufsposition))
            mlstEinkaufspositionen = value
        End Set
    End Property
End Class
