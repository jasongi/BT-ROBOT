﻿Public Class Form1

    Dim i, uart_in1, com_stat As Byte
    Dim uart_out(1) As Byte
    Dim binstring(8) As Char
    Dim ports() As String = SerialPort1.GetPortNames()

    Dim uart_in2, com_stat2 As Byte
    Dim uart_out2(1) As Byte

    Delegate Sub inputprocessCallback(ByVal [data] As Byte)

    Private Sub Reset()
        uart_out(0) = 0
        uart_in1 = 0
        com_stat = 0
        inputprocess(uart_in1)
    End Sub

    Private Sub inputprocess(ByVal [data] As Byte)
        uart_out(0) = [data]
        'feedback.Text = [data].ToString
        i = 0
        Do Until i > 7
            If [data] >= (2 ^ (7 - i)) Then
                binstring(i) = "1"
                [data] = ([data] - (2 ^ (7 - i)))
            Else
                binstring(i) = "0"
            End If
            i = (i + 1)
        Loop
        If (null_modem_select.Checked) Then
            feedback_in.Text = binstring
            feedback_out.Text = binstring
        Else
            feedback_in.Text = binstring
        End If
    End Sub

    Private Sub connect_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connect_button1.Click
        com_stat = 0
        Dim port As String
        For Each port In ports
            If port.Contains(SerialPort1.PortName) Then
                com_stat = 1
            End If
        Next port
        If com_stat = 1 Then
            Try
                SerialPort1.Open()
                Reset()
                disconnect_button1.Enabled = True
                connect_button1.Enabled = False
                ComboBox1.Enabled = False
            Catch exception As UnauthorizedAccessException
                MessageBox.Show("COM port may already be open. Close open applications and try again.")
            End Try
        Else
            MessageBox.Show("Selected COM port wasn't found on this machine.")
        End If
    End Sub

    Private Sub disconnect_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnect_button1.Click
        connect_button1.Enabled = True
        disconnect_button1.Enabled = False
        ComboBox1.Enabled = True
        SerialPort1.Close()
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        uart_in1 = SerialPort1.ReadByte
        uart_out(0) = uart_in1
        If (null_modem_select.Checked) Then
            SerialPort1.Write(uart_out, 0, 1)
        ElseIf (SerialPort2.IsOpen And port_relay_select.Checked) Then
            SerialPort2.Write(uart_out, 0, 1)
        End If
        If (feedback_in.InvokeRequired) Then
            Dim x As New inputprocessCallback(AddressOf inputprocess)
            feedback_in.Invoke(x, uart_in1)
        Else
            inputprocess(uart_in1)
        End If
    End Sub

    Private Sub SerialPort1_ErrorReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        MessageBox.Show("Error Received.")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.google.com/search?hl=en&q=uzzors2k")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connect_button2.Click
        com_stat2 = 0
        Dim port As String
        For Each port In ports
            If port.Contains(SerialPort2.PortName) Then
                com_stat2 = 1
            End If
        Next port
        If com_stat2 = 1 Then
            Try
                SerialPort2.Open()
                Reset()
                disconnect_button2.Enabled = True
                connect_button2.Enabled = False
                ComboBox2.Enabled = False
            Catch exception As UnauthorizedAccessException
                MessageBox.Show("COM port may already be open. Close open applications and try again.")
            End Try
        Else
            MessageBox.Show("Selected COM port wasn't found on this machine.")
        End If
    End Sub

    Private Sub disconnect_button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnect_button2.Click
        SerialPort2.Close()
        connect_button2.Enabled = True
        disconnect_button2.Enabled = False
        ComboBox2.Enabled = True
    End Sub

    Private Sub null_modem_select_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles null_modem_select.CheckedChanged
        disconnect_button2.Enabled = False
        connect_button2.Enabled = False
        ComboBox2.Enabled = False
    End Sub

    Private Sub port_relay_select_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles port_relay_select.CheckedChanged
        connect_button2.Enabled = True
        disconnect_button2.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub SerialPort2_ErrorReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles SerialPort2.ErrorReceived
        MessageBox.Show("Error Received.")
    End Sub

    Private Sub SerialPort2_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        uart_in2 = SerialPort2.ReadByte
        uart_out2(0) = uart_in2
        If (SerialPort1.IsOpen And port_relay_select.Checked) Then
            SerialPort1.Write(uart_out2, 0, 1)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        SerialPort1.PortName = ComboBox1.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        SerialPort2.PortName = ComboBox2.Text
    End Sub
End Class
