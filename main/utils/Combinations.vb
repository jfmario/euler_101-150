Public Class Combinations
    Public Shared Function CatalanNumber ( ByVal n As Integer ) As Long
        Return FactorialFunction ( 2 * m, n ) / ( n + 1 )
    End Function
    Public Shared Function Factorial ( ByVal number As BigInteger ) As BigInteger
        
        Dim product As BigInteger = 1
        
        While number >= 1
            product = number * product
            number = number - 1
        End While
        
        Return product
    End Function
    Public Shared Function FactorialFunction ( ByVal n As Integer, ByVal k As Integer ) As Long
        Return Factorial ( n ) / ( Factorial ( k ) * Factorial ( n - k ) )
    End Function
    Public Shared Function UniqueSubsetCount ( ByVal setSize As Integer ) As Integer
        
        Dim sum As Integer = 0
        Dim newNo As Integer
        Dim X As Double
        Dim Y As Double
        
        For i As Integer = 1 To setSize / 2
            For j As Integer = i To setSize - i
                
                X = FactorialFunction ( setSize, i )
                Y = FactorialFunction ( setSize - i, j )
                
                newNo = X * Y
                
                If i = j Then
                    newNo = newNo / 2
                End If
                
                sum = sum + newNo
            Next
        Next
        
        Return sum
    Return Function
End Class