' Primes.vb
' Contains static operations relating to prime numbers.
' Added for Problem #111.
' Edited for Problem #118.
' Editing for Problem #124.

Imports System.Collections.Generic
Imports System.Numerics

Public Class Primes

    Public Shared PrimeList As List ( Of Integer ) = New List ( Of Integer ) _
            From { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, _
            59, 61, 67, 71, 73, 79, 83, 89, 97 }
    
    ' Creates a list of primes using the sieve method.    
    Public Shared Function GetPrimes ( ByVal minimum As Long, ByVal maximum As _
        Long ) As List ( Of BigInteger )
        
        Dim sieve ( maximum ) As Boolean
        Dim primes As New List ( Of BigInteger )
        
        For i As Integer = 2 To maximum
            For j As Integer = i + 1 To maximum Step i
                sieve ( j ) = True
            Next
        Next
        For i As Integer = minimum To maximum - 1
            If ( Not sieve ( i ) ) Then
                primes.Add ( i )
            End If
        Next
        
        Return primes
    End Function
    ' Function added for Euler 124.
    ' Returns prime factors of n as a list of prime numbers.
    ' Takes an optional cache to save time.
    Public Shared Function GetPrimeFactors ( ByVal n As Integer, Optional _
        ByRef primeList As List ( Of BigInteger ) = Nothing ) As List ( Of _
        BigInteger )
        
        Dim primeFactors As List ( Of BigInteger) = New List ( Of BigInteger ) _
            ()
        
        If primeList Is Nothing Then
            primeList = GetPrimes ( 2, n + 1 )
        End If
        
        Dim primePosition As Integer = primeList.Count = 1
        While n <> 1
            If primeList ( primePosition ) > n Then
                primePosition = primePosition - 1
            ElseIf n Mod primeList ( primePosition ) = 0 Then
                n = n / primeList ( primePosition )
                primeFactors.Add ( primeList ( primePosition ) )
            Else
                primePosition = primePosition - 1
            End If
        End While
        
        Return primeFactors
    End Function
    ' Function added for Euler 111.
    ' Returns 0 if the number is not prime or if it starts with a leading 0.
    Public Shared Function CheckDigitArrayIsPrime ( ByRef digits As Integer () ) As BigInteger
        
        Dim isPrime As Boolean
        Dim number As BigInteger = 0
        
        If digits (0) = 0 Then
            Return 0
        End If
        For i As Integer = 0 To digits.Count - 1
            number = number * 10 + digits ( i )
        Next
        
        ' For testing 10-digit primes, using the Rabin-Miller algorithm
        ' with 2, 3, 5, 7, and 11 is sufficient.
        isPrime = RabinMillerTest ( number, { 2, 3, 5, 7, 11 } )
        If isPrime Then
            Return number
        Else
            Return 0
        End If
    End Function
    ' Function added for Euler 111.
    ' Rabin Miller algorithm for determining probable primes.
    Public Shared Function RabinMillerTest ( ByVal candidate As BigInteger, ByRef testArray As Integer () ) As Boolean
        
        If candidate <= 1 Then
            Return False
        ElseIf candidate = 2 Then
            Return True
        ElseIf candidate Mod 2 = 0 Then
            Return False
        ElseIf candidate < 9 Then
            Return True
        ElseIf ( ( candidate Mod 3 ) = 0 ) Or ( ( candidate Mod 5 ) = 0 ) Then
            Return False
        End If
        
        Dim r As Integer = 0
        Dim a As BigInteger
        Dim d As BigInteger = candidate - 1
        Dim n As BigInteger = d
        Dim x As BigInteger
        Dim k As BigInteger
        
        ' Express n (candidate-1) as d^r * d
        While d Mod 2 = 0
            
            d = d / 2
            
            r = r + 1
        End While
        
        For i As Integer = 0 To testArray.Count - 1
            
            a = testArray (i)
            x = BigInteger.ModPow ( a, d, candidate )
            
            For j As Integer = 0 To r - 1
                k = ( x * x ) Mod candidate
                If ( k = 1 ) And ( x <> 1 ) And ( x <> ( candidate - 1 ) ) Then
                    Return False
                End If
                x = k
            Next
            If x <> 1 Then
                Return False
            End If
        Next
        
        Return True
    End Function
    ' Function added for Problem #118.
    ' A simple test of primacy.
    Public Shared Function TestPrime ( n As BigInteger ) As Boolean
        
        If n <= 1 Then
            Return False
        End If
        If n <= 3 Then
            Return True
        End If
        If ( n Mod 2 ) = 0 Then
            Return False
        End If
        If n <= 7 Then
            Return True
        End If
        If ( n Mod 3 ) = 0 Then
            Return False
        End If
        If n <= 23 Then
            Return True
        End If
        
        Dim sqrt As BigInteger = Math.Sqrt ( n )
        
        For i As BigInteger = 5 To sqrt Step 6
            If ( n Mod i ) = 0 Then
                Return False
            ElseIf ( n Mod ( i + 2 ) ) = 0 Then
                Return False
            End If
        Next
        
        Return True
    End Function
End Class