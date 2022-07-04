@ModelType CoEasy.EinkaufViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Oeffnen</title>
</head>
<body>
    <div>
        <div>
            <h1>Einkauf</h1>
        </div>

        <div>
            @Using Html.BeginForm()
                @<div>
                    @Html.HiddenFor(Function(m) Model.Einkauf.EinkaufID)
                </div>
                @<div>
                    @Html.LabelFor(Function(m) Model.Einkauf.EinkaufListe, New With {.class = "control-label"})
                    
                </div>

            End Using
        </div>

    </div>
</body>
</html>
