Friend Module RNG
    Private _random As New Random
    Friend Function FromRange(minimum As Double, maximum As Double) As Double
        Return _random.NextDouble * (maximum - minimum) + minimum
    End Function
End Module
