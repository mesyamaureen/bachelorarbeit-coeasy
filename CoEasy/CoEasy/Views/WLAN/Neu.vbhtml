@ModelType CoEasy.WLANViewModel

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Neu</title>
</head>
<body>
    <div>
        WLAN Passwort für heute:
        @Using Html.BeginForm()
            @<div class="form-group">
                @Html.HiddenFor(Function(m) m.Wlan.WlanCode, New With {.readonly = "readonly"})
                @Html.ValidationMessageFor(Function(m) Model.Wlan.WlanCode)
            </div>
        End Using
     </div>
</body>
</html>
