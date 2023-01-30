Friend Class MainMenuState
    Inherits StateBase
    Private ReadOnly _menu As IMenu
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, MainMenuHeader, Hue.White, Hue.Black)

        _menu.Clear()
        If World.CanStart Then
            _menu.AddItem(StartText)
        End If
        If World.CanContinue Then
            _menu.AddItem(ContinueGame)
        End If
        If World.CanAbandon Then
            _menu.AddItem(AbandonText)
        End If
        _menu.AddItem(QuitText)
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
                SetState(State.ConfirmQuit)
            Case Enter
                ActivateMenuItem()
        End Select
    End Sub
    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case QuitText
                SetState(State.ConfirmQuit)
            Case StartText
                World.Start()
                SetState(State.InPlay)
            Case ContinueGame
                SetState(State.InPlay)
            Case AbandonText
                'TODO: confirm abandon
        End Select
    End Sub
End Class