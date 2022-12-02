Public Class Ship
    Private _worldData As WorldData
    Public ReadOnly Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub

    Friend Sub NextTurn()
        Interstellar.XYZ = Interstellar.Heading.AsRadians.AsPosition.Multiply(Interstellar.Speed.FromPercent).Add(Interstellar.XYZ)
    End Sub
    Public Function CanEnter(star As StarSystem) As Boolean
        Return star.XYZ.Distance(Interstellar.XYZ) < InterstellarStarEntranceDistance
    End Function

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
    ReadOnly Property Interstellar As Interstellar
        Get
            Return New ShipInterstellar(_worldData, Id)
        End Get
    End Property
    ReadOnly Property NearbyStars As IEnumerable(Of StarSystem)
        Get
            Return World.StarSystems.Where(Function(x) x.XYZ.Distance(Interstellar.XYZ) <= InterstellarViewDistance)
        End Get
    End Property
    ReadOnly Property World As World
        Get
            Return New World(_worldData)
        End Get
    End Property
    Sub SetOrder(ParamArray tokens As String())
        _worldData.Ships(Id).Orders = tokens
    End Sub
End Class
