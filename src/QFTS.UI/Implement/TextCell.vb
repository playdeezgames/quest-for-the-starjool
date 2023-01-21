Friend Class TextCell
    Implements ITextCell
    Public Property BackgroundHue As Hue Implements ITextCell.BackgroundHue
    Public Property ForegroundHue As Hue Implements ITextCell.ForegroundHue
    Public Property Character As Byte Implements ITextCell.Character
    Sub Put(character as Byte, backgroundHue as Hue, foregroundHue as Hue) Implements ITextCell.Put
        me.Character=character
        me.ForegroundHue=foregroundHue
        me.BackgroundHue=backgroundHue
    End Sub
End Class
