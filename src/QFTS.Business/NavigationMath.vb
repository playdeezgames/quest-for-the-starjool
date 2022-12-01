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
    <Extension>
    Public Function AsRadians(heading As (Double, Double)) As (Double, Double)
        Return (heading.Item1.AsRadians, heading.Item2.AsRadians)
    End Function
    <Extension>
    Public Function AsPosition(heading As (Double, Double)) As (Double, Double, Double)
        Return (Math.Sin(heading.Item2) * Math.Cos(heading.Item1), Math.Sin(heading.Item2) * Math.Sin(heading.Item1), Math.Cos(heading.Item2))
    End Function
    <Extension>
    Public Function Add(first As (Double, Double, Double), second As (Double, Double, Double)) As (Double, Double, Double)
        Return (first.Item1 + second.Item1, first.Item2 + second.Item2, first.Item3 + second.Item3)
    End Function
    <Extension>
    Public Function Multiply(position As (Double, Double, Double), scalar As Double) As (Double, Double, Double)
        Return (position.Item1 * scalar, position.Item2 * scalar, position.Item3 * scalar)
    End Function
End Module
