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
    public Sub Fill(column as Integer, row as integer, columns as integer, rows as integer, character as byte, foreground as hue, background as hue) implements ITextGrid.Fill
        for c=0 to columns-1
            for r=0 to rows-1
                GetCell(column+c,row+r).Plot(character,foreground,background)
            next
        next
    End Sub
End Class
