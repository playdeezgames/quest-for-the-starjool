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
    Public ReadOnly Property CurrentMap As String Implements IPlayer.CurrentMap
        Get
            Return _data.MapName
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements IPlayer.World
        Get
            Return New World(_worldData)
        End Get
    End Property

    Public Sub MoveNorth() Implements IPlayer.MoveNorth
        MoveBy(0, -1)
    End Sub
    Private Sub MoveBy(deltaX As Integer, deltaY As Integer)
        Dim currentCell = World.PlayerMap.GetCell(_data.MapColumn, _data.MapRow)
        Dim nextCell = World.PlayerMap.GetCell(_data.MapColumn + deltaX, _data.MapRow + deltaY)
        If currentCell.Character.CanEnter(nextCell) Then
            nextCell.Character = currentCell.Character
            currentCell.Character = Nothing
            _data.MapColumn += deltaX
            _data.MapRow += deltaY
            _data.TriggerIndex = 0
        End If
    End Sub
    Public Sub MoveSouth() Implements IPlayer.MoveSouth
        MoveBy(0, 1)
    End Sub
    Public Sub MoveWest() Implements IPlayer.MoveWest
        MoveBy(-1, 0)
    End Sub
    Public Sub MoveEast() Implements IPlayer.MoveEast
        MoveBy(1, 0)
    End Sub
    Public Function RunTrigger() As Boolean Implements IPlayer.RunTrigger
        Dim mapCell = World.PlayerMap.GetCell(_data.MapColumn, _data.MapRow)
        Dim triggers = mapCell.Triggers.ToList
        If _data.TriggerIndex >= triggers.Count Then
            Return False
        End If
        Dim trigger = triggers(_data.TriggerIndex)
        _data.TriggerIndex += 1
        trigger.Execute()
        Return True
    End Function
    Public Sub MoveTo(map As IMap, destinationX As Integer, destinationY As Integer) Implements IPlayer.MoveTo
        Dim currentCell = World.PlayerMap.GetCell(_data.MapColumn, _data.MapRow)
        Dim nextCell = map.GetCell(destinationX, destinationY)
        nextCell.Character = currentCell.Character
        currentCell.Character = Nothing
        _data.MapName = map.Name
        _data.MapColumn = destinationX
        _data.MapRow = destinationY
        _data.TriggerIndex = 0
    End Sub
End Class
