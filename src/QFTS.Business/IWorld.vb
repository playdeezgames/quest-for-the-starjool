Public Interface IWorld
    ReadOnly Property CanStart As Boolean
    ReadOnly Property CanContinue As Boolean
    ReadOnly Property CanAbandon As Boolean
    Sub Start()
    Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer))
    Function CanChooseRace(race As Race) As Boolean
    Sub RollBackCharacterCreation()
    ReadOnly Property NeedRace As Boolean
    ReadOnly Property IsCreatingCharacter As Boolean
    ReadOnly Property NeedsAbilityScores As Boolean
End Interface
