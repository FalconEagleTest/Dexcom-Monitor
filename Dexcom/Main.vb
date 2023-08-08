Imports System.Deployment.Application
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports IronPython.Hosting

Imports Microsoft.Scripting.Hosting
Imports Newtonsoft.Json
Imports ZedGraph

Public Class Main

    Dim result_string() As String = {"None", "DoubleUp", "SingleUp", "FortyFiveUp", "Flat", "FortyFiveDown", "SingleDown", "DoubleDown", "NotComputable", "RateOutOfRange"}
    Dim trand_arrow() As String = {"", "↑↑", "↑", "↗", "→", "↘", "↓", "↓↓", "?", "-"}
    Public f_time_list As List(Of String) = New List(Of String)
    Public f_str_list As List(Of String) = New List(Of String)
    Public t_0_result As String
    Public mark_low, mark_high As Boolean
    Dim min_value
    Dim max_value
    Dim sec As Integer = 0

    Public Class DexcomResult
        Public Property ST As String = String.Empty
        Public Property DT As String = String.Empty
        Public Property Trend As String = String.Empty
        Public Property Value As Double
        Public Property WT As String = String.Empty
    End Class

    Public Sub make_graph(ByVal zgc As ZedGraphControl, ByVal all_values As List(Of String), ByVal all_times As List(Of String))
        Const NumberOfBars = 5
        zgc.GraphPane.CurveList.Clear()
        zgc.GraphPane.GraphObjList.Clear()

        Dim myPane As GraphPane = ZedGraphControl2.GraphPane

        Dim list = New PointPairList()
        Dim list2 = New PointPairList()
        Dim list3 = New PointPairList()
        myPane.Title.Text = "mg/dL"
        'myPane.BarSettings.Type = BarType.Stack
        'myPane.BarSettings.ClusterScaleWidth = 1D

        Dim col = Color.White
        myPane.XAxis.Title.Text = "Time"
        myPane.XAxis.Title.FontSpec.FontColor = col
        myPane.XAxis.Type = AxisType.Date
        myPane.XAxis.Scale.Format = "HH-mm-ss"
        myPane.XAxis.Scale.MajorUnit = DateUnit.Hour
        myPane.XAxis.Scale.MajorStep = 1
        myPane.XAxis.Scale.Min = New XDate(DateTime.Now.AddHours(-4))
        myPane.XAxis.Scale.Max = New XDate(DateTime.Now)
        myPane.XAxis.MajorTic.IsBetweenLabels = True
        myPane.XAxis.MinorTic.Size = 0
        myPane.XAxis.MajorTic.IsInside = False
        myPane.XAxis.MajorTic.IsOutside = True
        myPane.XAxis.MajorGrid.IsVisible = False
        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.Color = col
        myPane.XAxis.Scale.FontSpec.FontColor = col
        myPane.XAxis.MajorTic.Color = col
        myPane.XAxis.MinorTic.Color = col

        myPane.YAxis.Title.Text = "mg/dL"
        myPane.YAxis.Title.FontSpec.FontColor = col
        myPane.YAxis.Type = AxisType.Linear
        'myPane.YAxis.Scale.Format = "00:\0\0"
        myPane.YAxis.Scale.Min = 0
        myPane.YAxis.Scale.Max = 500
        myPane.YAxis.Scale.MajorStep = 1
        myPane.YAxis.MinorTic.Size = 0
        myPane.YAxis.MajorGrid.IsVisible = False
        myPane.YAxis.MajorGrid.Color = Color.LightGray



        myPane.YAxis.Color = col
        myPane.YAxis.Scale.FontSpec.FontColor = col
        myPane.YAxis.MajorTic.Color = col
        myPane.YAxis.MinorTic.Color = col


        Dim DatesX As New List(Of Double)

        myPane.AddCurve("", list, Color.Yellow, SymbolType.Diamond)
        myPane.AddCurve("", list2, Color.Orange, SymbolType.None)
        myPane.AddCurve("", list3, Color.Red, SymbolType.None)

        For i = 0 To (all_values.Count - 1)


            list.Add(New XDate(Convert.ToDateTime(all_times(i))), all_values(i))
            list2.Add(New XDate(Convert.ToDateTime(all_times(i))), Settings1.Default.highlevel)
            list3.Add(New XDate(Convert.ToDateTime(all_times(i))), Settings1.Default.lowlevel)
        Next

        zgc.GraphPane.Fill = New Fill(Color.Black)
        zgc.GraphPane.Chart.Fill.Brush = New System.Drawing.SolidBrush(Color.Black)
        ' zgc.Dispose()
        zgc.AxisChange()
        zgc.Invalidate()

        zgc.Refresh()


    End Sub
    Private Sub updateGraph(ByVal zgc As ZedGraphControl, ByVal all_values As List(Of String), ByVal all_times As List(Of String))
        Dim x As Double
        Dim list = New PointPairList()

        Dim SizeOfArray

        zgc.GraphPane.CurveList.Clear()
        zgc.GraphPane.GraphObjList.Clear()

        Dim myPane As GraphPane
        Dim myCurve2 As LineItem
        myPane = zgc.GraphPane
        myPane.YAxis.Title.Text = "Hours Worked"
        myPane.YAxis.Type = AxisType.Linear
        'myPane.YAxis.Scale.Format = "00:\0\0"

        myPane.YAxis.Scale.MajorStep = 1
        myPane.YAxis.MinorTic.Size = 0
        myPane.YAxis.Scale.Min = 0
        myPane.XAxis.Scale.Max = 500

        myPane.XAxis.Type = AxisType.Date
        myPane.XAxis.Scale.Format = "HH:mm"
        myPane.XAxis.Scale.MajorUnit = DateUnit.Hour
        myPane.XAxis.Scale.MajorStep = 1
        myPane.XAxis.Scale.Min = New XDate(DateTime.Now.AddDays(-1))
        myPane.XAxis.Scale.Max = New XDate(DateTime.Now.AddDays(1))



        myCurve2 = myPane.AddCurve("", list, Color.Red, SymbolType.None)

        list.Clear()


        SizeOfArray = all_values.Count - 1



        For x = 0 To SizeOfArray

            list.Add(Convert.ToDouble(all_times(x)), Convert.ToDouble(all_values(x)))





        Next x


        '  ZedGraphControl2.GraphPane.XAxis.Scale.Max = 1725502708000





        zgc.AxisChange()

        zgc.Invalidate()

        zgc.Refresh()





    End Sub
    Public Sub update_all()
        Try


            Dim Client As HttpClient
            Dim Response As HttpResponseMessage
            Dim ApiPoint = $"https://shareous1.dexcom.com/ShareWebServices/Services/General/AuthenticatePublisherAccount"
            Dim accountIdRequestJson = JsonConvert.SerializeObject(New With {Key _
                .accountName = Settings1.Default.username, Key _
                .applicationId = "d8665ade-9673-4e27-9ff6-92db4ce13d13", Key _
                .password = Settings1.Default.password
            })
            Dim accountIdRequest = New HttpRequestMessage(HttpMethod.Post, New Uri(ApiPoint)) With {
        .Content = New StringContent(accountIdRequestJson, Encoding.UTF8, "application/json")
    }

            Client = New HttpClient()
            Client.BaseAddress = New Uri(ApiPoint)


            Dim Content = New StringContent(accountIdRequestJson, Encoding.UTF8, "application/json")
            Response = Client.SendAsync(accountIdRequest).Result 'sync, Await without .Result
            Dim accountId = Response.Content.ReadAsStringAsync.Result.Replace("""", "")

            Dim sessionIdRequestJson = JsonConvert.SerializeObject(New With {Key _
                .accountId = accountId, Key _
                .applicationId = "d8665ade-9673-4e27-9ff6-92db4ce13d13", Key _
                .password = Settings1.Default.password
            })
            Dim url = $"https://shareous1.dexcom.com/ShareWebServices/Services/General/LoginPublisherAccountById"
            Dim accountSessionIdRequest = New HttpRequestMessage(HttpMethod.Post, New Uri(url)) With {
               .Content = New StringContent(sessionIdRequestJson, Encoding.UTF8, "application/json")
            }

            Response = Client.SendAsync(accountSessionIdRequest).Result 'sync, Await without .Result
            Dim sessionId = Response.Content.ReadAsStringAsync.Result.Replace("""", "")


            Dim data_url = String.Format("https://{0}/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues?sessionId={1}&minutes=1440&maxCount=288", "shareous1.dexcom.com", sessionId)

            Dim request = New HttpRequestMessage(HttpMethod.Post, New Uri(data_url))
            Dim initialResult = Client.SendAsync(request).Result
            Dim stringResult = initialResult.Content.ReadAsStringAsync.Result

            Dim result = JsonConvert.DeserializeObject(Of List(Of DexcomResult))(stringResult)
            Dim nDateTime_start As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
            Dim strValue, nDateTime
            Dim resultString As Integer
            f_time_list.Clear()
            f_str_list.Clear()
            If (result(0).Value < 55) And (mark_low = False) Then
                mark_low = True
                send_msg(Settings1.Default.msglow)
            ElseIf (result(0).Value > 65) Then
                mark_low = False
            End If

            If (result(0).Value > 300) And (mark_high = False) Then
                mark_high = True
                send_msg(Settings1.Default.msghigh)
            ElseIf (result(0).Value < 250) Then
                mark_high = False
            End If

            t_0_result = result(0).Value.ToString + trand_arrow(Array.IndexOf(result_string, result(0).Trend))
            Dim firstDate As DateTime = Now
            Dim currentUTC As DateTime
            Dim localZone As TimeZone = TimeZone.CurrentTimeZone

            resultString = Regex.Match(result(0).WT, "\d+").Value / 1000
            nDateTime = nDateTime_start.AddSeconds(resultString)
            currentUTC = localZone.ToLocalTime(nDateTime)

            strValue = Strings.Format(currentUTC, "yyyy-MM-dd HH:mm:ss")

            Dim diff As System.TimeSpan = firstDate.Subtract(Convert.ToDateTime(strValue))
            Dim diff_n = (Math.Round(diff.TotalMinutes, 2)).ToString

            Label1.Text = t_0_result
            If diff_n > 6 Then
                Label2.ForeColor = Color.Red
            Else
                Label2.ForeColor = Color.White
            End If
            Label2.Text = String.Format("{0} Minutes Ago", diff_n) + Environment.NewLine + strValue

            For Each item In result
                Try
                    resultString = Regex.Match(item.WT, "\d+").Value / 1000
                    nDateTime = nDateTime_start.AddSeconds(resultString)
                    currentUTC = localZone.ToLocalTime(nDateTime)

                    strValue = Strings.Format(currentUTC, "yyyy-MM-dd HH:mm:ss")
                    f_time_list.Add(strValue)
                    f_str_list.Add(item.Value)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try


            Next
            'dex_item =
            f_time_list.Reverse()
            f_str_list.Reverse()

            make_graph(ZedGraphControl2, f_str_list, f_time_list)
        Catch ex As Exception
            MsgBox("Error getting data check username and password")
        End Try
    End Sub


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





        update_all()






    End Sub
    <DllImport("KERNEL32.DLL", EntryPoint:="SetProcessWorkingSetSize", SetLastError:=True, CallingConvention:=CallingConvention.StdCall)>
    Friend Shared Function SetProcessWorkingSetSize(ByVal pProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Integer, ByVal dwMaximumWorkingSetSize As Integer) As Boolean
    End Function
    <DllImport("KERNEL32.DLL", EntryPoint:="GetCurrentProcess", SetLastError:=True, CallingConvention:=CallingConvention.StdCall)>
    Friend Shared Function GetCurrentProcess() As IntPtr
    End Function
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        update_all()
        Dim pHandle As IntPtr = GetCurrentProcess()
        SetProcessWorkingSetSize(pHandle, -1, -1)
        GC.Collect()

    End Sub





    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (Me.WindowState = FormWindowState.Minimized) Then
            NotifyIcon1.Visible = True
            Me.Visible = False

        Else
            NotifyIcon1.Visible = False
            Me.Visible = True
            Me.Height = 645
            Me.Width = 1106

        End If


    End Sub

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        NotifyIcon1.Visible = False
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim myPane = ZedGraphControl2.GraphPane
        myPane.XAxis.Scale.Min = New XDate(DateTime.Now.AddHours(-1 * HScrollBar1.Value))
        myPane.XAxis.Scale.Max = New XDate(DateTime.Now)
        ZedGraphControl2.AxisChange()

        ZedGraphControl2.Invalidate()

        ZedGraphControl2.Refresh()
        Label3.Text = "Scale: " + HScrollBar1.Value.ToString + " Hours"
    End Sub





    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sec += 1
        If sec = 10 Then

            SendKeys.Send("{ENTER}")
            Timer1.Stop()
            sec = 0
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings_form.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        update_all()
    End Sub

    Private Sub ZedGraphControl2_Load(sender As Object, e As EventArgs) Handles ZedGraphControl2.Load

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about.Show()

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub

    Private Sub send_msg(msg As String)
        Dim web As WebBrowser = New WebBrowser
        web.Navigate(String.Format("whatsapp://send?phone={0}&text={1}", Settings1.Default.phonenumber, msg.Replace(" ", "+")))

        Timer1.Start()
    End Sub

    Private Sub NotifyIcon1_MouseMove(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseMove
        NotifyIcon1.Text = Label1.Text + Environment.NewLine + Label2.Text

    End Sub
End Class
