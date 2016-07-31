' E0117.vb
' Solves problem #117
' Answer: 100808458960497

Imports System.Numerics

Module E0117
    
    Sub Main ()
        
        Dim size As Integer = 50
        Dim red As Integer = 2
        Dim green As Integer = 3
        Dim blue As Integer = 4
        Dim cache ( size ) As Big Integer
        Dim redAnswer As BigInteger = Recurse ( size, cache, red )
        Dim greenAnswer As BigInteger = Recurse ( size, cache, green )
        Dim blueAnswer As BigInteger = Recurse ( size, cache, blue )
        Dim answer As BigInteger = redAnswer + greenAnswer + blueAnswer + 1
        
        Console.WriteLine ( "Answer: {0}", answer )
    End Sub
    
    Function Recurse ( ByVal rowLength As Integer, ByRef cache As _
        BigInteger (), ByVal tileLength As Integer ) As BigInteger
        
        If rowLength < tileLength Then
            Return 0
        End If
        
        Dim amount As BigInteger = 0
        
        For remnantLength As Integer = 0 To rowLength - tileLength
            
            Dim additional As BigInteger = 0
            
            Dim query As Integer = rowLength - ( remnantLength + tileLength )
            If query < 0 Then
                additional = 0
            Else If cache ( query ) <> 0
                additional += cache ( query )
            Else
                additional += Recurse ( query, cache, 2 )
                additional += Recurse ( query, cache, 3 )
                additional += Recurse ( query, cache, 4 )
                cache ( query ) = additional
            End If
            
            amount = amount + 1 + additional
        Next
        
        Return amount
    End Function
End Module