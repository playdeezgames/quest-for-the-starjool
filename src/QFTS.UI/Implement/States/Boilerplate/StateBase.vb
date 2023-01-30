Friend MustInherit Class StateBase
    Implements IState
    Private ReadOnly _stateMachine As IStateMachine
    Private ReadOnly _textGrid As ITextGrid
    Private ReadOnly _world As IWorld
    Protected ReadOnly Property World As IWorld
        Get
            Return _world
        End Get
    End Property
    Protected ReadOnly Property TextGrid As ITextGrid
        Get
            Return _textGrid
        End Get
    End Property
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        _world = world
        _stateMachine = stateMachine
        _textGrid = textGrid
    End Sub
    Public MustOverride Sub Update(elapsed As TimeSpan) Implements IState.Update
    Public Overridable Sub HandleKey(keyName As String) Implements IState.HandleKey
    End Sub
    Public MustOverride Sub Reset() Implements IState.Reset
    Public Sub Quit() Implements IState.Quit
        _stateMachine.Quit()
    End Sub
    Public Sub SetState(state As State) Implements IState.SetState
        _stateMachine.SetState(state)
    End Sub
End Class