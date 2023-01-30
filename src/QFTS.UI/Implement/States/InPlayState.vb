Friend Class InPlayState
    Inherits StateBase

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        'should not get here
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Reset()
        If _world.IsCreatingCharacter Then
            If _world.NeedsAbilityScores Then
                SetState(State.RollAbilities)
            ElseIf _world.NeedsRace Then
                SetState(State.ChooseRace)
            ElseIf _world.NeedsClass Then
                SetState(State.ChooseClass)
            End If
        Else
            While _world.Player.RunTrigger()
            End While
            If _world.Player.Shoppe IsNot Nothing Then
                SetState(State.ShoppeWelcome)
            Else
                SetState(State.Navigation)
            End If
        End If
    End Sub
End Class
