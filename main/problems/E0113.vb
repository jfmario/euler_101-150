' E0113.vb
' Solution for Problem 113.
' Answer: 51161058134250

Imports System.Collections.Generic
Imports System.Numerics

Module E0113
    Sub Main ()
        
        Dim digits As Integer = 10
        Dim nonZeroDigits As Integer = digits - 1
        Dim places As Integer = 100
        Dim answer As BigInteger
        Dim decreasingNumbers As BigInteger
        Dim increasingNumbers As BigInteger
        Dim nonBouncyNumbers As BigInteger
        
        increasingNumbers = Combinations.FactorialFunction ( places + nonZeroDigits, nonZeroDigits ) - 1
        decreasingNumbers = Combinations.FactorialFunction ( places + digits, digits ) - ( places + 1 )
        
        ' Add increasing and decreasing numbers
        nonBouncyNumbers = increasingNumbers + decreasingNumbers
        ' Remove duplicate flat numbers
        nonBouncyNumbers = nonBouncyNumbers - ( 9 * places )
        answer = nonBouncyNumbers
        
        Console.WriteLine ()
        Console.WriteLine ( "{0}", answer )
    End Sub
End Module