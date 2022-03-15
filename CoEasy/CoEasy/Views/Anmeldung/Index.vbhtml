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
    <!-- Body -->
    <div class="d-flex justify-content-center align-items-center">
        <a title="zur Startseite" href="Startseite.html">
            <img src="~/Bilder/CoEasy-Logo.jpg" width="100" alt="CoEasy-Logo" />
        </a>
    </div>
    <div class="d-flex justify-content-center align-items-center">
        <form>
            <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <input type="password" class="form-control" id="exampleInputPassword1">
            </div>
            <div class="form-group form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Check me out</label>
            </div>
            <button class="btn btn-outline-success" type="button">
                @Html.ActionLink("Startseite", "Startseite", "CoEasy")
            </button>
            @*<button type="submit" class="btn btn-primary">Submit</button>*@
        </form>
    </div>

    @*@Using Html.BeginForm()
            @Html.TextAreaFor(Function(m) m.Influencer.Vorname, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Influencer.Vorname)
        End Using*@


    <!-- Footer -->
    <div Class="text-center mt-lg-5">
        <p> Copyright © CoEasy - Bachelorarbeit, JEYNIE BHT Berlin</p>
    </div>

    <Script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></Script>
    <Script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></Script>
    <Script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></Script>
</body>


</html>

