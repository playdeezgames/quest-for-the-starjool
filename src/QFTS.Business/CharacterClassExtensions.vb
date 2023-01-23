Imports System.Runtime.CompilerServices

Public Module CharacterClassExtensions
    <Extension>
    Public Function CheckAbilitiesAndRace(characterClass As CharacterClass, abilities As IReadOnlyDictionary(Of Ability, Integer), race As Race) As Boolean
        Select Case characterClass
            Case CharacterClass.Cleric
                Return abilities(Ability.Wisdom) >= 9
            Case CharacterClass.Fighter
                Return abilities(Ability.Strength) >= 9
            Case CharacterClass.FighterMagicUser
                Return abilities(Ability.Strength) >= 9 AndAlso abilities(Ability.Intelligence) >= 9 AndAlso race = Race.Elf
            Case CharacterClass.MagicUser
                Return abilities(Ability.Intelligence) >= 9 AndAlso (race = Race.Human OrElse race = Race.Elf)
            Case CharacterClass.MagicUserThief
                Return abilities(Ability.Dexterity) >= 9 AndAlso abilities(Ability.Intelligence) >= 9 AndAlso race = Race.Elf
            Case CharacterClass.Thief
                Return abilities(Ability.Dexterity) >= 9
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
