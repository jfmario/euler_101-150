' E0121.vb
' Solves problem #121.
' 2269

Imports System.Collections.Generic
Imports System.Numerics

Module E0121

    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        ' Needed amount on hand is ( Factorial ( n + 1 ) ) / ( PositiveOutcomes )
        Console.WriteLine ( Combinations.Factorial ( 16 ) / _
            GoodOutcomes ( 15 ) )
    End Sub
    
    Function GoodOutcomes ( ByVal n As Integer ) As BigInteger
        
        Dim count As BigInteger = 0
        ' Create a descending chart of all possible outcomes
        Dim outcomes As List ( Of BigInteger )
        
        outcomes.Add ( 1 )
        outcomes.Add ( 1 )
        
        For i As Integer = 3 To ( n + 1 )
            outcomes.Add ( 0 )
        Next
        For i As Integer = 2 To n
            For j As Integer = i To 1 Step -1
                outcomes ( j ) = outcomes ( j ) + ( outcomes ( j - 1 ) * i )
            Next
        Next
        
        ' Answers are calculated differently if the length is even or odd
        If n Mod 2 Then
            For i As Integer = 0 To ( ( n + 1 ) / 2 ) - 1
                count = count + outcomes ( i )
            Next
        Else
            For i As Integer = 0 To ( n / 2 ) - 1
                count = count + outcomes ( i )
            Next
        End If
        
        Return count
    End Function
End Module