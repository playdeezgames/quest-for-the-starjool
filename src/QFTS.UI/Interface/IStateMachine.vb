Public Interface IStateMachine
    Sub Update(elapsedGameTime As TimeSpan)
    Sub OnKeyUp(keyName As String)
    Sub OnKeyDown(keyName As String)
End Interface
