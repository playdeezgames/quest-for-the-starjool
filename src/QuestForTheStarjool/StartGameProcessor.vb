Module StartGameProcessor
    Friend Sub Run()
        Dim world As New World(NormalWorldSize)
        PlayProcessor.Run(world)
    End Sub
End Module
