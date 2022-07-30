Imports System.Web.Mvc
Imports CoEasy.Benutzer

Namespace Controllers
    Public Class AnmeldungController
        Inherits Controller

        ' GET: Anmeldung
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpGet>
        Function Einloggen() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Einloggen(pben As Benutzer) As ActionResult
            If ModelState.IsValid Then
                Using db As CoEasy_Database = New CoEasy_Database
                    'Dim infl As InfluencerEntity
                    Dim benCoworker As CoworkerEntity
                    Try
                        For Each cow In db.tblCoworker.ToList
                            If (cow.Benutzername.Equals(pben.Benutzername) And cow.Passwort.Equals(pben.Passwort)) Then
                                benCoworker = cow
                            End If
                        Next
                    Catch ex As Exception
                        benCoworker = Nothing
                    End Try

                    '"State-Änderungen" in Session gespeichert wird
                    If benCoworker IsNot Nothing Then
                        System.Web.HttpContext.Current.Session("BenutzerID") = benCoworker.CoworkerIdPk.ToString()
                        System.Web.HttpContext.Current.Session("Benutzername") = benCoworker.Benutzername.ToString()
                        System.Web.HttpContext.Current.Session("Benutzertyp") = "Coworker"
                        Return RedirectToAction("MeineEinkaeufe", "CoEasyCoworker")
                    Else
                        'Dim mit As MitarbeiterEntity
                        Dim benMit As MitarbeiterEntity

                        For Each mit In db.tblMitarbeiter.ToList
                            If (mit.Benutzername.Equals(pben.Benutzername) And mit.Passwort.Equals(pben.Passwort)) Then
                                benMit = mit
                            End If
                        Next

                        If benMit IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("BenutzerID") = benMit.MitarbeiterIdPk.ToString()
                            System.Web.HttpContext.Current.Session("Benutzername") = benMit.Benutzername.ToString()
                            System.Web.HttpContext.Current.Session("Benutzertyp") = "Mitarbeiter"
                            Return RedirectToAction("Einkaeufe", "CoEasy")
                        End If
                    End If
                End Using
            End If
            Return View(pben)
        End Function
    End Class
End Namespace