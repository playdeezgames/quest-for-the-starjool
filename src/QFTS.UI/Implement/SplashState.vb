Friend Class SplashState
    Inherits StateBase
    private const SecondsRemaining = 5.0
    private _timeRemaining as TimeSpan
    Sub New(stateMachine as IStateMachine, textGrid as ITextGrid)
        MyBase.New(stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.Fill(0,Hue.Black, Hue.Black)
        _textGrid.WriteText(14,14,"Quest for the Starjool!", Hue.White, Hue.Black)
        _timeRemaining = TimeSpan.FromSeconds(SecondsRemaining)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        if _timeRemaining<=elapsed Then
            _timeRemaining=TimeSpan.FromSeconds(0.0)
            'go to next state
        Else
            _timeRemaining -= elapsed
        end if
    End Sub
End Class