Imports System.Runtime.CompilerServices

Module NavigationMath
    <Extension>
    Public Function AsDegrees(radians As Double) As Double
        Return radians * 180.0 / Math.PI
    End Function
    <Extension>
    Public Function AsRadians(degrees As Double) As Double
        Return degrees * Math.PI / 180.0
    End Function
    <Extension>
    Public Function FromPercent(percent As Double) As Double
        Return percent / 100.0
    End Function
    <Extension>
    Public Function ToPercent(ratio As Double) As Double
        Return ratio * 100.0
    End Function
    <Extension>
    Public Function Clamp(value As Double, minimum As Double, maximum As Double) As Double
        Return Math.Min(Math.Max(value, minimum), maximum)
    End Function
End Module
