' E0107.vb
' Solves problem #107.

Imports System.IO

Module E0107
    Sub Main ()
        
        Dim linkCost As Integer
        Dim i As Integer
        Dim j As Integer
        Dim link As NetworkLink
        Dim newWeight As Integer
        Dim network As NodeNetwork = New NodeNetwork ()
        Dim networkTxtLines As String ()
        Dim nodeCounter As Integer = 1
        Dim node As NetworkNode
        Dim oldWeight As Integer
        Dim splitLine As String ()
        
        networkTxtLines = File.ReadAllLines ( "network.txt" )
        For Each line As String In networkTxtLines
            
            node = New NetworkNode ( nodeCounter )
            network.Nodes.Add ( node )
            
            nodeCounter = nodeCounter + 1
        Next
        
        For i = 0 To network.Nodes.Count - 1
            
            splitLine = networkTxtLines (i).Split ( "," )
            
            For j = i + 1 To network.Nodes.Count - 1
                If splitLine (j) <> "-" Then
                    
                    linkCost = Convert.ToInt32 ( splitLine (j) )
                    link = New NetworkLink ( network.Nodes (i), _
                            network.Nodes (j), linkCost )
                    
                    network.Links.Add ( link )
                End If
            Next
        Next
        
        network.Links.Sort ( Function ( a As NetworkLink, b As NetworkLink )
                If a.Cost = b.Cost Then
                    Return 0
                ElseIf a.Cost > b.Cost Then
                    Return 1
                Else
                    Return -1
                End If
            End Function )
        oldWeight = network.Weight
        For i = 1 To network.Links.Count
            j = network.Links.Count - i
            network.Links (j).Status = False
            If network.IsComplete = False Then
                network.Links (j).Status = True
            End If
        Next
        netWeight = network.Weight
        
        Console.WriteLine ( "{0} - {1} = {2}", oldWeight, newWeight, _
                oldWeight - newWeight )
    End Sub
End Module