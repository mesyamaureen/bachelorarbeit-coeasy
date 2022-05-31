Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class Mitarbeiter
    Inherits Benutzer
    Sub New(pMitEntity As MitarbeiterEntity)
        BenutzerID = pMitEntity.MitarbeiterIdPk
        Benutzername = pMitEntity.Benutzername
        Vorname = pMitEntity.Vorname
        Name = pMitEntity.Name
        Email = pMitEntity.Email
    End Sub

    Public Function gibMitarbeiterEntity() As MitarbeiterEntity
        Dim mitE = New MitarbeiterEntity

        mitE.Benutzername = Benutzername
        mitE.Email = Email
        mitE.MitarbeiterIdPk = BenutzerID
        mitE.Name = Name
        mitE.Passwort = Passwort
        mitE.Vorname = Vorname
        Return mitE
    End Function
End Class
