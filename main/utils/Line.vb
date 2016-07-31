Public Class Line

    Private pointA As Point
    Private pointB As Point
    Private doubleSlope As Double
    Private pointYIntercept As Point
    
    Public Property A () As Point
        Get
            Return pointA
        End Get
        Set ( ByVal valA As Point )
            pointA = valA
        End Set
    End Property
    Public Property B () As Point
        Get
            Return pointB
        End Get
        Set ( ByVal valB As Point )
            pointB = valB
        End Set
    End Property
    Public Property Slope () As Double
        Get
            Return doubleSlope
        End Get
        Set ( ByVal valSlope As Double )
            doubleSlope = valSlope
        End Set
    End Property
    Public Property YIntercept As Point
        Get
            Return pointYIntercept
        End Get
        Set ( ByVal valYIntercept As Point )
            pointYIntercept = valYIntercept
        End Set
    End Property
    Public ReadOnly Property YInterceptInSegment () As Boolean
        Get
            
            If A.X >= 0 And B.X <= 0 Then
                Return True
            End If
            If A.X <= 0 And B.X >= 0 Then
                Return True
            End If
            
            Return False
        End Get
    End Property
    
    Public Sub New ( ByVal valA As Point, ByVal valB As Point )
        A = valA
        B = valB
        Slope = A.SlopeToOtherPoint ( B )
        ' b = y - mx
        YIntercept = New Point ( 0, A.Y - Slope * A.X )
    End Sub
End Class