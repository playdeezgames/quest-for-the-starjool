Imports QFTS.Business

Module Program
    Private ReadOnly MapFiles As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {"Overworld", "./Assets/Maps/Overworld.json"},
            {"Town1", "./Assets/Maps/Town1.json"}
        }
    Sub Main(args As String())
        World.MapFiles = MapFiles
        Using game = New QFTSGame()
            game.Run()
        End Using
    End Sub
End Module
