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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.connect_button1 = New System.Windows.Forms.Button
        Me.disconnect_button1 = New System.Windows.Forms.Button
        Me.feedback_in = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.disconnect_button2 = New System.Windows.Forms.Button
        Me.connect_button2 = New System.Windows.Forms.Button
        Me.port_relay_select = New System.Windows.Forms.RadioButton
        Me.null_modem_select = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.feedback_out = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.ReadTimeout = 2000
        Me.SerialPort1.WriteTimeout = 2000
        '
        'connect_button1
        '
        Me.connect_button1.Location = New System.Drawing.Point(24, 33)
        Me.connect_button1.Name = "connect_button1"
        Me.connect_button1.Size = New System.Drawing.Size(75, 23)
        Me.connect_button1.TabIndex = 0
        Me.connect_button1.Text = "Connect"
        Me.connect_button1.UseVisualStyleBackColor = True
        '
        'disconnect_button1
        '
        Me.disconnect_button1.Location = New System.Drawing.Point(24, 79)
        Me.disconnect_button1.Name = "disconnect_button1"
        Me.disconnect_button1.Size = New System.Drawing.Size(75, 23)
        Me.disconnect_button1.TabIndex = 1
        Me.disconnect_button1.Text = "Disconnect"
        Me.disconnect_button1.UseVisualStyleBackColor = True
        '
        'feedback_in
        '
        Me.feedback_in.Location = New System.Drawing.Point(56, 19)
        Me.feedback_in.Name = "feedback_in"
        Me.feedback_in.ReadOnly = True
        Me.feedback_in.Size = New System.Drawing.Size(100, 20)
        Me.feedback_in.TabIndex = 10
        Me.feedback_in.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Data:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.disconnect_button1)
        Me.GroupBox1.Controls.Add(Me.connect_button1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 135)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "COM Settings 1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(145, 314)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(184, 13)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Program created by Eirik Taylor, 2009"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.feedback_in)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 248)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 50)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Serial In (COM2 out)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.disconnect_button2)
        Me.GroupBox3.Controls.Add(Me.connect_button2)
        Me.GroupBox3.Location = New System.Drawing.Point(247, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(205, 135)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "COM Settings 2"
        '
        'disconnect_button2
        '
        Me.disconnect_button2.Enabled = False
        Me.disconnect_button2.Location = New System.Drawing.Point(24, 79)
        Me.disconnect_button2.Name = "disconnect_button2"
        Me.disconnect_button2.Size = New System.Drawing.Size(75, 23)
        Me.disconnect_button2.TabIndex = 1
        Me.disconnect_button2.Text = "Disconnect"
        Me.disconnect_button2.UseVisualStyleBackColor = True
        '
        'connect_button2
        '
        Me.connect_button2.Enabled = False
        Me.connect_button2.Location = New System.Drawing.Point(24, 33)
        Me.connect_button2.Name = "connect_button2"
        Me.connect_button2.Size = New System.Drawing.Size(75, 23)
        Me.connect_button2.TabIndex = 0
        Me.connect_button2.Text = "Connect"
        Me.connect_button2.UseVisualStyleBackColor = True
        '
        'port_relay_select
        '
        Me.port_relay_select.AutoSize = True
        Me.port_relay_select.Location = New System.Drawing.Point(201, 19)
        Me.port_relay_select.Name = "port_relay_select"
        Me.port_relay_select.Size = New System.Drawing.Size(74, 17)
        Me.port_relay_select.TabIndex = 16
        Me.port_relay_select.Text = "Port Relay"
        Me.port_relay_select.UseVisualStyleBackColor = True
        '
        'null_modem_select
        '
        Me.null_modem_select.AutoSize = True
        Me.null_modem_select.Checked = True
        Me.null_modem_select.Location = New System.Drawing.Point(43, 19)
        Me.null_modem_select.Name = "null_modem_select"
        Me.null_modem_select.Size = New System.Drawing.Size(91, 17)
        Me.null_modem_select.TabIndex = 17
        Me.null_modem_select.TabStop = True
        Me.null_modem_select.Text = "NULL Modem"
        Me.null_modem_select.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.null_modem_select)
        Me.GroupBox4.Controls.Add(Me.port_relay_select)
        Me.GroupBox4.Location = New System.Drawing.Point(75, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(325, 52)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Program Function"
        '
        'SerialPort2
        '
        Me.SerialPort2.PortName = "COM3"
        Me.SerialPort2.ReadTimeout = 2000
        Me.SerialPort2.WriteTimeout = 2000
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.feedback_out)
        Me.GroupBox5.Location = New System.Drawing.Point(247, 248)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(205, 50)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Serial Out (COM2 in)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Data:"
        '
        'feedback_out
        '
        Me.feedback_out.Location = New System.Drawing.Point(60, 19)
        Me.feedback_out.Name = "feedback_out"
        Me.feedback_out.ReadOnly = True
        Me.feedback_out.Size = New System.Drawing.Size(100, 20)
        Me.feedback_out.TabIndex = 10
        Me.feedback_out.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20"})
        Me.ComboBox1.Location = New System.Drawing.Point(128, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(66, 21)
        Me.ComboBox1.TabIndex = 19
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20"})
        Me.ComboBox2.Location = New System.Drawing.Point(120, 49)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(66, 21)
        Me.ComboBox2.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 341)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Serial Port Config"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents connect_button1 As System.Windows.Forms.Button
    Friend WithEvents disconnect_button1 As System.Windows.Forms.Button
    Friend WithEvents feedback_in As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents disconnect_button2 As System.Windows.Forms.Button
    Friend WithEvents connect_button2 As System.Windows.Forms.Button
    Friend WithEvents port_relay_select As System.Windows.Forms.RadioButton
    Friend WithEvents null_modem_select As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents feedback_out As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox

End Class
