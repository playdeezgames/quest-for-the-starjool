Public Class World
    Implements IWorld
    Private _worldData As WorldData

    Public ReadOnly Property CanStart As Boolean Implements IWorld.CanStart
        Get
            Return Not CanContinue
        End Get
    End Property

    Public ReadOnly Property CanContinue As Boolean Implements IWorld.CanContinue
        Get
            Return _worldData.CharacterCreation IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property CanAbandon As Boolean Implements IWorld.CanAbandon
        Get
            Return CanContinue
        End Get
    End Property

    Public ReadOnly Property IsCreatingCharacter As Boolean Implements IWorld.IsCreatingCharacter
        Get
            Return _worldData.CharacterCreation IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property NeedsAbilityScores As Boolean Implements IWorld.NeedsAbilityScores
        Get
            Return IsCreatingCharacter AndAlso _worldData.CharacterCreation.Abilities Is Nothing
        End Get
    End Property

    Public ReadOnly Property NeedRace As Boolean Implements IWorld.NeedRace
        Get
            If _worldData.CharacterCreation Is Nothing Then
                Return False
            End If
            Return _worldData.CharacterCreation.Race Is Nothing
        End Get
    End Property

    Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
    Sub New()
        _worldData = New WorldData
    End Sub

    Public Sub Start() Implements IWorld.Start
        _worldData.CharacterCreation = New CharacterCreationData
    End Sub

    Public Sub AssignAbilities(abilities As IReadOnlyDictionary(Of Ability, Integer)) Implements IWorld.AssignAbilities
        If _worldData.CharacterCreation Is Nothing Then
            Return
        End If
        _worldData.CharacterCreation.Abilities = abilities.ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Sub

    Public Function CanChooseRace(race As Race) As Boolean Implements IWorld.CanChooseRace
        If Not NeedRace Then
            Return False
        End If
        Return race.CheckAbilities(_worldData.CharacterCreation.Abilities)
    End Function

    Public Sub RollBackCharacterCreation() Implements IWorld.RollBackCharacterCreation
        If Not IsCreatingCharacter Then
            Return
        End If
        _worldData.CharacterCreation = New CharacterCreationData
    End Sub
End Class
