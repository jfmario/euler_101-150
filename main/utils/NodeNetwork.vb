
Imports System.Collections.Generic

Public Class NodeNetwork
    
    Private lNodes As List ( Of NetworkNode )
    Private lLinks As List ( Of NetworkLink )
    
    Public Property Nodes As List ( Of NetworkNode )
        Get
            Return lNodes
        End Get
        Set ( value As List ( Of NetworkNode ) )
            lNodes = value
        End Set
    End Property
    Public Property Links As List ( Of NetworkLink )
        Get
            Return lLinks
        End Get
        Set ( value As List ( Of NetworkLink ) )
            lLinks = value
        End Set
    End Property
    Public ReadOnly Property Weight As Integer
        Get
            
            Dim count As Integer = 0
            
            For Each link As NetworkLink In Links
                count = count + link.Cost
            Next
            
            Return count
        End Get
    End Property
    Public ReadOnly Property IsComplete As Boolean
        Get
            Dim aValue As Integer = Nodes (0).PingValue + 1
            Nodes (0).Ping ( aValue )
            For Each node As NetworkNode In Nodes
                If node.PingValue <> aValue Then
                    Return False
                End If
            Next
            
            Return True
        End Get
    End Property
    
    Public Sub New ()
        Links = New List ( Of NetworkLink )
        Nodes = New List ( Of NetworkNode )
    End Sub
End Class