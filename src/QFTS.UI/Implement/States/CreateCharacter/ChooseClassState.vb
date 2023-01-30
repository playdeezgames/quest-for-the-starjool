Friend Class ChooseClassState
    Inherits StateBase
    Private _menu As IMenu

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid)
        MyBase.New(world, stateMachine, textGrid)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        _menu.Update()
    End Sub

    Public Overrides Sub HandleKey(keyName As String)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Enter
                ActivateMenuItem()
            Case Escape
                GoBackToMainMenu()
        End Select
    End Sub

    Private Sub GoBackToMainMenu()
        World.RollBackCharacterCreation()
        SetState(State.MainMenu)
    End Sub

    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case CancelText
                GoBackToMainMenu()
            Case Else
                ChooseClass(AllClasses.Single(Function(x) x.Name = _menu.CurrentItem))
        End Select
    End Sub

    Private Sub ChooseClass(characterClass As CharacterClass)
        World.ChooseClass(characterClass)
        SetState(State.InPlay)
    End Sub

    Public Overrides Sub Reset()
        TextGrid.FillAll(0, Hue.Black, Hue.Black)
        TextGrid.WriteText(0, 0, ChooseClassHeader, Hue.White, Hue.Black)
        _menu.Clear()
        For Each characterClass In AllClasses
            If World.CanChooseClass(characterClass) Then
                _menu.AddItem(characterClass.Name)
            End If
        Next
        _menu.AddItem(CancelText)
    End Sub
End Class
