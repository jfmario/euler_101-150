
Imports System.Numerics

Public Class PandigitalOperations
    
    Private arrDigits As String () = { "1", "2", "3", "4", "5", "6", "7", "8", _
            "9", }
    Private lonCeil As Long = Math.Pow ( 10, 9 )
    
    ReadOnly Property Ceil As Long
        Get
            Return lonCeil
        End Get
    End Property
    ReadOnly Property Digits As String ()
        Get
            Return arrDigits
        End Get
    End Property
    
    Public Function IsPandigital ( Number As Long ) As Boolean
        
        Dim strNumber As String = Convert.ToString ( Number )
        
        For i As Integer = 0 To 8
            If strNumber.IndexOf ( Digits ( i ) ) = -1 Then
                Return False
            End If
        Next
        
        Return True
    End Function
    Public Function IsPandigitalFirst9 ( Number As BigInteger ) As Boolean
        
        Dim digitCount As Long = 1 + BigInteger.Log10 ( Number )
        Dim first9 As BigInteger = Number / BigInteger.Pow ( 10, digitCount - 9 )
        
        Return IsPandigital ( first9 )
    End Function
    Public Function IsPandigitalLast9 ( Number As BigInteger ) As Boolean
        Dim last9 As Long = Number Mod Ceil
        Return IsPandigital ( last9 )
    End Function
End Class