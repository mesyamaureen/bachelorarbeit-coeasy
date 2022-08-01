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
    <div>
        <h1>Neuer Einkauf</h1>
    </div>

    <div class="w-75 mx-2">
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

            @<div class="mb-lg-5">
                <!-- Link zum Abbrechen, d.h. zur Navigation zur Index-Seite und Schaltfläche zum Absenden des Formulars -->
                @Html.ActionLink("Abbrechen", "Einkaeufe", "CoEasy", Nothing,
                                                   New With {.class = "btn btn-default", .role = "button"})
                <input type="submit" class="btn btn-success" value="Einkauf Erstellen" />
            </div>
        End Using
    </div>
</body>
</html>
