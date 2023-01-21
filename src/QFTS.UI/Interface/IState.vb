Public Interface IState
    Sub Update(elapsed As TimeSpan)
    Sub OnKeyUp(keyName As String)
    Sub OnKeyDown(keyName As String)
    Sub Reset()
End Interface