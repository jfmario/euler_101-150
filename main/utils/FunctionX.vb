' Class represents a function that takes x as an argument.
' Provides methods for operating as Double, Integer, or Long.
Public Class FunctionX
    Overridable Public Function GoDouble ( x As Double ) As Double
        return x
    End Function
    Overridable Public Function GoInt ( x As Integer ) As Integer
        return x
    End Function
    Overridable Public Function GoLong ( x As Long ) As Long
        return x
    End Function
End Class