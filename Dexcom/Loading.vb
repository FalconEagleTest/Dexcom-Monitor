Public Class Loading
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Main.update_all()
        Me.Visible = False
        Main.Show()
        Me.Dispose()

    End Sub
End Class