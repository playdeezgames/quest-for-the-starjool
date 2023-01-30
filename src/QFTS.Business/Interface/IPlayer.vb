Public Interface IPlayer
    ReadOnly Property X As Integer
    ReadOnly Property Y As Integer
    ReadOnly Property CurrentMap As String
    Sub MoveNorth()
    Sub MoveSouth()
    Sub MoveWest()
    Sub MoveEast()
    Function RunTrigger() As Boolean
    Sub MoveTo(map As IMap, destinationX As Integer, destinationY As Integer)
    Sub LeaveShoppe()
    ReadOnly Property World As IWorld
    Property Shoppe As IShoppe
End Interface
