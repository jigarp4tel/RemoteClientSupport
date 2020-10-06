Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class RestConnection

    Dim jsonData As String = "{""groupid"":""g176021847""}"

    Friend Function SendToApi() As HttpWebRequest

        Dim reqString() As Byte
        Dim postReq As HttpWebRequest

        Console.WriteLine("IN API METHOD")

        Try
            postReq = HttpWebRequest.Create("https://webapi.teamviewer.com/api/v1/sessions")
            postReq.Method = "POST"
            postReq.ContentType = "application/json"
            postReq.Headers.Add("Authorization", "Bearer 10412826-XjAzWk5thcN4K4Yw7XGq")

            Using StreamWriter = New StreamWriter(postReq.GetRequestStream())

                StreamWriter.Write(jsonData)
                StreamWriter.Flush()
                StreamWriter.Close()
            End Using

        Catch ex As Exception
            Console.WriteLine("Send Request Error[{0}]", ex.Message)

            Return Nothing
        End Try
        Return postReq

    End Function

    Friend Function GetResponse(ByVal httpWebRequest As HttpWebRequest) As String
        Dim strResponse As String = "Bad Request:400"
        Try
            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()

                strResponse = result.ToString()
                Console.WriteLine($"PRINTING RESPONSE: {strResponse}")
            End Using
        Catch ex As Exception
            Console.WriteLine("GetResponse Error[{0}]", ex.Message)

            Return ex.Message
        End Try

        Return strResponse

    End Function


End Class
