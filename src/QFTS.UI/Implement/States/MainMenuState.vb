Friend Class MainMenuState
    Inherits StateBase
    Private ReadOnly _menuItems As New List(Of String)
    Private _menuItemIndex As Integer
    Private Const StartText = "Start"
    Private Const QuitText = "Quit"
    Sub New(stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, "Main Menu", Hue.White, Hue.Black)
        _menuItems.Clear()
        _menuItems.Add(StartText)
        _menuItems.Add(QuitText)
        _menuItemIndex = 0
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        Dim index = 0
        For Each menuItem In _menuItems
            If index = _menuItemIndex Then
                _textGrid.WriteText(0, index + 2, menuItem, Hue.Black, Hue.White)
            Else
                _textGrid.WriteText(0, index + 2, menuItem, Hue.White, Hue.Black)
            End If
            index += 1
        Next
    End Sub
    Public Overrides Sub OnKeyUp(keyName As String)
        Select Case keyName
            Case Up
                _menuItemIndex = (_menuItemIndex + _menuItems.Count - 1) Mod _menuItems.Count
            Case Down
                _menuItemIndex = (_menuItemIndex + 1) Mod _menuItems.Count
            Case Escape
                SetState(State.ConfirmQuit)
            Case Enter
                ActivateMenuItem()
        End Select
    End Sub
    Private Sub ActivateMenuItem()
        Select Case _menuItems(_menuItemIndex)
            Case QuitText
                SetState(State.ConfirmQuit)
            Case StartText
                'TODO: start game
        End Select
    End Sub
End Class