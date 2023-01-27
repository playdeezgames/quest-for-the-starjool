Imports System.Runtime.CompilerServices

Public Module RaceExtensions
    Public ReadOnly AllRaces As IReadOnlyList(Of Race) =
        New List(Of Race) From
        {
            Race.Dwarf,
            Race.Elf,
            Race.Halfling,
            Race.Human
        }
    Private ReadOnly hitDieTable As IReadOnlyDictionary(Of Race, Integer) =
        New Dictionary(Of Race, Integer) From
        {
            {Race.Dwarf, 8},
            {Race.Elf, 6},
            {Race.Halfling, 6},
            {Race.Human, 8}
        }
    <Extension>
    Public Function MaximumHitDie(race As Race) As Integer
        Return hitDieTable(race)
    End Function
    Private ReadOnly checkTable As IReadOnlyDictionary(Of Race, Func(Of IReadOnlyDictionary(Of Ability, Integer), Boolean)) =
        New Dictionary(Of Race, Func(Of IReadOnlyDictionary(Of Ability, Integer), Boolean)) From
        {
            {Race.Dwarf, Function(a) a(Ability.Constitution) >= 9 AndAlso a(Ability.Charisma) <= 17},
            {Race.Elf, Function(a) a(Ability.Intelligence) >= 9 AndAlso a(Ability.Constitution) <= 17},
            {Race.Halfling, Function(a) a(Ability.Dexterity) >= 9 AndAlso a(Ability.Strength) <= 17},
            {Race.Human, Function(a) True}
        }
    <Extension>
    Public Function CheckAbilities(race As Race, abilities As IReadOnlyDictionary(Of Ability, Integer)) As Boolean
        Return checkTable(race)(abilities)
    End Function
    Private ReadOnly nameTable As IReadOnlyDictionary(Of Race, String) =
        New Dictionary(Of Race, String) From
        {
            {Race.Dwarf, "Dwarf"},
            {Race.Elf, "Elf"},
            {Race.Halfling, "Halfling"},
            {Race.Human, "Human"}
        }
    <Extension>
    Public Function Name(race As Race) As String
        Return Name(race)
    End Function
End Module
