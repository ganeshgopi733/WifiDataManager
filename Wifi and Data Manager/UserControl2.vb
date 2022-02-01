Imports System.Data.SqlClient

Public Class UserControl2

    Private Sub UserControl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserControl12.Hide()
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Label2.Text = DataGridView1.CurrentCell.Value.ToString
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        Dim q As String = "select * from Professor where Name='" & Label2.Text & "';"
        Dim cmd As New SqlCommand(q, sql.con)
        Dim red As SqlDataReader
        Try
            sql.con.Open()
            red = cmd.ExecuteReader()
            If red.Read = True Then
                TextBox1.Text = red.GetString(2)
                TextBox2.Text = red.GetValue(1)
                TextBox3.Text = red.GetString(3)
                TextBox4.Text = red.GetString(4)
                TextBox5.Text = red.GetString(5)
                TextBox6.Text = red.GetValue(6)
            Else
            End If
        Catch ex As Exception
        End Try
        sql.con.Close()

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        DataGridView1.Show()
        DataGridView1.BringToFront()
        DataGridView2.Hide()
        GroupBox1.Text = "Professor"
        Label3.Text = "Id"
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Dim q As String = "select Name from Professor;"
        Dim adapter As New SqlDataAdapter(q, sql.con)
        Dim ds As New DataSet
        sql.con.Open()
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        sql.con.Close()

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        DataGridView2.Show()
        DataGridView2.BringToFront()
        DataGridView1.Hide()
        GroupBox1.Text = "Student"
        Label3.Text = "Regno"
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Dim q As String = "select Name from Student;"
        Dim adapter As New SqlDataAdapter(q, sql.con)
        Dim ds As New DataSet
        sql.con.Open()
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        sql.con.Close()

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Label2.Text = DataGridView2.CurrentCell.Value.ToString
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        Dim q As String = "select * from Student where Name='" & Label2.Text & "';"
        Dim cmd As New SqlCommand(q, sql.con)
        Dim red As SqlDataReader
        sql.con.Open()
        red = cmd.ExecuteReader()
        If red.Read = True Then
            TextBox1.Text = red.GetString(0)
            TextBox2.Text = red.GetValue(3)
            TextBox3.Text = red.GetString(4)
            TextBox4.Text = red.GetString(5)
            TextBox5.Text = red.GetString(6)
            TextBox6.Text = red.GetValue(7)
        End If
        sql.con.Close()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        UserControl12.Show()
        UserControl12.BringToFront()
        UserControl12.Height = Me.Height
        UserControl12.Width = Me.Width
        UserControl12.BackColor = Color.Transparent
        UserControl12.Location = Me.Location

    End Sub

    
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim query As String
        Dim confirm As MsgBoxResult
        confirm = MsgBox("Are you sure to change Department as " + TextBox2.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If GroupBox1.Text = "Professor" Then
                query = "update Professor set Department='" & TextBox2.Text & "' where Profid='" & TextBox1.Text & "';"
            Else
                query = "update Student set Department='" & TextBox2.Text & "' where Regno='" & TextBox1.Text & "';"
            End If
            Dim cmd As New SqlCommand(query, sql.con)
            Try
                sql.con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Department Succesfully updated")
            Catch ex As Exception
                MsgBox("problem with db connection", MsgBoxStyle.OkOnly, "G-Net")
            End Try
            sql.con.Close()

        End If
        

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim query As String
        Dim confirm As MsgBoxResult
        confirm = MsgBox("Are you sure to change Mobile number as " + TextBox6.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If GroupBox1.Text = "Professor" Then
                query = "update Professor set Mobile='" & Val(TextBox6.Text) & "' where Profid='" & TextBox1.Text & "';"
            Else
                query = "update Student set Mobile='" & Val(TextBox6.Text) & "' where Regno='" & TextBox1.Text & "';"
            End If
            Dim cmd As New SqlCommand(query, sql.con)
            Try
                sql.con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Mobile number Succesfully updated")
            Catch ex As Exception
                MsgBox("problem with db connection", MsgBoxStyle.OkOnly, "G-Net")
            End Try
            sql.con.Close()
        End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim query As String
        Dim confirm As MsgBoxResult
        confirm = MsgBox("Are you sure to change Mail-id as " + TextBox5.Text, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "G-Net")
        If confirm = MsgBoxResult.Yes Then
            If GroupBox1.Text = "Professor" Then
                query = "update Professor set Mail='" & TextBox5.Text & "' where Profid='" & TextBox1.Text & "';"
            Else
                query = "update Student set Mail='" & TextBox5.Text & "' where Regno='" & TextBox1.Text & "';"
            End If
            Dim cmd As New SqlCommand(query, sql.con)
            Try
                sql.con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Mail-id Succesfully updated")
            Catch ex As Exception
                MsgBox("problem with db connection", MsgBoxStyle.OkOnly, "G-Net")
            End Try
            sql.con.Close()
        End If

    End Sub
End Class
