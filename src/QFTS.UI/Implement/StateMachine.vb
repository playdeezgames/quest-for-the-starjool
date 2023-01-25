Imports QFTS.Business

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
        Dim random As New Random
        _states.Add(State.Splash, New SplashState(world, Me, _textGrid, random))
        _states.Add(State.MainMenu, New MainMenuState(world, Me, _textGrid, random))
        _states.Add(State.ConfirmQuit, New ConfirmQuitState(world, Me, _textGrid, random))
        _states.Add(State.InPlay, New InPlayState(world, Me, _textGrid, random))
        _states.Add(State.RollAbilities, New RollAbilitiesState(world, Me, _textGrid, random))
        _states.Add(State.ChooseRace, New ChooseRaceState(world, Me, _textGrid, random))
        _states.Add(State.ChooseClass, New ChooseClassState(world, Me, _textGrid, random))
        _states.Add(State.Navigation, New NavigationState(world, Me, _textGrid, random))
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
    Public Property State as State Implements IStateMachine.State
        Get
            return _state            
        End Get
        Set(value As State)
            SetState(value)
        End Set
    End Property
End Class
