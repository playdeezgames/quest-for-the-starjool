Friend Class ShoppeSellState
    Inherits StateBase
    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub
    Public Overrides Sub Update(elapsed As TimeSpan)
        Throw New NotImplementedException()
    End Sub
    Public Overrides Sub Reset()
        Throw New NotImplementedException()
    End Sub
End Class
