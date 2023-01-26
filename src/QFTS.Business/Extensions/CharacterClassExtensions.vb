Imports System.Runtime.CompilerServices

Public Module CharacterClassExtensions
    Public ReadOnly AllClasses As IReadOnlyList(Of CharacterClass) = New List(Of CharacterClass) From
        {
            CharacterClass.Cleric,
            CharacterClass.Fighter,
            CharacterClass.FighterMagicUser,
            CharacterClass.MagicUser,
            CharacterClass.MagicUserThief,
            CharacterClass.Thief
        }
    Private hitDieTable As IReadOnlyDictionary(Of CharacterClass, Integer) =
        New Dictionary(Of CharacterClass, Integer) From
        {
            {CharacterClass.Cleric, 6},
            {CharacterClass.Fighter, 8},
            {CharacterClass.FighterMagicUser, 8},
            {CharacterClass.MagicUser, 4},
            {CharacterClass.MagicUserThief, 4},
            {CharacterClass.Thief, 4}
        }
    <Extension>
    Public Function HitDie(characterClass As CharacterClass) As Integer
        Return hitDieTable(characterClass)
    End Function
    Private nameTable As IReadOnlyDictionary(Of CharacterClass, String) =
        New Dictionary(Of CharacterClass, String) From
        {
            {CharacterClass.Cleric, "Cleric"},
            {CharacterClass.Fighter, "Fighter"},
            {CharacterClass.FighterMagicUser, "Fighter/Magic-User"},
            {CharacterClass.MagicUser, "Magic-User"},
            {CharacterClass.MagicUserThief, "Magic-User/Thief"},
            {CharacterClass.Thief, "Thief"}
        }
    <Extension>
    Public Function Name(characterClass As CharacterClass) As String
        Return nameTable(characterClass)
    End Function
    Private checkTable As IReadOnlyDictionary(Of CharacterClass, Func(Of IReadOnlyDictionary(Of Ability, Integer), Race, Boolean)) =
        New Dictionary(Of CharacterClass, Func(Of IReadOnlyDictionary(Of Ability, Integer), Race, Boolean)) From
        {
            {
                CharacterClass.Cleric,
                Function(a, r) a(Ability.Wisdom) >= 9
            },
            {
                CharacterClass.Fighter,
                Function(a, r) a(Ability.Strength) >= 9
            },
            {
                CharacterClass.FighterMagicUser,
                Function(a, r) a(Ability.Strength) >= 9 AndAlso a(Ability.Intelligence) >= 9 AndAlso r = Race.Elf
            },
            {
                CharacterClass.MagicUser,
                Function(a, r) a(Ability.Intelligence) >= 9 AndAlso (r = Race.Human OrElse r = Race.Elf)
            },
            {
                CharacterClass.MagicUserThief,
                Function(a, r) a(Ability.Dexterity) >= 9 AndAlso a(Ability.Intelligence) >= 9 AndAlso r = Race.Elf
            },
            {
                CharacterClass.Thief,
                Function(a, r) a(Ability.Dexterity) >= 9
            }
        }
    <Extension>
    Public Function CheckAbilitiesAndRace(characterClass As CharacterClass, abilities As IReadOnlyDictionary(Of Ability, Integer), race As Race) As Boolean
        Return checkTable(characterClass)(abilities, race)
    End Function
End Module
