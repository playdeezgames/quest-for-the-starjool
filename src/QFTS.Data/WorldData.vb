Public Class WorldData
    Public Property PlayerFellowshipId As Guid?
    Public Property Fellowships As New Dictionary(Of Guid, FellowshipData)
    Public Property Ships As New Dictionary(Of Guid, ShipData)
    Public Property Stars As New Dictionary(Of Guid, StarData)
    Public Property Size As Double()
End Class
