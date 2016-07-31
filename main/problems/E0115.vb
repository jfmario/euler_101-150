' E0115.vb
' Solution for Problem #115.
' Answer: 168

Imports System.Numerics

Module E0115
    
    Sub Main ()
        
        ' Input data
        Dim m As Integer = 50
        Dim target As Integer = 1000000
        Dim answer As BigInteger = -1
        
        answer = Search ( m, target )
        Console.WriteLine ( "Answer: {0}", answer )
    End Sub
    
    Function Search ( m As Integer, target As Integer ) As Integer
        
        Dim n As Integer = m
        Dim test As Integer = 0
        
        While True
            
            Dim cache ( n ) As BigInteger
            test = Recurse ( n cache, m ) + 1
            
            If test > target Then
                Return n
            End If
            
            n = n + 1
        End While
        
        Return 0
    End Function
    Function Recurse ( ByVal blockLength As Integer, ByRef cache As BigInteger (), ByRef m As Integer ) As BigInteger
        If blockLength < m Then
            Return 0
        Else
            
            Dim amount As BigInteger = 0
            
            For redLength As Integer = m To blockLength
                For remnantLength As Integer = 0 To blockLength - redLength
                    
                    Dim additional As BigInteger = 0
                    
                    Dim query As Integer = blockLength - ( remnantLength + redLength + 1 )
                    If query < 0 Then
                        additional = 0
                    Else If cache ( query ) <> 0 Then
                        additional = cache ( query )
                    Else
                        additional = Recurse ( query, cache, m )
                        cache ( query ) = additional
                    End If
                    
                    amount = amount + 1 + additional
                Next
            Next
            
            Return amount
        End If
    End Function
End Module