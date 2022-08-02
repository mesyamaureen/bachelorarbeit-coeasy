@ModelType CoEasy.TicketViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Ticket</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" 
          integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
</head>
<body>
    <div id="dlgWLAN" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">

            <!-- Modal content-->
            <div class="modal-content" style="background-color: #D59C1D;">
                <div class="modal-header">
                    <h1>@Html.Encode(Model.Ticket.Bezeichnung) Ticket bearbeiten</h1>
                </div>

                <div class="modal-body">
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
                        @<div class="mb-lg-5 mt-lg-4; d-flex justify-content-end";>
                            @Html.ActionLink("Abbrechen", "AlleTickets", "AlleTickets", Nothing, New With {.class = "btn btn-default", .role = "button"})
                            <input type="submit" class="btn btn-success" value="Speichern" />
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
