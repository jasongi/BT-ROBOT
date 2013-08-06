﻿Public Class Form1

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Declarations
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Dim uart_out(1) As Byte
    Dim headlight As Boolean = False
    Dim brakelight As Boolean = False

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' The next three subrutines handle connecting to the serial port ''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connect_button.Click
        Try
            SerialPort1.Open()
            Reset()
            disconnect_button.Enabled = True
            connect_button.Enabled = False
            ComboBox1.Enabled = False
        Catch unauthorized As UnauthorizedAccessException
            MessageBox.Show("This program is forbidden access to the COM port. It may be in use by another application, or blocked for security reasons.")
        Catch exception As IO.IOException
            MessageBox.Show("Selected COM port wasn't found on this machine.")
        Catch arg As InvalidOperationException
            MessageBox.Show("Selected COM port is already open.")
        End Try
    End Sub

    Private Sub disconnect_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnect_button.Click
        Try
            connect_button.Enabled = True
            disconnect_button.Enabled = False
            ComboBox1.Enabled = True
            SerialPort1.Close()
        Catch invalid As InvalidOperationException
            MessageBox.Show("Selected COM port is already closed.")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        SerialPort1.PortName = ComboBox1.Text
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' The next two rutines determine the byte to send out '''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub PressKey(ByVal data As Byte, ByVal mask As Byte)
        If (SerialPort1.IsOpen) Then
            Try
                uart_out(0) = (data Or uart_out(0))
                uart_out(0) = (mask And uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            End Try
        Else
            MessageBox.Show("Serial Port is disconnected.")
        End If
    End Sub

    Private Sub ReleaseKey(ByVal data As Byte)
        If (SerialPort1.IsOpen) Then
            Try
                uart_out(0) = (data And uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            End Try
        Else
            MessageBox.Show("Serial Port is disconnected.")
        End If
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Handles label click '''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.google.com/search?hl=en&q=uzzors2k")
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' The next batch of rutines handle clicking the buttons '''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub forward_button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forward_button.MouseDown
        PressKey(16, 208)
    End Sub

    Private Sub reverse_button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles reverse_button.MouseDown
        PressKey(32, 224)
    End Sub

    Private Sub left_button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles left_button.MouseDown
        PressKey(4, 196)
    End Sub

    Private Sub right_button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles right_button.MouseDown
        PressKey(8, 200)
    End Sub

    Private Sub forward_button_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles forward_button.MouseUp
        ReleaseKey(236)
    End Sub

    Private Sub reverse_button_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles reverse_button.MouseUp
        ReleaseKey(220)
    End Sub

    Private Sub left_button_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles left_button.MouseUp
        ReleaseKey(248)
    End Sub

    Private Sub right_button_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles right_button.MouseUp
        ReleaseKey(244)
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' The next two rutines handle key-pressing keys '''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.W Then
            forward_button.Enabled = False
            reverse_button.Enabled = False
            PressKey(16, 220)
        End If
        If e.KeyCode = Keys.S Then
            reverse_button.Enabled = False
            forward_button.Enabled = False
            PressKey(32, 236)
        End If
        If e.KeyCode = Keys.A Then
            left_button.Enabled = False
            right_button.Enabled = False
            PressKey(4, 244)
        End If
        If e.KeyCode = Keys.D Then
            right_button.Enabled = False
            left_button.Enabled = False
            PressKey(8, 248)
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.W Then
            forward_button.Enabled = True
            reverse_button.Enabled = True
            ReleaseKey(236)
        End If
        If e.KeyCode = Keys.S Then
            reverse_button.Enabled = True
            forward_button.Enabled = True
            ReleaseKey(220)
        End If
        If e.KeyCode = Keys.A Then
            left_button.Enabled = True
            right_button.Enabled = True
            ReleaseKey(248)
        End If
        If e.KeyCode = Keys.D Then
            right_button.Enabled = True
            left_button.Enabled = True
            ReleaseKey(244)
        End If
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' The next two rutines handle controlling the lights ''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub headlights_checkbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles headlights_checkbox.CheckedChanged
        If headlight Then
            Try
                uart_out(0) = (192 And uart_out(0))
                uart_out(0) = (127 And uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
                headlight = False
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            Catch closed As InvalidOperationException
                MessageBox.Show("Serial Port is disconnected.")
            End Try
        Else
            Try
                uart_out(0) = (192 And uart_out(0))
                uart_out(0) = (128 Or uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
                headlight = True
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            Catch closed As InvalidOperationException
                MessageBox.Show("Serial Port is disconnected.")
            End Try
        End If
    End Sub

    Private Sub brakelights_checkbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brakelights_checkbox.CheckedChanged
        If brakelight Then
            Try
                uart_out(0) = (192 And uart_out(0))
                uart_out(0) = (191 And uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
                brakelight = False
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            Catch closed As InvalidOperationException
                MessageBox.Show("Serial Port is disconnected.")
            End Try
        Else
            Try
                uart_out(0) = (192 And uart_out(0))
                uart_out(0) = (64 Or uart_out(0))
                SerialPort1.Write(uart_out, 0, 1)
                brakelight = True
            Catch exception As TimeoutException
                MessageBox.Show("The connection timed out. Check hardware connection to device or select a different port.")
            Catch closed As InvalidOperationException
                MessageBox.Show("Serial Port is disconnected.")
            End Try
        End If
    End Sub
End Class
