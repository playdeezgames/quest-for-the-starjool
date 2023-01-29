Imports System.Runtime.CompilerServices
Public Module TerrainTypeExtensions
    Private ReadOnly table As IReadOnlyDictionary(Of TerrainType, TerrainDescriptor) =
        New Dictionary(Of TerrainType, TerrainDescriptor) From
        {
            {
                TerrainType.Grass,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = True
                }
            },
            {
                TerrainType.Road,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = True
                }
            },
            {
                TerrainType.HorizontalFence,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = False
                }
            },
            {
                TerrainType.VerticalFence,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = False
                }
            },
            {
                TerrainType.FenceCorner,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = False
                }
            },
            {
                TerrainType.House,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = True
                }
            },
            {
                TerrainType.Water,
                New TerrainDescriptor With
                {
                    .CanHaveCharacter = False
                }
            }
        }
    <Extension>
    Public Function ToDescriptor(terrainType As TerrainType) As TerrainDescriptor
        Return table(terrainType)
    End Function
End Module
