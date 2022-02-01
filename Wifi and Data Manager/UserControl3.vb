Imports System.Data.SqlClient

Public Class UserControl3

    Private Sub UserControl3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        TextBox4.UseSystemPasswordChar = False
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        TextBox4.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.Width = 22
        PictureBox3.Height = 20

    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Width = 20
        PictureBox3.Height = 18

    End Sub

    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.Width = 22
        PictureBox4.Height = 22
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Width = 20
        PictureBox4.Height = 18

    End Sub

    Private Sub PictureBox5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox5.Width = 22
        PictureBox5.Height = 20
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.Width = 20
        PictureBox5.Height = 18

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim confirm As MsgBoxResult
        Dim uqry As String
        Dim usr As String = TextBox3.Text
        confirm = MsgBox("Are you sure to change username as " + TextBox3.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If Label8.Visible = False Then
                uqry = "update Professor set Username='" & usr & "' where Name='" & Label1.Text & "';"
            Else
                uqry = "update Student set Username='" & usr & "' where Name='" & Label1.Text & "';"
            End If
            Dim cmd As New SqlCommand(uqry, sql.con)
            sql.con.Open()
            cmd.ExecuteNonQuery()
            sql.con.Close()
            MsgBox("username changed")
        End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim confirm As MsgBoxResult
        Dim pwd As String = TextBox4.Text
        Dim uqry As String
        confirm = MsgBox("Are you sure to change password as " + TextBox4.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If Label8.Visible = False Then
                uqry = "update Professor set Password='" & pwd & "' where Name='" & Label1.Text & "';"
            Else
                uqry = "update Student set Password='" & pwd & "' where Name='" & Label1.Text & "';"
            End If
            Dim cmd As New SqlCommand(uqry, sql.con)
            sql.con.Open()
            cmd.ExecuteNonQuery()
            sql.con.Close()
            MsgBox("password changed")
        End If

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim confirm As MsgBoxResult
        Dim mob As String = TextBox6.Text
        Dim uqry As String
        confirm = MsgBox("Are you sure to change mobile as " + TextBox6.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If Label8.Visible = False Then
                uqry = "update Professor set Mobile='" & mob & "' where Name='" & Label1.Text & "';"
            Else
                uqry = "update Student set Mobile='" & mob & "' where Name='" & Label1.Text & "';"
            End If
            Dim cmd As New SqlCommand(uqry, sql.con)
            sql.con.Open()
            cmd.ExecuteNonQuery()
            sql.con.Close()
            MsgBox("Mobile number changed")
        End If

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Me.Hide()

    End Sub
End Class
