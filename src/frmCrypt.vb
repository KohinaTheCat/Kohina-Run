Imports System.IO

Public Class frmCrypt
    Dim textReader As StreamReader
    Dim str() As String
    Dim questions(29, 3) As String
    Dim number(29) As Integer
    Dim floor, num, count, wrong As Integer
    Dim secondsGame As Integer = 0, secondsHint As Integer = 0
    Dim rand As New Random
    Dim answer As String

    Private Sub frmQuestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picNext.Visible = False
        lblHint.Visible = False
        btnHint.Visible = False

        textReader = File.OpenText("questions.txt")

        Do Until textReader.Peek = -1
            str = Split(textReader.ReadLine(), "* ")

            For i = 0 To 3
                questions(floor, i) = str(i)
            Next

            floor += 1
        Loop

        num = rand.Next(0, 30)
        lblQuestion.Text = questions(num, 1)
        answer = questions(num, 2)
        lblHint.Text = questions(num, 3)
        number(num) += 1
        count = 0

        textReader.Close()

        tmrGame.Start()
        tmrHint.Start()
    End Sub

    Private Sub picNext_Click(sender As Object, e As EventArgs) Handles picNext.Click
        lblHint.Visible = False
        btnHint.Visible = False

        If number.Contains(0) Then
            txtAnswer.Clear()
            txtAnswer.Enabled = True
            btnClear.Enabled = True
            btnCheck.Enabled = True

            Do
                num = rand.Next(0, 30)
            Loop Until number(num) = 0

            lblQuestion.Text = questions(num, 1)
            answer = questions(num, 2)
            lblHint.Text = questions(num, 3)
            number(num) += 1

            count += 1

            picNext.Visible = False

            secondsHint = 0
            tmrHint.Start()
        Else
            tmrGame.Stop()
            tmrHint.Stop()
            MessageBox.Show("You have completed all questions. Congratulations." &
                            vbNewLine & wrong & " incorrect attempt(s)" & vbNewLine &
                            "Time taken: " & secondsGame \ 60 & ":" & secondsGame Mod 60, "FINISH",
                            MessageBoxButtons.OK)
            gameWin = True
            btnExit.PerformClick()
        End If
    End Sub



    Private Sub btnHint_Click(sender As Object, e As EventArgs) Handles btnHint.Click
        lblHint.Visible = True
        btnHint.Visible = False
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim circle() As PictureBox = {pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10,
                                      pic11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20,
                                      pic21, pic22, pic23, pic24, pic25, pic26, pic27, pic28, pic29, pic30}

        If txtAnswer.Text = answer Then
            txtAnswer.Enabled = False
            btnClear.Enabled = False
            btnCheck.Enabled = False
            MessageBox.Show("CORRECT", "Congrats", MessageBoxButtons.OK)
            circle(count).Image = My.Resources.green_circle
            picNext.Visible = True
        ElseIf txtAnswer.Text = Nothing Then
            MessageBox.Show("Please enter an answer.", "U WOT", MessageBoxButtons.OK)
        Else
            MessageBox.Show("INCORRECT", "RIP", MessageBoxButtons.OK)
            txtAnswer.Clear()
            picNext.Visible = False
            wrong += 1

            If wrong = 5 Then
                MessageBox.Show("You have answered incorrectly 5 times. Please start over.", "SADNESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnExit.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAnswer.Clear()
        txtAnswer.Focus()
    End Sub
    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick
        secondsGame += 1
    End Sub

    Private Sub tmrHint_Tick(sender As Object, e As EventArgs) Handles tmrHint.Tick
        secondsHint += 1

        If secondsHint = 10 Then
            btnHint.Visible = True
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


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        tmrTransition.Start()

        If minigame = True Then
            minigame = False
            openForm = frmMinigames
        Else
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
            openForm = frmOutsideHouse
            frmOutsideHouse.picKohina.Image = My.Resources.kohina_back
            frmOutsideHouse.picKohina.Location = New Point(504, 208)
        End If

    End Sub

    Private Sub lblIntructions_Click(sender As Object, e As EventArgs) Handles lblIntructions.Click
        lblIntructions.Visible = False
    End Sub
End Class