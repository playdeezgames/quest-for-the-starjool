Friend Class SplashState
    Inherits StateBase
    Sub New(stateMachine as IStateMachine, textGrid as ITextGrid)
        MyBase.New(stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.Fill(0,Hue.Black, Hue.Black)
        _textGrid.WriteText(14,14,"Quest for the Starjool!", Hue.White, Hue.Black)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
    End Sub
End Class