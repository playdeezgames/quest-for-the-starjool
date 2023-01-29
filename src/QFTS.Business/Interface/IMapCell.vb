﻿Public Interface IMapCell
    ReadOnly Property Terrain As TerrainType
    Property Character As ICharacter
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property CanHaveCharacter As Boolean
End Interface
