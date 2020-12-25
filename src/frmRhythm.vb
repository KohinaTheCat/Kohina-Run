Public Class frmRhythm
    Private num(8), rhythm(8), count, timer, correct, wrong As Integer

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        Dim rand As New Random
        tmrTick.Start()

        For i = 0 To 8
            num(i) = rand.Next(0, 9)
        Next

    End Sub

    Private Sub btnGreen_Click(sender As Object, e As EventArgs) Handles btnGreen.Click
        rhythm(count) = 0
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnRed_Click(sender As Object, e As EventArgs) Handles btnRed.Click
        rhythm(count) = 1
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnMagenta_Click(sender As Object, e As EventArgs) Handles btnMagenta.Click
        rhythm(count) = 2
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnCyan_Click(sender As Object, e As EventArgs) Handles btnCyan.Click
        rhythm(count) = 3
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnOrange_Click(sender As Object, e As EventArgs) Handles btnOrange.Click
        rhythm(count) = 4
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnPink_Click(sender As Object, e As EventArgs) Handles btnPink.Click
        rhythm(count) = 5
        CheckMatch()
        count += 1
    End Sub

    Private Sub frmRhythm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim btn() As Button = {btnGreen, btnRed, btnMagenta, btnCyan, btnOrange, btnPink, btnBlue, btnPurple, btnYellow}

        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        For i = 0 To 8
            btn(i).Enabled = False
        Next
    End Sub

    Private Sub btnBlue_Click(sender As Object, e As EventArgs) Handles btnBlue.Click
        rhythm(count) = 6
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnWhite_Click(sender As Object, e As EventArgs) Handles btnPurple.Click
        rhythm(count) = 7
        CheckMatch()
        count += 1
    End Sub

    Private Sub btnYellow_Click(sender As Object, e As EventArgs) Handles btnYellow.Click
        rhythm(count) = 8
        CheckMatch()
        count += 1
    End Sub

    Private Sub CheckMatch()
        If num(count) = rhythm(count) Then
            correct += 1
        Else
            wrong += 1
        End If

        lblScore.Text = correct & "-" & wrong

        If correct + wrong = 8 Then

            If correct = 8 Then
                gameWin = True
            End If

            btnExit.PerformClick()

        End If

    End Sub

    Private Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick
        Dim btn() As Button = {btnGreen, btnRed, btnMagenta, btnCyan, btnOrange, btnPink, btnBlue, btnPurple, btnYellow}
        Dim colors() As Color = {Color.Green, Color.Red, Color.Magenta, Color.Cyan, Color.Orange, Color.Pink, Color.Blue, Color.Purple, Color.Yellow}
        timer += 1

        For i = 0 To 8
            btn(i).Enabled = False
            If timer = 2 + i Then
                btn(num(i)).BackColor = Color.White
            ElseIf timer = 3 + i Then
                btn(num(i)).BackColor = colors(num(i))
            End If
        Next

        For i = 0 To 8
            btn(i).Enabled = True
        Next

        If timer = 13 Then
            tmrTick.Stop()
            timer = 0
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        tmrTransition.Start()
        If minigame = True Then


            minigame = False
            openForm = frmMinigames ' HAVE A LOSE OPTION
        Else
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
            If gameWin = True Then
                gameWin = False
                openForm = frmTreeHouse
                frmTent.picKohina.Location = New Point(546, 140)
                frmTent.picKohina.Image = My.Resources.kohina_front
            Else
                openForm = frmTent
                frmTent.picKohina.Location = New Point(546, 140)
                frmTent.picKohina.Image = My.Resources.kohina_front
            End If
        End If
    End Sub

    Private Sub tmrTransition_Tick(sender As Object, e As EventArgs) Handles tmrTransition.Tick
        tickFade += 1
        If tickFade = 10 Then
            openForm.Show()
            tmrTransition.Stop()
            Me.Close()
            tickFade = 0
        End If
        Me.Opacity -= 0.1
    End Sub
End Class