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

    Public ReadOnly Property HitDie As Integer Implements ICharacterCreation.HitDie
        Get
            If NeedsRace OrElse NeedsClass Then
                Return 0
            End If
            Return Math.Min(_data.CharacterClass.Value.HitDie, _data.Race.Value.MaximumHitDie)
        End Get
    End Property

    Public ReadOnly Property Race As Race Implements ICharacterCreation.Race
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property CharacterClass As CharacterClass Implements ICharacterCreation.CharacterClass
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property Abilities As IReadOnlyDictionary(Of Ability, Integer) Implements ICharacterCreation.Abilities
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements ICharacterCreation.AssignAbilities
        _data.Abilities = abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Sub

    Public Sub ChooseRace(race As Race) Implements ICharacterCreation.ChooseRace
        _data.Race = race
    End Sub

    Public Function CanChooseRace(race As Race) As Boolean Implements ICharacterCreation.CanChooseRace
        Return NeedsRace AndAlso race.CheckAbilities(_data.Abilities)
    End Function

    Public Function CanChooseClass(characterClass As CharacterClass) As Boolean Implements ICharacterCreation.CanChooseClass
        Return NeedsClass AndAlso characterClass.CheckAbilitiesAndRace(_data.Abilities, _data.Race.Value)
    End Function

    Public Sub ChooseClass(characterClass As CharacterClass) Implements ICharacterCreation.ChooseClass
        _data.CharacterClass = characterClass
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
