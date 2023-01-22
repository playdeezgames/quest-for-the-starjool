Friend Class MainMenuState
    Inherits StateBase
    Private ReadOnly _menu As IMenu
    Private Const StartText = "Start"
    Private Const QuitText = "Quit"
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, "Main Menu", Hue.White, Hue.Black)

        _menu.Clear()
        _menu.AddItem(StartText)
        _menu.AddItem(QuitText)
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
                'TODO: start game
        End Select
    End Sub
End Class