Imports System.Runtime.CompilerServices

Public Module AbilityExtensions
    Function AbilityScoreBonus(score As Integer) As Integer
        Select Case score
            Case 3
                Return -3
            Case 4, 5
                Return -2
            Case 6 To 8
                Return -1
            Case 9 To 12
                Return 0
            Case 13 To 15
                Return 1
            Case 16, 17
                Return 2
            Case 18
                Return 3
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function Abbreviation(ability As Ability) As String
        Select Case ability
            Case Ability.Charisma
                Return "CHA"
            Case Ability.Constitution
                Return "CON"
            Case Ability.Dexterity
                Return "DEX"
            Case Ability.Intelligence
                Return "INT"
            Case Ability.Strength
                Return "STR"
            Case Ability.Wisdom
                Return "WIS"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
