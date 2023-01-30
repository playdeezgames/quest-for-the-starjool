Friend Class Player
    Inherits Thingie(Of PlayerData)
    Implements IPlayer
    Public Sub New(worldData As WorldData, player As PlayerData)
        MyBase.New(worldData, player)
    End Sub
    Public ReadOnly Property X As Integer Implements IPlayer.X
        Get
            Return Data.MapColumn
        End Get
    End Property
    Public ReadOnly Property Y As Integer Implements IPlayer.Y
        Get
            Return Data.MapRow
        End Get
    End Property
    Public ReadOnly Property CurrentMap As String Implements IPlayer.CurrentMap
        Get
            Return Data.MapName
        End Get
    End Property
    Public ReadOnly Property World As IWorld Implements IPlayer.World
        Get
            Return New World(WorldData)
        End Get
    End Property
    Public Property Shoppe As IShoppe Implements IPlayer.Shoppe
        Get
            If Data.Shoppe Is Nothing Then
                Return Nothing
            End If
            Return New Shoppe(WorldData, Data.Shoppe)
        End Get
        Set(value As IShoppe)
            If value Is Nothing Then
                Data.Shoppe = Nothing
                Return
            End If
            Data.Shoppe = DirectCast(value, Shoppe).Data
        End Set
    End Property
    Public Sub MoveNorth() Implements IPlayer.MoveNorth
        MoveBy(0, -1)
    End Sub
    Private Sub MoveBy(deltaX As Integer, deltaY As Integer)
        Dim currentCell = World.PlayerMap.GetCell(Data.MapColumn, Data.MapRow)
        Dim nextCell = World.PlayerMap.GetCell(Data.MapColumn + deltaX, Data.MapRow + deltaY)
        If currentCell.Character.CanEnter(nextCell) Then
            nextCell.Character = currentCell.Character
            currentCell.Character = Nothing
            Data.MapColumn += deltaX
            Data.MapRow += deltaY
            Data.TriggerIndex = 0
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
        Dim mapCell = World.PlayerMap.GetCell(Data.MapColumn, Data.MapRow)
        Dim triggers = mapCell.Triggers.ToList
        If Data.TriggerIndex >= triggers.Count Then
            Return False
        End If
        Dim trigger = triggers(Data.TriggerIndex)
        Data.TriggerIndex += 1
        trigger.Execute()
        Return True
    End Function
    Public Sub MoveTo(map As IMap, destinationX As Integer, destinationY As Integer) Implements IPlayer.MoveTo
        Dim currentCell = World.PlayerMap.GetCell(Data.MapColumn, Data.MapRow)
        Dim nextCell = map.GetCell(destinationX, destinationY)
        nextCell.Character = currentCell.Character
        currentCell.Character = Nothing
        Data.MapName = map.Name
        Data.MapColumn = destinationX
        Data.MapRow = destinationY
        Data.TriggerIndex = 0
    End Sub
    Public Sub LeaveShoppe() Implements IPlayer.LeaveShoppe
        Shoppe = Nothing
    End Sub
End Class
