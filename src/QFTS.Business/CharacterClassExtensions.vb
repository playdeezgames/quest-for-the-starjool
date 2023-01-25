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
    <Extension>
    Public Function HitDie(characterClass As CharacterClass) As Integer
        Select Case characterClass
            Case CharacterClass.Cleric
                Return 6
            Case CharacterClass.Fighter, CharacterClass.FighterMagicUser
                Return 8
            Case CharacterClass.MagicUser, CharacterClass.MagicUserThief, CharacterClass.Thief
                Return 4
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
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
    <Extension>
    Public Function Name(characterClass As CharacterClass) As String
        Select Case characterClass
            Case CharacterClass.Cleric
                Return "Cleric"
            Case CharacterClass.Fighter
                Return "Fighter"
            Case CharacterClass.FighterMagicUser
                Return "Fighter/Magic-User"
            Case CharacterClass.MagicUser
                Return "Magic-User"
            Case CharacterClass.MagicUserThief
                Return "Magic-User/Thief"
            Case CharacterClass.Thief
                Return "Thief"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
