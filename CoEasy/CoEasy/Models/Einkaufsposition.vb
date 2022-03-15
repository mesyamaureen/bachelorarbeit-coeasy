Public Class Einkaufsposition
    Private mintEinkaufspositionID As Integer
    Private mintAnzahl As Integer
    Private mdblTotalpreis As Double

    Sub New()
        mintEinkaufspositionID = Nothing
        mintAnzahl = Nothing
        mdblTotalpreis = Nothing
    End Sub

    Sub New(pintEinkaufspositionID As Integer, pintAnzahl As Integer, pdblTotalpreis As Double)
        mintEinkaufspositionID = pintEinkaufspositionID
        mintAnzahl = pintAnzahl
        mdblTotalpreis = pdblTotalpreis
    End Sub

    Public Property EinkaufspositionID As Integer
        Get
            Return mintEinkaufspositionID
        End Get
        Set(value As Integer)
            mintEinkaufspositionID = value
        End Set
    End Property
    Public Property Anzahl As Integer
        Get
            Return mintAnzahl
        End Get
        Set(value As Integer)
            mintAnzahl = value
        End Set
    End Property
    Public Property Totalpreis As Double
        Get
            Return mdblTotalpreis
        End Get
        Set(value As Double)
            mdblTotalpreis = value
        End Set
    End Property

    'Konstruktor Entity
    'gibEntity
End Class
