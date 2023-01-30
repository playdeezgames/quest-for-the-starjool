Friend Class Map
    Inherits Thingie(Of MapData)
    Implements IMap
    Public Sub New(worldData As WorldData, mapData As MapData, name As String)
        MyBase.New(worldData, mapData)
        Me.Name = name
    End Sub
    Public ReadOnly Property Name As String Implements IMap.Name
    Public Function GetCell(mapColumn As Integer, mapRow As Integer) As IMapCell Implements IMap.GetCell
        If mapColumn < 0 OrElse mapRow < 0 OrElse mapColumn >= Data.Columns OrElse mapRow >= Data.Rows Then
            Return New MapCell(WorldData, New MapCellData With
                               {
                                .Terrain = Data.DefaultTerrain
                               })
        End If
        Return New MapCell(WorldData, Data.Cells(mapColumn + mapRow * Data.Columns))
    End Function
End Class
