Public Interface ITextCell
    Property BackgroundHue As Hue
    Property ForegroundHue As Hue
    Property Character As Byte
    Sub Plot(character as Byte, backgroundHue as Hue, foregroundHue as Hue)
End Interface
