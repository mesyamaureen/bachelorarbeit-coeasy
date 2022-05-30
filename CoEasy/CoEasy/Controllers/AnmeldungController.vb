Imports System.Web.Mvc

Namespace Controllers
    Public Class AnmeldungController
        Inherits Controller
        Private Const CONCURRENCY_EXCEPTION As String = "DBUpdateConcurrencyException"

        Private db As CoEasy_DBEntities = New CoEasy_DBEntities '= New collabEntities

        ' GET: Anmeldung
        ' GET: AlleProfile
        Function Index() As ActionResult
            Return View()
        End Function


        Function Einloggen() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Einloggen(pben As Benutzer) As ActionResult
            If ModelState.IsValid Then
                Using db As CoEasy_DBEntities = New CoEasy_DBEntities
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
                        Return RedirectToAction("Index", "CoEasyCoworker")
                    Else
                        Dim mit As MitarbeiterEntity
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
                            Return RedirectToAction("Startseite", "CoEasy")
                        End If
                    End If
                End Using
            End If
            Return View(pben)
        End Function
    End Class
End Namespace