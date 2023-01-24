Imports System.Runtime.CompilerServices

Public Module AbilityExtensions
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
