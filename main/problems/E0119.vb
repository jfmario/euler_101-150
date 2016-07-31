' E0119.vb
' Solves problem #119.
' Uses NumberStrings
' 248155780267521

Imports System.Collection.Generic
Imports System.Numerics

Module E0119
    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        ' Create list of all a's
        Dim aList As List ( Of BigInteger ) = New List ( Of BigInteger )
        Dim power As BigInteger
        
        ' Try to create a's from bases 2-1000
        For base As Integer = 2 To 1000
            
            ' Raise base to powers up to 100
            power = base
            
            For exponent As Integer = 2 To 100
                power = power * base
                ' If the sum of power's digits equal the base, it is an a
                If NumberStrings.DigitSum ( power ) = base Then
                    aList.add ( power )
                End If
            Next
        Next
        
        ' Sort all the a's
        aList.Sort ()
        ' Answer is the 30th a
        Console.WriteLine ( aList ( 29 ) )
    End Sub
End Module