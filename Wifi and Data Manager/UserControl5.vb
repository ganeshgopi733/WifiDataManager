Imports System.Data.SqlClient

Public Class UserControl5

    Private Sub UserControl5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        DataGridView1.Show()
        DataGridView1.BringToFront()
        DataGridView2.Hide()
        GroupBox1.Text = "Professor"
        Label3.Text = "Name"
        Label5.Text = "Unlimited"
        Label5.Location = New Point(170, 67)
        Label6.Text = "0"
        Dim q As String = "select Name from Professor;"
        sql.con.Open()
        Dim adapter As New SqlDataAdapter(q, sql.con)
        Dim ds As New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        sql.con.Close()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        DataGridView2.Show()
        DataGridView2.BringToFront()
        DataGridView1.Hide()
        GroupBox1.Text = "Student"
        Label3.Text = "Name"
        Label5.Text = "remaining of 10 MB"
        Label5.Location = New Point(118, 68)
        Label6.Text = "0"
        Dim q As String = "select Name from Student;"
        sql.con.Open()
        Dim adapter As New SqlDataAdapter(q, sql.con)
        Dim ds As New DataSet
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        sql.con.Close()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Label3.Text = DataGridView1.CurrentCell.Value.ToString
        Dim q As String = "select Data from Professor where Name='" & DataGridView1.CurrentCell.Value.ToString & "';"
        Dim cmd As New SqlCommand(q, sql.con)
        Dim red As SqlDataReader
        sql.con.Open()
        red = cmd.ExecuteReader()
        red.Read()
        Label6.Text = Convert.ToInt64(red.GetValue(0))
        sql.con.Close()

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Label3.Text = DataGridView2.CurrentCell.Value.ToString
        Dim q As String = "select Data from Student where Name='" & DataGridView2.CurrentCell.Value.ToString & "';"
        Dim cmd As New SqlCommand(q, sql.con)
        Dim red As SqlDataReader
        sql.con.Open()
        red = cmd.ExecuteReader()
        red.Read()
        Label6.Text = 10 - Convert.ToInt64(red.GetValue(0))
        sql.con.Close()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()

    End Sub
End Class
