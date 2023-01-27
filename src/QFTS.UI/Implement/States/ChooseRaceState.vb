Friend Class ChooseRaceState
    Inherits StateBase
    Private ReadOnly _menu As IMenu

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        _menu.Update()
    End Sub

    Public Overrides Sub HandleKey(keyName As String)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Escape
                RollBackCharacterCreation()
            Case Enter
                ActivateMenuItem()
        End Select
    End Sub

    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case CancelText
                RollBackCharacterCreation()
            Case Else
                ChooseRace(AllRaces.Single(Function(x) x.Name = _menu.CurrentItem))
        End Select
    End Sub

    Private Sub RollBackCharacterCreation()
        _world.RollBackCharacterCreation()
        SetState(State.MainMenu)
    End Sub

    Private Sub ChooseRace(race As Race)
        _world.ChooseRace(race)
        SetState(State.InPlay)
    End Sub

    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, ChooseRaceHeader, Hue.White, Hue.Black)
        _menu.Clear()
        For Each race In AllRaces
            If _world.CanChooseRace(race) Then
                _menu.AddItem(race.Name)
            End If
        Next
        _menu.AddItem(CancelText)
    End Sub
End Class
