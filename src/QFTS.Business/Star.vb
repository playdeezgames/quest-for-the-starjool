Public Class Star
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub
    Public ReadOnly Property XYZ As (Double, Double, Double)
        Get
            Return (_worldData.Stars(Id).XYZ(0), _worldData.Stars(Id).XYZ(1), _worldData.Stars(Id).XYZ(2))
        End Get
    End Property
End Class
