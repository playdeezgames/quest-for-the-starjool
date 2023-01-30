Friend Class Character
    Inherits Thingie(Of CharacterData)
    Implements ICharacter
    Public Sub New(worldData As WorldData, character As CharacterData)
        MyBase.New(worldData, character)
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
            Return Data.Token
        End Get
    End Property
End Class
