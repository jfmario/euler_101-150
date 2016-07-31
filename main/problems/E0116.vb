' E0116.vb
' Solves Project Euler problem 116.
' Answer: 20492570929

Imports System.Numerics

Module E0116
    
    Sub Main ()
        
        Dim size As Integer = 50
        Dim red As Integer = 2
        Dim green As Integer = 3
        Dim blue As Integer = 4
        Dim redCache ( size ) As BigInteger
        Dim greenCache ( size ) As BigInteger
        Dim blueCache ( size ) As BigInteger
        Dim redAnswer As BigInteger = Recurse ( size, red, redCache )
        Dim greenAnswer As BigInteger = Recurse ( size, green, greenCache )
        Dim blueAnswer As BigInteger = Recurse ( size, blue, blueCache )
        Dim answer As BigInteger = redAnswer + greenAnswer + blueAnswer
        
        Console.WriteLine ( "Answer: {0}", answer )
    End Sub
    
    Function Recurse ( ByVal rowLength As Integer, ByVal tileLength As _
        Integer, ByRef cache As BigInteger () ) As BigInteger
        
        If rowLength < tileLength Then
            Return 0
        End If
        
        Dim amount As BigInteger = 0
        
        For remnantLength As Integer = 0 To rowLength - tileLength
            
            Dim additional As BigInteger = 0
            
            Dim query As Integer = rowLength - ( remnantLength + tileLength )
            If query < 0 Then
                additional = 0
            Else If cache ( query ) <> 0 Then
                additional = cache ( query )
            Else
                additional = Recurse ( query, tileLength, cache )
                cache ( query ) = additional
            End If
            
            amount = amount + 1 + additional
        Next
        
        Return amount
    End Function
End Module