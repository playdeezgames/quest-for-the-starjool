Friend Class SplashState
    Inherits StateBase
    Private Const SecondsRemaining = SplashDuration
    Private _timeRemaining as TimeSpan
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub
    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.Black, Hue.Black)
        TextGrid.WriteText((GridColumns - Title.Length) \ 2, GridRows \ 2, Title, Hue.White, Hue.Black)
        _timeRemaining = TimeSpan.FromSeconds(SecondsRemaining)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        if _timeRemaining<=elapsed Then
            SetState(State.MainMenu)
        Else
            _timeRemaining -= elapsed
        end if
    End Sub
    Public Overrides Sub HandleKey(keyName As String)
        SetState(State.MainMenu)
    End Sub
End Class