Public Class StarSystem
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub
    Public ReadOnly Property XYZ As (Double, Double, Double)
        Get
            Return (_worldData.StarSystems(Id).XYZ(0), _worldData.StarSystems(Id).XYZ(1), _worldData.StarSystems(Id).XYZ(2))
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return _worldData.StarSystems(Id).Name
        End Get
    End Property
    Public ReadOnly Property UniqueName As String
        Get
            Return $"{Name} (#{Id})"
        End Get
    End Property
End Class
