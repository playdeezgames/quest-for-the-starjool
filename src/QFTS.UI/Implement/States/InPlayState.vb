Friend Class InPlayState
    Inherits StateBase

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        MyBase.New(world, stateMachine, textGrid, random)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        'should not get here
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Reset()
        If _world.IsCreatingCharacter Then
            If _world.NeedsAbilityScores Then
                SetState(State.RollAbilities)
            ElseIf _world.NeedRace Then
                SetState(State.ChooseRace)
            End If
        End If
    End Sub
End Class
