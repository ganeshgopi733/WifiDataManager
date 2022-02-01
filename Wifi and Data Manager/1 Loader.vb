Public Class Loader

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Task_Icon
        Me.Width = PictureBox1.Image.Width
        Me.Height = PictureBox1.Image.Height
    End Sub
    Private Sub Ti1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ti1.Tick
        PictureBox1.Image = My.Resources.wifi_2
        Ti1.Stop()
    End Sub
    Private Sub Ti2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ti2.Tick
        PictureBox1.Image = My.Resources.wifi_3
        Ti2.Stop()
    End Sub

    Private Sub Ti3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ti3.Tick
        PictureBox1.Image = My.Resources.wifi_4
        Ti3.Stop()
    End Sub

    Private Sub Ti4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ti4.Tick
        PictureBox1.Image = My.Resources.wifi_5
        Ti4.Stop()
    End Sub

    Private Sub Ti5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ti5.Tick
        Me.Hide()
        Introduction.Show()
        Ti5.Stop()
    End Sub

End Class
