Imports RemoteClientSupport.Helper
Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rc = New RestConnection()
        Dim request = rc.SendToApi()
        Dim response = rc.GetResponse(request)
        Dim link = rc.GetSessionInfo(response)
        labelSessionLink.Text = link
        labelSessionLink.Links.Add(0, labelSessionLink.Text.Length, link)
        MsgBox("Clink on the link to start a session")

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rc = New RestConnection()
        Dim request = rc.TestConnection()

        If (rc.GetResponse(request) IsNot Nothing) Then
            labelConnectionStatus.Text = "Connected"
            labelConnectionStatus.ForeColor = Color.Green
        Else
            labelConnectionStatus.Text = "No Connection"
            labelConnectionStatus.ForeColor = Color.Red
        End If

        labelSessionLink.Text = String.Empty

    End Sub

    Private Sub labelSessionLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles labelSessionLink.LinkClicked
        Process.Start(e.Link.LinkData.ToString)
    End Sub
End Class
