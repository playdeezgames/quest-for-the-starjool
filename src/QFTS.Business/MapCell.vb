Friend Class MapCell
    Implements IMapCell

    Private _worldData As WorldData
    Private _data As MapCellData

    Public Sub New(worldData As WorldData, mapCellData As MapCellData)
        _worldData = worldData
        _data = mapCellData
    End Sub

    Public Property Token As TokenType? Implements IMapCell.Token
        Get
            Return _data.Token
        End Get
        Set(value As TokenType?)
            _data.Token = value
        End Set
    End Property
End Class
