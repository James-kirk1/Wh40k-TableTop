Public Class CustomMessageBox
    Public buttonid As Integer
    ''reads right to left
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        buttonid = 2
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        buttonid = 3
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        buttonid = 4
        Me.Close()
    End Sub

    Private Sub CustomMessageBox_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) And Not IsBetween(buttonid, 2, 4) Then
            e.Cancel = True
            MessageBox.Show("Closing of the form is not allowed", "Security", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class