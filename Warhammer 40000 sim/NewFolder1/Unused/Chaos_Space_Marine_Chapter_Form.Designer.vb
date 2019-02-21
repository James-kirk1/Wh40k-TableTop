<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chaos_Space_Marine_Chapter_Form
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
        Me.CSM_Emperors_Children = New System.Windows.Forms.Button()
        Me.CSM_Death_Guard = New System.Windows.Forms.Button()
        Me.CSM_Thousand_Sons = New System.Windows.Forms.Button()
        Me.CSM_Worldeaters = New System.Windows.Forms.Button()
        Me.Returntoraceselection = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CSM_Emperors_Children
        '
        Me.CSM_Emperors_Children.Location = New System.Drawing.Point(12, 100)
        Me.CSM_Emperors_Children.Name = "CSM_Emperors_Children"
        Me.CSM_Emperors_Children.Size = New System.Drawing.Size(210, 23)
        Me.CSM_Emperors_Children.TabIndex = 7
        Me.CSM_Emperors_Children.Text = "Emperors's Children"
        Me.CSM_Emperors_Children.UseVisualStyleBackColor = True
        '
        'CSM_Death_Guard
        '
        Me.CSM_Death_Guard.Location = New System.Drawing.Point(12, 71)
        Me.CSM_Death_Guard.Name = "CSM_Death_Guard"
        Me.CSM_Death_Guard.Size = New System.Drawing.Size(210, 23)
        Me.CSM_Death_Guard.TabIndex = 6
        Me.CSM_Death_Guard.Text = "Death Guard"
        Me.CSM_Death_Guard.UseVisualStyleBackColor = True
        '
        'CSM_Thousand_Sons
        '
        Me.CSM_Thousand_Sons.Location = New System.Drawing.Point(12, 42)
        Me.CSM_Thousand_Sons.Name = "CSM_Thousand_Sons"
        Me.CSM_Thousand_Sons.Size = New System.Drawing.Size(210, 23)
        Me.CSM_Thousand_Sons.TabIndex = 5
        Me.CSM_Thousand_Sons.Text = "Thousand Sons"
        Me.CSM_Thousand_Sons.UseVisualStyleBackColor = True
        '
        'CSM_Worldeaters
        '
        Me.CSM_Worldeaters.Location = New System.Drawing.Point(12, 12)
        Me.CSM_Worldeaters.Name = "CSM_Worldeaters"
        Me.CSM_Worldeaters.Size = New System.Drawing.Size(210, 23)
        Me.CSM_Worldeaters.TabIndex = 4
        Me.CSM_Worldeaters.Text = "Worldeaters"
        Me.CSM_Worldeaters.UseVisualStyleBackColor = True
        '
        'Returntoraceselection
        '
        Me.Returntoraceselection.Location = New System.Drawing.Point(12, 158)
        Me.Returntoraceselection.Name = "Returntoraceselection"
        Me.Returntoraceselection.Size = New System.Drawing.Size(210, 23)
        Me.Returntoraceselection.TabIndex = 9
        Me.Returntoraceselection.Text = "Return to Race Selection"
        Me.Returntoraceselection.UseVisualStyleBackColor = True
        '
        'Chaos_Space_Marine_Chapter_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 264)
        Me.Controls.Add(Me.Returntoraceselection)
        Me.Controls.Add(Me.CSM_Emperors_Children)
        Me.Controls.Add(Me.CSM_Death_Guard)
        Me.Controls.Add(Me.CSM_Thousand_Sons)
        Me.Controls.Add(Me.CSM_Worldeaters)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Chaos_Space_Marine_Chapter_Form"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CSM_Emperors_Children As System.Windows.Forms.Button
    Friend WithEvents CSM_Death_Guard As System.Windows.Forms.Button
    Friend WithEvents CSM_Thousand_Sons As System.Windows.Forms.Button
    Friend WithEvents CSM_Worldeaters As System.Windows.Forms.Button
    Friend WithEvents Returntoraceselection As System.Windows.Forms.Button
End Class
