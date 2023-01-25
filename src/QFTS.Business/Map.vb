Friend Class Map
    Implements IMap

    Private _worldData As WorldData
    Private _data As MapData

    Public Sub New(worldData As WorldData, mapData As MapData)
        Me._worldData = worldData
        Me._data = mapData
    End Sub

    Public Function GetCell(mapColumn As Integer, mapRow As Integer) As IMapCell Implements IMap.GetCell
        Return New MapCell(_worldData, _data.Cells(mapColumn + mapRow * _data.Columns))
    End Function
End Class
