Imports System.Runtime.CompilerServices

Public Module AbilityExtensions
    Private ReadOnly bonusTable As IReadOnlyDictionary(Of Integer, Integer) =
        New Dictionary(Of Integer, Integer) From
        {
            {3, -3},
            {4, -2},
            {5, -2},
            {6, -1},
            {7, -1},
            {8, -1},
            {9, 0},
            {10, 0},
            {11, 0},
            {12, 0},
            {13, 1},
            {14, 1},
            {15, 1},
            {16, 2},
            {17, 2},
            {18, 3}
        }
    Function AbilityScoreBonus(score As Integer) As Integer
        Return bonusTable(score)
    End Function
    Private abbreviationTable As IReadOnlyDictionary(Of Ability, String) =
        New Dictionary(Of Ability, String) From
        {
            {Ability.Strength, "STR"},
            {Ability.Dexterity, "DEX"},
            {Ability.Constitution, "CON"},
            {Ability.Intelligence, "INT"},
            {Ability.Wisdom, "WIS"},
            {Ability.Charisma, "CHA"}
        }
    <Extension>
    Function Abbreviation(ability As Ability) As String
        Return abbreviationTable(ability)
    End Function
End Module
