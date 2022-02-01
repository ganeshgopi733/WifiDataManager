Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.Net

Public Class Professor

    Private startUploaded, startDownloaded, downS, upS As Long

    Private Sub Professor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Icon = Wifi_and_Data_Manager.My.Resources.Task_Icon
        UserControl31.Hide()
        UserControl41.Hide()

        Identify_adapter()

        gnet.nadapter = NetworkInterface.GetAllNetworkInterfaces(gnet.index)
        startDownloaded = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesReceived / 1048576)
        downS = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesReceived / 1048576)
        startUploaded = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesSent / 1048576)
        upS = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesSent / 1048576)
        UpdateStats()
        Timer1.Start()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseHover
        Label2.BackColor = Color.Gainsboro
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.BackColor = Color.White
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.Click
        Dim confirm As MsgBoxResult
        confirm = MsgBox("Are you sure to exit ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            Me.Close()
            Loader.Close()
            Introduction.Close()
            Login.Close()
            Management.Close()
            Student.Close()
        End If
    End Sub

    Private Sub Label3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseHover
        Label3.BackColor = Color.Red
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.BackColor = Color.White
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        Label4.ForeColor = Color.White
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.Maroon
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim c As MsgBoxResult
        c = MsgBox("Are u sure want to signout of the app", MsgBoxStyle.YesNo, "G-Net")
        If c = MsgBoxResult.Yes Then
            Me.Hide()
            Login.Show()
            UserControl31.TextBox1.Clear()
            UserControl31.TextBox2.Clear()
            UserControl31.TextBox3.Clear()
            UserControl31.TextBox4.Clear()
            UserControl31.TextBox5.Clear()
            UserControl31.TextBox6.Clear()
            UserControl31.Label1.Text = "Name"
            UserControl31.Hide()
            Timer1.Stop()
            UpdateDataUsage()
            Label7.Text = "0"
            Label8.Text = "0"
        Else

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UserControl31.Show()
        UserControl31.BringToFront()
        UserControl31.Label1.Text = Label4.Text
        UserControl31.Dock = DockStyle.Fill
        UserControl41.Hide()
        UserControl31.Label2.Text = "ID"
        UserControl31.PictureBox1.Image = My.Resources.professor_login
        UserControl31.Label2.Location = New Point(141, 222)
        UserControl31.TextBox1.Location = New Point(287, 221)
        UserControl31.Label8.Visible = False
        UserControl31.TextBox7.Visible = False
        Dim qurey As String = "select * from Professor where Name='" & Label4.Text & "';"
        Try
            Dim cmd As New SqlCommand(qurey, sql.con)
            Dim red As SqlDataReader
            sql.con.Open()
            red = cmd.ExecuteReader
            red.Read()
            UserControl31.TextBox1.Text = red.GetValue(2)
            UserControl31.TextBox2.Text = red.GetString(1)
            UserControl31.TextBox3.Text = red.GetString(3)
            UserControl31.TextBox4.Text = red.GetString(4)
            UserControl31.TextBox5.Text = red.GetString(5)
            UserControl31.TextBox6.Text = red.GetString(6)
        Catch ex As Exception
            UserControl31.Hide()
            MsgBox("Problem with your login please login again", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        UpdateStats()
        UpdateDataUsage()

    End Sub

    Private Sub UpdateStats()
        Try
            gnet.nadapter = NetworkInterface.GetAllNetworkInterfaces(gnet.index)
            Label7.Text = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesReceived / 1048576 - startDownloaded)
            downS = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesReceived / 1048576 - startDownloaded)
            Label8.Text = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesSent / 1048576 - startUploaded)
            upS = Math.Round(gnet.nadapter.GetIPv4Statistics.BytesSent / 1048576 - startUploaded)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UserControl41.Show()
        UserControl41.Dock = DockStyle.Fill
        UserControl41.BringToFront()
        UserControl31.Hide()

    End Sub
    Public Shared Function InternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://google.com")
                    Return True
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub UpdateDataUsage()
        sql.con.Open()
        Dim squery As String = "select Data from Professor where Name='" & Label4.Text & "';"
        Dim scmd As New SqlCommand(squery, sql.con)
        Dim red As SqlDataReader
        red = scmd.ExecuteReader
        red.Read()
        Dim value As Integer = Convert.ToInt64(downS) + Convert.ToInt64(red.GetValue(0)) + Convert.ToInt64(upS)
        red.Close()
        ' Updating data usage
        Dim query As String = "update Professor set Data='" & value & "' where Name='" & Label4.Text & "';"
        Dim cmd As New SqlCommand(query, sql.con)
        cmd.ExecuteNonQuery()
        sql.con.Close()
        downS = 0
        upS = 0
    End Sub

End Class