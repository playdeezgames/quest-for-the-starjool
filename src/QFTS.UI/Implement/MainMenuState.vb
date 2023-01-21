Friend Class MainMenuState
    Inherits StateBase
    Sub New(stateMachine as IStateMachine, textGrid as ITextGrid)
        MyBase.New(stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0,Hue.Black, Hue.Black)
        _textGrid.WriteText(0,0,"Main Menu",Hue.White, Hue.Black)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
    End Sub
End Class