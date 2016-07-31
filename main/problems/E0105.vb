' E0105.vb
' Solves problem #105.

Imports System.IO

Module E0105
    Sub Main ()
        
        Dim numberSet As NumberSet
        Dim setsTxtLines As String ()
        Dim answer As Long = 0L
        
        setsTxtLines = File.ReadAllLines ( "sets.txt" )
        For Each setTxtLine As String In setsTxtLines
            numberSet = New NumberSet ( setTxtLine )
            If numberSet.IsSpecialSumSet () Then
                answer += numberSet.Sum
            End If
        Next
        
        Console.WriteLine ( "Answer: {0}", answer )
    End Sub
End Module