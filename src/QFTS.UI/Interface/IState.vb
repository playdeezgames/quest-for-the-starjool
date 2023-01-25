Public Interface IState
    Sub Update(elapsed As TimeSpan)
    Sub OnKeyUp(keyName As String)
    Sub Reset()
    Sub Quit()
    Sub SetState(state As State)
End Interface