<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Ti1 = New System.Windows.Forms.Timer(Me.components)
        Me.Ti2 = New System.Windows.Forms.Timer(Me.components)
        Me.Ti3 = New System.Windows.Forms.Timer(Me.components)
        Me.Ti4 = New System.Windows.Forms.Timer(Me.components)
        Me.Ti5 = New System.Windows.Forms.Timer(Me.components)
        Me.Ti6 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Wifi_and_Data_Manager.My.Resources.Resources.wifi_1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(629, 443)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Ti1
        '
        Me.Ti1.Enabled = True
        Me.Ti1.Interval = 800
        '
        'Ti2
        '
        Me.Ti2.Enabled = True
        Me.Ti2.Interval = 1400
        '
        'Ti3
        '
        Me.Ti3.Enabled = True
        Me.Ti3.Interval = 2000
        '
        'Ti4
        '
        Me.Ti4.Enabled = True
        Me.Ti4.Interval = 2600
        '
        'Ti5
        '
        Me.Ti5.Enabled = True
        Me.Ti5.Interval = 3200
        '
        'Ti6
        '
        Me.Ti6.Interval = 3800
        '
        'Loader
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ClientSize = New System.Drawing.Size(628, 441)
        Me.Controls.Add(Me.PictureBox1)
        Me.Enabled = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Loader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.SystemColors.MenuBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Ti1 As System.Windows.Forms.Timer
    Friend WithEvents Ti2 As System.Windows.Forms.Timer
    Friend WithEvents Ti3 As System.Windows.Forms.Timer
    Friend WithEvents Ti4 As System.Windows.Forms.Timer
    Friend WithEvents Ti5 As System.Windows.Forms.Timer
    Friend WithEvents Ti6 As System.Windows.Forms.Timer

End Class
