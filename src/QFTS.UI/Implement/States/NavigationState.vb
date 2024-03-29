﻿Friend Class NavigationState
    Inherits StateBase
    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub
    Const OffsetX = 1
    Const OffsetY = 1
    Const DeltaX = -18
    Const DeltaY = -11
    Const Columns = 37
    Const Rows = 23
    Public Overrides Sub Update(elapsed As TimeSpan)
        For column = 0 To Columns - 1
            For row = 0 To Rows - 1
                Dim fromX = World.Player.X + DeltaX + column
                Dim fromY = World.Player.Y + DeltaY + row
                Dim toX = OffsetX + column
                Dim toY = OffsetY + row
                Dim cell = World.PlayerMap.GetCell(fromX, fromY)
                If cell IsNot Nothing Then
                    If cell.Character?.Token IsNot Nothing Then
                        RenderToken(toX, toY, cell.Character.Token)
                    Else
                        RenderTerrain(toX, toY, cell.Terrain)
                    End If
                End If
            Next
        Next
    End Sub
    Public Overrides Sub HandleKey(keyName As String)
        Select Case keyName
            Case Up
                World.Player.MoveNorth()
                SetState(State.InPlay)
            Case Down
                World.Player.MoveSouth()
                SetState(State.InPlay)
            Case Left
                World.Player.MoveWest()
                SetState(State.InPlay)
            Case Right
                World.Player.MoveEast()
                SetState(State.InPlay)
            Case Escape
                'bring up context menu
        End Select
    End Sub
    Private Sub RenderTerrain(column As Integer, row As Integer, terrain As TerrainType)
        TextGrid.Plot(column, row, terrain.Character, terrain.Foreground, terrain.Background)
    End Sub
    Private Sub RenderToken(column As Integer, row As Integer, token As TokenType)
        TextGrid.Plot(column, row, token.Character, token.Foreground, token.Background)
    End Sub
    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.Black, Hue.Black)
        TextGrid.Fill(OffsetX, 0, Columns, 1, &HCD, Hue.Gray, Hue.DarkGray)
        TextGrid.Fill(OffsetX, OffsetY + Rows, Columns, 1, &HCD, Hue.Gray, Hue.DarkGray)
        TextGrid.Fill(0, OffsetY, 1, Rows, &HBA, Hue.Gray, Hue.DarkGray)
        TextGrid.Fill(Columns + OffsetX, OffsetY, 1, Rows, &HBA, Hue.Gray, Hue.DarkGray)
        TextGrid.Plot(0, 0, &HC9, Hue.Gray, Hue.DarkGray)
        TextGrid.Plot(OffsetX + Columns, 0, &HBB, Hue.Gray, Hue.DarkGray)
        TextGrid.Plot(0, OffsetY + Rows, &HC8, Hue.Gray, Hue.DarkGray)
        TextGrid.Plot(OffsetX + Columns, OffsetY + Rows, &HBC, Hue.Gray, Hue.DarkGray)
    End Sub
End Class
