﻿Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rc = New RestConnection()
        Dim request = rc.SendToApi()
        MsgBox(rc.GetResponse(request))

    End Sub
End Class
