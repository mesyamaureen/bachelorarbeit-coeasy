@ModelType CoEasy.EinkaufspositionViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    <title>WLAN generieren</title>
</head>
<body>
    <div id="dlgWLAN" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h6 class="modal-title">Hallo Coworker,</h6>
                </div>

                <div class="modal-body">
                    <h1>dein WLAN-Passwort für heute:</h1>
                </div>

                <div class="modal-footer">
                    @Using Html.BeginForm
                        @*@<div class="form-group">*@
                            @<h2> @Html.Encode(Model.WlanCode) </h2>
                            @*@Html.ValidationMessageFor(Function(m) m.WlanCode)*@
                        @*</div>*@
                        @*@<div class="form-group">*@
                            @<h4> Sie haben noch <b>"@Html.Encode(Model.Einkaufsposition.AnzahlWLAN)"</b> WLAN-Passwörter</h4>
                            @<p> Dieses WLAN-Passwort können Sie nur einmal aufrufen. Bitte schließen Sie dieses Fenster </p>
                        '</div>
                        @<div>
                            @Html.HiddenFor(Function(m) Model.WlanID)
                            @Html.HiddenFor(Function(m) Model.WlanCode)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufspositionID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.Totalpreis)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.AnzahlWLAN)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.TicketID)
                        </div>
                        @<div>
                            <input type="submit" class="btn btn-secondary" value="Schließen" />
                        </div>
                    End Using

                </div>
            </div>

        </div>

    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>

    <!-- Dialog öffnen, nachdem JavaScript-Dateien geladen wurden -->
    <script type="text/javascript">
        $("#dlgWLAN").modal("show");
    </script>
</body>
</html>
