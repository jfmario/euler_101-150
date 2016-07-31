' E0125.vb
' Solves problem #125.
' 2906969179

Imports System.Collections.Generic
Imports System.Numerics

Module E0124
    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim answer As BigInteger = 0
        ' Use a set in case duplicate palindromes are possible.
        Dim answerSet As HashSet ( Of BigInteger ) = New HashSet ( Of _
            BigInteger ) ()
        Dim limit As BigInteger = BigInteger.Pow ( 10, 8 )
        Dim root As BigInteger = 1
        Dim square As BigInteger = 0
        Dim squaresList As List ( Of BigInteger ) = New List ( Of BigInteger )
        
        While square < limit
            
            square = root * root
            squaresList.Add ( square )
            
            root = root + 1
        End While
        
        For i As Integer = 0 To squaresList.Count - 1
            Dim sum As BigInteger = squaresList ( i )
            For j As Integer = i + 1 To squaresList.Count - 1
                sum = sum + squaresList ( j )
                If sum >= limit Then
                    Exit For
                End If
                If NumberStrings.IsPalindrome ( sum ) Then
                    answerSet.Add ( sum )
                End If
            Next
        Next
        
        For k As Integer = 0 To answerSet.Count - 1
            answer = answer + answerSet ( k )
        Next
        
        Console.WriteLine ( answer )
    End Sub
End Module