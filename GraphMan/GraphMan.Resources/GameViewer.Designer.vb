<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameViewer
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
    Me.loadPlayerButton = New System.Windows.Forms.Button()
    Me.loadLevelButton = New System.Windows.Forms.Button()
    Me.throttleLabel = New System.Windows.Forms.Label()
    Me.throttleUpDown = New System.Windows.Forms.NumericUpDown()
    Me.playerLabel = New System.Windows.Forms.Label()
    Me.playerText = New System.Windows.Forms.TextBox()
    Me.scoreText = New System.Windows.Forms.TextBox()
    Me.scoreLabel = New System.Windows.Forms.Label()
    Me.startButton = New System.Windows.Forms.Button()
    Me.gamePicture = New System.Windows.Forms.PictureBox()
    CType(Me.throttleUpDown,System.ComponentModel.ISupportInitialize).BeginInit
    CType(Me.gamePicture,System.ComponentModel.ISupportInitialize).BeginInit
    Me.SuspendLayout
    '
    'loadPlayerButton
    '
    Me.loadPlayerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    Me.loadPlayerButton.Location = New System.Drawing.Point(11, 249)
    Me.loadPlayerButton.Margin = New System.Windows.Forms.Padding(2)
    Me.loadPlayerButton.Name = "loadPlayerButton"
    Me.loadPlayerButton.Size = New System.Drawing.Size(75, 24)
    Me.loadPlayerButton.TabIndex = 0
    Me.loadPlayerButton.Text = "Player..."
    Me.loadPlayerButton.UseVisualStyleBackColor = true
    '
    'loadLevelButton
    '
    Me.loadLevelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    Me.loadLevelButton.Location = New System.Drawing.Point(90, 249)
    Me.loadLevelButton.Margin = New System.Windows.Forms.Padding(2)
    Me.loadLevelButton.Name = "loadLevelButton"
    Me.loadLevelButton.Size = New System.Drawing.Size(75, 24)
    Me.loadLevelButton.TabIndex = 1
    Me.loadLevelButton.Text = "Level..."
    Me.loadLevelButton.UseVisualStyleBackColor = true
    '
    'throttleLabel
    '
    Me.throttleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    Me.throttleLabel.AutoSize = true
    Me.throttleLabel.Location = New System.Drawing.Point(170, 255)
    Me.throttleLabel.Name = "throttleLabel"
    Me.throttleLabel.Size = New System.Drawing.Size(68, 13)
    Me.throttleLabel.TabIndex = 99
    Me.throttleLabel.Text = "Throttle (ms):"
    '
    'throttleUpDown
    '
    Me.throttleUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
    Me.throttleUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
    Me.throttleUpDown.Location = New System.Drawing.Point(240, 253)
    Me.throttleUpDown.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.throttleUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.throttleUpDown.Name = "throttleUpDown"
    Me.throttleUpDown.Size = New System.Drawing.Size(49, 20)
    Me.throttleUpDown.TabIndex = 2
    Me.throttleUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.throttleUpDown.Value = New Decimal(New Integer() {100, 0, 0, 0})
    '
    'playerLabel
    '
    Me.playerLabel.AutoSize = true
    Me.playerLabel.Location = New System.Drawing.Point(8, 15)
    Me.playerLabel.Name = "playerLabel"
    Me.playerLabel.Size = New System.Drawing.Size(39, 13)
    Me.playerLabel.TabIndex = 98
    Me.playerLabel.Text = "Player:"
    '
    'playerText
    '
    Me.playerText.Location = New System.Drawing.Point(51, 12)
    Me.playerText.Name = "playerText"
    Me.playerText.ReadOnly = true
    Me.playerText.Size = New System.Drawing.Size(100, 20)
    Me.playerText.TabIndex = 4
    '
    'scoreText
    '
    Me.scoreText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.scoreText.Location = New System.Drawing.Point(352, 12)
    Me.scoreText.Name = "scoreText"
    Me.scoreText.ReadOnly = true
    Me.scoreText.Size = New System.Drawing.Size(100, 20)
    Me.scoreText.TabIndex = 3
    Me.scoreText.Text = "0"
    Me.scoreText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'scoreLabel
    '
    Me.scoreLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.scoreLabel.AutoSize = true
    Me.scoreLabel.Location = New System.Drawing.Point(308, 15)
    Me.scoreLabel.Name = "scoreLabel"
    Me.scoreLabel.Size = New System.Drawing.Size(38, 13)
    Me.scoreLabel.TabIndex = 97
    Me.scoreLabel.Text = "Score:"
    '
    'startButton
    '
    Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.startButton.Location = New System.Drawing.Point(352, 249)
    Me.startButton.Margin = New System.Windows.Forms.Padding(2)
    Me.startButton.Name = "startButton"
    Me.startButton.Size = New System.Drawing.Size(101, 24)
    Me.startButton.TabIndex = 100
    Me.startButton.Text = "Start Game"
    Me.startButton.UseVisualStyleBackColor = true
    '
    'gamePicture
    '
    Me.gamePicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.gamePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.gamePicture.Location = New System.Drawing.Point(11, 38)
    Me.gamePicture.Name = "gamePicture"
    Me.gamePicture.Size = New System.Drawing.Size(442, 206)
    Me.gamePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.gamePicture.TabIndex = 101
    Me.gamePicture.TabStop = false
    '
    'GameViewer
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(464, 281)
    Me.Controls.Add(Me.gamePicture)
    Me.Controls.Add(Me.startButton)
    Me.Controls.Add(Me.scoreText)
    Me.Controls.Add(Me.scoreLabel)
    Me.Controls.Add(Me.playerText)
    Me.Controls.Add(Me.playerLabel)
    Me.Controls.Add(Me.throttleUpDown)
    Me.Controls.Add(Me.throttleLabel)
    Me.Controls.Add(Me.loadLevelButton)
    Me.Controls.Add(Me.loadPlayerButton)
    Me.MinimumSize = New System.Drawing.Size(480, 320)
    Me.Name = "GameViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GraphMan"
    CType(Me.throttleUpDown,System.ComponentModel.ISupportInitialize).EndInit
    CType(Me.gamePicture,System.ComponentModel.ISupportInitialize).EndInit
    Me.ResumeLayout(false)
    Me.PerformLayout

End Sub
    Friend WithEvents throttleLabel As System.Windows.Forms.Label
    Friend WithEvents playerLabel As System.Windows.Forms.Label
    Friend WithEvents scoreLabel As System.Windows.Forms.Label
    Public WithEvents loadPlayerButton As System.Windows.Forms.Button
    Public WithEvents loadLevelButton As System.Windows.Forms.Button
    Public WithEvents throttleUpDown As System.Windows.Forms.NumericUpDown
    Public WithEvents playerText As System.Windows.Forms.TextBox
    Public WithEvents scoreText As System.Windows.Forms.TextBox
    Public WithEvents startButton As System.Windows.Forms.Button
    Public WithEvents gamePicture As System.Windows.Forms.PictureBox
End Class
