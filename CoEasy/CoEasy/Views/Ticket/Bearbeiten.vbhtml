@ModelType CoEasy.TicketViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Ticket</title>
</head>
<body>
    <div>
        test ticket
    </div>

    <div class="col">
        @Using Html.BeginForm
            @<div class="form-group">
                @Html.Label("Ticket ID")
                @Html.TextBoxFor(Function(m) m.Ticket.TicketID, New With {.readonly = "readonly", .class = "form-control-plaintext"})
                @Html.ValidationMessageFor(Function(m) m.Ticket.TicketID)
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(m) m.Ticket.Bezeichnung, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(m) m.Ticket.Bezeichnung, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Ticket.Bezeichnung)
            </div>

            @<div class="form-group">
                @Html.LabelFor(Function(m) m.Ticket.Preis, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(m) m.Ticket.Preis, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Ticket.Preis)
            </div>

            @<div class="mb-lg-5 mt-lg-4">
                @*@Html.ActionLink("Abbrechen", "MeinProfilInfluencer", "InfluencerEinzeln", New With {.class = "btn btn-default", .role = "button"})*@
                <input type="submit" class="btn btn-primary" value="Speichern" />
            </div>
        End Using
    </div>

</body>
</html>
