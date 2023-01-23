Friend Class ChooseRaceState
    Inherits StateBase
    Private _menu As IMenu

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        MyBase.New(world, stateMachine, textGrid, random)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        _menu.Update()
    End Sub

    Public Overrides Sub OnKeyUp(keyName As String)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Escape
                _world.RollBackCharacterCreation()
                SetState(State.MainMenu)
            Case Enter
                ActivateMenuItem()
        End Select
    End Sub

    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case DwarfText
            Case ElfText
            Case HalflingText
            Case HumanText
            Case CancelText
                _world.RollBackCharacterCreation()
                SetState(State.MainMenu)
        End Select
    End Sub

    Private Const DwarfText = "Dwarf"
    Private Const ElfText = "Elf"
    Private Const HalflingText = "Halfling"
    Private Const HumanText = "Human"

    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, "Choose Race:", Hue.White, Hue.Black)
        _menu.Clear()
        If _world.CanChooseRace(Race.Dwarf) Then
            _menu.AddItem(DwarfText)
        End If
        If _world.CanChooseRace(Race.Elf) Then
            _menu.AddItem(ElfText)
        End If
        If _world.CanChooseRace(Race.Halfling) Then
            _menu.AddItem(HalflingText)
        End If
        If _world.CanChooseRace(Race.Human) Then
            _menu.AddItem(HumanText)
        End If
        _menu.AddItem(CancelText)
    End Sub
End Class
