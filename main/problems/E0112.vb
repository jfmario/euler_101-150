' Answer: 1587000
' solved without help (easy)

Module E0112
    Sub Main ()
        
        Dim target As Double = 0.99
        Dim reverseNumber As Integer
        Dim sortedNumber As Integer
        Dim answer As Long
        ' Start with 0 bouncy numbers
        Dim count As Long = 0
        ' Start at 100 because there are no two-digit bouncy numbers
        Dim number As Long = 99
        Dim strNumber As String
        Dim arrStrNumber As Char ()
        
        While True
            
            number += 1
            ' Convert current number to Char array
            strNumber = Convert.ToString ( number )
            
            arrStrNumber = strNumber.ToCharArray ()
            ' Sort the array and convert back to number
            Array.Sort ( arrStrNumber )
            sortedNumber = convert.ToInt32 ( arrStrNumber )
            
            ' If true, number is an increasing number
            If sortedNumber = number Then
                Continue While
            End If
            
            ' Reverse sorted array and convert that to number
            Array.Reverse ( arrStrNumber )
            reverseNumber = Convert.ToInt32 ( arrStrNumber )
            
            ' If true, number is a decreasing number
            If reverseNumber = number Then
                Continue While
            End If
            
            count += 1
            If number * target = count Then
                
                answer = number
                
                End While
            End If
        End While
        
        Console.WriteLine ( "{0}", answer )
    End Sub
End Module