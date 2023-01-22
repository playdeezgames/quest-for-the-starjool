Friend Class SplashState
    Inherits StateBase
    private const SecondsRemaining = 5.0
    private _timeRemaining as TimeSpan
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0,Hue.Black, Hue.Black)
        _textGrid.WriteText(14,14,"Quest for the Starjool!", Hue.White, Hue.Black)
        _timeRemaining = TimeSpan.FromSeconds(SecondsRemaining)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        if _timeRemaining<=elapsed Then
            SetState(State.MainMenu)
        Else
            _timeRemaining -= elapsed
        end if
    End Sub
    Public Overrides Sub OnKeyUp(keyName as String)
        SetState(State.MainMenu)
    End Sub
End Class