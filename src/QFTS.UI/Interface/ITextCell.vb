Public Interface ITextCell
    Property BackgroundHue As Hue
    Property ForegroundHue As Hue
    Property Character As Byte
    Sub Put(character as Byte, backgroundHue as Hue, foregroundHue as Hue)
End Interface
