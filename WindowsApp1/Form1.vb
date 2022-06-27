Imports System.IO
Public Class Form1


    Dim status As Boolean
  


    Public Sub Input(ByRef msg As String, ByRef Status As Boolean)
        Dim strFile As String = "D:\WritetoErrLog_" & DateTime.Today.ToString("dd-MMM-yyyy") & ".txt"
        Dim sw As StreamWriter
        Dim fs As FileStream
        Try
            If (Not File.Exists(strFile)) Then
                Try
                    fs = File.Create(strFile)
                    sw = File.AppendText(strFile)
                    sw.WriteLine("Start Error Log for today")
                    Status = True


                Catch ex As Exception
                    MsgBox("Error Creating Log File")
                    Status = False

                End Try
            Else
                sw = File.AppendText(strFile)
                sw.WriteLine(msg & " " & DateTime.Now)
                Status = True
                sw.Close()
            End If


        Catch ex As Exception
            Status = False

            MsgBox(Status)

        End Try

    End Sub


    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click
        status = True
        Input(TextBox.Text, status)

    End Sub


End Class


