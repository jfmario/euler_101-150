' 9350130049860600
' mathblg

Imports System.Collections.Generic
Imports System.Numerics

Module E110
    Sub Main ()
        
        Dim target As Integer = 4000000
        Dim answer As BigInteger = 0
        Dim count As Integer = 0
        Dim reverseTarget As Integer = 2 * target - 1
        Dim divisors As Long = 1
        
        Dim primeFactorExponents As List (Of Integer) = _
                New List ( Of Integer ) ()
        
        Dim bigNumber As BigInteger = 0
        
        ' Initialize array of 0's equal to number of working primes
        Dim smallPrimeCount = Primes.PrimeList.Count
        For i As Integer = 1 To smallPrimeCount
            primeFactorExponents.Add ( 0 )
        Next
        
        ' Generate numbers form prime factorizations
        While True
            
            ' Set up the exponent for the number 2
            primeFactorExponents (0) = 0
            
            divisors = 1
            
            For i As Integer = 0 To primeFactorExponents.Count - 1
                divisors = divisors * ( 2 * primeFactorExponents ( i ) + 1 )
            Next
            primeFactorExponents ( 0 ) = ( reverseTarget / divisors - 1 ) / 2
            While divisors * ( 2 * primeFactorExponents ( 0 ) + 1 ) < reverseTarget
                primeFactorExponents ( 0 ) = primeFactorExponents ( 0 ) + 1
            End While
            ' If 2's exponent is less than 3's exponent, it's bad so move on
            If primeFactorExponents ( 0 ) < primeFactorExponents ( 1 ) Then
                count = count + 1
            Else
                
                ' Get the current number from the exponents and check if it is 
                ' the best answer yet
                bigNumber = 1
                For i As Integer = 0 To primeFactorExponents.Count - 1
                    bigNumber= bigNumber * BigInteger.Pow ( Primes.PrimeList ( i ), primeFactorExponents ( i ) )
                Next
                
                If ( bigNumber < answer ) Or ( answer = 0 ) Then
                    answer = bigNumber
                End If
                
                count = 1
            End If
            If count >= primeFactorExponents.Count Then
                Exit While
            End If
            primeFactorExponents ( count ) = primeFactorExponents ( count ) + 1
            
            For i As Integer = 0 To count - 1
                primeFactorExponents ( i ) = primeFactorExponents ( count )
            Next
        End While
        
        Console.WriteLine ()
        Console.WriteLine ( "{0}", answer )
    End Sub
End Modulue