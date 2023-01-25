Imports System.Runtime.CompilerServices

Friend Module TerrainTypeExtensions
    Private ReadOnly table As IReadOnlyDictionary(Of TerrainType, (Byte, Hue, Hue)) =
        New Dictionary(Of TerrainType, (Byte, Hue, Hue)) From
        {
            {TerrainType.Grass, (&H2E, Hue.LightGreen, Hue.Green)},
            {TerrainType.FenceCorner, (&H2B, Hue.White, Hue.Green)},
            {TerrainType.HorizontalFence, (&H2D, Hue.White, Hue.Green)},
            {TerrainType.VerticalFence, (&H7C, Hue.White, Hue.Green)},
            {TerrainType.Road, (&HB0, Hue.Black, Hue.Blue)},
            {TerrainType.Water, (&HF7, Hue.LightBlue, Hue.DarkGray)},
            {TerrainType.House, (&H7F, Hue.Brown, Hue.Green)}
        }
    <Extension>
    Friend Function Foreground(terrainType As TerrainType) As Hue
        Return table(terrainType).Item2
    End Function
    <Extension>
    Friend Function Background(terrainType As TerrainType) As Hue
        Return table(terrainType).Item3
    End Function
    <Extension>
    Friend Function Character(terrainType As TerrainType) As Byte
        Return table(terrainType).Item1
    End Function
End Module
