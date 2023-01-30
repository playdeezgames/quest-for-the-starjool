Friend Class Trigger
    Implements ITrigger
    Private _worldData As WorldData
    Private _data As TriggerData
    Public Sub New(worldData As WorldData, x As TriggerData)
        _worldData = worldData
        _data = x
    End Sub
    Public ReadOnly Property World As IWorld Implements ITrigger.World
        Get
            Return New World(_worldData)
        End Get
    End Property

    Private ReadOnly Property TriggerType As TriggerType
        Get
            Return _data.TriggerType
        End Get
    End Property
    Public Sub Execute() Implements ITrigger.Execute
        Select Case TriggerType
            Case TriggerType.Teleport
                ExecuteTeleport(_data.Teleport)
            Case TriggerType.Shoppe
                ExecuteShoppe(_data.Shoppe)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Private Sub ExecuteShoppe(shoppe As ShoppeData)
        World.Player.Shoppe = New Shoppe(_worldData, shoppe)
    End Sub
    Private Sub ExecuteTeleport(data As TeleportTriggerData)
        World.Player.MoveTo(World.Map(data.DestinationMap), data.DestinationX, data.DestinationY)
    End Sub
End Class
