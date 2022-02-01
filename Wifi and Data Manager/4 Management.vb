Imports System.Net
Imports System.Data.SqlClient

Public Class Management

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Icon = Wifi_and_Data_Manager.My.Resources.Task_Icon
        UserControl21.Hide()
        UserControl51.Hide()
        UserControl21.Height = Panel3.Height
        UserControl21.Width = Panel3.Width
        UserControl21.BackColor = Color.Transparent
        Button4.Location = New Point(1, 194)
        UserControl61.Hide()
        Label6.Hide()
        DataGridView1.Hide()
        PictureBox3.Hide()
        Dim query As String = "select Regno from Temp;"
        Dim cmd As New SqlCommand(query, sql.con)
        Dim red As SqlDataReader
        sql.con.Open()
        red = cmd.ExecuteReader
        Try
            Do While red.Read
                Label5.Text += 1
            Loop
        Catch ex As Exception
        End Try
        sql.con.Close()
        If Label5.Text = 0 Then
            Label5.Hide()
            'Button4.Enabled = False
        Else
            fillgrid()
        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Dim confirm As MsgBoxResult
        confirm = MsgBox("Are you sure to exit ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            Me.Close()
            Loader.Close()
            Introduction.Close()
            Login.Close()
            Professor.Close()
            Student.Close()
        End If

    End Sub

    Private Sub Label3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.BackColor = Color.Red
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.BackColor = Color.White
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

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        Label4.ForeColor = Color.PaleVioletRed
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim c As MsgBoxResult
        c = MsgBox("Are u sure want to signout of the app", MsgBoxStyle.YesNo, "G-Net")
        If c = MsgBoxResult.Yes Then
            Me.Hide()
            Login.Show()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UserControl21.Show()
        UserControl21.BringToFront()
        UserControl21.Dock = DockStyle.Fill
        UserControl51.Hide()
        UserControl61.Hide()
        UserControl21.BackColor = Color.Transparent

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UserControl21.Hide()
        UserControl51.Show()
        UserControl51.BringToFront()
        UserControl51.Dock = DockStyle.Fill
        UserControl51.Label1.Show()
        UserControl51.Label2.Show()
        UserControl51.GroupBox1.Show()
        UserControl51.DataGridView1.Show()
        UserControl51.DataGridView2.Show()
        UserControl61.Hide()
        UserControl51.BackColor = Color.Transparent

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UserControl21.Hide()
        UserControl51.Hide()
        UserControl61.Show()
        UserControl61.BringToFront()
        UserControl61.Dock = DockStyle.Fill
        UserControl61.ComboBox1.Hide()
        UserControl61.TextBox1.Hide()
        UserControl61.Label1.Hide()
        UserControl61.Button1.Hide()
        UserControl61.Button2.Hide()
        UserControl61.BackColor = Color.Transparent

    End Sub

    Private Sub Button4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        Label5.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Label5.BackColor = Color.Transparent
    End Sub

    Private Sub fillgrid()
        Dim query As String = "select * from Temp;"
        Dim adapter As New SqlDataAdapter(query, sql.con)
        Dim ds As New DataSet
        adapter.Fill(ds)
        UserControl61.DataGridView1.DataSource = ds.Tables(0)
        Dim dtbutton1, dtbutton2 As New DataGridViewButtonColumn
        dtbutton1.Text = "accept"
        dtbutton2.Text = "deny"
        dtbutton1.HeaderText = "permission"
        dtbutton2.HeaderText = "permission"
        dtbutton1.UseColumnTextForButtonValue = True
        dtbutton2.UseColumnTextForButtonValue = True
        dtbutton1.Width = 70
        dtbutton2.Width = 70
        UserControl61.DataGridView1.Columns.Add(dtbutton1)
        UserControl61.DataGridView1.Columns.Add(dtbutton2)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label6.Show()
        DataGridView1.Show()
        PictureBox3.Show()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim query As String = "select Regno, Name, Department, Data as Dataused from Student where Data>5 order by Data;"
        Dim adapter As New SqlDataAdapter(query, sql.con)
        Dim ds As New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Label6.Hide()
        DataGridView1.DataSource = Nothing
        DataGridView1.Hide()
        PictureBox3.Hide()
    End Sub
End Class