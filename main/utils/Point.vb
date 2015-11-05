'Class representing an X,Y coordinate point
Public Class Point
    
    Private i_x As Double
    Private i_y As Double
    
    Property X() As Double
        Get
            return i_x
        End Get
        Set ( ByVal Value As Double )
            i_x = Value
        End Set
    End Property
    Property Y() As Double
        Get
            return i_y
        End Get
        Set ( ByVal Value As Double )
            i_y = Value
        End Set
    End Property
    
    Public Sub New ( ByVal valX As Double, ByVal valY As Double )
        X = valX
        Y = valY
    End Sub
    
    ' slope = ( y_2 - y_1 ) / ( x_2 - x_1 )
    Public Function SlopeToOtherPoint ( otherPoint As Point ) As Double
        
        Dim num As Double = Y - otherPoint.Y
        Dim den As Double = X - otherPoint.X
        
        Return num / den
    End Function
End Class