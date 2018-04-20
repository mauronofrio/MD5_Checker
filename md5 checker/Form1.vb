Imports System.Security.Cryptography
Imports System.IO
Public Class Form1
    Dim sSourceData As String
    Dim tmpSource() As Byte
    Dim tmpHash() As Byte
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hash = MD5.Create
        Dim hashValue() As Byte
        Dim fileStream As FileStream = File.OpenRead(TextBox1.Text)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)
        Dim hash_hex = PrintByteArray(hashValue)
        fileStream.Close()
        My.Computer.FileSystem.WriteAllText(TextBox1.Text & ".md5", hash_hex, True, System.Text.Encoding.ASCII)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        OpenFileDialog1.DefaultExt = ".*"
        OpenFileDialog1.Filter = "File|*.*"
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub
    Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            TextBox1.Text = path
        Next
    End Sub
    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Public Function PrintByteArray(ByVal array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value.ToLower
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim hash = MD5.Create
        Dim hashValue() As Byte
        Dim fileStream As FileStream = File.OpenRead(TextBox1.Text)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)
        Dim hash_hex = PrintByteArray(hashValue)
        fileStream.Close()
        TextBox2.Text = hash_hex
    End Sub
End Class
