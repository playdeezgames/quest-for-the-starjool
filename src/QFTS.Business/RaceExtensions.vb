Imports System.Runtime.CompilerServices

Public Module RaceExtensions
    Public ReadOnly AllRaces As IReadOnlyList(Of Race) = New List(Of Race) From {Race.Dwarf, Race.Elf, Race.Halfling, Race.Human}
    <Extension>
    Public Function MaximumHitDie(race As Race) As Integer
        Select Case race
            Case Race.Dwarf, Race.Human
                Return 8
            Case Race.Halfling, Race.Elf
                Return 6
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
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
    <Extension>
    Public Function Name(race As Race) As String
        Select Case race
            Case Race.Dwarf
                Return "Dwarf"
            Case Race.Elf
                Return "Elf"
            Case Race.Halfling
                Return "Halfling"
            Case Race.Human
                Return "Human"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
