Public Class World
    Implements IWorld
    Private _data As WorldData
    Public ReadOnly Property CanStart As Boolean Implements IWorld.CanStart
        Get
            Return Not CanContinue
        End Get
    End Property
    Public ReadOnly Property CanContinue As Boolean Implements IWorld.CanContinue
        Get
            Return _data.CharacterCreation IsNot Nothing OrElse _data.Player IsNot Nothing
        End Get
    End Property
    Public ReadOnly Property CanAbandon As Boolean Implements IWorld.CanAbandon
        Get
            Return CanContinue
        End Get
    End Property
    Public ReadOnly Property IsCreatingCharacter As Boolean Implements IWorld.IsCreatingCharacter
        Get
            Return _data.CharacterCreation IsNot Nothing
        End Get
    End Property
    Public ReadOnly Property NeedsAbilityScores As Boolean Implements IWorld.NeedsAbilityScores
        Get
            Return If(CharacterCreation?.NeedsAbilityScores, False)
        End Get
    End Property
    Public ReadOnly Property NeedsRace As Boolean Implements IWorld.NeedsRace
        Get
            Return If(CharacterCreation?.NeedsRace, False)
        End Get
    End Property
    Public ReadOnly Property NeedsClass As Boolean Implements IWorld.NeedsClass
        Get
            Return If(CharacterCreation?.NeedsClass, False)
        End Get
    End Property
    Sub New(worldData As WorldData)
        _data = worldData
    End Sub
    Sub New()
        _data = New WorldData
    End Sub
    Public Sub Start() Implements IWorld.Start
        _data.CharacterCreation = New CharacterCreationData
    End Sub
    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements IWorld.AssignAbilities
        CharacterCreation?.AssignAbilities(abilities)
    End Sub
    Public Function CanChooseRace(race As Race) As Boolean Implements IWorld.CanChooseRace
        Return If(CharacterCreation?.CanChooseRace(race), False)
    End Function
    Public Sub RollBackCharacterCreation() Implements IWorld.RollBackCharacterCreation
        If Not IsCreatingCharacter Then
            Return
        End If
        _data.CharacterCreation = Nothing
    End Sub
    Public Sub ChooseRace(race As Race) Implements IWorld.ChooseRace
        CharacterCreation?.ChooseRace(race)
    End Sub
    Public Function CanChooseClass(characterClass As CharacterClass) As Boolean Implements IWorld.CanChooseClass
        Return If(CharacterCreation?.CanChooseClass(characterClass), False)
    End Function
    Public Sub ChooseClass(characterClass As CharacterClass) Implements IWorld.ChooseClass
        CharacterCreation?.ChooseClass(characterClass)
        Initialize()
        FinishCharacter()
    End Sub
    Private Sub FinishCharacter()
        InitializePlayer()
        CharacterCreation.PlaceCharacter(Map(Player.CurrentMap).GetCell(Player.X, Player.Y))
        _data.CharacterCreation = Nothing
    End Sub
    Private Sub InitializePlayer()
        _data.Player = New PlayerData With
            {
                .MapName = InitialPlayerLocation.Item1,
                .MapColumn = InitialPlayerLocation.Item2,
                .MapRow = InitialPlayerLocation.Item3
            }
    End Sub

    Private Sub Initialize()
        _data.Maps.Clear()
        For Each mapFile In MapFiles
            _data.Maps(mapFile.Key) = JsonSerializer.Deserialize(Of MapData)(File.ReadAllText(mapFile.Value))
        Next
    End Sub
    Public Shared Property MapFiles As IReadOnlyDictionary(Of String, String)
    Public Shared Property InitialPlayerLocation As (String, Integer, Integer)
    Public ReadOnly Property PlayerMap As IMap Implements IWorld.PlayerMap
        Get
            Return New Map(_data, _data.Maps(_data.Player.MapName), _data.Player.MapName)
        End Get
    End Property

    Public ReadOnly Property Player As IPlayer Implements IWorld.Player
        Get
            Return New Player(_data, _data.Player)
        End Get
    End Property

    Public ReadOnly Property CharacterCreation As ICharacterCreation Implements IWorld.CharacterCreation
        Get
            If _data.CharacterCreation Is Nothing Then
                Return Nothing
            End If
            Return New CharacterCreation(_data, _data.CharacterCreation)
        End Get
    End Property

    Public ReadOnly Property Map(mapName As String) As IMap Implements IWorld.Map
        Get
            If Not _data.Maps.ContainsKey(mapName) Then
                Return Nothing
            End If
            Return New Map(_data, _data.Maps(mapName), mapName)
        End Get
    End Property
End Class
