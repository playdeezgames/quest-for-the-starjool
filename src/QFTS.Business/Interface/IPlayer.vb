Public Interface IPlayer
    ReadOnly Property X As Integer
    ReadOnly Property Y As Integer
    ReadOnly Property CurrentMap As String
    Sub MoveNorth()
    Sub MoveSouth()
    Sub MoveWest()
    Sub MoveEast()
    ReadOnly Property World As IWorld
End Interface
