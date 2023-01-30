﻿Friend Class ConfirmQuitState
    Inherits StateBase
    Private ReadOnly _menu As Menu
    Public Sub New(world As IWorld, stateMachine As StateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        _menu.Update()
    End Sub
    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.Black, Hue.Black)
        TextGrid.WriteText(0, 0, ConfirmQuitHeader, Hue.Red, Hue.Black)
        _menu.Clear()
        _menu.AddItem(NoText)
        _menu.AddItem(YesText)
    End Sub
    Public Overrides Sub HandleKey(keyName As String)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Escape
                SetState(State.MainMenu)
            Case Enter
                ActivateMenuItem()
        End Select
    End Sub
    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case YesText
                Quit()
            Case NoText
                SetState(State.MainMenu)
        End Select
    End Sub
End Class