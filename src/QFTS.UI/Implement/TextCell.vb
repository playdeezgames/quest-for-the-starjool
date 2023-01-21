Friend Class TextCell
    Implements ITextCell
    Public Property BackgroundHue As Hue Implements ITextCell.BackgroundHue
    Public Property ForegroundHue As Hue Implements ITextCell.ForegroundHue
    Public Property Character As Byte Implements ITextCell.Character
End Class
