
Imports System.Numerics

Public Class Fibonacci

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
    
    Public Sub AdvanceTo ( fNumber As Integer )
        If Num >= fNumber Then
            Return
        End If
        While Num < fNumber
            NextNumber ()
        End While
    End Sub
    
    Public Function NextNumber () As BigInteger
        
        Dim old As BigInteger = Curr
        Curr += Last
        
        Last = old
        
        Num += 1
        
        Return Curr
    End Function
End Class