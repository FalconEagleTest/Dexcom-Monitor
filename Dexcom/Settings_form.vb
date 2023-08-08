Public Class Settings_form
    Private Sub Settings_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = Settings1.Default.username
        txtPassword.Text = Settings1.Default.password

        txtHighBg.Text = Settings1.Default.highlevel
        TxtLowBg.Text = Settings1.Default.lowlevel

        TxtPnum.Text = Settings1.Default.phonenumber
        TxtMsgHigh.Text = Settings1.Default.msghigh
        TxtMsgLow.Text = Settings1.Default.msglow
        Me.BackgroundImage = Main.BackgroundImage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Settings1.Default.username = txtUsername.Text

        Settings1.Default.password = txtPassword.Text

        Settings1.Default.highlevel = txtHighBg.Text
        Settings1.Default.lowlevel = TxtLowBg.Text

        Settings1.Default.phonenumber = TxtPnum.Text
        Settings1.Default.msghigh = TxtMsgHigh.Text
        Settings1.Default.msglow = TxtMsgLow.Text
        Settings1.Default.Save()
        Main.update_all()
        Me.Close()

    End Sub


    Private Sub txtHighBg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHighBg.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtLowBg_TextChanged(sender As Object, e As EventArgs) Handles TxtLowBg.TextChanged

    End Sub

    Private Sub TxtLowBg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLowBg.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtPnum_TextChanged(sender As Object, e As EventArgs) Handles TxtPnum.TextChanged

    End Sub

    Private Sub TxtPnum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPnum.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class