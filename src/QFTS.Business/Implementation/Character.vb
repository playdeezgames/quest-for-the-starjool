﻿Friend Class Character
    Implements ICharacter
    Private _worldData As WorldData
    Friend _data As CharacterData
    Public Sub New(worldData As WorldData, character As CharacterData)
        _worldData = worldData
        _data = character
    End Sub
    Public Function CanEnter(cell As IMapCell) As Boolean Implements ICharacter.CanEnter
        If cell.HasCharacter Then
            Return False
        End If
        If Not cell.CanHaveCharacter Then
            Return False
        End If
        Return True
    End Function
    Public ReadOnly Property Token As TokenType Implements ICharacter.Token
        Get
            Return _data.Token
        End Get
    End Property
End Class
