' Fibonacci.vb
' Made for Euler #104

Imports System.Numerics

''' <summary>
''' Iterator class for the Fibonacci sequence.</summary>
Public Class Fibonacci

    ' Keep track of the current number, last number, and which Fibonnaci
    '     number the current number is.
    Private biLast As BigInteger
    Private biCurr As BigInteger
    Private intNum As Integer
    
    Property Last() As BigInteger
        Get
            Return biLast
        End Get
        Set ( ByVal valLast As BigInteger )
            biLast = valLast
        End Set
    End Property
    Property Curr() As BigInteger
        Get
            Return biCurr
        End Get
        Set ( ByVal valCurr As BigInteger )
            biCurr = valCurr
        End Set
    End Property
    Property Num() As Integer
        Get
            Return intNum
        End Get
        Set ( ByVal valNum As Integer )
            intNum = valNum
        End Set
    End Property
    
    Public Sub New ()
        
        Last  = 0
        
        Curr = 1
        Num = 1
    End Sub
    
    ' Advance to a given start point in the Fibonacci sequence.
    Public Sub AdvanceTo ( fNumber As Integer )
        If Num >= fNumber Then
            Return
        End If
        While Num < fNumber
            NextNumber ()
        End While
    End Sub
    
    Public Function NextNumber () As BigInteger
        
        ' The next number in the sequence is the current number plus the
        '     previous number.
        Dim old As BigInteger = Curr
        Curr += Last
        
        Last = old
        
        Num += 1
        
        Return Curr
    End Function
End Class