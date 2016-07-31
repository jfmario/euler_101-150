'180180

Module E0108

    Sub Main ()
        
        Dim target As Integer = 1000
        Dim answer As Integer = 2
        
        Do While CountDiophantineSolutions ( answer ) < target
            answer = answer + 1
        End While
        
        Console.WriteLine ( answer )
    End Sub
    
    Function CountDiophantineSolutions ( n As Integer ) As Integer
        ' 1/(n+a)+1/(n+b) = 1/n
        ' n = sqrt (ab)
        Return ( Algorithms.CountFactors ( n ) + 1 ) / 2
    End Function
End Module