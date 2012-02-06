Option Strict On
Option Explicit On

Imports System.Management

Public Class WMIProcessing
    Protected LastPID As Integer

#Region " Definitions "
    'WMI Objects.
    Private mManagementScope As New System.Management.ManagementScope
    Private mConnectionOptions As New System.Management.ConnectionOptions
    Private mCollection As System.Management.ManagementObjectCollection
    Private mObject As System.Management.ManagementObject

    'WMI Authentivation
    Private WMIServer As String = "."
    Private WMIUsername As String = ""
    Private WMIPassword As String = ""

    'Data Storage.
    Private mOldData As RawData
    Private mNowData As RawData
    Private mResult As Double

    'Flag to indicate first run.
    Private mFirstRun As Boolean = True

    'Data Storage Structure.
    Private Structure RawData
        Public RAWPercentProcessorTime As ULong
        Public TimeStamp As ULong
    End Structure
#End Region

#Region " Constructor "
    Public Sub New()
        Try
            With mConnectionOptions
                .Impersonation = System.Management.ImpersonationLevel.Impersonate
                '* Use next line for XP
                .Authentication = System.Management.AuthenticationLevel.Packet
                '* Use next line for Win prior XP
                '*.Authentication = System.Management.AuthenticationLevel.Connect
                '.Username = WMIUsername
                '.Password = WMIPassword
            End With

            mManagementScope = New System.Management.ManagementScope("\\" & WMIServer & "\root\cimv2", mConnectionOptions)

            'Connect to WMI namespace.
            mManagementScope.Connect()
            If mManagementScope.IsConnected = False Then
                Throw New Exception("Could not connect to WMI namespace")
            End If

            'Initialize mOldData.
            mOldData.RAWPercentProcessorTime = 0
            mOldData.TimeStamp = 0

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
#End Region

#Region " Get Data Functions "
    Friend Function GetProcessorUtilisation(ByVal intIDProcess As Integer) As Integer
        Try
            If Not intIDProcess = LastPID Then
                'Reinitialize mOldData.
                mOldData.RAWPercentProcessorTime = 0
                mOldData.TimeStamp = 0
                LastPID = intIDProcess
            End If

            'Build query.
            Dim mObjectSearcher = New System.Management.ManagementObjectSearcher("Select * From Win32_PerfRawData_PerfProc_Process where IDProcess=" & intIDProcess)

            'Run the WMI Query to get the current Win32_PerfRawData_PerfOS_Processor data.
            mCollection = mObjectSearcher.Get()

            'Store the data.
            For Each Me.mObject In mCollection
                'Get current data.
                mNowData.RAWPercentProcessorTime = CULng(mObject.GetPropertyValue("PercentProcessorTime"))
                mNowData.TimeStamp = CULng(mObject.GetPropertyValue("Timestamp_Sys100NS"))
            Next

            'Calculate CPU % Utilisation.
            Dim CoreCount As Integer = System.Environment.ProcessorCount
            mResult = (((mNowData.RAWPercentProcessorTime - mOldData.RAWPercentProcessorTime) / (mNowData.TimeStamp - mOldData.TimeStamp)) * 100)
            mResult = mResult / CoreCount

            'Convert to integer
            mResult = Convert.ToInt16(mResult)

            'Make sure output stays within bounds.
            If mResult < 0 Then mResult = 0
            If mResult > 100 Then mResult = 100

            'Store data for next refresh.
            mOldData = mNowData

            'Check for the first run through.
            If mFirstRun = True Then
                mFirstRun = False
                mResult = 0
            End If
            Return Convert.ToInt16(mResult)

        Catch ex As Exception
            'CATCH ERROR HERE
        End Try
    End Function

    Friend Function IsConnected() As Boolean
        Return mManagementScope.IsConnected
    End Function
#End Region
End Class