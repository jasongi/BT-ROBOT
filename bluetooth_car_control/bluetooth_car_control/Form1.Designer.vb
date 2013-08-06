<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.connect_button = New System.Windows.Forms.Button
        Me.disconnect_button = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.forward_button = New System.Windows.Forms.Button
        Me.reverse_button = New System.Windows.Forms.Button
        Me.left_button = New System.Windows.Forms.Button
        Me.right_button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.headlights_checkbox = New System.Windows.Forms.CheckBox
        Me.brakelights_checkbox = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'connect_button
        '
        Me.connect_button.Location = New System.Drawing.Point(20, 24)
        Me.connect_button.Name = "connect_button"
        Me.connect_button.Size = New System.Drawing.Size(75, 23)
        Me.connect_button.TabIndex = 0
        Me.connect_button.Text = "Connect"
        Me.connect_button.UseVisualStyleBackColor = True
        '
        'disconnect_button
        '
        Me.disconnect_button.Location = New System.Drawing.Point(20, 53)
        Me.disconnect_button.Name = "disconnect_button"
        Me.disconnect_button.Size = New System.Drawing.Size(75, 23)
        Me.disconnect_button.TabIndex = 1
        Me.disconnect_button.Text = "Disconnect"
        Me.disconnect_button.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20"})
        Me.ComboBox1.Location = New System.Drawing.Point(119, 41)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(86, 21)
        Me.ComboBox1.TabIndex = 2
        Me.ComboBox1.Text = "COM1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(116, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select COM Port:"
        '
        'forward_button
        '
        Me.forward_button.Location = New System.Drawing.Point(74, 60)
        Me.forward_button.Name = "forward_button"
        Me.forward_button.Size = New System.Drawing.Size(75, 23)
        Me.forward_button.TabIndex = 4
        Me.forward_button.Text = "Forward"
        Me.forward_button.UseVisualStyleBackColor = True
        '
        'reverse_button
        '
        Me.reverse_button.Location = New System.Drawing.Point(83, 89)
        Me.reverse_button.Name = "reverse_button"
        Me.reverse_button.Size = New System.Drawing.Size(57, 23)
        Me.reverse_button.TabIndex = 5
        Me.reverse_button.Text = "Reverse"
        Me.reverse_button.UseVisualStyleBackColor = True
        '
        'left_button
        '
        Me.left_button.Location = New System.Drawing.Point(22, 89)
        Me.left_button.Name = "left_button"
        Me.left_button.Size = New System.Drawing.Size(55, 23)
        Me.left_button.TabIndex = 6
        Me.left_button.Text = "Left"
        Me.left_button.UseVisualStyleBackColor = True
        '
        'right_button
        '
        Me.right_button.Location = New System.Drawing.Point(146, 89)
        Me.right_button.Name = "right_button"
        Me.right_button.Size = New System.Drawing.Size(48, 23)
        Me.right_button.TabIndex = 7
        Me.right_button.Text = "Right"
        Me.right_button.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.disconnect_button)
        Me.GroupBox1.Controls.Add(Me.connect_button)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 92)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serial Port Settings"
        '
        'headlights_checkbox
        '
        Me.headlights_checkbox.AutoSize = True
        Me.headlights_checkbox.Location = New System.Drawing.Point(19, 27)
        Me.headlights_checkbox.Name = "headlights_checkbox"
        Me.headlights_checkbox.Size = New System.Drawing.Size(83, 17)
        Me.headlights_checkbox.TabIndex = 9
        Me.headlights_checkbox.Text = "Head Lights"
        Me.headlights_checkbox.UseVisualStyleBackColor = True
        '
        'brakelights_checkbox
        '
        Me.brakelights_checkbox.AutoSize = True
        Me.brakelights_checkbox.Location = New System.Drawing.Point(118, 27)
        Me.brakelights_checkbox.Name = "brakelights_checkbox"
        Me.brakelights_checkbox.Size = New System.Drawing.Size(85, 17)
        Me.brakelights_checkbox.TabIndex = 10
        Me.brakelights_checkbox.Text = "Brake Lights"
        Me.brakelights_checkbox.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.brakelights_checkbox)
        Me.GroupBox2.Controls.Add(Me.headlights_checkbox)
        Me.GroupBox2.Controls.Add(Me.right_button)
        Me.GroupBox2.Controls.Add(Me.left_button)
        Me.GroupBox2.Controls.Add(Me.reverse_button)
        Me.GroupBox2.Controls.Add(Me.forward_button)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 129)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Car Controls"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(30, 265)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(184, 13)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Program created by Eirik Taylor, 2009"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 290)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(264, 324)
        Me.Name = "Form1"
        Me.Text = "Bluetooth Car Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents connect_button As System.Windows.Forms.Button
    Friend WithEvents disconnect_button As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents forward_button As System.Windows.Forms.Button
    Friend WithEvents reverse_button As System.Windows.Forms.Button
    Friend WithEvents left_button As System.Windows.Forms.Button
    Friend WithEvents right_button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents headlights_checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents brakelights_checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort

End Class
