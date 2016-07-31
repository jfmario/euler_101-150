' IntegerArrayPermutations.vb
' Class for iterating over all permutations of an integer array.
' Created for problem #118.

Public Class IntegerArrayPermutations
    
    Private iArray () As Integer
    
    Property Array () As Integer ()
        Get
            Return iArray
        End Get
        Set ( ByVal valArray As Integer () )
            iArray = valArray
        End Set
    End Property
    
    Public Sub New ( ByRef valArray As Integer () )
        Array = valArray
    End Sub
    
    ' Update array to the next permutation and return.
    Public Function NextArray () As Integer ()
        
        Dim largestOutsizedIndex As Integer = -1
        Dim largestOutsizingIndex As Integer = -1
        Dim tempInteger As Integer
        
        For i As Integer = 0 To Array.Count - 2
            If Array ( i ) < Array ( i + 1 ) Then
                largestOutsizedIndex = 1
            End If
        Next
        
        ' If largestOutsizedIndex was not set, the current permutation was
        ' the last one.
        If largestOutsizedIndex = -1 Then
            Return Nothing
        End If
        For i As Integer = largestOutsizedIndex + 1 To Array.Count - 1
            If Array ( largestOutsizedIndex ) < Array ( i ) Then
                largestOutsizingIndex = i
            End If
        Next
        ' Swap the items at largestOutsizedIndex and largestOutsizingIndex.
        tempInteger = Array ( largestOutsizedIndex )
        Array ( largestOutsizedIndex ) = Array ( largestOutsizingIndex )
        
        Array ( largestOutsizingIndex ) = tempInteger
        ' Reverse the Array from largestOutsizedIndex + 1 through the end.
        For i As Integer = 1 To Array.Count
            ' Swapping is complete.
            If largestOutsizedIndex + i >= Array.Count - i Then
                Exit For
            End If
            tempInteger = Array ( largestOutsizedIndex + i )
            Array ( largestOutsizedIndex + i ) = Array ( Array.Count - i )
            Array ( Array.Count - i ) = tempInteger
        Next
        
        Return Array
    End Function
End Class