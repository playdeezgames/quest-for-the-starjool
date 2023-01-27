Friend Class CharacterCreation
    Implements ICharacterCreation
    Private _worldData As WorldData
    Private _data As CharacterCreationData
    Public Sub New(worldData As WorldData, characterCreation As CharacterCreationData)
        _worldData = worldData
        _data = characterCreation
    End Sub

    Public ReadOnly Property NeedsAbilityScores As Boolean Implements ICharacterCreation.NeedsAbilityScores
        Get
            Return _data.Abilities Is Nothing
        End Get
    End Property

    Public ReadOnly Property NeedsRace As Boolean Implements ICharacterCreation.NeedsRace
        Get
            Return Not _data.Race.HasValue
        End Get
    End Property

    Public ReadOnly Property NeedsClass As Boolean Implements ICharacterCreation.NeedsClass
        Get
            Return Not _data.CharacterClass.HasValue
        End Get
    End Property

    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements ICharacterCreation.AssignAbilities
        _data.Abilities = abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Sub
End Class
