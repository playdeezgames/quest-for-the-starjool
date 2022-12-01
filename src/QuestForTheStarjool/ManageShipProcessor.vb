Module ManageShipProcessor
    Friend Sub Run(ship As Ship)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Serial#: {ship.Id}")
            AnsiConsole.MarkupLine($"Name: {ship.Name}")
            AnsiConsole.MarkupLine($"Position: ({ship.XYZ.Item1:F}, {ship.XYZ.Item2:F}, {ship.XYZ.Item3:F})")
            AnsiConsole.MarkupLine($"Heading: ({ship.Heading.Item1:F}°, {ship.Heading.Item2:F}°)")
            AnsiConsole.MarkupLine($"Speed: {ship.Speed:F}%")
            ShowNearbyStars(ship)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoices(DoneText, ChangeHeadingText, ChangeSpeedText, ChangeNameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case ChangeHeadingText
                    HandleChangeHeading(ship)
                Case ChangeSpeedText
                    HandleChangeSpeed(ship)
                Case ChangeNameText
                    HandleChangeName(ship)
                Case DoneText
                    Exit Do
            End Select
        Loop
    End Sub

    Private Sub ShowNearbyStars(ship As Ship)
        Dim stars = ship.NearbyStars
        If Not stars.Any Then
            Return
        End If
        AnsiConsole.MarkupLine("Nearby Stars:")
        For Each star In stars
            Dim headingTo = ship.XYZ.HeadingTo(star.XYZ).AsDegrees
            AnsiConsole.MarkupLine($" - {star.Name} (Distance: {star.XYZ.Distance(ship.XYZ):F}, Heading: ({headingTo.Item1:F}°, {headingTo.Item2:F}°))")
        Next
    End Sub

    Private Sub HandleChangeSpeed(ship As Ship)
        ship.Speed = AnsiConsole.Ask("[olive]New Speed?[/]", ship.Speed)
    End Sub
    Private Sub HandleChangeHeading(ship As Ship)
        Dim newTheta = AnsiConsole.Ask("[olive]New Θ?[/]", ship.Heading.Item1)
        Dim newPhi = AnsiConsole.Ask("New Φ?", ship.Heading.Item2)
        ship.Heading = (newTheta, newPhi)
    End Sub
    Private Sub HandleChangeName(ship As Ship)
        ship.Name = Utility.SanitizedStringAsk("[olive]New Name?[/]", ship.Name)
    End Sub
End Module
