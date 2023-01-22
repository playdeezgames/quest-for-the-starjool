Public Class StateMachine
    Implements IStateMachine
    Private ReadOnly _textGrid As ITextGrid
    private Readonly _states As New Dictionary(Of State, IState)
    Sub New(textGrid As ITextGrid)
        _textGrid = textGrid
        _state = State.None
        _states.Add(State.Splash, New SplashState(Me, _textGrid))
        _states.Add(State.MainMenu, New MainMenuState(Me, _textGrid))
        _states.Add(State.ConfirmQuit, New ConfirmQuitState(Me, _textGrid))
        State = State.Splash
    End Sub

    Public Sub Update(elapsed As TimeSpan) Implements IStateMachine.Update
        _states(_state).Update(elapsed)
        '_textGrid.Fill(1,0,51,1,&hcd,Hue.Brown, Hue.Black)
        '_textGrid.Fill(1,29,51,1,&hcd,Hue.Brown, Hue.Black)
        '_textGrid.Fill(1,24,51,1,&hcd,Hue.Brown, Hue.Black)
        '_textGrid.Fill(0,1,1,23,&hba,Hue.Brown, Hue.Black)
        '_textGrid.Fill(52,1,1,23,&hba,Hue.Brown, Hue.Black)
        '_textGrid.Fill(0,25,1,4,&hba,Hue.Brown, Hue.Black)
        '_textGrid.Fill(52,25,1,4,&hba,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(0,0).Plot(&hc9,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(52,0).Plot(&hbb,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(0,24).Plot(&hcc,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(52,24).Plot(&hb9,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(0,29).Plot(&hc8,Hue.Brown, Hue.Black)
        '_textGrid.GetCell(52,29).Plot(&hbc,Hue.Brown, Hue.Black)
    End Sub

    Public Sub OnKeyUp(keyName As String) Implements IStateMachine.OnKeyUp
        _states(_state).OnKeyUp(keyName)
    End Sub

    Public Sub OnKeyDown(keyName As String) Implements IStateMachine.OnKeyDown
        _states(_state).OnKeyDown(keyName)
    End Sub

    public Sub Reset() Implements IStateMachine.Reset
        For Each entry in _states
            entry.Value.Reset()
        Next
    End Sub

    Private _state as State
    Public Property State as State Implements IStateMachine.State
        Get
            return _state            
        End Get
        Set(value As State)
            if value = _state Then
                return 
            end if
            _state = value
            _states(_state).Reset()
        End Set
    End Property
End Class
