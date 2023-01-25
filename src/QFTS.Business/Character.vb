Friend Class Character
    Implements ICharacter

    Private _worldData As WorldData
    Private _data As CharacterData

    Public Sub New(worldData As WorldData, character As CharacterData)
        _worldData = worldData
        _data = character
    End Sub

    Public ReadOnly Property Token As TokenType Implements ICharacter.Token
        Get
            Return _data.Token
        End Get
    End Property
End Class
