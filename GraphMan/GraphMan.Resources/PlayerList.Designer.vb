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
    Me.cancelButton = New System.Windows.Forms.Button()
    Me.selectButton = New System.Windows.Forms.Button()
    Me.playersGroup = New System.Windows.Forms.GroupBox()
    Me.playersList = New System.Windows.Forms.ListBox()
    Me.playersGroup.SuspendLayout
    Me.SuspendLayout
    '
    'cancelButton
    '
    Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cancelButton.Location = New System.Drawing.Point(126, 405)
    Me.cancelButton.Name = "cancelButton"
    Me.cancelButton.Size = New System.Drawing.Size(80, 24)
    Me.cancelButton.TabIndex = 0
    Me.cancelButton.Text = "Cancel"
    Me.cancelButton.UseVisualStyleBackColor = true
    '
    'selectButton
    '
    Me.selectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    Me.selectButton.Location = New System.Drawing.Point(212, 405)
    Me.selectButton.Name = "selectButton"
    Me.selectButton.Size = New System.Drawing.Size(80, 24)
    Me.selectButton.TabIndex = 1
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
    Me.playersGroup.Text = "Players"
    '
    'playersList
    '
    Me.playersList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.playersList.FormattingEnabled = true
    Me.playersList.Location = New System.Drawing.Point(3, 16)
    Me.playersList.Name = "playersList"
    Me.playersList.Size = New System.Drawing.Size(274, 368)
    Me.playersList.TabIndex = 0
    '
    'PlayerList
    '
    Me.AcceptButton = Me.selectButton
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(314, 474)
    Me.ControlBox = false
    Me.Controls.Add(Me.playersGroup)
    Me.Controls.Add(Me.selectButton)
    Me.Controls.Add(Me.cancelButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MinimumSize = New System.Drawing.Size(320, 480)
    Me.Name = "PlayerList"
    Me.ShowIcon = false
    Me.ShowInTaskbar = false
    Me.Text = "Available Players"
    Me.playersGroup.ResumeLayout(false)
    Me.ResumeLayout(false)

End Sub
    Public WithEvents playersGroup As System.Windows.Forms.GroupBox
    Public Shadows WithEvents cancelButton As System.Windows.Forms.Button
    Public WithEvents selectButton As System.Windows.Forms.Button
    Public WithEvents playersList As System.Windows.Forms.ListBox
End Class
