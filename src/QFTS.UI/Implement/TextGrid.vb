Public Class TextGrid
    Implements ITextGrid
    Private ReadOnly _textCells As New List(Of ITextCell)
    Sub New(columns As Integer, rows As Integer)
        Me.Columns = columns
        Me.Rows = rows
        _textCells.Clear()
        For row = 0 To rows - 1
            For column = 0 To columns - 1
                _textCells.Add(New TextCell())
            Next
        Next
    End Sub

    Public ReadOnly Property Columns As Integer Implements ITextGrid.Columns
    Public ReadOnly Property Rows As Integer Implements ITextGrid.Rows
    Public Function GetCell(column As Integer, row As Integer) As ITextCell Implements ITextGrid.GetCell
        If column < 0 OrElse row < 0 OrElse column >= Columns OrElse row >= Rows Then
            Return Nothing
        End If
        Return _textCells(column + row * Columns)
    End Function
    Public Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, character As Byte, foreground As Hue, background As Hue) Implements ITextGrid.Fill
        For c = 0 To columns - 1
            For r = 0 To rows - 1
                Plot(column + c, row + r, character, foreground, background)
            Next
        Next
    End Sub
    Public Sub Plot(column As Integer, row As Integer, character As Byte, foreground As Hue, background As Hue) Implements ITextGrid.Plot
        GetCell(column, row)?.Plot(character, foreground, background)
    End Sub
    Sub WriteText(column As Integer, row As Integer, text As String, foreground As Hue, background As Hue) Implements ITextGrid.WriteText
        For Each character In text
            Plot(column, row, CByte(AscW(character)), foreground, background)
            column += 1
        Next
    End Sub
    Sub FillAll(character As Byte, foreground As Hue, background As Hue) Implements ITextGrid.FillAll
        Fill(0, 0, Columns, Rows, character, foreground, background)
    End Sub
End Class
