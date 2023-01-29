Public Interface ICharacter
    ReadOnly Property Token As TokenType
    Function CanEnter(cell As IMapCell) As Boolean
End Interface
