Module Utility
    Friend Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoice(OkText)
        AnsiConsole.Prompt(prompt)
    End Sub
    Friend Function Confirm(title As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = title}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
    Friend Function SanitizedStringAsk(title As String, defaultValue As String) As String
        Dim answer = AnsiConsole.Ask(title, String.Empty)
        If String.IsNullOrEmpty(answer) Then
            Return defaultValue
        End If
        Return answer.Replace("[", "[[").Replace("]", "]]")
    End Function
End Module
