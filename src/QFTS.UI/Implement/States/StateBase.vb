Friend MustInherit Class StateBase
    Implements IState
    Private ReadOnly _stateMachine As IStateMachine
    Protected ReadOnly _textGrid As ITextGrid
    Protected ReadOnly _world As IWorld
    Protected ReadOnly _random As Random
    Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        _world = world
        _stateMachine = stateMachine
        _textGrid = textGrid
        _random = random
    End Sub
    Public MustOverride Sub Update(elapsed As TimeSpan) Implements IState.Update
    Public Overridable Sub OnKeyDown(keyName As String) Implements IState.OnKeyDown
    End Sub
    Public Overridable Sub OnKeyUp(keyName As String) Implements IState.OnKeyUp
    End Sub
    Public MustOverride Sub Reset() Implements IState.Reset

    Public Sub Quit() Implements IState.Quit
        _stateMachine.Quit()
    End Sub

    Public Sub SetState(state As State) Implements IState.SetState
        _stateMachine.SetState(state)
    End Sub
End Class