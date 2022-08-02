@ModelType CoEasy.EinkaufspositionViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" 
          integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
    <title>WLAN generieren</title>
</head>
<body>
    <div id="dlgWLAN" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content" style="background-color: #D59C1D;">
                <div class="modal-header">
                    <h6 class="modal-title">Hallo Coworker, dein WLAN-Passwort für heute:</h6>
                </div>
                <div class="modal-body">
                    @Using Html.BeginForm
                        @<h1 class="text-center" style="color: white;"> @Html.Encode(Model.WlanCode) </h1>
                        @<div class="mt-5 text-sm-center">
                            <h4> Sie haben noch <b>"@Html.Encode(Model.Einkaufsposition.AnzahlWLAN)"</b> WLAN-Passwörter</h4>
                            <p> Dieses WLAN-Passwort können Sie nur einmal aufrufen. Bitte schließen Sie dieses Fenster </p>
                        </div>
                        @<div>
                            @Html.HiddenFor(Function(m) Model.WlanID)
                            @Html.HiddenFor(Function(m) Model.WlanCode)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufspositionID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.Totalpreis)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.AnzahlWLAN)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.EinkaufID)
                            @Html.HiddenFor(Function(m) Model.Einkaufsposition.TicketID)
                        </div>
                        @<div class="d-flex justify-content-center mt-3">
                            <input type="submit" class="btn btn-outline-secondary" value="Schließen" />
                        </div>
                    End Using
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" 
            crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN"
            crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF"
            crossorigin="anonymous"></script>
    <script type="text/javascript">
        $("#dlgWLAN").modal("show");
    </script>
</body>
</html>
