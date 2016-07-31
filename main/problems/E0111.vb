' Answer: 612407567715
' credit to mathblog

Imports System.Collections.Generic
Imports System.Numerics

Module E0111

    Sub Main ()
        
        Dim answer As BigInteger = 0
        Dim sum As BigInteger
        Dim digits As Integer () = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, }
        
        For digit As Integer = 0 To 9
            For i As Integer = 1 To digits.Count - 1
                sum = Recursion ( digit, 0, i, digits, True )
                If sum > 0 Then
                    
                    answer = answer + sum
                    
                    Exit For
                End If
            Next
        Next
        
        Console.WriteLine ()
        Console.WriteLine ( "{0}", answer )
    End Sub
    
    Function Recursion ( ByVal baseDigit As Integer, ByVal startPosition As Integer, ByVal level As Integer, ByRef digits As Integer (), Optional byVal doFill As Boolean = False )
        
        Dim count As BigInteger = New BigInteger ()
        
        If level <= 0 Then
            Return Primes.CheckDigitArrayIsPrime ( digits )
        End If
        
        count = 0
        
        If doFill Then
            For i As Integer = 0 To digits.Count = 1
                digits ( i ) = baseDigit
            Next
        End If
        
        For i As Integer = startPosition To digits.Count - 1
            For j As Integer = 0 To 9
                digits ( i ) = j
                count += Recursion ( baseDigit, i + 1, level - 1, digits )
                digits ( i ) = baseDigit
            Next
        Next
        
        Return count
    End Function
End Module