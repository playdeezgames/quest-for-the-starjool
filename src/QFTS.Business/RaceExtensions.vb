Imports System.Runtime.CompilerServices

Public Module RaceExtensions
    <Extension>
    Public Function CheckAbilities(race As Race, abilities As IReadOnlyDictionary(Of Ability, Integer)) As Boolean
        Select Case race
            Case Race.Dwarf
                Return abilities(Ability.Constitution) >= 9 AndAlso abilities(Ability.Charisma) <= 17
            Case Race.Elf
                Return abilities(Ability.Intelligence) >= 9 AndAlso abilities(Ability.Constitution) <= 17
            Case Race.Halfling
                Return abilities(Ability.Dexterity) >= 9 AndAlso abilities(Ability.Strength) <= 17
            Case Race.Human
                Return True
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
