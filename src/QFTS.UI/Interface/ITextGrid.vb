Public Interface ITextGrid
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Function GetCell(column As Integer, row As Integer) As ITextCell
    Sub Fill(column as Integer, row as Integer, columns as INteger, rows as Integer, character as byte, foreground as hue, background as Hue)
    Sub Fill(character as byte, foreground as hue, background as Hue)
    Sub Plot(column as Integer, row as Integer, character as byte, foreground as hue, background as Hue)
    Sub WriteText(column as Integer, row as Integer, textt as String, foreground as Hue, background as Hue)
End Interface
