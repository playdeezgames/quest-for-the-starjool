﻿Public Class MapCellData
    Public Property Terrain As TerrainType
    Public Property Triggers As New List(Of TriggerData)
    Public Property Token As TokenType?
End Class
