Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Module sqlconect
    Public Class sql
        'Public Shared con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\INTEL\Documents\Visual Studio 2010\Projects\Wifi and Data Manager\Wifi and Data Manager\G-Net.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")

        Public Shared con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=I:\Documents\Wifi and Data Manager\Wifi and Data Manager\G-Net.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
    End Class

    Public Class gnet
        Public Shared networks() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        Public Shared nadapter As NetworkInterface
        Public Shared index As Integer

    End Class

    Public Sub Identify_adapter()
        If gnet.networks(0).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 + gnet.networks(0).OperationalStatus = OperationalStatus.Up Then
            gnet.index = 0
        ElseIf gnet.networks(1).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 + gnet.networks(1).OperationalStatus = OperationalStatus.Up Then
            gnet.index = 1
        ElseIf gnet.networks(2).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 + gnet.networks(2).OperationalStatus = OperationalStatus.Up Then
            gnet.index = 2
        ElseIf gnet.networks(3).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
            gnet.index = 3
        ElseIf gnet.networks(4).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
            gnet.index = 4
        ElseIf gnet.networks(5).NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
            gnet.index = 5
        Else
            gnet.index = 6
        End If

    End Sub

End Module
