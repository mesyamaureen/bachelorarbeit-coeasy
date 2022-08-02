@ModelType CoEasy.EinkaufViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Neu</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
</head>
<body>
    <div id="dlgWLAN" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">

            <!-- Modal content-->
            <div class="modal-content" style="background-color: #D59C1D;">
                <div class="modal-header">
                    <h1>Neuen Einkauf erstellen</h1>
                </div>

                <div class="modal-body">
                    @Using Html.BeginForm()
                        @<div class="form-group">
                            <!-- Versteckte Felder, die dem Benutzer nicht angezeigt werden müssen -->
                            @Html.HiddenFor(Function(m) Model.Einkauf.EinkaufID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.Totalpreis)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufspositionID)
                        </div>

                        @<div class="form-group">
                            <!-- Status des Einkaufs -->
                            @Html.LabelFor(Function(m) Model.Einkauf.Status, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(m) Model.Einkauf.Status, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) Model.Einkauf.Status)
                        </div>
                        @<div class="form-group">
                            <!-- Erstelldatum des Einkaufs -->
                            @Html.LabelFor(Function(m) Model.Einkauf.Erstelldatum, New With {.class = "control-label"})
                            @Html.TextBoxFor(Function(m) Model.Einkauf.Erstelldatum, "{0:dd.MM.yyyy}", New With {.class = "form-control datepicker"})
                            @Html.ValidationMessageFor(Function(m) Model.Einkauf.Erstelldatum)
                        </div>

                        @<div class="form-group">
                            <!-- Tickets -->
                            @Html.Label("Ticket Typ")
                            @Html.DropDownListFor(Function(m) Model.Einkaufsposition.TicketID,
                                                        New SelectList(Model.ListeTickets, "TicketID", "Bezeichnung"),
                                                        New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) Model.Einkaufsposition.TicketID)
                        </div>

                        @<div class="form-group">
                            <!-- WLAN Anzahl -->
                            @Html.Label("Anzahl WLAN")
                            @Html.TextBoxFor(Function(m) Model.Einkaufsposition.AnzahlWLAN, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) Model.Einkaufsposition.AnzahlWLAN)
                        </div>

                        @<div class="form-group">
                            <!-- Coworker -->
                            @Html.LabelFor(Function(m) Model.Einkauf.Coworker, New With {.class = "control-label"})
                            @Html.DropDownListFor(Function(m) Model.Einkauf.CoworkerID,
                                                        New SelectList(Model.ListeCoworkers, "BenutzerID", "Name"),
                                                        New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) Model.ListeTickets)
                        </div>

                        @<div class="mb-lg-5 d-flex justify-content-end">
                            <!-- Link zum Abbrechen, d.h. zur Navigation zur Index-Seite und Schaltfläche zum Absenden des Formulars -->
                            @Html.ActionLink("Abbrechen", "Einkaeufe", "CoEasy", Nothing,
                                                 New With {.class = "btn btn-default", .role = "button"})
                            <input type="submit" class="btn btn-success" value="Einkauf Erstellen" />
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
    <!-- Dialog öffnen, nachdem JavaScript-Dateien geladen wurden -->
    <script type="text/javascript">
        $("#dlgWLAN").modal("show");
    </script>
</body>
</html>
