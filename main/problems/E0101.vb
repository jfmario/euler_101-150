' Yields correct answer

Imports System.Collections.Generic

Module E0101
    
    Sub Main ()
        Test ()
        Go ()
    End Sub
    
    Sub Test ()
        Dim f As New TestCaseFunction ()
        Console.Write ( "Test Case: " )
        Console.WriteLine ( Process ( f, 5 ) )
    End Sub
    Sub Go ()
        Dim f As New MainFunction ()
        Console.Write ( "Answer: " )
        Console.WriteLine ( Process ( f, 14 ) )
    End Sub
    
    Function Process ( fX As FunctionX, max As Integer ) As Long
        
        Dim sum As Long = 0
        Dim pList As List ( Of Point )
        
        ' Generate the list of correct points
        pList = GeneratePoints ( fX, max )
        For i As Integer = 1 To max
            For j As Integer = 1 To max
                ' Apply polynomial interpolation
                Dim jSolution As Double = OptimumPolynomial ( j,
                    pList.getRange ( 0, i ) )
                ' If the result is a First Incorrect Term
                If jSolution <> pList.Item ( j - 1 ).Y
                    
                    sum += jSolution
                    
                    ' If the result was a FIT, it was added to the total and it is time to go to the next sequence
                    Exit For
                End If
            Next
        Next
        
        Return sum
    End Function
    
    ' Generates points from function f(x) using x values 1 to max
    Function GeneratePoints ( fX As FunctionX, max As Integer ) As List ( Of Point )
        
        Dim points As New List ( Of Point )
        
        For i As Integer = 1 To max
            points.Add ( new Point ( i, fX.GoLong ( i ) ) )
        Next
        
        Return points
    End Function
    'Runs an optimum polynomial for generating sequence pList, solving for x = n
    Function OptimumPolynomial ( n As Integer, pList As List ( Of Point ) ) As Double
        
        Dim answer As Long =  0
        Dim numerator As Double
        Dim denominator As Double
        Dim currentY As Double
        
        For i As Integer = 0 To pList.Count - 1
            
            numerator = 1
            denominator = 1
            
            currentY = pList.Item ( i ).Y
            ' Create the numerator and denominator of the fraction
            For j As Integer = 0 To pList.Count - 1
                If j = i
                    Continue For
                End If
                numerator *= n - pList.Item ( j ).X
                denominator *= pList.Item ( i ).X - pList.Item ( j ).X
            Next
            
            answer += ( numerator / denominator * currentY )
        Next
        
        Return answer
    End Function
    
    ' PRIVATE CLASSES EXTEND FunctionX
    ' Class representing f(x) = x ^ 3
    Class TestCaseFunction
        Inherits FunctionX
        Overrides Public Function GoLong ( x As Long ) As Long
            return Math.Pow ( x, 3 )
        End Function
    End Class
    
    Class MainFunction
        Inherits FunctionX
        Overrides Public Function GoLong ( x As Long ) As Long
            return 1 - x + Math.Pow ( x, 2 ) - Math.Pow ( x, 3 ) + Math.Pow ( x, 4 ) - Math.Pow ( x, 5 ) + Math.Pow ( x, 6 ) - Math.Pow ( x, 7 ) + Math.Pow ( x, 8 ) - Math.Pow ( x, 9 ) + Math.Pow ( x, 10 )
        End Function
    End Class
End Module