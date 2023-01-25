Public Class World
    Implements IWorld
    Private _worldData As WorldData

    Public ReadOnly Property CanStart As Boolean Implements IWorld.CanStart
        Get
            Return Not CanContinue
        End Get
    End Property

    Public ReadOnly Property CanContinue As Boolean Implements IWorld.CanContinue
        Get
            Return _worldData.CharacterCreation IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property CanAbandon As Boolean Implements IWorld.CanAbandon
        Get
            Return CanContinue
        End Get
    End Property

    Public ReadOnly Property IsCreatingCharacter As Boolean Implements IWorld.IsCreatingCharacter
        Get
            Return _worldData.CharacterCreation IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property NeedsAbilityScores As Boolean Implements IWorld.NeedsAbilityScores
        Get
            Return IsCreatingCharacter AndAlso _worldData.CharacterCreation.Abilities Is Nothing
        End Get
    End Property

    Public ReadOnly Property NeedsRace As Boolean Implements IWorld.NeedsRace
        Get
            If _worldData.CharacterCreation Is Nothing Then
                Return False
            End If
            Return _worldData.CharacterCreation.Race Is Nothing
        End Get
    End Property

    Public ReadOnly Property NeedsClass As Boolean Implements IWorld.NeedsClass
        Get
            If _worldData.CharacterCreation Is Nothing Then
                Return False
            End If
            Return _worldData.CharacterCreation.CharacterClass Is Nothing
        End Get
    End Property

    Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
    Sub New()
        _worldData = New WorldData
    End Sub

    Public Sub Start() Implements IWorld.Start
        _worldData.CharacterCreation = New CharacterCreationData
    End Sub

    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements IWorld.AssignAbilities
        If _worldData.CharacterCreation Is Nothing Then
            Return
        End If
        _worldData.CharacterCreation.Abilities = abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Sub

    Public Function CanChooseRace(race As Race) As Boolean Implements IWorld.CanChooseRace
        If Not NeedsRace Then
            Return False
        End If
        Return race.CheckAbilities(_worldData.CharacterCreation.Abilities)
    End Function

    Public Sub RollBackCharacterCreation() Implements IWorld.RollBackCharacterCreation
        If Not IsCreatingCharacter Then
            Return
        End If
        _worldData.CharacterCreation = Nothing
    End Sub

    Public Sub ChooseRace(race As Race) Implements IWorld.ChooseRace
        If Not NeedsRace Then
            Return
        End If
        _worldData.CharacterCreation.Race = race
    End Sub

    Public Function CanChooseClass(characterClass As CharacterClass) As Boolean Implements IWorld.CanChooseClass
        If Not NeedsClass Then
            Return False
        End If
        Return characterClass.CheckAbilitiesAndRace(_worldData.CharacterCreation.Abilities, _worldData.CharacterCreation.Race.Value)
    End Function

    Public Sub ChooseClass(characterClass As CharacterClass, random As Random) Implements IWorld.ChooseClass
        If Not NeedsClass Then
            Return
        End If
        _worldData.CharacterCreation.CharacterClass = characterClass
        Initialize()
        FinishCharacter(random)
    End Sub

    Private Sub FinishCharacter(random As Random)
        Dim hitDie = Math.Min(_worldData.CharacterCreation.CharacterClass.Value.HitDie, _worldData.CharacterCreation.Race.Value.MaximumHitDie)
        Dim hitPoints = 1 + Math.Max(0, random.Next(hitDie) + AbilityScoreBonus(_worldData.CharacterCreation.Abilities(Ability.Constitution)))
        Dim gold As Decimal = (random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7)) * 10D
        'create actual character data
        'place character on map
        'set player data
        'remove character creation data
    End Sub

    Private Sub Initialize()
        _worldData.Maps.Clear()
        For Each mapFile In MapFiles
            _worldData.Maps(mapFile.Key) = JsonSerializer.Deserialize(Of MapData)(File.ReadAllText(mapFile.Value))
        Next
    End Sub

    Public Shared Property MapFiles As IReadOnlyDictionary(Of String, String)
End Class
