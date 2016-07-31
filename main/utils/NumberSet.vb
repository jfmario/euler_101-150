
Public Class NumberSet
    
    Private intSet As SortedSet ( Of Integer ) = New SortedSet ( Of Integer ) ()
    
    Property Numbers As SortedSet ( Of Integer )
        Get
            Return intSet
        End Get
        Set ( value As SortedSet ( Of Integer ) )
            intSet = value
        End Set
    End Property
    ReadOnly Property Sum As Integer
        Get
            Return Numbers.Sum
        End Get
    End Property
    
    Private Function subSum ( n As Integer ) As Integer
        
        Dim sum As Integer = 0
        
        For i As Integer = 0 To Numbers.Count - 1
            If ( n And 1 ) = 1 Then
                sum += Numbers (i)
            End If
            n = n >> 1
        Next
        
        Return sum
    End Function
    Private Function subSums () As Integer ()
        Dim sums ( Math.Pow ( 2, Numbers.Count ) - 1 ) As Integer
        For i As Integer = 0 To sums.Count - 1
            sums (i) - subSum (i)
        Next
        Return sums
    End Function
    Private Function testRule1 ( sums As Integer () ) As Boolean
        
        Dim count As Integer = 1
        Dim k As Integer
        For i As Integer = 0 To sums.Count - 1
            
            k = i
            
            While k <> -1
            
                count += 1
                k+= 1
                
                If k >= sums.Count Then
                    Exit For
                End If
                If sums.Skip ( k + 1 ).Contains ( sums (i) ) Then
                    k = sums.Skip (k).ToList ().IndexOf ( sums (i) ) + k
                Else
                    k = -1
                End If
                If k <> -1 And ( ( i And k ) = 0 ) Then
                    Return False
                End If
            End While
        Next
        
        Return True
    End Function
    Private Function testRule2 () As Boolean
        
        Dim frontSum As Integer = Numbers (0)
        Dim backSum As Integer = 0
        For i As Integer = 0 To Numbers.Count - 2
            
            frontSum += Numbers ( i + 1 )
            backSum += Numbers ( Numbers.Count - i -1 )
            
            If frontSum <= backSum Then
                Return False
            End If
        Next
        
        Return True
    End Function
    
    Public Sub New ( line As String )
        Dim strList As String () = line.Split ( "," )
        For Each numStr As String in strList
            Numbers.Add ( Convert.ToInt32 ( numStr ) )
        Next
    End Sub
    Public Sub Write ()
        
        Console.Write ( "{ " )
        
        For Each i As Integer In Numbers
            Console.Write ( "{0} ", i )
        Next
        
        Console.WriteLine ( "}" )
    End Sub
    
    Public Function IsSpecialSumSet () As Boolean
        
        If testRule2 () Then
            Dim temp As Integer () = subSums ()
            If testRule1 ( temp ) Then
                Return True
            End If
        End If
        Return False
    End Function
End Class