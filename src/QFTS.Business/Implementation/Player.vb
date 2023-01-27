Friend Class Player
    Implements IPlayer
    Private _worldData As WorldData
    Private _data As PlayerData
    Public Sub New(worldData As WorldData, player As PlayerData)
        _worldData = worldData
        _data = player
    End Sub
    Public ReadOnly Property X As Integer Implements IPlayer.X
        Get
            Return _data.MapColumn
        End Get
    End Property
    Public ReadOnly Property Y As Integer Implements IPlayer.Y
        Get
            Return _data.MapRow
        End Get
    End Property
End Class
