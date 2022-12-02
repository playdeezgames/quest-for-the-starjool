Module ManageEnterStarSystemShipProcessor
    Friend Function Run(ship As Ship) As Boolean
        Dim starSystem = ship.World.GetStarSystem(ship.Order(1))
        AnsiConsole.MarkupLine($"Entering: {starSystem.UniqueName}")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
        prompt.AddChoices(DoneText, CancelOrderText)
        Select Case AnsiConsole.Prompt(prompt)
            Case DoneText
                Return True
            Case CancelOrderText
                ship.SetOrder()
        End Select
        Return False
    End Function
End Module
