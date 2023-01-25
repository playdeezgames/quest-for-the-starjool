Friend Class Map
    Implements IMap

    Private _worldData As WorldData
    Private _data As MapData

    Public Sub New(worldData As WorldData, mapData As MapData)
        Me._worldData = worldData
        Me._data = mapData
    End Sub

    Public Function GetCell(mapColumn As Integer, mapRow As Integer) As IMapCell Implements IMap.GetCell
        If mapColumn < 0 OrElse mapRow < 0 OrElse mapColumn >= _data.Columns OrElse mapRow >= _data.Rows Then
            Return Nothing
        End If
        Return New MapCell(_worldData, _data.Cells(mapColumn + mapRow * _data.Columns))
    End Function
End Class
