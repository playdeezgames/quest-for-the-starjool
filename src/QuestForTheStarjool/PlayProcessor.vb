Module PlayProcessor
    Friend Sub Run(world As World)
        Do
            AnsiConsole.Clear()
            ShowStatus(world.PlayerFellowship)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoices(NextTurnText, ManageFellowshipText, ManageShipsText, GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If GameMenuProcessor.Run(world) Then
                        Exit Do
                    End If
                Case ManageFellowshipText
                    ManageFellowshipProcessor.Run(world.PlayerFellowship)
                Case ManageShipsText
                    ManageShipsProcessor.Run(world.PlayerFellowship)
                Case NextTurnText
                    NextTurnProcessor.Run(world)
            End Select
        Loop
    End Sub

    Private Sub ShowStatus(fellowship As Fellowship)
        AnsiConsole.MarkupLine($"Fellowship: {fellowship.Name}")
        ShowShips(fellowship)
    End Sub

    Private Sub ShowShips(fellowship As Fellowship)
        Dim ships = fellowship.Ships
        If Not ships.Any Then
            Return
        End If
        AnsiConsole.MarkupLine("Ships:")
        For Each ship In ships
            ShowShip(ship)
        Next
    End Sub

    Private Sub ShowShip(ship As Ship)
        AnsiConsole.Markup($" - {ship.Name}")
        Select Case ship.Mode
            Case EnterStarSystemOrder
                ShowEnteringStarSystemShip(ship)
            Case Else
                ShowInterstellarShip(ship)
        End Select
        AnsiConsole.WriteLine()
    End Sub
    Private Sub ShowEnteringStarSystemShip(ship As Ship)
        Dim starSystem = ship.World.GetStarSystem(ship.Order(1))
        AnsiConsole.Markup($"(entering {starSystem.Name})")
    End Sub
    Private Sub ShowInterstellarShip(ship As Ship)
        Dim starSystem = ship.Interstellar.NearestStarSystem
        If starSystem IsNot Nothing Then
            AnsiConsole.Markup($"(near {starSystem.Name}, Distance: {ship.Interstellar.XYZ.Distance(starSystem.XYZ):F})")
        Else
            AnsiConsole.Markup($"({ship.Interstellar.XYZ.Item1}, {ship.Interstellar.XYZ.Item2}, {ship.Interstellar.XYZ.Item3})")
        End If
    End Sub
End Module
