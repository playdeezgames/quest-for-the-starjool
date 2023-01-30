Friend Class ShoppeWelcomeState
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
            Case Enter
                ActivateMenuItem()
            Case Escape
                LeaveShoppe()
        End Select
    End Sub
    Private Sub LeaveShoppe()
        World.Player.LeaveShoppe()
        SetState(State.InPlay)
    End Sub
    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case LeaveText
                LeaveShoppe()
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.Black, Hue.Black)
        TextGrid.WriteText(0, 0, World.Player.Shoppe.Name, Hue.White, Hue.Black)
        _menu.Clear()
        _menu.AddItem(LeaveText)
    End Sub
End Class
