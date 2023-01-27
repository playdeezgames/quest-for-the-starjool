Friend Class CharacterCreation
    Implements ICharacterCreation
    Private _worldData As WorldData
    Private _data As CharacterCreationData
    Public Sub New(worldData As WorldData, characterCreation As CharacterCreationData)
        _worldData = worldData
        _data = characterCreation
    End Sub
End Class
