Public Class Algorithms
    Public Shared Function CountFactors ( n As Integer ) As Integer
        
        Dim count As Integer = 1
        Dim dividedNumber As Integer = n
        Dim power As Integer = 1
        For Each primeNumber As Integer In Primes.PrimeList
        
            If primeNumber * primeNumber > n Then
                Return count * 2
            End If
            
            power = 1
            
            While dividedNumber Mod primeNumber = 0
            
                power = power + 2
                
                dividedNumber = dividedNumber / primeNumber
            End While
            
            count = count * power
            
            If dividedNumber = 1 Then
                Return count
    End Function
End Class