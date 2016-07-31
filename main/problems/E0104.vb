' E0125.vb
' Solves Problem #104
' Uses Fibonacci, PandigitalOperations

Imports System.Numerics

Module E0104
    Sub Main ()
        
        Dim f As New Fibonacci ()
        Dim po As New PandigitalOperations ()
        Dim fn As Integer = 100000 ' arbitrary start point
        Dim c As BigInteger
        
        f.AdvanceTo ( fn )
        c = f.Curr
        
        While True
            
            ' Checking the last nine is cheaper than checking the first 9
            If po.IsPandigitalLast9 ( c ) Then
                If po.IsPandigitalFirst9 ( c ) Then
                    Console.WriteLine ( "Answer: {0}", fn )
                    Exit While
                End If
            End If
            
            c = f.NextNumber ()
            fn = f.Num
        End While
    End Sub
End Module