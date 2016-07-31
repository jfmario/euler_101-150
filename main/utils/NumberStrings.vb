' NumberStrings.vb
' Contains string-related operations for numbers.
' Created for problem #119.
' Edited for problem #125. 

Imports System.Numerics

Public Class NumberStrings
    Public Shared Function DigitSum ( ByVal n As BigInteger ) As Integer
        
        Dim strNumber As String = Convert.ToString ( n )
        Dim sum As Integer = 0
        
        For i As Integer = 0 To strNumber.Count - 1
            sum = sum + Convert.ToInt32 ( Integer.Parse ( strNumber.Chars ( i ) ) )
        Next
        
        Return sum
    End Function
    ' Added for problem #125.
    Public Shared Function IsPalindrome ( ByVal n As BigInteger ) As Boolean
        
        Dim i As Integer = 0
        Dim strNumber As String = Convert.ToString ( n )
        
        Dim j As Integer = strNumber.Count - 1
        While j >= i
            
            If strNumber.Chars ( i ) <> strNumber.Chars ( j ) Then
                Return False
            End If
        End While
        
        Return True
    End Function
End Class