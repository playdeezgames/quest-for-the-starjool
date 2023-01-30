Imports System.Runtime.CompilerServices

Friend Module TokenTypeExtensions
    Private ReadOnly table As IReadOnlyDictionary(Of TokenType, (Byte, Hue, Hue)) =
        New Dictionary(Of TokenType, (Byte, Hue, Hue)) From
        {
            {TokenType.Player, (2, Hue.Pink, Hue.Black)}
        }
    <Extension>
    Friend Function Foreground(tokenType As TokenType) As Hue
        Return table(tokenType).Item2
    End Function
    <Extension>
    Friend Function Background(tokenType As TokenType) As Hue
        Return table(tokenType).Item3
    End Function
    <Extension>
    Friend Function Character(tokenType As TokenType) As Byte
        Return table(tokenType).Item1
    End Function
End Module
