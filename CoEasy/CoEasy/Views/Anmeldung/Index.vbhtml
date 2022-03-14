@ModelType CoEasy.BenutzerViewModel
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
    <!-- Header -->
    <div>
        <div id="header" style="background-color: #F8E6BC;">
            <a title="zur Startseite" href="Startseite.html">
                <img src="../Bilder/COLLAB-BILD.png" width="300" alt="Collab-Logo" />
            </a>
            <h1 style="font-style: italic;">Collaborate with the right influencer</h1>

            <div>
                <ul class="nav justify-content-end">
                    <li class="nav-item">
                        @Html.ActionLink("Einkauf", "Index", "Collab")
                    </li>
                    <li class="nav-item" style="margin-left: 25px;">
                        @Html.ActionLink("WLAN hochladen", "InfluencerSuchen", "AlleInfluencer")
                    </li>
                </ul>
            </div>
        </div>
    </div>

    <div class="container-fluid" style="background-color:#FFCCBC;">
        <!-- Content fängt hier an -->
        <!-- left Column -->
        <div class="row">
            <div class="col-2">
                <ul class="nav flex-column position-fixed float-start">
                    <li class="nav-item">
                        @Html.ActionLink("Startseite", "Index")
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Tickets", "InfluencerSuchen", "AlleInfluencer")
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Coworkers", "UnternehmenSuchen", "AlleUnternehmen")
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Mitarbeiter", "AlleJobanzeigen", "AlleJobanzeigen")
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Mein Profil", "Einloggen", "AlleProfile")
                    </li>
                    <li class="nav-item">
                        @Html.ActionLink("Ausloggen", "Impressum")
                    </li>
                </ul>
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

