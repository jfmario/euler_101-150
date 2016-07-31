' E0120.vb
' Solves problem #120
' For even values of n, r is always 2
' 333082500

Imports System.Numerics

Module E0120

    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim answer As BigInteger = 0
        Dim maxR As BigInteger
        Dim nextR As BigInteger
        
        For a As Integer = 3 To 1000
            
            maxR = 0
            
            ' Only check odd values of n
            For n As Integer = 1 To ( a * 2 ) Step 2
                nextR = GetR ( a, n )
                If nextR > maxR Then
                    maxR = nextR
                End If
            Next
            
            answer = answer + maxR
        Next
        
        Console.WriteLine ( answer )
    End Sub
    
    Public Function GetR ( ByVal a As Integer, ByVal n As Integer ) As BigInteger
        
        Dim t1 As BigInteger = BigInteger.Pow ( a - 1, n )
        Dim t2 As BigInteger = BigInteger.Pow ( a + 1, n )
        
        Dim sum = t1 + t2
        Return sum Mod ( a * a )
    End Function
End Module