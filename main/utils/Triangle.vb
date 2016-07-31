Public Class Triangle
    
    Private lineA As Line
    Private lineB As Line
    Private lineC As Line
    
    Public Property A () As Line
        Get
            Return lineA
        End Get
        Set ( ByVal valA As Line )
            lineA = valA
        End Set
    End Property
    Public Property B () As Line
        Get
            Return lineB
        End Get
        Set ( ByVal valB As Line )
            lineB = valB
        End Set
    End Property
    Public Property C () As Line
        Get
            Return lineC
        End Get
        Set ( ByVal valC As Line )
            lineC = valC
        End Set
    End Property
    
    Public Sub New ( ByVal valA As Point, ByVal valB As Point, ByVal valC _
            As Point )
        A = New Line ( valA, valB )
        B = New Line ( valB, valC )
        C = New Line ( valC, valA )
    End Sub
    Public Sub New ( ByVal valA As Line, ByVal valB As Line, -
            ByVal valC As Line )
        A = valA
        B = valB
        C = valC
    End Sub
    Public Sub New ( ByVal valA1 As Double, ByVal valA2 As Double, ByVal _
            valB1 As Double, ByVal valB2 As Double, ByVal valC1 As Double, _
            ByVal valC2 As Double )
        
        Dim pa As New Point ( valA1, valA2 )
        Dim pb As New Point ( valB1, valB2 )
        Dim pc As New Point ( valC1, valC2 )
        
        A = New Line ( pa, pb )
        B = New Line ( pb, pc )
        C = New Line ( pc, pa )
    End Sub
    
    ' Determine if origin is within the Triangle by using the Ray Test
    '   with the positive y-axis.
    Public Function ContainsOrigin () As Boolean
        
        Dim yInterceptCount As Integer = 0
        
        If A.YIntercept > Y And A.YInterceptInSegment Then
            yInterceptCount += 1
        End If
        If B.YIntercept > Y And B.YInterceptInSegment Then
            yInterceptCount += 1
        End If
        If C.YIntercept > Y And C.YInterceptInSegment Then
            yInterceptCount += 1
        End If
        If yInterceptCount Mod 2 = 1 Then
            Return True
        End If
        
        Return False
    End Function
End Class