Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Public Class Formulario

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0.0
        Me.FlatTextBox1.Text = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", Nothing))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.02
        Dim flag As Boolean = Me.Opacity = 98.0
        If flag Then
            Me.Timer1.[Stop]()
        End If
    End Sub


    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        Dim flag As Boolean = Operators.CompareString(Me.FlatTextBox2.Text, "Clique em 'Gerar HWID'", False) = 0
        If flag Then
            Interaction.MsgBox("Por favor, Gere algum HWID antes de alterar!", MsgBoxStyle.Critical, "Erro")
        Else
            Me.Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.FlatProgressBar1.Increment(1)
        Dim flag As Boolean = Me.FlatProgressBar1.Value = 100
        If flag Then
            Me.Timer2.[Stop]()
            Me.FlatProgressBar1.Value = 0
            Try
                Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", Me.FlatTextBox2.Text)
                Interaction.MsgBox("HWID Alterado com sucesso!", MsgBoxStyle.Information, "Sucesso")
                Me.FlatTextBox1.Text = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", Nothing))
            Catch expr_9B As Exception
                ProjectData.SetProjectError(expr_9B)
                Dim ex As Exception = expr_9B
                Erro.Show()
                Erro.TextBox1.Text = ex.Message
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        Dim n As String = ""
        For i = 65 To 90
            n += Chr(i)
        Next
        Dim AG1 As New Random
        Dim AG2 As String = ""
        AG2 = AG1.Next(1, 123).ToString("000")

        Dim AG3 As New Random
        Dim AG4 As String = ""
        AG4 = AG3.Next(1, 456).ToString("000")

        Dim AG5 As New Random
        Dim AG6 As String = ""
        AG6 = AG5.Next(1, 789).ToString("000")

        Dim AG7 As New Random
        Dim AG8 As String = ""
        AG8 = AG7.Next(1, 101).ToString("000")

        Dim AG9 As New Random
        Dim AG10 As String = ""
        AG10 = AG9.Next(1, 623).ToString("000")

        Dim AG11 As New Random
        Dim AG12 As String = ""
        AG12 = AG11.Next(1, 831).ToString("000")

        Dim AG13 As New Random
        Dim AG14 As String = ""
        AG14 = AG13.Next(1, 205).ToString("000")

        FlatTextBox2.Text = "{" & AG2 & "Y" & "-" & "K" & AG4 & "-" & "H" & AG6 & "-" & AG8 & "W" & "-" & "A" & AG10 & "-" & AG12 & "F" & "-" & "S" & AG14 & "}"
    End Sub

    Private Sub FormSkin1_Click(sender As Object, e As EventArgs) Handles FormSkin1.Click

    End Sub
End Class
