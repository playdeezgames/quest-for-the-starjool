Module ManageShipProcessor
    Friend Sub Run(ship As Ship)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Serial#: {ship.Id}")
            AnsiConsole.MarkupLine($"Name: {ship.Name}")
            AnsiConsole.MarkupLine($"Position: ({ship.XYZ.Item1:F}, {ship.XYZ.Item2:F}, {ship.XYZ.Item3:F})")
            AnsiConsole.MarkupLine($"Heading: ({ship.Heading.Item1:F}, {ship.Heading.Item2:F})")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoices(DoneText, ChangeHeadingText, ChangeNameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case ChangeHeadingText
                    HandleChangeHeading(ship)
                Case ChangeNameText
                    HandleChangeName(ship)
                Case DoneText
                    Exit Do
            End Select
        Loop
    End Sub
    Private Sub HandleChangeHeading(ship As Ship)
        Dim newTheta = AnsiConsole.Ask("[olive]New Θ?[/]", ship.Heading.Item1)
        Dim newPhi = AnsiConsole.Ask("New Φ?", ship.Heading.Item2)
        ship.Heading = (newTheta, newPhi)
    End Sub
    Private Sub HandleChangeName(ship As Ship)
        Dim newName = Utility.SanitizedStringAsk("[olive]New Name?[/]")
        If String.IsNullOrEmpty(newName) Then
            Return
        End If
        ship.Name = newName
    End Sub
End Module
