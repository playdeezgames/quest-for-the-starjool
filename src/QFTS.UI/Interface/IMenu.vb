Friend Interface IMenu
    Sub Clear()
    Sub AddItem(itemText As String)
    Sub Update()
    Function OnKeyUp(keyName As String) As Boolean
    ReadOnly Property CurrentItem As String
End Interface
