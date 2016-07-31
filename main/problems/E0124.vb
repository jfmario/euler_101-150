' E0124.vb
' Solves problem #124.
' 21417

Imports System.Collections.Generic
Imports System.Numerics

Module E0124

    Sub Main ()
        Go ()
    End Sub
    Sub Go ()
        
        Dim primeList As List ( Of BigInteger ) = Primes.GetPrimes ( 1, 100000 )
        Dim thisRad As Integer
        Dim radListing As List ( Of DataPoint ) = New List ( Of DataPoint ) ()
        
        For i As Integer = 1 To 100000
            radListing.Add ( New DataPoint ( i, rad ( i, primeList ) ) )
        Next
        
        radListing.Sort ()
        Console.WriteLine ( radListing ( 10000 - 1 ).N )
    End Sub
    
    Class DataPoint
        Implements IComparable
        
        Public N As Integer
        Public Rad As Integer
        
        Public Sub New ( ByVal intN As Integer, ByVal intRad As Integer )
            N = intN
            Rad = intRad
        End Sub
        
        Public Function CompareTo ( obj As Object ) As Integer Implements _
            IComparable.CompareTo
            If Rad <> obj.Rad Then
                Return Rad - obj.Rad
            End If
            Return N = obj.N
        End Function
    End Class
    
    Function rad ( ByVal n As Integer, Optional ByRef primesList As List _
        ( Of BigInteger ) = Nothing ) As Integer
        
        If n <= 3 Then
            Return n
        End If
        
        Dim uniquePrimeFactors As HashSet ( Of BigInteger ) = New HashSet ( Of _
            BigInteger ) ( Primes.GetPrimeFactors ( n, primesList ) )
        Dim product As Integer = 1
        
        For i As Integer = 0 To uniquePrimeFactors.Count - 1
            product = product * uniquePrimeFactors ( i )
        Next
        
        Return product
    End Function
End Module