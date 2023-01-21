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
    Private destinationRectangles As New List(Of Rectangle)
    Private textGrid As ITextGrid
    Private stateMachine As IStateMachine
    Private keyboardState As KeyboardState

    Sub New()
        graphics = New GraphicsDeviceManager(Me)
        InitializeSourceRectangles()
        InitializeDestinationRectangles()
    End Sub

    Private Sub InitializeDestinationRectangles()
        destinationRectangles.Clear()
        For row = 0 To ViewRows - 1
            For column = 0 To ViewColumns - 1
                destinationRectangles.Add(New Rectangle(column * CellWidth, row * CellHeight, CellWidth, CellHeight))
            Next
        Next
    End Sub

    Private Sub InitializeSourceRectangles()
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
        textGrid = New TextGrid(ViewColumns, ViewRows)
        stateMachine = New StateMachine(textGrid)
        keyboardState = Keyboard.GetState
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        Dim newKeyboardState = Keyboard.GetState()
        For Each key In keyboardState.GetPressedKeys().Where(Function(x) Not newKeyboardState.IsKeyDown(x))
            stateMachine.OnKeyUp(key.ToString())
        Next
        For Each key In newKeyboardState.GetPressedKeys().Where(Function(x) Not keyboardState.IsKeyDown(x))
            stateMachine.OnKeyDown(key.ToString())
        Next
        keyboardState = newKeyboardState
        stateMachine.Update(gameTime.ElapsedGameTime)
        MyBase.Update(gameTime)
    End Sub

    Private hueTable As IReadOnlyDictionary(Of Hue, Color) =
        New Dictionary(Of Hue, Color) From
        {
            {Hue.Black, New Color(0, 0, 0)},
            {Hue.Blue, New Color(0, 0, 170)},
            {Hue.Green, New Color(0, 170, 0)},
            {Hue.Cyan, New Color(0, 170, 170)},
            {Hue.Red, New Color(170, 0, 0)},
            {Hue.Magenta, New Color(170, 0, 170)},
            {Hue.Brown, New Color(170, 85, 0)},
            {Hue.Gray, New Color(170, 170, 170)},
            {Hue.DarkGray, New Color(85, 85, 85)},
            {Hue.LightBlue, New Color(85, 85, 255)},
            {Hue.LightGreen, New Color(85, 255, 85)},
            {Hue.LightCyan, New Color(85, 255, 255)},
            {Hue.Pink, New Color(255, 85, 85)},
            {Hue.LightMagenta, New Color(255, 85, 255)},
            {Hue.Yellow, New Color(255, 255, 85)},
            {Hue.White, New Color(255, 255, 255)}
        }

    Protected Overrides Sub Draw(gameTime As GameTime)
        graphics.GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()
        Dim destinationIndex = 0
        For row = 0 To ViewRows - 1
            For column = 0 To ViewColumns - 1
                Dim textCell = textGrid.GetCell(column, row)
                Dim background = textCell.BackgroundHue
                Dim foreground = textCell.ForegroundHue
                Dim character = textCell.Character
                spriteBatch.Draw(romFont, destinationRectangles(destinationIndex), sourceRectangles(&HDB), hueTable(background))
                spriteBatch.Draw(romFont, destinationRectangles(destinationIndex), sourceRectangles(character), hueTable(foreground))
                destinationIndex += 1
            Next
        Next
        spriteBatch.End()
    End Sub
End Class
