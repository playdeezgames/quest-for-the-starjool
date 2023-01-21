Public Class QFTSGame
    Inherits Game

    Const CellWidth = 16
    Const CellHeight = 16
    Const ViewWidth = 1280
    Const ViewHeight = 720
    Const ViewColumns = ViewWidth \ CellWidth
    Const ViewRows = ViewHeight \ CellHeight
    Const TextureColumns = 16
    Const TextureRows = 16
    Const TextureCells = TextureColumns * TextureRows
    Const TextureFilename = "romfont8x8.png"

    Private graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private romFont As Texture2D
    Private sourceRectangles As New Dictionary(Of Byte, Rectangle)

    Sub New()
        graphics = New GraphicsDeviceManager(Me)
        For value = 0 To TextureCells - 1
            sourceRectangles(CByte(value)) = New Rectangle((value Mod TextureColumns) * CellWidth, (value \ TextureColumns) * CellHeight, CellWidth, CellHeight)
        Next
    End Sub

    Protected Overrides Sub LoadContent()
        graphics.PreferredBackBufferWidth = ViewWidth
        graphics.PreferredBackBufferHeight = ViewHeight
        graphics.ApplyChanges()
        spriteBatch = New SpriteBatch(GraphicsDevice)
        romFont = Texture2D.FromFile(GraphicsDevice, TextureFilename)
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        graphics.GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()
        spriteBatch.Draw(romFont, New Vector2(), sourceRectangles(2), Color.White)
        spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub
End Class
