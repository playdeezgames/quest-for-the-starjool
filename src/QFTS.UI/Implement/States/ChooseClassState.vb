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

    Public Overrides Sub OnKeyUp(keyName As String)
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
        _world.RollBackCharacterCreation()
        SetState(State.MainMenu)
    End Sub

    Private Sub ActivateMenuItem()
        Select Case _menu.CurrentItem
            Case ClericText
                ChooseClass(CharacterClass.Cleric)
            Case FighterMagicUserText
                ChooseClass(CharacterClass.FighterMagicUser)
            Case FighterText
                ChooseClass(CharacterClass.Fighter)
            Case MagicUserText
                ChooseClass(CharacterClass.MagicUser)
            Case MagicUserThiefText
                ChooseClass(CharacterClass.MagicUserThief)
            Case ThiefText
                ChooseClass(CharacterClass.Thief)
            Case CancelText
                GoBackToMainMenu()
        End Select
    End Sub

    Private Sub ChooseClass(characterClass As CharacterClass)
        _world.ChooseClass(characterClass)
        SetState(State.InPlay)
    End Sub

    Public Overrides Sub Reset()
        _textGrid.FillAll(0, Hue.Black, Hue.Black)
        _textGrid.WriteText(0, 0, "Choose Class:", Hue.White, Hue.Black)
        _menu.Clear()
        If _world.CanChooseClass(CharacterClass.Cleric) Then
            _menu.AddItem(ClericText)
        End If
        If _world.CanChooseClass(CharacterClass.Fighter) Then
            _menu.AddItem(FighterText)
        End If
        If _world.CanChooseClass(CharacterClass.FighterMagicUser) Then
            _menu.AddItem(FighterMagicUserText)
        End If
        If _world.CanChooseClass(CharacterClass.MagicUser) Then
            _menu.AddItem(MagicUserText)
        End If
        If _world.CanChooseClass(CharacterClass.MagicUserThief) Then
            _menu.AddItem(MagicUserThiefText)
        End If
        If _world.CanChooseClass(CharacterClass.Thief) Then
            _menu.AddItem(ThiefText)
        End If
        _menu.AddItem(CancelText)
    End Sub

    Private Const ThiefText = "Thief"
    Private Const MagicUserThiefText = "Magic-User/Thief"
    Private Const MagicUserText = "Magic-User"
    Private Const FighterMagicUserText = "Fighter/Magic-User"
    Private Const FighterText = "Fighter"
    Private Const ClericText = "Cleric"
End Class
