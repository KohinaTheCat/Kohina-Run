Imports System.IO
Public Class frmEnding
    Dim pictures() As Bitmap = {My.Resources.endingEatingNoodles, My.Resources.endingSick, My.Resources.endingAmbulence, My.Resources.endingPat}
    Dim story As StreamReader = File.OpenText("ENDING.txt")
    Dim picturePlace As Integer

    Private Sub frmEnding_Load(sender As Object, e As EventArgs) Handles Me.Load
        displayText = story.ReadLine
        picStory.Image = pictures(picturePlace)
        tmrDisplayText.Start()
        picturePlace += 1
    End Sub

    Private Sub frmEnding_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        lblStory.Text = ""

        If picturePlace >= 4 Then
            frmStart.Show()
            Me.Close()
            openForm = frmStart
            Kill("INVENTORY.txt")
            Kill("ITEMSTAKEN.txt")
            Kill("SAVE.txt")
            File.Create("INVENTORY.txt")
            File.Create("ITEMSTAKEN.txt")
            File.Create("SAVE.txt")
        Else

            If e.KeyCode = Keys.A Then
                displayText = story.ReadLine
                picStory.Image = pictures(picturePlace)
                tmrDisplayText.Start()
                picturePlace += 1
            End If

        End If

    End Sub

    Private Sub tmrDisplayText_Tick(sender As Object, e As EventArgs) Handles tmrDisplayText.Tick

        If lblStory.Text = displayText Then
            tmrDisplayText.Stop()
        Else

            lblStory.Text += displayText.Substring(lblStory.Text.Length, 1)
        End If

    End Sub
End Class