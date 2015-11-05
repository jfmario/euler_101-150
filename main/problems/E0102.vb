' Answer: 228
Imports System.IO

Module E0102
    Sub Main ()
    
        Dim coordsArray As String ()
        Dim doubleArray (6) As Double
        Dim line As String
        Dim originCount As Integer
        Dim triangle As Triangle
        Dim triangleTextLines As String ()
        
        triangleTextLines = File.ReadAllLines ( "triangles.txt" )
        For Each line in triangleTextLines
            
            coordsArray = line.Split ( "," )
            
            For i As Integer = 0 To 5
                doubleArray ( i ) = Convert.ToDouble ( coordsArray ( i ) )
            Next
            
            triangle = New Triangle ( doubleArray (0), doubleArray (1), _
                    doubleArray (2), doubleArray (3), doubleArray (4), _
                    doubleArray (5) )
            If triangle.ContainsOrigin () Then
                originCount += 1
            End If
        Next
        
        Console.Write ( "Answer: " )
        Console.WriteLine ( originCount )
    End Sub
End Module