<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Map
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
        Me.Unit_Information = New System.Windows.Forms.GroupBox()
        Me.ActiveWeaponsList = New System.Windows.Forms.ListBox()
        Me.TargetUnit = New System.Windows.Forms.Button()
        Me.ShootUnit = New System.Windows.Forms.Button()
        Me.UseSelectedWeapon = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.BtnNxtPhase = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_Apply_Damage = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Model_flees = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShootingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ShootingSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ShootingCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ShootingCancelAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TargetingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_TargetSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_TargetCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_TargetCancelAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Unit_Information.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Unit_Information
        '
        Me.Unit_Information.Controls.Add(Me.ActiveWeaponsList)
        Me.Unit_Information.Controls.Add(Me.TargetUnit)
        Me.Unit_Information.Controls.Add(Me.ShootUnit)
        Me.Unit_Information.Controls.Add(Me.UseSelectedWeapon)
        Me.Unit_Information.Controls.Add(Me.BtnReset)
        Me.Unit_Information.Controls.Add(Me.BtnNxtPhase)
        Me.Unit_Information.Controls.Add(Me.Label2)
        Me.Unit_Information.Location = New System.Drawing.Point(120, 12)
        Me.Unit_Information.Name = "Unit_Information"
        Me.Unit_Information.Size = New System.Drawing.Size(182, 338)
        Me.Unit_Information.TabIndex = 0
        Me.Unit_Information.TabStop = False
        Me.Unit_Information.Text = "Unit Information"
        '
        'ActiveWeaponsList
        '
        Me.ActiveWeaponsList.FormattingEnabled = True
        Me.ActiveWeaponsList.Items.AddRange(New Object() {"asdfasf", "zdfgs d", "dgh", "df"})
        Me.ActiveWeaponsList.Location = New System.Drawing.Point(9, 178)
        Me.ActiveWeaponsList.Name = "ActiveWeaponsList"
        Me.ActiveWeaponsList.Size = New System.Drawing.Size(157, 43)
        Me.ActiveWeaponsList.TabIndex = 6
        '
        'TargetUnit
        '
        Me.TargetUnit.Location = New System.Drawing.Point(9, 227)
        Me.TargetUnit.Name = "TargetUnit"
        Me.TargetUnit.Size = New System.Drawing.Size(157, 23)
        Me.TargetUnit.TabIndex = 5
        Me.TargetUnit.Text = "Select this unit to Target"
        Me.TargetUnit.UseVisualStyleBackColor = True
        '
        'ShootUnit
        '
        Me.ShootUnit.Location = New System.Drawing.Point(9, 150)
        Me.ShootUnit.Name = "ShootUnit"
        Me.ShootUnit.Size = New System.Drawing.Size(157, 23)
        Me.ShootUnit.TabIndex = 4
        Me.ShootUnit.Text = "Select this unit to Shoot with"
        Me.ShootUnit.UseVisualStyleBackColor = True
        '
        'UseSelectedWeapon
        '
        Me.UseSelectedWeapon.Location = New System.Drawing.Point(9, 256)
        Me.UseSelectedWeapon.Name = "UseSelectedWeapon"
        Me.UseSelectedWeapon.Size = New System.Drawing.Size(157, 23)
        Me.UseSelectedWeapon.TabIndex = 3
        Me.UseSelectedWeapon.Text = "Use Selected Weapon"
        Me.UseSelectedWeapon.UseVisualStyleBackColor = True
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(91, 120)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(75, 23)
        Me.BtnReset.TabIndex = 2
        Me.BtnReset.Text = "Reset"
        Me.BtnReset.UseVisualStyleBackColor = True
        '
        'BtnNxtPhase
        '
        Me.BtnNxtPhase.Location = New System.Drawing.Point(9, 121)
        Me.BtnNxtPhase.Name = "BtnNxtPhase"
        Me.BtnNxtPhase.Size = New System.Drawing.Size(75, 23)
        Me.BtnNxtPhase.TabIndex = 1
        Me.BtnNxtPhase.Text = "Next Phase"
        Me.BtnNxtPhase.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Apply_Damage, Me.TSMI_Model_flees})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(275, 48)
        Me.ContextMenuStrip1.Text = "Model flees during Moralea Phase"
        '
        'TSMI_Apply_Damage
        '
        Me.TSMI_Apply_Damage.Name = "TSMI_Apply_Damage"
        Me.TSMI_Apply_Damage.Size = New System.Drawing.Size(274, 22)
        Me.TSMI_Apply_Damage.Text = "Apply Damage due to Shooting Phase"
        '
        'TSMI_Model_flees
        '
        Me.TSMI_Model_flees.Name = "TSMI_Model_flees"
        Me.TSMI_Model_flees.Size = New System.Drawing.Size(274, 22)
        Me.TSMI_Model_flees.Text = "Model flees during Morale Phase"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShootingToolStripMenuItem, Me.TargetingToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(126, 48)
        Me.ContextMenuStrip2.Text = "Model flees during Moralea Phase"
        '
        'ShootingToolStripMenuItem
        '
        Me.ShootingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_ShootingSelect, Me.TSMI_ShootingCancel, Me.TSMI_ShootingCancelAll})
        Me.ShootingToolStripMenuItem.Name = "ShootingToolStripMenuItem"
        Me.ShootingToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ShootingToolStripMenuItem.Text = "Shooting"
        '
        'TSMI_ShootingSelect
        '
        Me.TSMI_ShootingSelect.Name = "TSMI_ShootingSelect"
        Me.TSMI_ShootingSelect.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_ShootingSelect.Text = "Select"
        '
        'TSMI_ShootingCancel
        '
        Me.TSMI_ShootingCancel.Name = "TSMI_ShootingCancel"
        Me.TSMI_ShootingCancel.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_ShootingCancel.Text = "Cancel"
        '
        'TSMI_ShootingCancelAll
        '
        Me.TSMI_ShootingCancelAll.Name = "TSMI_ShootingCancelAll"
        Me.TSMI_ShootingCancelAll.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_ShootingCancelAll.Text = "Cancel All"
        '
        'TargetingToolStripMenuItem
        '
        Me.TargetingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_TargetSelect, Me.TSMI_TargetCancel, Me.TSMI_TargetCancelAll})
        Me.TargetingToolStripMenuItem.Name = "TargetingToolStripMenuItem"
        Me.TargetingToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.TargetingToolStripMenuItem.Text = "Targeting"
        '
        'TSMI_TargetSelect
        '
        Me.TSMI_TargetSelect.Name = "TSMI_TargetSelect"
        Me.TSMI_TargetSelect.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_TargetSelect.Text = "Select"
        '
        'TSMI_TargetCancel
        '
        Me.TSMI_TargetCancel.Name = "TSMI_TargetCancel"
        Me.TSMI_TargetCancel.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_TargetCancel.Text = "Cancel"
        '
        'TSMI_TargetCancelAll
        '
        Me.TSMI_TargetCancelAll.Name = "TSMI_TargetCancelAll"
        Me.TSMI_TargetCancelAll.Size = New System.Drawing.Size(127, 22)
        Me.TSMI_TargetCancelAll.Text = "Cancel All"
        '
        'Map
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(596, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.Unit_Information)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Map"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Map"
        Me.Unit_Information.ResumeLayout(False)
        Me.Unit_Information.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Unit_Information As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnReset As System.Windows.Forms.Button
    Friend WithEvents BtnNxtPhase As System.Windows.Forms.Button
    Friend WithEvents UseSelectedWeapon As System.Windows.Forms.Button
    Friend WithEvents TargetUnit As System.Windows.Forms.Button
    Friend WithEvents ShootUnit As System.Windows.Forms.Button
    Friend WithEvents TSMI_Apply_Damage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Model_flees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveWeaponsList As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShootingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ShootingSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ShootingCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ShootingCancelAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TargetingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_TargetSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_TargetCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_TargetCancelAll As System.Windows.Forms.ToolStripMenuItem
End Class
