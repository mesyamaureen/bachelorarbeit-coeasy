Public Class Einkauf
    Private mintEinkaufID As Integer
    Private mdblTotalpreis As Double
    Private mstrStatus As String
    Private mdatErstelldatum As Date

    Sub New()
        mintEinkaufID = Nothing
        mdblTotalpreis = Nothing
        mstrStatus = String.Empty
        mdatErstelldatum = Nothing
    End Sub

    Sub New(pintEinkaufID As Integer, pdblTotalpreis As Double, pstrStatus As String, pdatErstelldatum As Date)
        mintEinkaufID = pintEinkaufID
        mdblTotalpreis = pdblTotalpreis
        mstrStatus = pstrStatus
        pdatErstelldatum = mdatErstelldatum
    End Sub

    Public Property EinkaufID As Integer
        Get
            Return mintEinkaufID
        End Get
        Set(value As Integer)
            mintEinkaufID = value
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
    Public Property Status As String
        Get
            Return mstrStatus
        End Get
        Set(value As String)
            mstrStatus = value
        End Set
    End Property
    Public Property Erstelldatum As Date
        Get
            Return mdatErstelldatum
        End Get
        Set(value As Date)
            mdatErstelldatum = value
        End Set
    End Property

    'Konstruktor: Entity
    'gibEntity

End Class
