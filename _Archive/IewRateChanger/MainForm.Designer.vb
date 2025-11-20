<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.cboRates = New System.Windows.Forms.ComboBox
        Me.lblSelectRateFile = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboRates
        '
        Me.cboRates.FormattingEnabled = True
        Me.cboRates.Location = New System.Drawing.Point(36, 53)
        Me.cboRates.Name = "cboRates"
        Me.cboRates.Size = New System.Drawing.Size(198, 21)
        Me.cboRates.TabIndex = 0
        '
        'lblSelectRateFile
        '
        Me.lblSelectRateFile.AutoSize = True
        Me.lblSelectRateFile.Location = New System.Drawing.Point(33, 37)
        Me.lblSelectRateFile.Name = "lblSelectRateFile"
        Me.lblSelectRateFile.Size = New System.Drawing.Size(117, 13)
        Me.lblSelectRateFile.TabIndex = 1
        Me.lblSelectRateFile.Text = "Please Select Rate File"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(93, 152)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 197)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblSelectRateFile)
        Me.Controls.Add(Me.cboRates)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "IEW Rate Changer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboRates As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelectRateFile As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button

End Class
