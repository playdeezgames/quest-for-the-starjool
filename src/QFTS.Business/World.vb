Public Class World
    Private _worldData As WorldData
    Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
    Sub New()
        _worldData = New WorldData
    End Sub
End Class
