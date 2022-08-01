@ModelType CoEasy.CoworkerViewModel
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Coworker</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
</head>
<body>
    <div class="container-fluid">
        <div class="row row-cols-2">
            <!-- sideMenu -->
            <div class="col col-lg-2" style="background-color: #D59C1D;">
                <img src="../Bilder/2a6d0db3fe8f4fc9a7081f9879ace954.png" alt="" width="72" height="72">
                <div>
                    <ul>
                        <li>@Html.ActionLink("Startseite", "Einkaeufe", "CoEasy")</li>
                        <li>@Html.ActionLink("Tickets", "AlleTickets", "AlleTickets")</li>
                        <li>@Html.ActionLink("Coworkers", "AlleCoworkers", "AlleCoworkers")</li>
                        <li>@Html.ActionLink("Mitarbeiter", "AlleMitarbeiter", "AlleMitarbeiter")</li>
                        <li>@Html.ActionLink("Mein Profil", "Profil", "MeinProfil")</li>
                        <li>@Html.ActionLink("Ausloggen", "Einloggen", "Anmeldung")</li>
                    </ul>
                </div>
            </div>

            <div class="col-lg-8" style="display: flex; flex-direction:column; justify-content:flex-start; align-content:flex-end; align-items:flex-end; padding-left:0;">
                <!-- topNavBar -->
                <div class="col" style="display:flex;flex-direction:row-reverse; flex-wrap:wrap; background-color:#F8E6BC;">
                    <button>Einkauf</button>
                    <button>WLAN hochladen</button>
                </div>
                <!-- contentComponent -->
                <div class="col">
                    @Using Html.BeginForm
                        @<div class="form-group">
                            @Html.Label("BenutzerID")
                            @Html.TextBoxFor(Function(m) m.Coworker.BenutzerID, New With {.readonly = "readonly", .class = "form-control-plaintext"})
                            @Html.ValidationMessageFor(Function(m) m.Coworker.BenutzerID)
                        </div>

                        @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Coworker.Benutzername, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(m) m.Coworker.Benutzername, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Coworker.Benutzername)
                        </div>

                        @<div class="form-group">
                            @Html.LabelFor(Function(m) m.Coworker.Vorname, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(m) m.Coworker.Vorname, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Coworker.Vorname)
                        </div>

                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Name, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Name, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Name)
                                </div>
                            </div>
                        </div>

                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Email, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Email, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Email)
                                </div>
                            </div>
                        </div>

                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Passwort, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Passwort, New With {.class = "form-control", .type = "password"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Passwort)
                                </div>
                            </div>
                        </div>


                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Adresse, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Adresse, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Adresse)
                                </div>
                            </div>
                        </div>


                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Steuernummer, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Steuernummer, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Steuernummer)
                                </div>
                            </div>
                        </div>


                        @<div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    @Html.LabelFor(Function(m) m.Coworker.Firmenname, New With {.class = "control-label"})
                                    @Html.TextBoxFor(Function(m) m.Coworker.Firmenname, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Coworker.Firmenname)
                                </div>
                            </div>
                        </div>

                        @<div class="mb-lg-5 mt-lg-4">
                                @Html.ActionLink("Abbrechen", "AlleCoworkers", "AlleCoworkers", Nothing, New With {.class = "btn btn-default", .role = "button"})
                        </div>
                    End Using
                </div>
            </div>
        </div>
    </div>


        <!-- Bootstrap -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>


</body>
</html>

