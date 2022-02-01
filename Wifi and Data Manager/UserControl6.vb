Imports System.Data.SqlClient

Public Class UserControl6

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex < 0 And TextBox1.Text = "" Then
            MsgBox("Please select Data Pack and" + vbCrLf + "Enter Reason for requesting Data", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "G_Net")
        ElseIf ComboBox1.SelectedIndex < 0 Then
            MsgBox("Please select Data Pack", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "G_Net")
        ElseIf TextBox1.Text = "" Then
            MsgBox("Please enter Reason for requesting Data", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "G_Net")
        Else
            Dim query As String = "select Regno,Department from Student where Regno='" & Student.Label4.Text & "';"
            Dim cmd As New SqlCommand(query, sql.con)
            Dim red As SqlDataReader
            sql.con.Open()
            red = cmd.ExecuteReader
            red.Read()
            Dim req As String = Convert.ToString(ComboBox1.Text) + Label1.Text
            Dim insert As String = "insert into Temp values('" & red.GetValue(0) & "','" & red.GetString(1) & "','" & req & "','" & TextBox1.Text & "');"
            red.Close()
            Dim check As String = "select Regno from Temp where Regno='" & Student.Label4.Text & "';"
            cmd = New SqlCommand(check, sql.con)
            red = cmd.ExecuteReader
            If red.Read = True Then
                MsgBox("Your request in progress please wait......")
                Exit Sub
            End If
            red.Close()
            cmd = New SqlCommand(insert, sql.con)
            cmd.ExecuteNonQuery()
            MsgBox("Submitted")
            Me.Hide()
            ComboBox1.Text = ""
            TextBox1.Clear()
            sql.con.Close()
            Me.Hide()
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        ComboBox1.Text = ""
        TextBox1.Clear()

    End Sub

    Private Sub UserControl6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim reg As Integer = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Dim requesteddata As Integer = Val(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
        Dim cmd As New SqlCommand
        If e.ColumnIndex = 4 Then
            Dim grant As String = "update Student set Datalimit='" & requesteddata & "' where Regno='" & reg & "';"
            Dim remove As String = "delete from Temp where Regno='" & reg & "';"
            sql.con.Open()
            cmd = New SqlCommand(grant, sql.con)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand(remove, sql.con)
            cmd.ExecuteNonQuery()
            DataGridView1.Rows.RemoveAt(e.RowIndex)
            MsgBox("permission granted")
            Management.Label5.Text = 0
            Dim query As String = "select Regno from Temp;"
            cmd = New SqlCommand(query, sql.con)
            Dim red As SqlDataReader
            red = cmd.ExecuteReader
            Try
                Do While red.Read
                    Management.Label5.Text += 1
                Loop
            Catch ex As Exception
            End Try
            sql.con.Close()
        End If
        If e.ColumnIndex = 5 Then
            Dim remove As String = "delete from Temp where Regno='" & reg & "';"
            cmd = New SqlCommand(remove, sql.con)
            sql.con.Open()
            cmd.ExecuteNonQuery()
            DataGridView1.Rows.RemoveAt(e.RowIndex)
            MsgBox("permission denied")
            Management.Label5.Text = 0
            Dim query As String = "select Regno from Temp;"
            cmd = New SqlCommand(query, sql.con)
            Dim red As SqlDataReader
            red = cmd.ExecuteReader
            Try
                Do While red.Read
                    Management.Label5.Text += 1
                Loop
            Catch ex As Exception
            End Try
            sql.con.Close()
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub

End Class
