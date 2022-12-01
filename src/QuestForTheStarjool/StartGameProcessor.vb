Module StartGameProcessor
    Friend Sub Run()
        Dim world As New World(NormalWorldSize, NormalMinimumStarDistance)
        PlayProcessor.Run(world)
    End Sub
End Module
