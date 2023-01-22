Friend Class Menu
    Implements IMenu
    Private ReadOnly _menuItems As New List(Of String)
    Private _menuItemIndex As Integer
    Private ReadOnly _column As Integer
    Private ReadOnly _row As Integer
    Private ReadOnly _textGrid As ITextGrid
    Private ReadOnly _foreground As Hue
    Private ReadOnly _background As Hue

    Public ReadOnly Property CurrentItem As String Implements IMenu.CurrentItem
        Get
            If _menuItemIndex >= _menuItems.Count Then
                Return Nothing
            End If
            Return _menuItems(_menuItemIndex)
        End Get
    End Property

    Sub New(textGrid As ITextGrid, column As Integer, row As Integer, foreground As Hue, background As Hue)
        _textGrid = textGrid
        _column = column
        _row = row
        _foreground = foreground
        _background = background
    End Sub

    Public Sub Clear() Implements IMenu.Clear
        _menuItemIndex = 0
        _menuItems.Clear()
    End Sub

    Public Sub AddItem(itemText As String) Implements IMenu.AddItem
        _menuItems.Add(itemText)
    End Sub

    Public Sub Update() Implements IMenu.Update
        Dim index = 0
        For Each menuItem In _menuItems
            If index = _menuItemIndex Then
                _textGrid.WriteText(_column, index + _row, menuItem, _background, _foreground)
            Else
                _textGrid.WriteText(_column, index + _row, menuItem, _foreground, _background)
            End If
            index += 1
        Next
    End Sub

    Public Function OnKeyUp(keyName As String) As Boolean Implements IMenu.OnKeyUp
        Select Case keyName
            Case Up
                _menuItemIndex = (_menuItemIndex + _menuItems.Count - 1) Mod _menuItems.Count
                Return True
            Case Down
                _menuItemIndex = (_menuItemIndex + 1) Mod _menuItems.Count
                Return True
        End Select
        Return False
    End Function
End Class
