Friend MustInherit Class StateBase
    Implements IState
    Protected Readonly _stateMachine As IStateMachine
    Protected ReadOnly _textGrid As ITextGrid
    Sub New(stateMachine as IStateMachine, textGrid as ITextGrid)
        _stateMachine = stateMachine
        _textGrid = textGrid
    End Sub
    Public MustOverride Sub Update(elapsed As TimeSpan) implements IState.Update
    Public Overridable Sub OnKeyDown(keyName As String) implements IState.OnKeyDown
    End Sub
    Public Overridable Sub OnKeyUp(keyName as String) implements IState.OnKeyUp
    End Sub
    Public MustOverride Sub Reset() Implements IState.Reset
End Class