Imports System.Runtime.CompilerServices

Friend Module ItemTypeExtensions
    Private ReadOnly table As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.Club, New ItemTypeDescriptor}
        }
    <Extension>
    Function ToDescriptor(itemType As ItemType) As ItemTypeDescriptor
        Return table(itemType)
    End Function
End Module
