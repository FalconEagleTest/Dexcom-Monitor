Imports System.Deployment.Application

Public Class about
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = Main.BackgroundImage
        Dim myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion
        Label2.Text = "Version:" + Convert.ToString(myVersion)



    End Sub
End Class