Public Class World
    Private _worldData As WorldData
    Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
    Sub New(size As (Double, Double, Double), minimumStarDistance As Double)
        _worldData = New WorldData With {
                .Size = New Double() {size.Item1, size.Item2, size.Item3}
            }

        _worldData.PlayerFellowshipId = CreateFellowship("Yer Company").Id

        CreateShip(
            "Yer Ship",
            PlayerFellowship,
            (RNG.FromRange(0.0, size.Item1), RNG.FromRange(0.0, size.Item2), RNG.FromRange(0.0, size.Item3)),
            (RNG.FromRange(-Math.PI, Math.PI), RNG.FromRange(0.0, Math.PI)),
            1.0,
            Array.Empty(Of String))

        CreateShip(
            "Derelict Ship",
            Nothing,
            (RNG.FromRange(0.0, size.Item1), RNG.FromRange(0.0, size.Item2), RNG.FromRange(0.0, size.Item3)),
            (RNG.FromRange(-Math.PI, Math.PI), RNG.FromRange(-Math.PI / 2.0, Math.PI / 2.0)),
            0.0,
            Array.Empty(Of String))

        GenerateStarSystems(minimumStarDistance)
    End Sub
    Private Sub GenerateStarSystems(minimumStarDistance As Double)
        Dim attempts As Integer = 0
        Do While attempts < 5000
            Dim xyz = (RNG.FromRange(0.0, Size.Item1), RNG.FromRange(0.0, Size.Item2), RNG.FromRange(0.0, Size.Item3))
            If StarSystems.Any(Function(x) x.XYZ.Distance(xyz) < minimumStarDistance) Then
                attempts += 1
            Else
                attempts = 0
                CreateStarSystem(GenerateStarSystemName(), xyz)
            End If
        Loop
    End Sub
    Private Function GenerateStarSystemName() As String
        Dim nameLength = RNG.FromValues(1, 2, 3) + RNG.FromValues(1, 2, 3) + RNG.FromValues(1, 2, 3) + RNG.FromValues(1, 2, 3)
        Dim isVowel = RNG.FromValues(False, True)
        Dim result As String = String.Empty
        While nameLength > 0
            nameLength -= 1
            isVowel = Not isVowel
            If isVowel Then
                result &= RNG.FromValues("a", "e", "i", "o", "u")
            Else
                result &= RNG.FromValues("h", "k", "l", "m", "p")
            End If
        End While
        Return result
    End Function

    Private Sub CreateStarSystem(name As String, xyz As (Double, Double, Double))
        _worldData.StarSystems.Add(Guid.NewGuid, New StarSystemData With {
                .Name = name,
                .XYZ = New Double() {xyz.Item1, xyz.Item2, xyz.Item3}
            })
    End Sub

    Public ReadOnly Property StarSystems As IEnumerable(Of StarSystem)
        Get
            Return _worldData.StarSystems.Select(Function(x) New StarSystem(_worldData, x.Key))
        End Get
    End Property
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
    Private Function CreateShip(name As String, owner As Fellowship, xyz As (Double, Double, Double), heading As (Double, Double), speed As Double, orders As String()) As Ship
        Dim id = Guid.NewGuid
        _worldData.Ships.Add(id, New ShipData With {
                                .Name = name,
                                .FellowshipId = If(owner Is Nothing, Guid.Empty, owner.Id),
                                .Interstellar = New InterstellarShipData With
                                {
                                    .XYZ = New Double() {xyz.Item1, xyz.Item2, xyz.Item3},
                                    .Heading = New Double() {heading.Item1, heading.Item2},
                                    .Speed = speed
                                },
                                .StarSystem = New StarSystemShipData,
                                .Orders = orders
                             })
        Return New Ship(_worldData, id)
    End Function

    Public Sub Save(filename As String)
        File.WriteAllText(filename, JsonSerializer.Serialize(_worldData))
    End Sub

    Private ReadOnly Property Ships As IEnumerable(Of Ship)
        Get
            Return _worldData.Ships.Select(Function(x) New Ship(_worldData, x.Key))
        End Get
    End Property

    Public Sub NextTurn()
        For Each ship In Ships
            ship.NextTurn()
        Next
    End Sub

    Public ReadOnly Property PlayerFellowship As Fellowship
        Get
            If _worldData.PlayerFellowshipId.HasValue Then
                Return New Fellowship(_worldData, _worldData.PlayerFellowshipId.Value)
            End If
            Return Nothing
        End Get
    End Property
    Function GetStarSystem(starSystemId As String) As StarSystem
        Return New StarSystem(_worldData, Guid.Parse(starSystemId))
    End Function
End Class
