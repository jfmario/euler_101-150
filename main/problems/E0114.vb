' E0114.vb
' Solution for problem 114.
' Answer: 16475640049

Imports System.Numerics

Module E0114
    
    Sub Main ()
        
        Dim n As Integer = 50
        Dim answer As BigInteger = 1
        
        Dim cache ( n ) As BigInteger
        
        answer = Recurse ( n, cache ) + 1
        
        Console.WriteLine ( "Answer: {0}", answer )
    End Sub
    
    Function Recurse ( ByVal blockLength As Integer, ByRef cache As BigInteger () ) As BigInteger
        If blockLength < 3 Then
            Return 0
        Else
            
            Dim amount As BigInteger = 0
            
            For redLength As Integer = 3 To blockLength
                For remnantLength As Integer = 0 To blockLength - redLength
                    
                    Dim additional As BigInteger = 0
                    
                    Dim query As Integer = blockLength - ( remnantLength + redLength + 1 )
                    If query < 0 Then
                        additional = 0
                    Else If cache ( query ) <> 0 Then
                        additional = cache ( query )
                    Else
                        additional = Recurse ( query, cache )
                        cache ( query ) = additional
                    End If
                    
                    amount = amount + 1 + additional
                Next
            Next
            
            Return amount
        End If
    End Function
End Module