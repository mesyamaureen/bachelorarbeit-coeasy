@ModelType CoEasy.EinkaufViewModel

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
        test Neu Einkauf
    </div>

    <div class="w-100">
        @Using Html.BeginForm()
            @<div class="form-group">
                <!-- Verstecktes Feld für die ID der Aufgabe, die dem Benutzer nicht angezeigt werden muss -->
                @Html.HiddenFor(Function(m) Model.Einkauf.EinkaufID)
            </div>

            @*@<div class="form-group">
                @Html.HiddenFor(Function(m) m.Einkauf.UnternehmerID, New With {.readonly = "readonly"})
                @Html.ValidationMessageFor(Function(m) Model.Jobanzeige.UnternehmerID)
            </div>*@

            @<div class="form-group">
                <!-- Titel der Jobanzeige -->
                @Html.LabelFor(Function(m) Model.Einkauf.Status, New With {.class = "control-label"})
                @Html.TextBoxFor(Function(m) Model.Einkauf.Status, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) Model.Einkauf.Status)
            </div>
            @<div class="form-group">
                <!-- Beschreibung der Jobanzeige -->
                @Html.LabelFor(Function(m) Model.Einkauf.Erstelldatum, New With {.class = "control-label"})
                @Html.TextAreaFor(Function(m) Model.Einkauf.Erstelldatum, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) Model.Einkauf.Erstelldatum)
            </div>

            '@<div class="form-group">
            '<!-- Branche der Jobanzeige -->
            '@Html.LabelFor(Function(m) Model.Eink.Branche.BrancheTitel,
            'New With {.class = "control-label"})
            '@Html.DropDownListFor(Function(m) Model.Jobanzeige.Branche.BrancheID,
            'New SelectList(Model.ListeBranche, "BrancheID", "BrancheTitel"),
            'New With {.class = "form-control"})
            '@Html.ValidationMessageFor(Function(m) Model.Jobanzeige.Branche.BrancheTitel)
            '</div>
            @<div class="mb-lg-5">
                <!-- Link zum Abbrechen, d.h. zur Navigation zur Index-Seite und Schaltfläche zum Absenden des Formulars -->
                @Html.ActionLink("Abbrechen", "meineJobanzeigen", Nothing,
                          New With {.class = "btn btn-default", .role = "button"})
                <input type="submit" class="btn btn-success" value="Erstellen" />
            </div>
        End Using
    </div>

</body>
</html>
