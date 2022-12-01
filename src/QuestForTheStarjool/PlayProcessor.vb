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
        AnsiConsole.MarkupLine($"Ships: {String.Join(", ", fellowship.Ships.Select(Function(x) x.Name).ToArray)}")
    End Sub
End Module
