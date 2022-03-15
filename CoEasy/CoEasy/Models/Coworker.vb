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

    Public Property Adresse As String
        Get
            Return mstrAdresse
        End Get
        Set(value As String)
            mstrAdresse = value
        End Set
    End Property

    Public Property Steuernummer As String
        Get
            Return mstrSteuernummer
        End Get
        Set(value As String)
            mstrSteuernummer = value
        End Set
    End Property

    Public Property Firmenname As String
        Get
            Return mstrFirmenname
        End Get
        Set(value As String)
            mstrFirmenname = value
        End Set
    End Property

    Sub New(pCowEntity As CoworkerEntity)
        BenutzerID = pCowEntity.CoworkerIdPk
        Benutzername = pCowEntity.Benutzername
        Vorname = pCowEntity.Vorname
        Name = pCowEntity.Name
        Email = pCowEntity.Email
        Adresse = pCowEntity.Adresse
        Steuernummer = pCowEntity.Steuernummer
        Firmenname = pCowEntity.Firmenname
    End Sub

    Public Function gibAlsCowEntity() As CoworkerEntity
        Dim cowE As CoworkerEntity
        cowE = New CoworkerEntity
        cowE.Adresse = Adresse
        cowE.Benutzername = Benutzername
        cowE.CoworkerIdPk = BenutzerID
        cowE.Email = Email
        cowE.Firmenname = Firmenname
        cowE.Name = Name
        cowE.Passwort = Passwort
        cowE.Steuernummer = Steuernummer
        cowE.Vorname = Vorname
        Return cowE
    End Function

End Class
