Public Class StateMachine
    Implements IStateMachine
    Private ReadOnly _world As IWorld
    Private ReadOnly _textGrid As ITextGrid
    Private ReadOnly _states As New Dictionary(Of State, IState)
    Private ReadOnly _quit As Action
    Sub New(world As IWorld, textGrid As ITextGrid, quit As Action)
        _world = world
        _quit = quit
        _textGrid = textGrid
        _state = State.None
        _states.Add(State.Splash, New SplashState(world, Me, _textGrid))
        _states.Add(State.MainMenu, New MainMenuState(world, Me, _textGrid))
        _states.Add(State.ConfirmQuit, New ConfirmQuitState(world, Me, _textGrid))
        _states.Add(State.InPlay, New InPlayState(world, Me, _textGrid))
        _states.Add(State.RollAbilities, New RollAbilitiesState(world, Me, _textGrid))
        _states.Add(State.ChooseRace, New ChooseRaceState(world, Me, _textGrid))
        _states.Add(State.ChooseClass, New ChooseClassState(world, Me, _textGrid))
        _states.Add(State.Navigation, New NavigationState(world, Me, _textGrid))
        _states.Add(State.ShoppeWelcome, New ShoppeWelcomeState(world, Me, _textGrid))
        State = State.Splash
    End Sub
    Public Sub Update(elapsed As TimeSpan) Implements IStateMachine.Update
        _states(_state).Update(elapsed)
    End Sub
    Public Sub HandleKey(keyName As String) Implements IStateMachine.HandleKey
        _states(_state).HandleKey(keyName)
    End Sub
    Public Sub Reset() Implements IStateMachine.Reset
        For Each entry In _states
            entry.Value.Reset()
        Next
    End Sub
    Public Sub Quit() Implements IState.Quit
        _quit()
    End Sub
    Public Sub SetState(state As State) Implements IState.SetState
        If state = _state Then
            Return
        End If
        _state = state
        _states(_state).Reset()
    End Sub
    Private _state As State
    Public Property State As State Implements IStateMachine.State
        Get
            Return _state
        End Get
        Set(value As State)
            SetState(value)
        End Set
    End Property
End Class
