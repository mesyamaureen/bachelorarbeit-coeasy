@ModelType CoEasy.Einkaufsliste

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>CoEasy</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
</head>
<body>
    <div class="container-fluid">
        <div class="row row-cols-2">
            <!-- sideMenu -->
            <div class="col col-lg-2" style="background-color: #D59C1D;">
                <img src="../Bilder/2a6d0db3fe8f4fc9a7081f9879ace954.png" alt="" width="72" height="72">
                <div>hallo Peter</div>
                <div>
                    <ul>
                        <li>@Html.ActionLink("Startseite", "Einkaeufe", "CoEasy")</li>
                        <li>@Html.ActionLink("Tickets", "Tickets", "AlleTickets")</li>
                        <li>@Html.ActionLink("Coworkers", "Coworkers", "AlleCoworkers")</li>
                        <li>@Html.ActionLink("Mitarbeiter", "Mitarbeiter", "AlleMitarbeiter")</li>
                        <li>@Html.ActionLink("Mein Profil", "Profil", "MeinProfil")</li>
                        <li>@Html.ActionLink("Ausloggen", "Ausloggen", "Anmeldung")</li>
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
                    <div>
                        <h1>Verfügbare Plätze</h1>
                    </div>
                    <div>
                        <table class="table table-striped table-bordered" id="Tabelle">
                            <tr class="header">
                                <th>ID</th>
                                @*<th>Anzahl</th>
                                <th>Artikel</th>*@
                                <th>Status</th>
                                <th>Einkaufsdatum</th>
                                <th>Total</th>
                                <th></th>
                            </tr>


                            @For Each eEink In Model.Einkauf 'hier Model.alle öffentlichen Properties
                                @<tr>
                                    <td>@eEink.EinkaufID</td>
                                    @*<td>@eEink.Einkaufsposition.Anzahl</td>
                                    <td>@eEink.Einkaufsposition.Ticket</td>*@
                                    <td>@eEink.Status</td>
                                    <td>@eEink.Erstelldatum</td>
                                    <td>@eEink.Totalpreis</td>
                                    <td>
                                        @Html.ActionLink("Öffnen", "Oeffnen", "Einkauf", New With {.ID = eEink.EinkaufID}, New With {.class = "btn btn-info", .role = "button"})
                                    </td>
                                </tr>
                            Next
                        </table>
                    </div>
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
