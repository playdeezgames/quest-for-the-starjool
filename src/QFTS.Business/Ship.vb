Public Class Ship
    Private _worldData As WorldData
    Public ReadOnly Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub
    Friend Sub NextTurn()
        Select Case Mode
            Case EnterStarSystemOrder
                OnEnterStarSystem()
            Case StarSystemNavigationOrder
                OnStarSystemNavigation()
            Case ExitStarSystemOrder
                OnExitStarSystem()
            Case Else
                OnInterstellarMovement()
        End Select
    End Sub
    Private Sub OnExitStarSystem()
        Throw New NotImplementedException()
    End Sub
    Private Sub OnStarSystemNavigation()
        Throw New NotImplementedException()
    End Sub
    Private Sub OnEnterStarSystem()
        Dim destination = World.GetStarSystem(Order(1))
        StarSystem.StarSystem = destination
        StarSystem.XYZ = Interstellar.XYZ.Add(destination.XYZ.Multiply(-1.0)).Multiply(StarSystemScale)
        StarSystem.Heading = Interstellar.Heading
        StarSystem.Speed = 1.0
        SetOrder(StarSystemNavigationOrder)
    End Sub
    Public ReadOnly Property StarSystem As ShipStarSystem
        Get
            Return New ShipStarSystem(_worldData, Id)
        End Get
    End Property
    Private Sub OnInterstellarMovement()
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
    ReadOnly Property Interstellar As ShipInterstellar
        Get
            Return New ShipInterstellar(_worldData, Id)
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
    ReadOnly Property Order As String()
        Get
            Return _worldData.Ships(Id).Orders
        End Get
    End Property
    ReadOnly Property Mode As String
        Get
            Return _worldData.Ships(Id).Orders.FirstOrDefault
        End Get
    End Property
End Class
