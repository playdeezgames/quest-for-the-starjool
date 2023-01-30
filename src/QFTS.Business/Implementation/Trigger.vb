Friend Class Trigger
    Inherits Thingie(Of TriggerData)
    Implements ITrigger
    Public Sub New(worldData As WorldData, x As TriggerData)
        MyBase.New(worldData, x)
    End Sub
    Public ReadOnly Property World As IWorld Implements ITrigger.World
        Get
            Return New World(WorldData)
        End Get
    End Property

    Private ReadOnly Property TriggerType As TriggerType
        Get
            Return Data.TriggerType
        End Get
    End Property
    Public Sub Execute() Implements ITrigger.Execute
        Select Case TriggerType
            Case TriggerType.Teleport
                ExecuteTeleport(Data.Teleport)
            Case TriggerType.Shoppe
                ExecuteShoppe(Data.Shoppe)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Private Sub ExecuteShoppe(shoppe As ShoppeData)
        World.Player.Shoppe = New Shoppe(WorldData, shoppe)
    End Sub
    Private Sub ExecuteTeleport(data As TeleportTriggerData)
        World.Player.MoveTo(World.Map(data.DestinationMap), data.DestinationX, data.DestinationY)
    End Sub
End Class
