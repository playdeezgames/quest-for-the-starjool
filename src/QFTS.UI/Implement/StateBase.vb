Friend MustInherit Class StateBase
    Implements IState
    Public MustOverride Sub Update(elapsed As TimeSpan) implements IState.Update
    Public MustOverride Sub OnKeyDown(keyName As String) implements IState.OnKeyDown
    Public MustOverride Sub OnKeyUp(keyName as String) implements IState.OnKeyUp
    Public MustOverride Sub Reset() Implements IState.Reset
End Class