Public Class Coworker
    Inherits Benutzer
    Private mstrAdresse As String
    Private mstrSteuernummer As String
    Private mstrFirmenname As String

    Sub New()
        mstrAdresse = String.Empty
        mstrSteuernummer = String.Empty
        mstrFirmenname = String.Empty
    End Sub

    Sub New(pstrAdresse As String, pstrSteuernummer As String, pstrFirmenname As String)
        mstrAdresse = pstrAdresse
        mstrSteuernummer = pstrSteuernummer
        mstrFirmenname = pstrFirmenname
    End Sub
End Class
