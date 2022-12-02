Module ManageShipProcessor
    Friend Sub Run(ship As Ship)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Serial#: {ship.Id}")
            AnsiConsole.MarkupLine($"Name: {ship.Name}")
            If ManageInterstellarShipProcessor.Run(ship) Then
                Exit Do
            End If
        Loop
    End Sub

    Friend Sub HandleChangeName(ship As Ship)
        ship.Name = Utility.SanitizedStringAsk("[olive]New Name?[/]", ship.Name)
    End Sub
End Module
