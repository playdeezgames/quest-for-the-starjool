Module GameMenuProcessor
    Friend Function Run(world As World) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Game Menu:[/]"}
        prompt.AddChoices(GoBackText, SaveGameText, AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case AbandonGameText
                If Confirm("[red]Are you sure you want to abandon the game?[/]") Then
                    Return True
                End If
            Case SaveGameText
                Dim filename = AnsiConsole.Ask("[olive]Filename:[/]", String.Empty)
                If Not String.IsNullOrEmpty(filename) Then
                    world.Save(filename)
                End If
        End Select
        Return False
    End Function
End Module
