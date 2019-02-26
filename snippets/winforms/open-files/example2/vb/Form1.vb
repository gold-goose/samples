Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports System.Windows.Forms

Public Class OpenFileDialogForm : Inherits Form 
    Dim WithEvents selectButton As Button
    Dim openFileDialog1 As OpenFileDialog
    Dim backgroundWorker1 As BackgroundWorker

    Public Shared Sub Main()
      Application.SetCompatibleTextRenderingDefault(false)
      Application.EnableVisualStyles()
      Dim frm As New OpenFileDialogForm()
      Application.Run(frm)
    End Sub

    Private Sub New()
        backgroundWorker1 = New BackgroundWorker()
        openFileDialog1 = New OpenFileDialog()
        With openFileDialog1
           .FileName = "Select a text file"
           .Filter = "Text files (*.txt)|*.txt"
           .Title = "Open text file"
        End With
        selectButton = New Button()
        With selectButton
           .Text = "Select file"
        End With
        Controls.Add(selectButton)
    End Sub
    
    Public Sub selectButton_Click(sender As Object, e As EventArgs) _ 
            Handles selectButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim filePath = OpenFileDialog1.FileName
                Dim fs As FileStream = New FileStream(filePath, FileMode.Open)
                Process.Start("notepad.exe", filePath)
            Catch SecEx As SecurityException
                MessageBox.Show($"Security error:{vbCrLf}{vbCrLf}{SecEx.Message}{vbCrLf}{vbCrLf}" &
                $"Details:{vbCrLf}{vbCrLf}{SecEx.StackTrace}")
            End Try
        End If
    End Sub
End Class
