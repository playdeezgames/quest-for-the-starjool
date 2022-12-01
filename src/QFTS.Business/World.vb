Public Class World
    Private _worldData As WorldData
    Sub New(size As (Double, Double, Double))
        _worldData = New WorldData With {
                .Size = New Double() {size.Item1, size.Item2, size.Item3}
            }

        _worldData.PlayerFellowshipId = CreateFellowship("Yer Company").Id

        CreateShip(
            "Yer Ship",
            PlayerFellowship,
            (RNG.FromRange(0.0, size.Item1), RNG.FromRange(0.0, size.Item2), RNG.FromRange(0.0, size.Item3)),
            (RNG.FromRange(-Math.PI, Math.PI), RNG.FromRange(0.0, Math.PI)))

        CreateShip(
            "Derelict Ship",
            Nothing,
            (RNG.FromRange(0.0, size.Item1), RNG.FromRange(0.0, size.Item2), RNG.FromRange(0.0, size.Item3)),
            (RNG.FromRange(-Math.PI, Math.PI), RNG.FromRange(-Math.PI / 2.0, Math.PI / 2.0)))

    End Sub
    Public ReadOnly Property Size As (Double, Double, Double)
        Get
            Return (_worldData.Size(0), _worldData.Size(1), _worldData.Size(2))
        End Get
    End Property
    Private Function CreateFellowship(name As String) As Fellowship
        Dim id = Guid.NewGuid
        _worldData.Fellowships.Add(id, New FellowshipData With {.Name = name})
        Return New Fellowship(_worldData, id)
    End Function
    Private Function CreateShip(name As String, owner As Fellowship, xyz As (Double, Double, Double), heading As (Double, Double)) As Ship
        Dim id = Guid.NewGuid
        _worldData.Ships.Add(id, New ShipData With {
                                .Name = name,
                                .FellowshipId = If(owner Is Nothing, Guid.Empty, owner.Id),
                                .XYZ = New Double() {xyz.Item1, xyz.Item2, xyz.Item3},
                                .Heading = New Double() {heading.Item1, heading.Item2}
                             })
        Return New Ship(_worldData, id)
    End Function

    Public Sub Save(filename As String)
        File.WriteAllText(filename, JsonSerializer.Serialize(_worldData))
    End Sub

    Public ReadOnly Property PlayerFellowship As Fellowship
        Get
            If _worldData.PlayerFellowshipId.HasValue Then
                Return New Fellowship(_worldData, _worldData.PlayerFellowshipId.Value)
            End If
            Return Nothing
        End Get
    End Property
End Class
