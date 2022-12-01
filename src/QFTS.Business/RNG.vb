Friend Module RNG
    Private _random As New Random
    Friend Function FromRange(minimum As Double, maximum As Double) As Double
        Return _random.NextDouble * (maximum - minimum) + minimum
    End Function
    Friend Function FromValues(Of TValue)(ParamArray values As TValue()) As TValue
        Return values(_random.Next(values.Length))
    End Function
End Module
