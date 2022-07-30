Public Class EinkaufspositionViewModel
    Private einkID As Integer
    Private mstrWlan As String
    Private mintWlanID As Integer
    'Private mintAnzahlWlan As Integer
    Private mintEinkaufspositionId As Integer
    Private mEinkaufsposition As Einkaufsposition

    Property Einkaufsposition As Einkaufsposition
        Get
            Return mEinkaufsposition
        End Get
        Set(value As Einkaufsposition)
            mEinkaufsposition = value
        End Set
    End Property

    Property EinkaufspositionId As Integer
        Get
            Return mintEinkaufspositionId
        End Get
        Set(value As Integer)
            mintEinkaufspositionId = value
        End Set
    End Property

    'Property AnzahlWlan As Integer
    '    Get
    '        Return mintAnzahlWlan
    '    End Get
    '    Set(value As Integer)
    '        mintAnzahlWlan = value
    '    End Set
    'End Property

    Property WlanID As Integer
        Get
            Return mintWlanID
        End Get
        Set(value As Integer)
            mintWlanID = value
        End Set
    End Property

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

End Class
