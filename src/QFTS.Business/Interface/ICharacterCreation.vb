Public Interface ICharacterCreation
    ReadOnly Property NeedsAbilityScores As Boolean
    ReadOnly Property NeedsRace As Boolean
    ReadOnly Property NeedsClass As Boolean
    Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer))
    Function CanChooseRace(race As Race) As Boolean
    Sub ChooseRace(race As Race)
    Function CanChooseClass(characterClass As CharacterClass) As Boolean
    Sub ChooseClass(characterClass As CharacterClass)
    Function RollHitPoints() As Integer
    Function RollMoney() As Decimal
    Sub PlaceCharacter(mapCell As IMapCell)
    ReadOnly Property Race() As Race
    ReadOnly Property CharacterClass() As CharacterClass
    ReadOnly Property Abilities As IReadOnlyDictionary(Of Ability, Integer)
    ReadOnly Property HitDie As Integer
End Interface
