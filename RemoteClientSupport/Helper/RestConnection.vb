Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports RemoteClientSupport.Resources
Imports RemoteClientSupport.DataType

Namespace Helper


    Public Class RestConnection

        Dim jsonData As String = "{""groupid"":""g176111429""}"
        Private Const AccessToken As String = "10435310-iDXxYbaR7SeBmDywhvVp"
        Dim postReq As HttpWebRequest

        Friend Function TestConnection() As HttpWebRequest
            Console.WriteLine("TESTING PING...")
            Try
                postReq = HttpWebRequest.Create(ApiUrls.UrlPing)
                postReq.Method = "GET"
                postReq.Headers.Add("Authorization", "Bearer " + AccessToken)
            Catch ex As Exception
                Console.WriteLine("Send Request Error[{0}]", ex.Message)
            End Try
            Return postReq
        End Function
        Friend Function SendToApi() As HttpWebRequest
            Console.WriteLine("IN API METHOD")
            Try
                postReq = HttpWebRequest.Create(ApiUrls.UrlCreateSession)
                postReq.Method = "POST"
                postReq.ContentType = "application/json"
                postReq.Headers.Add("Authorization", "Bearer " + AccessToken)

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

        Friend Function GetSessionInfo(ByVal strResponse As String) As String
            Console.WriteLine("Getting session info....")
            Dim tempLink = New With {Key .end_customer_link = ""}
            Dim session = JsonConvert.DeserializeAnonymousType(strResponse, tempLink)
            Dim link As String = session.end_customer_link
            Console.WriteLine("Session INFO:")
            Console.WriteLine(link)
            Return link
        End Function


    End Class
End Namespace