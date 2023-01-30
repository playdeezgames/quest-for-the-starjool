Friend Class ShoppeSellState
    Inherits StateBase
    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
    End Sub
    Public Overrides Sub HandleKey(keyName As String)
        Select Case keyName
            Case Escape
                SetState(State.ShoppeWelcome)
        End Select
    End Sub
    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.White, Hue.Black)
        TextGrid.WriteText(0, 0, "Sell", Hue.White, Hue.Black)
    End Sub
End Class
