Public Interface ICharacterCreation
    ReadOnly Property NeedsAbilityScores As Boolean
    ReadOnly Property NeedsRace As Boolean
    ReadOnly Property NeedsClass As Boolean
    Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer))
End Interface
