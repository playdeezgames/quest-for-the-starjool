Imports System.Data

Public Class ShipStarSystem
    Private _worldData As WorldData
    Private _shipId As Guid
    Sub New(worldData As WorldData, shipId As Guid)
        _worldData = worldData
        _shipId = shipId
    End Sub
    Property StarSystem As StarSystem
        Get
            Return New StarSystem(_worldData, _worldData.Ships(_shipId).StarSystem.StarSystemId)
        End Get
        Set(value As StarSystem)
            _worldData.Ships(_shipId).StarSystem.StarSystemId = If(value IsNot Nothing, value.Id, Guid.Empty)
        End Set
    End Property
    Property XYZ As (Double, Double, Double)
        Get
            Return (_worldData.Ships(_shipId).StarSystem.XYZ(0), _worldData.Ships(_shipId).StarSystem.XYZ(1), _worldData.Ships(_shipId).StarSystem.XYZ(2))
        End Get
        Set(value As (Double, Double, Double))
            _worldData.Ships(_shipId).StarSystem.XYZ = New Double() {value.Item1, value.Item2, value.Item3}
        End Set
    End Property
    Property Heading As (Double, Double)
        Get
            Return (_worldData.Ships(_shipId).StarSystem.Heading(0), _worldData.Ships(_shipId).StarSystem.Heading(1))
        End Get
        Set(value As (Double, Double))
            _worldData.Ships(_shipId).StarSystem.Heading = New Double() {value.Item1, value.Item2}
        End Set
    End Property
    Property Speed As Double
        Get
            Return _worldData.Ships(_shipId).StarSystem.Speed
        End Get
        Set(value As Double)
            _worldData.Ships(_shipId).StarSystem.Speed = value
        End Set
    End Property
End Class
