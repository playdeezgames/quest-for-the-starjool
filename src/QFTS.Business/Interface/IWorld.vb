Public Interface IWorld
    ReadOnly Property CanStart As Boolean
    ReadOnly Property CanContinue As Boolean
    ReadOnly Property CanAbandon As Boolean
    ReadOnly Property NeedsClass As Boolean
    ReadOnly Property NeedsRace As Boolean
    ReadOnly Property IsCreatingCharacter As Boolean
    ReadOnly Property NeedsAbilityScores As Boolean
    Sub Start()
    Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer))
    Function CanChooseRace(race As Race) As Boolean
    Sub RollBackCharacterCreation()
    Sub ChooseRace(race As Race)
    Function CanChooseClass(characterClass As CharacterClass) As Boolean
    Sub ChooseClass(characterClass As CharacterClass)
    ReadOnly Property PlayerMap As IMap
    ReadOnly Property Player As IPlayer
    ReadOnly Property CharacterCreation As ICharacterCreation
    ReadOnly Property Map(mapName As String) As IMap
End Interface
