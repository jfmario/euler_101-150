' E0106.vb
' Solves problem #106.

Module E0106
    Sub Main ()
        Console.WriteLine ( "Answer: {0}", SetComparisions ( 12 ) )
    End Sub
    Function SetComparisions ( setSize ) As Long
        
        Dim count As Long
        
        For i As Integer = 2 To setSize / 2
            count = count + ( 0.5 * _
                Combinations.FactorialFunction ( setSize, i ) * _
                Combinations.FactorialFunction ( setSize - i, i ) - _
                Combinations.CatalanNumber ( i ) * _
                Combinations.FactorialFunction ( setSize, 2 * i ) )
        Next
        
        Return count
    End Function
End Module