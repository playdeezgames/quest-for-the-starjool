Friend Class Shoppe
    Implements IShoppe
    Private ReadOnly _worldData As WorldData
    Friend ReadOnly _data As ShoppeData
    Public Sub New(worldData As WorldData, shoppe As ShoppeData)
        _worldData = worldData
        _data = shoppe
    End Sub
End Class
