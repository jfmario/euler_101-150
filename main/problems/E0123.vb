' E0122.vb
' Solves problem #123.
' r = 2pn
' 21035

Imports System.Collections.Generic
Imports System.Numerics

Module E0123
    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim limit As BigInteger = BigInteger.Pow ( 10, 10 )
        Dim primesList As List ( Of BigInteger ) = Primes.GetPrimes ( 2, _
            9999999 )
        Dim r As BigInteger
        Dim two As BigInteger = 2
        
        ' Start at 7037
        For i As BigInteger = 7037 To primesList.Count - 1 Step 2
            r = two * primesList ( i - 1 ) * i
            If r > limit Then
                
                Console.WriteLine ( i )
                
                Exit For
            End If
        Next
    End Sub
End Module