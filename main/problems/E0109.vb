'38182

Imports System.Collections.Generic

Module E0109
    Sub Main ()
        
        Dim count As Integer = 0
        Dim doublePossibilities As List ( Of Integer )
        Dim max As Integer = 99
        Dim scorePossibilities As List ( Of Integer )
        
        ' Generate all dart score and double possibilities
        scorePossibilities = New List ( Of Integer )
        doublePossibilities = New List ( Of Integer )
        For i As Integer = 1 To 20
            scorePossibilities.Add ( i )
            scorePossibilities.Add ( i * 2 )
            scorePossibilities.Add ( i * 3 )
            doublePossibilities.Add ( i * 2 )
        Next
        
        scorePossibilities.Add ( 25 )
        scorePossibilities.Add ( 50 )
        doublePossibilities.Add ( 50 )
        
        For Each i As Integer In doublePossibilities
            If i <= max Then
                count = count + 1
            End If
        Next
        For Each i As Integer In scorePossibilities
            For Each j As Integer In doublePossibilities
                If i + j <= max Then
                    count = count + 1
                End If
            Next
        Next
        
        For i As Integer = 0 To scorePossibilities.Count - 1
            For j As Integer = i To scorePossibilities.Count - 1
                For Each k As Integer In doublePossibilities
                    If scorePossibilities (i) + scorePossibilities (j) _
                            + k <= max Then
                        count = count + 1
                    End If
                Next
            Next
        Next
        
        Console.WriteLine ( "{0}", count )
    End Sub
End Module