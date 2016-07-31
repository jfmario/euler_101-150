' E0122.vb
' Solves problem #122.
' Kind of a Djikstra approach
' 1582

Imports System.Collections.Generic

Module E0122

    Class DataPoint
        
        Public TotalValue As Integer
        Public FoundValues As List ( Of Integer )
        Public Steps As Integer
        
        Sub New ()
            
            TotalValue = 1
            
            FoundValues = New List ( Of Integer ) ()
            FoundValues.Add ( 1 )
            
            Steps = 0
        End Sub
        Sub New ( ByRef oldDp As DataPoint, ByVal exponent As Integer )
            
            TotalValue = oldDp.TotalValue + exponent
            
            FoundValues = New List ( Of Integer ) ()
            For i As Integer = 0 To oldDp.FoundValues.Count - 1
                FoundValues.Add ( oldDp.FoundValues ( i ) )
            Next
            FoundValues.Add ( TotalValue )
            
            Steps = oldDp.Steps += 1
        End Sub
    End Class
    
    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim answer As Integer = 0
        For i As Integer = 1 To 200
            answer = answer + GetM ( i )
        Next
        
        Console.WriteLine ( answer )
    End Sub
    
    Function GetM ( ByVal k As Integer ) As Integer
        
        If k = 1 Then
            Return 0
        End If
        
        Dim lastLayer As List ( Of DataPoint ) = New List ( Of DataPoint ) ()
        Dim nextLayer As List ( Of DataPoint )
        Dim nextItem As DataPoint
        lastLayer.Add ( New DataPoint () )
        
        While True
            
            nextLayer = New List ( Of DataPoint )
            
            For i As Integer = 0 To lastLayer.Count - 1
                For j As Integer = 0 To lastLayer ( i ).FoundValues.Count - 1
                    nextItem = New DataPoint ( lastLayer (i ), _
                        lastLayer ( i ).FoundValues ( j ) )
                    If nextItem.TotalValue = k Then
                        Return nextItem.Steps
                    End If
                    nextLayer.Add ( nextItem )
                Next
            Next
            
            lastLayer = nextLayer
        End While
        
        Return 0
    End Function
End Module