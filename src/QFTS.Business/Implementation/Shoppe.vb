Friend Class Shoppe
    Inherits Thingie(Of ShoppeData)
    Implements IShoppe
    Public ReadOnly Property Name As String Implements IShoppe.Name
        Get
            Return Data.Name
        End Get
    End Property
    Public ReadOnly Property CanBuy As Boolean Implements IShoppe.CanBuy
        Get
            Return Data.Prices.Any
        End Get
    End Property
    Public ReadOnly Property CanSell As Boolean Implements IShoppe.CanSell
        Get
            Return Data.Offers.Any
        End Get
    End Property
    Public Sub New(worldData As WorldData, shoppe As ShoppeData)
        MyBase.New(worldData, shoppe)
    End Sub
End Class
