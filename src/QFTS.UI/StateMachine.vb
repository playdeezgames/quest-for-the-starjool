Public Class StateMachine
    Implements IStateMachine
    Private ReadOnly _textGrid As ITextGrid
    Sub New(textGrid As ITextGrid)
        _textGrid = textGrid
    End Sub

    Public Sub Update(elapsedGameTime As TimeSpan) Implements IStateMachine.Update
        _textGrid.GetCell(0, 0).Character = 2
        _textGrid.GetCell(0, 0).ForegroundHue = Hue.White
        _textGrid.GetCell(0, 0).BackgroundHue = Hue.Black
    End Sub
End Class
