<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ZedGraphControl2 = New ZedGraph.ZedGraphControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ZedGraphControl2
        '
        Me.ZedGraphControl2.AutoSize = True
        Me.ZedGraphControl2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ZedGraphControl2.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.ZedGraphControl2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ZedGraphControl2.IsAntiAlias = True
        Me.ZedGraphControl2.Location = New System.Drawing.Point(401, 26)
        Me.ZedGraphControl2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ZedGraphControl2.Name = "ZedGraphControl2"
        Me.ZedGraphControl2.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.ZedGraphControl2.ScrollGrace = 0R
        Me.ZedGraphControl2.ScrollMaxX = 0R
        Me.ZedGraphControl2.ScrollMaxY = 0R
        Me.ZedGraphControl2.ScrollMaxY2 = 0R
        Me.ZedGraphControl2.ScrollMinX = 0R
        Me.ZedGraphControl2.ScrollMinY = 0R
        Me.ZedGraphControl2.ScrollMinY2 = 0R
        Me.ZedGraphControl2.Size = New System.Drawing.Size(676, 432)
        Me.ZedGraphControl2.TabIndex = 371
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(85, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 91)
        Me.Label1.TabIndex = 372
        Me.Label1.Text = "Label1"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 60000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(101, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 31)
        Me.Label2.TabIndex = 373
        Me.Label2.Text = "Label2"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "hi"
        Me.NotifyIcon1.BalloonTipTitle = "dex"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Value"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.LargeChange = 1
        Me.HScrollBar1.Location = New System.Drawing.Point(401, 490)
        Me.HScrollBar1.Maximum = 24
        Me.HScrollBar1.Minimum = 2
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(676, 17)
        Me.HScrollBar1.TabIndex = 374
        Me.HScrollBar1.Value = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(673, 518)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 31)
        Me.Label3.TabIndex = 375
        Me.Label3.Text = "Scale: "
        '
        'Timer1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1090, 24)
        Me.MenuStrip1.TabIndex = 376
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(192, 295)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 31)
        Me.Button1.TabIndex = 377
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(978, 531)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 378
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1090, 606)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ZedGraphControl2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "Dexcom Monitor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ZedGraphControl2 As ZedGraph.ZedGraphControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
