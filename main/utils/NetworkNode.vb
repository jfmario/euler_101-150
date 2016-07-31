
Imports System.Collections.Generic

Public Class NetworkNode
    
    Private iid As Integer
    Private lLinks As List ( Of NetworkLink )
    Private iPingValue As Integer
    
    Public Property ID As Integer
        Get
            Return iid
        End Get
        Set ( value As Integer )
            lLinks = value
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
    Public Property PingValue As Integer
        Get
            Return iPingValue
        End Get
        Set ( value As Integer )
            iPingValue = value
        End Set
    End Property
    
    Public Sub New ( valId As Integer )
        ID = valId
        PingValue = 0
        lLinks = New List ( Of NetworkLink )
    End Sub
    
    Public Sub Ping ( value As Integer )
        If PingValue = value Then
            Return
        Else
            
            PingValue = value
            
            For Each link As NetworkLink In Links
                link.Ping ( value )
            Next
            
            Return
        End If
    End Sub
End Class