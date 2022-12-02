Module ManageInterstellarShipProcessor
    Friend Function Run(ship As Ship) As Boolean
        AnsiConsole.MarkupLine($"Position: ({ship.Interstellar.XYZ.Item1:F}, {ship.Interstellar.XYZ.Item2:F}, {ship.Interstellar.XYZ.Item3:F})")
        AnsiConsole.MarkupLine($"Heading: ({ship.Interstellar.Heading.Item1:F}°, {ship.Interstellar.Heading.Item2:F}°)")
        AnsiConsole.MarkupLine($"Speed: {ship.Interstellar.Speed:F}%")
        Dim table = ShowNearbyStars(ship).ToDictionary(Function(x) $"Enter star system {x.UniqueName}", Function(x) x)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
        prompt.AddChoices(DoneText, ChangeHeadingText, ChangeSpeedText, ChangeNameText)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case ChangeHeadingText
                HandleChangeHeading(ship)
            Case ChangeSpeedText
                HandleChangeSpeed(ship)
            Case ChangeNameText
                HandleChangeName(ship)
            Case DoneText
                Return True
            Case Else
                ship.SetOrder(EnterStarSystemOrder, table(answer).Id.ToString())
        End Select
        Return False
    End Function
    Private Function ShowNearbyStars(ship As Ship) As IEnumerable(Of StarSystem)
        Dim result As New List(Of StarSystem)
        Dim stars = ship.NearbyStars
        If Not stars.Any Then
            Return result
        End If
        AnsiConsole.MarkupLine("Nearby Stars:")
        For Each star In stars
            Dim headingTo = ship.Interstellar.XYZ.HeadingTo(star.XYZ).AsDegrees
            If ship.CanEnter(star) Then
                result.Add(star)
            End If
            AnsiConsole.MarkupLine($" - {star.Name} (Distance: {star.XYZ.Distance(ship.Interstellar.XYZ):F}, Heading: ({headingTo.Item1:F}°, {headingTo.Item2:F}°))")
        Next
        Return result
    End Function

    Private Sub HandleChangeSpeed(ship As Ship)
        ship.Interstellar.Speed = AnsiConsole.Ask("[olive]New Speed?[/]", ship.Interstellar.Speed)
    End Sub
    Private Sub HandleChangeHeading(ship As Ship)
        Dim newTheta = AnsiConsole.Ask("[olive]New Θ?[/]", ship.Interstellar.Heading.Item1)
        Dim newPhi = AnsiConsole.Ask("New Φ?", ship.Interstellar.Heading.Item2)
        ship.Interstellar.Heading = (newTheta, newPhi)
    End Sub
End Module
