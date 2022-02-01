Imports System.Data.SqlClient

Public Class Login

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialsetup()
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        Label1.Visible = True
        PictureBox2.Height = 40
        PictureBox2.Width = 40
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        Label1.Visible = False
        PictureBox2.Height = 35
        PictureBox2.Width = 35
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        Label2.Visible = True
        PictureBox3.Height = 40
        PictureBox3.Width = 40
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        Label2.Visible = False
        PictureBox3.Height = 35
        PictureBox3.Width = 35
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        Label3.Visible = True
        PictureBox4.Height = 40
        PictureBox4.Width = 40
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        Label3.Visible = False
        PictureBox4.Height = 35
        PictureBox4.Width = 35
    End Sub

    Private Sub RectangleShape2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Introduction.Show()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Hide()
        Introduction.Show()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Professorloginpage()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        adminloginpage()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        studentloginpage()
    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
        TextBox1.Clear()
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Clear()
    End Sub

    Private Sub TextBox3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox3.MouseClick
        TextBox3.Clear()
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.Clear()
    End Sub

    Private Sub TextBox5_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox5.MouseClick
        TextBox5.Clear()
    End Sub

    Private Sub TextBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.Clear()
    End Sub

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click
        adminlogin()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        adminlogin()
    End Sub

    Private Sub RectangleShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape3.Click
        Professorlogin()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Professorlogin()
    End Sub

    Private Sub RectangleShape4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape4.Click
        studentlogin()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        studentlogin()
    End Sub

    Private Sub Professorlogin()
        If TextBox3.Text = "" And TextBox4.Text = "" Then
            MsgBox("please enter username and password")
        ElseIf TextBox3.Text = "" Then
            MsgBox("please enter username")
        ElseIf TextBox4.Text = "" Then
            MsgBox("please enter password")
        Else
            Try
                Dim usr As String = TextBox3.Text
                Dim psw As String = TextBox4.Text
                Dim uqry As String = "select Username from Professor where Username='" & usr & "';"
                Dim pqry As String = "select Password from Professor where Password='" & psw & "';"
                Dim ucmd As New SqlCommand(uqry, sql.con)
                Dim pcmd As New SqlCommand(pqry, sql.con)
                Dim ured As SqlDataReader
                Dim pred As SqlDataReader
                sql.con.Open()
                ured = ucmd.ExecuteReader
                If ured.Read = True Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = True Then
                        pred.Close()
                        Me.Hide()
                        Introduction.Hide()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        Dim unam As String = "select Name from Professor where Username='" & usr & "';"
                        Dim cmd As New SqlCommand(unam, sql.con)
                        Dim red As SqlDataReader
                        red = cmd.ExecuteReader
                        red.Read()
                        Professor.Label4.Text = red.GetString(0)
                        red.Close()
                        sql.con.Close()
                        Professor.Show()
                        Exit Sub
                    End If
                    pred.Close()
                End If
                ured.Close()
                ured = ucmd.ExecuteReader
                If ured.Read = False Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = True Then
                        MsgBox("invalid username")
                        TextBox3.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
                ured.Close()
                ured = ucmd.ExecuteReader
                If ured.Read = True Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = False Then
                        MsgBox("invalid password")
                        TextBox4.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
                ured.Close()
                ured = ucmd.ExecuteReader
                If ured.Read = False Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = False Then
                        MsgBox("invalid username and password")
                        TextBox3.Clear()
                        TextBox4.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
            Catch ex As Exception
                MsgBox("Problem with connection")
            End Try
        End If
        sql.con.Close()

    End Sub

    Private Sub adminlogin()
        If TextBox1.Text = My.Settings.Developer And TextBox2.Text = My.Settings.Language Then
            Me.Hide()
            Introduction.Hide()
            Management.Show()
            TextBox1.Clear()
            TextBox2.Clear()
        ElseIf TextBox1.Text = My.Settings.Developer And TextBox2.Text <> My.Settings.Language Then
            MsgBox("invalid password")
            TextBox2.Clear()
            TextBox2.Focus()
        ElseIf TextBox1.Text <> My.Settings.Developer And TextBox2.Text = My.Settings.Language Then
            MsgBox("invalid username")
            TextBox1.Clear()
            TextBox1.Focus()
        Else
            MsgBox("invalid username and password")
            TextBox1.Clear()
            TextBox2.Clear()
        End If
    End Sub

    Private Sub adminloginpage()
        PictureBox1.Image = PictureBox2.Image
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        RectangleShape1.Visible = True
        Label4.Visible = True
        RectangleShape3.Visible = False
        Label6.Visible = False
        RectangleShape4.Visible = False
        Label7.Visible = False
    End Sub

    Private Sub Professorloginpage()
        PictureBox1.Image = PictureBox3.Image
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = False
        TextBox6.Visible = False
        Label6.Text = "Login"
        RectangleShape3.Visible = True
        Label6.Visible = True
        RectangleShape1.Visible = False
        Label4.Visible = False
        RectangleShape4.Visible = False
        Label7.Visible = False
    End Sub

    Private Sub studentloginpage()
        PictureBox1.Image = PictureBox4.Image
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = True
        TextBox6.Visible = True
        RectangleShape1.Visible = False
        RectangleShape3.Visible = False
        RectangleShape4.Visible = True
        Label4.Visible = False
        Label6.Visible = False
        Label7.Visible = True
        Label7.Text = "Login"
    End Sub

    Private Sub initialsetup()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Me.Icon = Wifi_and_Data_Manager.My.Resources.Task_Icon
        TextBox1.BorderStyle = BorderStyle.None
        TextBox2.BorderStyle = BorderStyle.None
        TextBox3.BorderStyle = BorderStyle.None
        TextBox4.BorderStyle = BorderStyle.None
        TextBox5.BorderStyle = BorderStyle.None
        TextBox6.BorderStyle = BorderStyle.None
        TextBox1.Text = "User name"
        TextBox2.Text = "Password"
        TextBox3.Text = "User name"
        TextBox4.Text = "Password"
        TextBox5.Text = "User name"
        TextBox6.Text = "Password"
        TextBox3.Location = TextBox1.Location
        TextBox4.Location = TextBox2.Location
        TextBox5.Location = TextBox1.Location
        TextBox6.Location = TextBox2.Location
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        RectangleShape3.Location = RectangleShape1.Location
        Label6.Location = Label4.Location
        RectangleShape3.Visible = False
        Label6.Visible = False
        RectangleShape4.Location = RectangleShape1.Location
        Label7.Location = Label4.Location
        RectangleShape4.Visible = False
        Label7.Visible = False
        sql.con.Close()
    End Sub

    Private Sub studentlogin()
        If TextBox5.Text = "" And TextBox6.Text = "" Then
            MsgBox("please enter username and password")
        ElseIf TextBox5.Text = "" Then
            MsgBox("please enter username")
        ElseIf TextBox6.Text = "" Then
            MsgBox("please enter password")
        Else
            Try
                Dim usr As String = TextBox5.Text
                Dim psw As String = TextBox6.Text
                Dim uqry As String = "select Username from Student where Username='" & usr & "';"
                Dim pqry As String = "select Password from Student where Password='" & psw & "';"
                Dim ucmd As New SqlCommand(uqry, sql.con)
                Dim pcmd As New SqlCommand(pqry, sql.con)
                Dim ured As SqlDataReader
                Dim pred As SqlDataReader
                sql.con.Open()
                ured = ucmd.ExecuteReader
                If ured.Read = True Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = True Then
                        pred.Close()
                        Me.Hide()
                        Introduction.Hide()
                        TextBox5.Clear()
                        TextBox6.Clear()
                        Dim unam As String = "select Regno from Student where Username='" & usr & "';"
                        Dim cmd As New SqlCommand(unam, sql.con)
                        Dim red As SqlDataReader
                        sql.con.Close()
                        sql.con.Open()
                        red = cmd.ExecuteReader
                        red.Read()
                        Student.Label4.Text = red.GetValue(0)
                        red.Close()
                        sql.con.Close()
                        Student.Show()
                    End If
                    pred.Close()
                End If
                ured.Close()
                sql.con.Open()
                ured = ucmd.ExecuteReader
                If ured.Read = False Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = True Then
                        MsgBox("invalid username")
                        TextBox5.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
                ured.Close()
                ured = ucmd.ExecuteReader
                If ured.Read = True Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = False Then
                        MsgBox("invalid password")
                        TextBox6.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
                ured.Close()
                ured = ucmd.ExecuteReader
                If ured.Read = False Then
                    ured.Close()
                    pred = pcmd.ExecuteReader
                    If pred.Read = False Then
                        MsgBox("invalid username and password")
                        TextBox5.Clear()
                        TextBox6.Clear()
                        ured.Close()
                    End If
                    pred.Close()
                End If
            Catch ex As Exception
                MsgBox("Problem with connection")
            End Try
        End If
        sql.con.Close()

    End Sub

End Class