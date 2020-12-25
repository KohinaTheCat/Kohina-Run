Imports System.IO
Public Class frmIntro
    Dim objStreamReader As StreamReader = File.OpenText("INTRODUCTION.txt")
    Dim tickFade, nextline As Integer
    Dim story As String

    Private Sub frmIntro_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim pictures() As Bitmap = {My.Resources.loveNoodles, My.Resources.kokkuriTake, My.Resources.kohinaIdea, My.Resources.guugle} 'yeoooo bois

        If e.KeyCode = Keys.A Then

            lblStory.Text = ""
            story = objStreamReader.ReadLine
            tmrDisplayText.Start()

            nextline += 1

            If nextline < 4 Then
                picStory.Image = pictures(nextline)
            End If

            If nextline = 4 Then
                lblS.Visible = True
                lblESC.Visible = True
                lblArrow.Visible = True
                lblA.Visible = True
                picStory.Image = My.Resources.howtoplay
                story = "INSTRUCTIONS"
                tmrDisplayText.Start()
            End If

            If nextline = 5 Then
                tmrTransition.Start()
            End If

        End If

    End Sub

    Private Sub tmrDisplayText_Tick(sender As Object, e As EventArgs) Handles tmrDisplayText.Tick

        If lblStory.Text = story Then
            tmrDisplayText.Stop()
        Else
            lblStory.Text += story.Substring(lblStory.Text.Length, 1)
        End If

    End Sub

    Private Sub tmrTransition_Tick(sender As Object, e As EventArgs) Handles tmrTransition.Tick
        tickFade += 1

        If tickFade = 10 Then
            frmBedroom.Show()
            tmrTransition.Stop()
            Me.Close()
            tickFade = 0
        End If

        Me.Opacity -= 0.1
    End Sub
End Class