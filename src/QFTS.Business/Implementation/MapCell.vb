Friend Class MapCell
    Implements IMapCell
    Private _worldData As WorldData
    Private _data As MapCellData
    Public Sub New(worldData As WorldData, mapCellData As MapCellData)
        _worldData = worldData
        _data = mapCellData
    End Sub
    Public ReadOnly Property Terrain As TerrainType Implements IMapCell.Terrain
        Get
            Return _data.Terrain
        End Get
    End Property
    Public Property Character As ICharacter Implements IMapCell.Character
        Get
            If _data.Character Is Nothing Then
                Return Nothing
            End If
            Return New Character(_worldData, _data.Character)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                _data.Character = Nothing
                Return
            End If
            _data.Character = DirectCast(value, Character)._data
        End Set
    End Property
End Class
