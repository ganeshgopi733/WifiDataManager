Imports System.Data.SqlClient

Public Class UserControl1

    Private Sub UserControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Hide()
        PictureBox2.Hide()
        PictureBox3.Hide()
        PictureBox4.Hide()
        PictureBox5.Hide()
        PictureBox6.Hide()
        TextBox3.Enabled = False
        PictureBox2.Location = PictureBox1.Location
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        facultyview()
        textfieldclear()
        Dim query As String = "select Profid + 1 from Professor;"
        Dim cmd As New SqlCommand(query, sql.con)
        Dim red As SqlDataReader
        Try
            sql.con.Open()
            red = cmd.ExecuteReader
            Do While red.Read
                TextBox1.Text = red.GetValue(0)
            Loop
        Catch ex As Exception
        End Try
        sql.con.Close()

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        studentview()
        textfieldclear()
        Dim query As String = "select Regno + 1 from Student;"
        Dim cmd As New SqlCommand(query, sql.con)
        Dim red As SqlDataReader
        Try
            sql.con.Open()
            red = cmd.ExecuteReader
            Do While red.Read
                TextBox1.Text = red.GetValue(0)
            Loop
        Catch ex As Exception
        End Try
        sql.con.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        findprofessor()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        addprofessor()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        findstudent()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        addstudent()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        removeprofessor()
        textfieldclear()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        removestudent()
        textfieldclear()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Me.Hide()
        Me.Height = 80
        Me.Width = 80
        PictureBox1.Hide()
        PictureBox2.Hide()
        PictureBox3.Hide()
        PictureBox4.Hide()
        PictureBox5.Hide()
        PictureBox6.Hide()
        textfieldclear()
    End Sub

    Private Sub addprofessor()
        sql.con.Open()
        Dim id As String = TextBox1.Text
        Dim nam As String = TextBox2.Text
        Dim dept As String = ComboBox1.Text
        Dim usr As String = TextBox4.Text
        Dim psw As String = TextBox5.Text
        Dim mail As String = TextBox6.Text
        Dim mob As String = TextBox7.Text
        Try
            If TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text + TextBox5.Text + TextBox6.Text + TextBox7.Text = "" Then
                MsgBox("please enter details", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox1.Text = "" Then
                MsgBox("please enter id", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox2.Text = "" Then
                MsgBox("please enter name", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("please select department", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox4.Text = "" Then
                MsgBox("please enter username", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox5.Text = "" Then
                MsgBox("please enter password", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox6.Text = "" Then
                MsgBox("please enter mail-id", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox7.Text = "" Then
                MsgBox("please enter mobile number", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim cmd As New SqlCommand("select Profid from Professor where Profid='" & TextBox1.Text & "';", sql.con)
                Dim red As SqlDataReader
                red = cmd.ExecuteReader
                If red.Read = True Then
                    MsgBox("Professor Already exists can't add", MsgBoxStyle.OkOnly, "G-Net")
                    red.Close()
                Else
                    Dim query As String = "insert into Professor(Name, Department, Profid, Username, Password, Mail, Mobile,Data) values ('" & nam & "','" & dept & "','" & id & "','" & usr & "','" & psw & "','" & mail & "','" & mob & "',0);"
                    cmd = New SqlCommand(query, sql.con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Professor Added Succesfully", MsgBoxStyle.OkOnly, "G-Net")
                    textfieldclear()
                End If
            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub addstudent()
        sql.con.Open()
        Dim reg As String = TextBox1.Text
        Dim nam As String = TextBox2.Text
        Dim dob As String = TextBox3.Text
        Dim dept As String = ComboBox1.Text
        Dim usr As String = TextBox4.Text
        Dim psw As String = TextBox5.Text
        Dim mail As String = TextBox6.Text
        Dim mob As String = TextBox7.Text
        Try
            If TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text + TextBox5.Text + TextBox6.Text + TextBox7.Text = "" Then
                MsgBox("please enter details", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox1.Text = "" Then
                MsgBox("please enter id", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox2.Text = "" Then
                MsgBox("please enter name", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("please select department", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox4.Text = "" Then
                MsgBox("please enter username", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox5.Text = "" Then
                MsgBox("please enter password", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox6.Text = "" Then
                MsgBox("please enter mail-id", MsgBoxStyle.OkOnly, "G-Net")
            ElseIf TextBox7.Text = "" Then
                MsgBox("please enter mobile number", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim cmd As New SqlCommand("select Regno from Student where Regno='" & TextBox1.Text & "';", sql.con)
                Dim red As SqlDataReader
                red = cmd.ExecuteReader
                If red.Read = True Then
                    MsgBox("Student Already exists can't add", MsgBoxStyle.OkOnly, "G-Net")
                    red.Close()
                Else
                    Dim query As String = "insert into Student(Regno, Name, DOB, Department, Username, Password, Mail, Mobile,Data,Datalimit)values('" & reg & "','" & nam & "','" & dob & "','" & dept & "','" & usr & "','" & psw & "','" & mail & "','" & mob & "',0,10);"
                    cmd = New SqlCommand(query, sql.con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Student Added Succesfully", MsgBoxStyle.OkOnly, "G-Net")
                    textfieldclear()
                End If

            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub findprofessor()
        sql.con.Open()
        Dim id As String = TextBox1.Text
        Try
            If TextBox1.Text = "" Then
                MsgBox("please enter id", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim query As String = "select * from Professor where Profid='" & id & "';"
                Dim cmd As New SqlCommand(query, sql.con)
                Dim red As SqlDataReader
                red = cmd.ExecuteReader
                If red.Read = True Then
                    TextBox1.Text = red.GetValue(2)
                    TextBox2.Text = red.GetString(0)
                    ComboBox1.Text = red.GetString(1)
                    TextBox4.Text = red.GetString(3)
                    TextBox5.Text = red.GetString(4)
                    TextBox6.Text = red.GetString(5)
                    TextBox7.Text = red.GetString(6)
                Else
                    MsgBox("Faculty not found", MsgBoxStyle.OkOnly, "G-Net")
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub findstudent()
        sql.con.Open()
        Dim reg As String = TextBox1.Text
        Try
            If TextBox1.Text = "" Then
                MsgBox("please enter Regno", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim query As String = "select * from Student where Regno='" & reg & "';"
                Dim cmd As New SqlCommand(query, sql.con)
                Dim red As SqlDataReader
                red = cmd.ExecuteReader
                If red.Read = True Then
                    TextBox1.Text = red.GetValue(0)
                    TextBox2.Text = red.GetString(1)
                    TextBox3.Text = red.GetValue(2)
                    ComboBox1.Text = red.GetString(3)
                    TextBox4.Text = red.GetString(4)
                    TextBox5.Text = red.GetString(5)
                    TextBox6.Text = red.GetString(6)
                    TextBox7.Text = red.GetString(7)
                Else
                    MsgBox("Student not found", MsgBoxStyle.OkOnly, "G-Net")
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub textfieldclear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox1.Text = ""
    End Sub

    Private Sub facultyview()
        PictureBox1.Show()
        PictureBox2.Hide()
        PictureBox3.Show()
        PictureBox4.Hide()
        PictureBox5.Show()
        PictureBox6.Hide()
        TextBox3.Enabled = False
    End Sub

    Private Sub studentview()
        PictureBox2.Show()
        PictureBox1.Hide()
        PictureBox3.Hide()
        PictureBox4.Show()
        PictureBox5.Hide()
        PictureBox6.Show()
        PictureBox2.Location = PictureBox1.Location
        PictureBox4.Location = PictureBox3.Location
        PictureBox6.Location = PictureBox5.Location
        TextBox3.Enabled = True
    End Sub

    Private Sub removeprofessor()
        sql.con.Open()
        Dim id As String = TextBox1.Text
        Try
            If TextBox1.Text = "" Then
                MsgBox("please enter id to remove ", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim selectquery As String = "select Profid from Professor where Profid='" & TextBox1.Text & "';"
                Dim scmd As New SqlCommand(selectquery, sql.con)
                Dim red As SqlDataReader
                red = scmd.ExecuteReader
                If red.Read = True Then
                    red.Close()
                    Dim deletequery As String = "delete from Professor where Profid='" & id & "';"
                    Dim cmd As New SqlCommand(deletequery, sql.con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Professor Removed Succesfully", MsgBoxStyle.OkOnly, "G-Net")
                Else
                    MsgBox("Faculty not found! please enter valid id to remove", MsgBoxStyle.OkOnly, "G-Net")
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

    Private Sub removestudent()
        sql.con.Open()
        Dim reg As String = TextBox1.Text
        Try
            If TextBox1.Text = "" Then
                MsgBox("please enter Regno to remove ", MsgBoxStyle.OkOnly, "G-Net")
            Else
                Dim selectquery As String = "select Regno from Student where Regno='" & TextBox1.Text & "';"
                Dim scmd As New SqlCommand(selectquery, sql.con)
                Dim red As SqlDataReader
                red = scmd.ExecuteReader
                If red.Read = True Then
                    red.Close()
                    Dim query As String = "delete from Student where Regno='" & reg & "';"
                    Dim cmd As New SqlCommand(query, sql.con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Student Removed Succesfully", MsgBoxStyle.OkOnly, "G-Net")
                Else
                    MsgBox("Student not found! please enter valid Regno to remove", MsgBoxStyle.OkOnly, "G-Net")
                End If
                
            End If
        Catch ex As Exception
            MsgBox("Problem with database", MsgBoxStyle.OkOnly, "G-Net")
        End Try
        sql.con.Close()

    End Sub

End Class
