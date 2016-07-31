Public Class NetworkLink
    
    Private mNode1 As NetworkNode
    Private mNode2 As NetworkNode
    Private iCost As Integer
    Private bStatus As Boolean
    
    Public Property Node1 As NetworkNode
        Get
            Return mNode1
        End Get
        Set ( value As NetworkNode )
            mNode1 = value
        End Set
    End Property
    Public Property Node2 As NetworkNode
        Get
            Return mNode2
        End Get
        Set ( value As NetworkNode )
            mNode2 = value
        End Set
    End Property
    Public Property Cost As Integer
        Get
            If Status Then
                Return iCost
            Else
                Return 0
            End If
        End Get
        Set ( value As Integer )
            iCost = value
        End Set
    End Property
    Property Status As Boolean
        Get
            Return bStatus
        End Get
        Set ( value As Boolean )
            bStatus = value
        End Set
    End Property
    
    Public Sub New ( valNode1 As NetworkNode, valNode2 As NetworkNode, valCost As Integer )
        
        Node1 = valNode1
        Node2 = valNode2
        Cost = valCost
        Status = True
        
        Node1.Links.Add ( Me )
        Node2.Links.Add ( Me )
    End Sub
    
    Public Sub Ping ( value As Integer )
        If Status Then
            Node1.Ping ( value )
            Node2.Ping ( value )
        End If
    End Sub
End Class