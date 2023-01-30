Friend Class CharacterCreation
    Inherits Thingie(Of CharacterCreationData)
    Implements ICharacterCreation
    Public Sub New(worldData As WorldData, characterCreation As CharacterCreationData)
        MyBase.New(worldData, characterCreation)
    End Sub
    Public ReadOnly Property NeedsAbilityScores As Boolean Implements ICharacterCreation.NeedsAbilityScores
        Get
            Return Data.Abilities Is Nothing
        End Get
    End Property
    Public ReadOnly Property NeedsRace As Boolean Implements ICharacterCreation.NeedsRace
        Get
            Return Not Data.Race.HasValue
        End Get
    End Property
    Public ReadOnly Property NeedsClass As Boolean Implements ICharacterCreation.NeedsClass
        Get
            Return Not Data.CharacterClass.HasValue
        End Get
    End Property
    Public ReadOnly Property HitDie As Integer Implements ICharacterCreation.HitDie
        Get
            If NeedsRace OrElse NeedsClass Then
                Return 0
            End If
            Return Math.Min(Data.CharacterClass.Value.HitDie, Data.Race.Value.MaximumHitDie)
        End Get
    End Property
    Public ReadOnly Property Race As Race Implements ICharacterCreation.Race
        Get
            Return Data.Race.Value
        End Get
    End Property
    Public ReadOnly Property CharacterClass As CharacterClass Implements ICharacterCreation.CharacterClass
        Get
            Return Data.CharacterClass.Value
        End Get
    End Property
    Public ReadOnly Property Abilities As IReadOnlyDictionary(Of Ability, Integer) Implements ICharacterCreation.Abilities
        Get
            Return Data.Abilities
        End Get
    End Property
    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements ICharacterCreation.AssignAbilities
        Data.Abilities = abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Sub
    Public Sub ChooseRace(race As Race) Implements ICharacterCreation.ChooseRace
        Data.Race = race
    End Sub
    Public Function CanChooseRace(race As Race) As Boolean Implements ICharacterCreation.CanChooseRace
        Return NeedsRace AndAlso race.CheckAbilities(Data.Abilities)
    End Function
    Public Function CanChooseClass(characterClass As CharacterClass) As Boolean Implements ICharacterCreation.CanChooseClass
        Return NeedsClass AndAlso characterClass.CheckAbilitiesAndRace(Data.Abilities, Data.Race.Value)
    End Function
    Public Sub ChooseClass(characterClass As CharacterClass) Implements ICharacterCreation.ChooseClass
        Data.CharacterClass = characterClass
    End Sub
    Public Function RollHitPoints() As Integer Implements ICharacterCreation.RollHitPoints
        Return 1 + Math.Max(0, RNG.FromRange(1, HitDie) + AbilityScoreBonus(Abilities(Ability.Constitution)))
    End Function
    Public Function RollMoney() As Decimal Implements ICharacterCreation.RollMoney
        Return (RNG.FromRange(1, 6) + RNG.FromRange(1, 6) + RNG.FromRange(1, 6)) * 10D
    End Function
    Public Sub PlaceCharacter(mapCell As IMapCell) Implements ICharacterCreation.PlaceCharacter
        mapCell.Character = New Character(Nothing, New CharacterData With
            {
                .Token = TokenType.Player,
                .Abilities = Abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value),
                .Race = Race,
                .CharacterClass = CharacterClass,
                .HitPoints = RollHitPoints(),
                .Gold = RollMoney()
            })
    End Sub
End Class
