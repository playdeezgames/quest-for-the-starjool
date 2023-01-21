Public Class StateMachine
    Implements IStateMachine
    Private ReadOnly _textGrid As ITextGrid
    private const _minimumX=1
    private const _minimumY=1
    private const _maximumX=51
    private const _maximumY=23
    Private _x As Integer
    Private _y As Integer
    Sub New(textGrid As ITextGrid)
        _textGrid = textGrid
        _x = 0
        _y = 0
        PutDude()
    End Sub

    private sub ClearDude()
        if _x<0 orelse _y<0 orelse _x>=_textGrid.Columns orelse _y>=_textGrid.Rows Then 
            return
        End If
        _textGrid.GetCell(_x, _y).Character = 0
        _textGrid.GetCell(_x, _y).ForegroundHue = Hue.Black
        _textGrid.GetCell(_x, _y).BackgroundHue = Hue.Black
    end sub

    private sub PutDude()
        if _x<0 orelse _y<0 orelse _x>=_textGrid.Columns orelse _y>=_textGrid.Rows Then 
            return
        End If
        _textGrid.GetCell(_x, _y).Character = 2
        _textGrid.GetCell(_x, _y).ForegroundHue = Hue.White
        _textGrid.GetCell(_x, _y).BackgroundHue = Hue.Black
    End sub

    Public Sub Update(elapsed As TimeSpan) Implements IStateMachine.Update
        _textGrid.Fill(1,0,51,1,&hcd,Hue.Brown, Hue.Black)
        _textGrid.Fill(1,29,51,1,&hcd,Hue.Brown, Hue.Black)
        _textGrid.Fill(1,24,51,1,&hcd,Hue.Brown, Hue.Black)
        _textGrid.Fill(0,1,1,23,&hba,Hue.Brown, Hue.Black)
        _textGrid.Fill(52,1,1,23,&hba,Hue.Brown, Hue.Black)
        _textGrid.Fill(0,25,1,4,&hba,Hue.Brown, Hue.Black)
        _textGrid.Fill(52,25,1,4,&hba,Hue.Brown, Hue.Black)

        _textGrid.GetCell(0,0).Plot(&hc9,Hue.Brown, Hue.Black)
        _textGrid.GetCell(52,0).Plot(&hbb,Hue.Brown, Hue.Black)
        _textGrid.GetCell(0,24).Plot(&hcc,Hue.Brown, Hue.Black)
        _textGrid.GetCell(52,24).Plot(&hb9,Hue.Brown, Hue.Black)
        _textGrid.GetCell(0,29).Plot(&hc8,Hue.Brown, Hue.Black)
        _textGrid.GetCell(52,29).Plot(&hbc,Hue.Brown, Hue.Black)
    End Sub

    Public Sub OnKeyUp(keyName As String) Implements IStateMachine.OnKeyUp

    End Sub

    Public Sub OnKeyDown(keyName As String) Implements IStateMachine.OnKeyDown
        ClearDude()
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
        PutDude()
    End Sub
End Class
