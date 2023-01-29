Friend Class Map
    Implements IMap
    Private ReadOnly _worldData As WorldData
    Private ReadOnly _data As MapData
    Public Sub New(worldData As WorldData, mapData As MapData, name As String)
        Me.Name = name
        _worldData = worldData
        _data = mapData
    End Sub
    Public ReadOnly Property Name As String Implements IMap.Name
    Public Function GetCell(mapColumn As Integer, mapRow As Integer) As IMapCell Implements IMap.GetCell
        If mapColumn < 0 OrElse mapRow < 0 OrElse mapColumn >= _data.Columns OrElse mapRow >= _data.Rows Then
            Return Nothing
        End If
        Return New MapCell(_worldData, _data.Cells(mapColumn + mapRow * _data.Columns))
    End Function
End Class
