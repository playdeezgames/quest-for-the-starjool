Public Class StateMachine
    Implements IStateMachine
    Private ReadOnly _textGrid As ITextGrid
    Private _x As Integer
    Private _y As Integer
    Sub New(textGrid As ITextGrid)
        _textGrid = textGrid
        _x = 0
        _y = 0
    End Sub

    Public Sub Update(elapsedGameTime As TimeSpan) Implements IStateMachine.Update
        _textGrid.GetCell(_x, _y).Character = 2
        _textGrid.GetCell(_x, _y).ForegroundHue = Hue.White
        _textGrid.GetCell(_x, _y).BackgroundHue = Hue.Black
    End Sub

    Public Sub OnKeyUp(keyName As String) Implements IStateMachine.OnKeyUp

    End Sub

    Public Sub OnKeyDown(keyName As String) Implements IStateMachine.OnKeyDown
        Select Case keyName
            Case Up
                _y -= 1
            Case Down
                _y += 1
            Case Left
                _x -= 1
            Case Right
                _x += 1
        End Select
    End Sub
End Class
