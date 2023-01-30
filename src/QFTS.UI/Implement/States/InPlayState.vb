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
        If World.IsCreatingCharacter Then
            If World.NeedsAbilityScores Then
                SetState(State.RollAbilities)
            ElseIf World.NeedsRace Then
                SetState(State.ChooseRace)
            ElseIf World.NeedsClass Then
                SetState(State.ChooseClass)
            End If
        Else
            While World.Player.RunTrigger()
            End While
            If World.Player.Shoppe IsNot Nothing Then
                SetState(State.ShoppeWelcome)
            Else
                SetState(State.Navigation)
            End If
        End If
    End Sub
End Class
