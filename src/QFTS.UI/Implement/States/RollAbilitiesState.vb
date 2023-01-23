Friend Class RollAbilitiesState
    Inherits StateBase
    Private _abilities As New Dictionary(Of Ability, Integer)
    Private _menu As IMenu

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        MyBase.New(world, stateMachine, textGrid, random)
        _menu = New Menu(textGrid, 0, 9, Hue.White, Hue.Black)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        _textGrid.WriteText(4, 2, $"{_abilities(Ability.Strength),2}", Hue.White, Hue.Black)
        _textGrid.WriteText(4, 3, $"{_abilities(Ability.Intelligence),2}", Hue.White, Hue.Black)
        _textGrid.WriteText(4, 4, $"{_abilities(Ability.Wisdom),2}", Hue.White, Hue.Black)
        _textGrid.WriteText(4, 5, $"{_abilities(Ability.Dexterity),2}", Hue.White, Hue.Black)
        _textGrid.WriteText(4, 6, $"{_abilities(Ability.Constitution),2}", Hue.White, Hue.Black)
        _textGrid.WriteText(4, 7, $"{_abilities(Ability.Charisma),2}", Hue.White, Hue.Black)
        _menu.Update()
    End Sub

    Private Const AcceptText = "Accept"
    Private Const RerollText = "Re-roll"

    Public Overrides Sub Reset()
        _menu.Clear()
        _menu.AddItem(AcceptText)
        _menu.AddItem(RerollText)
        _menu.AddItem(CancelText)

        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, "Roll Abilities:", Hue.White, Hue.Black)

        _textGrid.WriteText(0, 2, "STR", Hue.White, Hue.Black)
        _textGrid.WriteText(0, 3, "INT", Hue.White, Hue.Black)
        _textGrid.WriteText(0, 4, "WIS", Hue.White, Hue.Black)
        _textGrid.WriteText(0, 5, "DEX", Hue.White, Hue.Black)
        _textGrid.WriteText(0, 6, "CON", Hue.White, Hue.Black)
        _textGrid.WriteText(0, 7, "CHA", Hue.White, Hue.Black)
        RollAbilities()
    End Sub

    Public Overrides Sub OnKeyUp(keyName As String)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Enter
                ActivateMenuItem()
            Case Escape
                _world.RollBackCharacterCreation()
                SetState(State.MainMenu)
        End Select
    End Sub

    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case AcceptText
                _world.AssignAbilities(_abilities)
                SetState(State.InPlay)
            Case RerollText
                RollAbilities()
            Case CancelText
                _world.RollBackCharacterCreation()
                SetState(State.MainMenu)
        End Select
    End Sub

    Private Sub RollAbilities()
        _abilities.Clear()
        _abilities.Add(Ability.Strength, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
        _abilities.Add(Ability.Intelligence, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
        _abilities.Add(Ability.Wisdom, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
        _abilities.Add(Ability.Dexterity, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
        _abilities.Add(Ability.Constitution, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
        _abilities.Add(Ability.Charisma, _random.Next(1, 7) + _random.Next(1, 7) + _random.Next(1, 7))
    End Sub
End Class
