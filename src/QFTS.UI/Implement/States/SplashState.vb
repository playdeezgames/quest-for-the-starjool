Friend Class SplashState
    Inherits StateBase
    Private Const SecondsRemaining = SplashDuration
    Private _timeRemaining as TimeSpan
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        MyBase.New(world, stateMachine, textGrid, random)
    End Sub
    Public Overrides Sub Reset()
        _textGrid.FillAll(0,Hue.Black, Hue.Black)
        _textGrid.WriteText((GridColumns - Title.Length) \ 2, GridRows \ 2, Title, Hue.White, Hue.Black)
        _timeRemaining = TimeSpan.FromSeconds(SecondsRemaining)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        if _timeRemaining<=elapsed Then
            SetState(State.MainMenu)
        Else
            _timeRemaining -= elapsed
        end if
    End Sub
    Public Overrides Sub OnKeyUp(keyName As String)
        SetState(State.MainMenu)
    End Sub
End Class