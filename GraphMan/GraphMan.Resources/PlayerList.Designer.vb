<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerList
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
    Me.escapeButton = New System.Windows.Forms.Button()
    Me.selectButton = New System.Windows.Forms.Button()
    Me.playersGroup = New System.Windows.Forms.GroupBox()
    Me.playersList = New System.Windows.Forms.ListBox()
    Me.playersGroup.SuspendLayout
    Me.SuspendLayout
    '
    'escapeButton
    '
    Me.escapeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.escapeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.escapeButton.Location = New System.Drawing.Point(126, 405)
    Me.escapeButton.Name = "escapeButton"
    Me.escapeButton.Size = New System.Drawing.Size(80, 24)
    Me.escapeButton.TabIndex = 3
    Me.escapeButton.Text = "Cancel"
    Me.escapeButton.UseVisualStyleBackColor = true
    '
    'selectButton
    '
    Me.selectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.selectButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.selectButton.Location = New System.Drawing.Point(212, 405)
    Me.selectButton.Name = "selectButton"
    Me.selectButton.Size = New System.Drawing.Size(80, 24)
    Me.selectButton.TabIndex = 2
    Me.selectButton.Text = "Select"
    Me.selectButton.UseVisualStyleBackColor = true
    '
    'playersGroup
    '
    Me.playersGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.playersGroup.Controls.Add(Me.playersList)
    Me.playersGroup.Location = New System.Drawing.Point(12, 12)
    Me.playersGroup.Name = "playersGroup"
    Me.playersGroup.Size = New System.Drawing.Size(280, 387)
    Me.playersGroup.TabIndex = 2
    Me.playersGroup.TabStop = false
    Me.playersGroup.Text = "Available Players"
    '
    'playersList
    '
    Me.playersList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.playersList.FormattingEnabled = true
    Me.playersList.Location = New System.Drawing.Point(3, 16)
    Me.playersList.Name = "playersList"
    Me.playersList.Size = New System.Drawing.Size(274, 368)
    Me.playersList.TabIndex = 1
    '
    'PlayerList
    '
    Me.AcceptButton = Me.selectButton
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.escapeButton
    Me.ClientSize = New System.Drawing.Size(314, 474)
    Me.ControlBox = false
    Me.Controls.Add(Me.playersGroup)
    Me.Controls.Add(Me.selectButton)
    Me.Controls.Add(Me.escapeButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MinimumSize = New System.Drawing.Size(320, 480)
    Me.Name = "PlayerList"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "GraphMan - Choose a Player"
    Me.playersGroup.ResumeLayout(false)
    Me.ResumeLayout(false)

End Sub
    Public WithEvents playersGroup As System.Windows.Forms.GroupBox
    Public Shadows WithEvents escapeButton As System.Windows.Forms.Button
    Public WithEvents selectButton As System.Windows.Forms.Button
    Public WithEvents playersList As System.Windows.Forms.ListBox
End Class
