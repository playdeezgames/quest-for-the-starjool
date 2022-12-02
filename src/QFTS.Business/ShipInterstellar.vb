Public Class ShipInterstellar
    Private _worldData As WorldData
    Private _shipId As Guid
    Sub New(worldData As WorldData, shipId As Guid)
        _worldData = worldData
        _shipId = shipId
    End Sub
    Public Property XYZ As (Double, Double, Double)
        Get
            Return (_worldData.Ships(_shipId).Interstellar.XYZ(0), _worldData.Ships(_shipId).Interstellar.XYZ(1), _worldData.Ships(_shipId).Interstellar.XYZ(2))
        End Get
        Set(value As (Double, Double, Double))
            _worldData.Ships(_shipId).Interstellar.XYZ = New Double() {value.Item1, value.Item2, value.Item3}
        End Set
    End Property
    Public Property Heading As (Double, Double)
        Get
            Return (_worldData.Ships(_shipId).Interstellar.Heading(0).AsDegrees, _worldData.Ships(_shipId).Interstellar.Heading(1).AsDegrees)
        End Get
        Set(value As (Double, Double))
            _worldData.Ships(_shipId).Interstellar.Heading = New Double() {value.Item1.Clamp(-180.0, +180.0).AsRadians, value.Item2.Clamp(0.0, 180.0).AsRadians}
        End Set
    End Property
    Public Property Speed As Double
        Get
            Return _worldData.Ships(_shipId).Interstellar.Speed.ToPercent
        End Get
        Set(value As Double)
            _worldData.Ships(_shipId).Interstellar.Speed = value.FromPercent.Clamp(0.0, 1.0)
        End Set
    End Property
End Class
