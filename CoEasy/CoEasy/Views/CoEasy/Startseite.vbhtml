@ModelType CoEasy.Einkaufsliste

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
    <title>Anmeldung</title>
</head>

<body>
    <div class="row">
        <div class="col-3" style="background-color:#D59C1E;">
            <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                <a title="zur Startseite" href="Startseite.html">
                    <img src="~/Bilder/CoEasy-Logo.jpg" width="100" alt="CoEasy-Logo" />
                </a>
                <div class="nav-link">
                    @Html.ActionLink("Startseite", "Startseite", "CoEasy")
                </div>
                <div class="nav-link">
                    @Html.ActionLink("Tickets", "Index")
                </div>
                <div class="nav-link">
                    @Html.ActionLink("Coworkers", "Index")
                </div>
                <div class="nav-link">
                    @Html.ActionLink("Mitarbeiter", "Index")
                </div>
                <div class="nav-link">
                    @Html.ActionLink("Mein Profil", "Index")
                </div>
                <div class="nav-link">
                    @Html.ActionLink("Ausloggen", "Index")
                </div>

                @*<div class="nav-link active" id="v-pills-home-tab" data-toggle="pill" role="tab" aria-controls="v-pills-home" aria-selected="true">
                        @Html.ActionLink("Startseite", "Index")
                    </div>*@
                @*<a class="nav-link active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true">Home</a>*@
                @*<a class="nav-link" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false">Profile</a>
                    <a class="nav-link" id="v-pills-messages-tab" data-toggle="pill" href="#v-pills-messages" role="tab" aria-controls="v-pills-messages" aria-selected="false">Messages</a>
                    <a class="nav-link" id="v-pills-settings-tab" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false">Settings</a>*@
            </div>
        </div>
        <div>
            <div id="header" class="nav justify-content-end" style="background-color: #F8E6BC; width: inherit;">
                <nav class="navbar">
                    <form class="form-inline">
                        <button class="btn btn-outline-success" type="button">
                            @Html.ActionLink("Einkauf", "Index", "Collab")
                        </button>
                        <button class="btn btn-outline-success" type="button">
                            @Html.ActionLink("WLAN hochladen", "Index", "Collab")
                        </button>
                    </form>
                </nav>
            </div>
        </div>
    </div>

    <!-- Body -->
    <!-- Footer -->
    <div class="text-center mt-lg-5">
        <p>Copyright © CoEasy - Bachelorarbeit, JEYNIE BHT Berlin</p>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>
</body>
</html>
