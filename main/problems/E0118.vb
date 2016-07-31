' E0118.vb
' Solves problem #118
' Users IntegerArrayPermutations, Primes
' Help from online.
' 44680

Imports System.Numerics

Module E0118
    
    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim answer As BigInteger = 0
        Dim digits () As Integer = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        ' Object to iterate through all permutations.
        Dim permute As New IntegerArrayPermutations ( digits )
        Dim thisArray () As Integer = digits
        
        While Not thisArray Is Nothing
            answer = answer + Partitions ( thisArray, 0, 0 )
            thisArray = permute.NextArray ()
        End While
        
        Console.WriteLine ( answer )
    End Sub
    
    Private Function Partitions ( ByRef Array As Integer (), startIndex As _
        Integer, previousNumber As Integer ) As Integer
        
        Dim count As Integer = 0
        
        For i As Integer = startIndex To Array.Length - 1
            
            Dim number As BigInteger = 0
            
            ' Create number from partition
            For j As Integer = startIndex To i
                number = number * 10 + Array ( 10 )
            Next
            
            ' Ignore descending sets
            If number < previousNumber Then
                Continue For
            End If
            If Not Primes.TestPrime ( number ) Then
                Continue For
            End If
            If i = ( Array.Length - 1 ) Then
                Return count + 1
            End If
            
            count = count + Partitions ( Array, i + 1, number )
        Next
        
        Return count
    End Function
End Module