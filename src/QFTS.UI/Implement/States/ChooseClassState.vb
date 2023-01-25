Friend Class ChooseClassState
    Inherits StateBase
    Private _menu As IMenu

    Public Sub New(world As IWorld, stateMachine As IStateMachine, textGrid As ITextGrid, random As Random)
        MyBase.New(world, stateMachine, textGrid, random)
        _menu = New Menu(textGrid, 0, 2, Hue.White, Hue.Black)
    End Sub

    Public Overrides Sub Update(elapsed As TimeSpan)
        _menu.Update()
    End Sub

    Public Overrides Sub OnKeyUp(keyName As String, random As Random)
        If _menu.OnKeyUp(keyName) Then
            Return
        End If
        Select Case keyName
            Case Enter
                ActivateMenuItem(random)
            Case Escape
                GoBackToMainMenu()
        End Select
    End Sub

    Private Sub GoBackToMainMenu()
        _world.RollBackCharacterCreation()
        SetState(State.MainMenu)
    End Sub

    Private Sub ActivateMenuItem(random As Random)
        Select Case _menu.CurrentItem
            Case CancelText
                GoBackToMainMenu()
            Case Else
                ChooseClass(AllClasses.Single(Function(x) x.Name = _menu.CurrentItem), random)
        End Select
    End Sub

    Private Sub ChooseClass(characterClass As CharacterClass, random As Random)
        _world.ChooseClass(characterClass, random)
        SetState(State.InPlay)
    End Sub

    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, ChooseClassHeader, Hue.White, Hue.Black)
        _menu.Clear()
        For Each characterClass In AllClasses
            If _world.CanChooseClass(characterClass) Then
                _menu.AddItem(characterClass.Name)
            End If
        Next
        _menu.AddItem(CancelText)
    End Sub
End Class
