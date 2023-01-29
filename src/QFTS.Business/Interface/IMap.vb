Public Interface IMap
    Function GetCell(mapColumn As Integer, mapRow As Integer) As IMapCell
    ReadOnly Property Name As String
End Interface
