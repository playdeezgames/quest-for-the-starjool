Friend MustInherit Class Thingie(Of TData)
    Private ReadOnly _worldData As WorldData
    Private ReadOnly _data As TData
    Protected ReadOnly Property WorldData As WorldData
        Get
            Return _worldData
        End Get
    End Property
    Friend ReadOnly Property Data As TData
        Get
            Return _data
        End Get
    End Property
    Sub New(worldData As WorldData, data As TData)
        _worldData = worldData
        _data = data
    End Sub
End Class
