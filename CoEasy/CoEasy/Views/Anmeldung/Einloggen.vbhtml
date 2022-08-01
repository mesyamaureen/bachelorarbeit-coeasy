﻿@ModelType CoEasy.Benutzer

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors">
    <meta name="generator" content="Hugo 0.88.1">
    <title>Anmelden</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.6/examples/sign-in/">

    <!-- Bootstrap core CSS -->
    @*<link href="../assets/dist/css/bootstrap.min.css" rel="stylesheet">
        <link href="../Css/style.css" rel="stylesheet">*@
</head>
<body class="d-flex justify-content-center" style="background-color: #D59C1D;">
    <div class="mb-4" style="display: flex; justify-content: center; align-items: center;">
        <img src="~/Bilder/2a6d0db3fe8f4fc9a7081f9879ace954.png" alt="" width="72" height="72">
    </div>
    <div style="display: flex; justify-content: center; align-items: center;; flex-direction:column;">
        @Using Html.BeginForm("Einloggen", "Anmeldung", FormMethod.Post)
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True)

            @<div class="form-group">
                @Html.LabelFor(Function(m) m.Benutzername, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(m) m.Benutzername, New With {.class = "form-control password"})
                @Html.ValidationMessageFor(Function(m) m.Benutzername)
            </div>
            @<div class="form-group">
                @Html.LabelFor(Function(m) m.Passwort, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(m) m.Passwort, New With {.class = "form-control", .type = "password"})
                @Html.ValidationMessageFor(Function(m) m.Passwort)
            </div>

            @<div>
                <input type="submit" class="btn btn-primary" value="Login" />
            </div>
        End Using
    </div>


    <!-- Bootstrap -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>
</body>
</html>
