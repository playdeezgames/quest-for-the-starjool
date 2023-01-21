Module Program
    Sub Main(args As String())
        Using game = New QFTSGame()
            game.Run()
        End Using
    End Sub
End Module
