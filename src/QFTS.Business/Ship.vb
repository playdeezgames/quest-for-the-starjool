Public Class Ship
    Private _worldData As WorldData
    Public ReadOnly Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub

    Friend Sub NextTurn()
        XYZ = Heading.AsRadians.AsPosition.Multiply(Speed.FromPercent).Add(XYZ)
    End Sub

    Property Name As String
        Get
            Return _worldData.Ships(Id).Name
        End Get
        Set(value As String)
            _worldData.Ships(Id).Name = value
        End Set
    End Property
    ReadOnly Property UniqueName As String
        Get
            Return $"{Name} (#{Id})"
        End Get
    End Property
    Property XYZ As (Double, Double, Double)
        Get
            Return (_worldData.Ships(Id).XYZ(0), _worldData.Ships(Id).XYZ(1), _worldData.Ships(Id).XYZ(2))
        End Get
        Set(value As (Double, Double, Double))
            _worldData.Ships(Id).XYZ = New Double() {value.Item1, value.Item2, value.Item3}
        End Set
    End Property
    Property Heading As (Double, Double)
        Get
            Return (_worldData.Ships(Id).Heading(0).AsDegrees.Clamp(-180.0, +180.0), _worldData.Ships(Id).Heading(1).AsDegrees.Clamp(0.0, 180.0))
        End Get
        Set(value As (Double, Double))
            _worldData.Ships(Id).Heading = New Double() {value.Item1.AsRadians, value.Item2.AsRadians}
        End Set
    End Property
    Property Speed As Double
        Get
            Return _worldData.Ships(Id).Speed.ToPercent
        End Get
        Set(value As Double)
            _worldData.Ships(Id).Speed = value.FromPercent.Clamp(0.0, 1.0)
        End Set
    End Property
End Class
