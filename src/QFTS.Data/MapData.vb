﻿Public Class MapData
    Public Property Columns As Integer
    Public Property Rows As Integer
    Public Property Cells As New List(Of MapCellData)
    Public Property DefaultTerrain As TerrainType
End Class
