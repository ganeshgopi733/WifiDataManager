Imports System.Data.SQLite
Public Class UserControl4

    Private Sub UserControl4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chromehistory()
        Try
            Dim chcon As New SQLiteConnection("data source=" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Google\Chrome\User Data\Default\History")
            chcon.Open()
            Dim query As String = "select url as URL, title as Title, time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') as Time, date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') as Date  from urls order by last_visit_time desc limit 50;"
            Dim adapter As New SQLiteDataAdapter(query, chcon)
            Dim ds As New DataSet
            adapter.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            chcon.Close()
        Catch ex As Exception
            MsgBox("Google Chrome is running in background please close it ", MsgBoxStyle.OkOnly, "G-Net")
        End Try

    End Sub
    Private Sub operahistory()
        Try
            Dim opcon As New SQLiteConnection("data source=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Opera Software\OPera Stable\History")
            opcon.Open()
            Dim query As String = "select url as URL, title as Title, time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') as Time, date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') as Date  from urls order by last_visit_time desc limit 50;"
            Dim adapter As New SQLiteDataAdapter(query, opcon)
            Dim ds As New DataSet
            adapter.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            opcon.Close()
        Catch ex As Exception
            MsgBox("please check if u are installed opera or not ", MsgBoxStyle.OkOnly, "G-Net")
        End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        chromehistory()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        operahistory()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Me.Hide()
    End Sub
End Class
