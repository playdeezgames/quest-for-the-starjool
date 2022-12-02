Module ManageShipProcessor
    Friend Sub Run(ship As Ship)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Serial#: {ship.Id}")
            AnsiConsole.MarkupLine($"Name: {ship.Name}")
            Select Case ship.Mode
                Case EnterStarSystemOrder
                    If ManageEnterStarSystemShipProcessor.Run(ship) Then
                        Exit Do
                    End If
                Case Else
                    If ManageInterstellarShipProcessor.Run(ship) Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub

    Friend Sub HandleChangeName(ship As Ship)
        ship.Name = Utility.SanitizedStringAsk("[olive]New Name?[/]", ship.Name)
    End Sub
End Module
