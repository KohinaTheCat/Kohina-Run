Public Class frmMatching
    Private randBtn(11), randBtn1(11), randPic(11), num, randPic1(11), seconds, count, picClicked(1), pic1, pic2, button1, button2, totalCount, correct As Integer
    Dim win As Boolean
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        count += 1
        GeneratePic(0, True, False)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        count += 1
        GeneratePic(1, True, False)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        count += 1
        GeneratePic(2, True, False)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        count += 1
        GeneratePic(3, True, False)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        count += 1
        GeneratePic(4, True, False)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        count += 1
        GeneratePic(5, True, False)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        count += 1
        GeneratePic(6, True, False)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        count += 1
        GeneratePic(7, True, False)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        count += 1
        GeneratePic(8, True, False)
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        count += 1
        GeneratePic(9, True, False)
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        count += 1
        GeneratePic(10, True, False)
    End Sub

    Private Sub btn12_Click(sender As Object, e As EventArgs) Handles btn12.Click
        count += 1
        GeneratePic(11, True, False)
    End Sub

    Private Sub btn13_Click(sender As Object, e As EventArgs) Handles btn13.Click
        count += 1
        GeneratePic(0, False, True)
    End Sub

    Private Sub btn14_Click(sender As Object, e As EventArgs) Handles btn14.Click
        count += 1
        GeneratePic(1, False, True)
    End Sub


    Private Sub btn15_Click(sender As Object, e As EventArgs) Handles btn15.Click
        count += 1
        GeneratePic(2, False, True)
    End Sub

    Private Sub btn16_Click(sender As Object, e As EventArgs) Handles btn16.Click
        count += 1
        GeneratePic(3, False, True)
    End Sub

    Private Sub btn17_Click(sender As Object, e As EventArgs) Handles btn17.Click
        count += 1
        GeneratePic(4, False, True)
    End Sub

    Private Sub btn18_Click(sender As Object, e As EventArgs) Handles btn18.Click
        count += 1
        GeneratePic(5, False, True)
    End Sub

    Private Sub btn19_Click(sender As Object, e As EventArgs) Handles btn19.Click
        count += 1
        GeneratePic(6, False, True)
    End Sub

    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        count += 1
        GeneratePic(7, False, True)
    End Sub

    Private Sub btn21_Click(sender As Object, e As EventArgs) Handles btn21.Click
        count += 1
        GeneratePic(8, False, True)
    End Sub

    Private Sub btn22_Click(sender As Object, e As EventArgs) Handles btn22.Click
        count += 1
        GeneratePic(9, False, True)
    End Sub

    Private Sub btn23_Click(sender As Object, e As EventArgs) Handles btn23.Click
        count += 1
        GeneratePic(10, False, True)
    End Sub

    Private Sub btn24_Click(sender As Object, e As EventArgs) Handles btn24.Click
        count += 1
        GeneratePic(11, False, True)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim inner, outer As Integer
        Dim btn1To12() As Button = {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12}
        Dim btn13To24() As Button = {btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24}
        Dim pic() As Bitmap = {My.Resources.pic1, My.Resources.pic2, My.Resources.pic3, My.Resources.pic4, My.Resources.pic5, My.Resources.pic6,
        My.Resources.pic7, My.Resources.pic8, My.Resources.pic9, My.Resources.pic10, My.Resources.pic11, My.Resources.pic12}


        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        End If


        Randomize()

        For outer = 0 To 11
            randPic(outer) = Int(Rnd() * 12) + 0
            For inner = 0 To outer
                If inner < outer Then
                    If randPic(outer) = randPic(inner) Then
                        outer = outer - 1
                        Exit For
                    End If
                End If
            Next inner
        Next outer

        For outer = 0 To 11
            randPic1(outer) = Int(Rnd() * 12) + 0
            For inner = 0 To outer
                If inner < outer Then
                    If randPic1(outer) = randPic1(inner) Then
                        outer = outer - 1
                        Exit For
                    End If
                End If
            Next inner
        Next outer

        count = 0
    End Sub

    Private Sub GeneratePic(num As Integer, btn1To12Clicked As Boolean, btn13To24Clicked As Boolean)

        Dim btn1To12() As Button = {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12}
        Dim btn13To24() As Button = {btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24}
        Dim pic() As Bitmap = {My.Resources.pic1, My.Resources.pic2, My.Resources.pic3, My.Resources.pic4, My.Resources.pic5, My.Resources.pic6,
        My.Resources.pic7, My.Resources.pic8, My.Resources.pic9, My.Resources.pic10, My.Resources.pic11, My.Resources.pic12}
        Dim btn() As Button = {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24}

        If btn1To12Clicked = True And btn13To24Clicked = False Then
            btn1To12(num).BackgroundImage = pic(randPic(num))
            tmrTick.Start()
        End If

        If btn13To24Clicked = True And btn1To12Clicked = False Then
            btn13To24(num).BackgroundImage = pic(randPic1(num))
            tmrTick.Start()
        End If

        If count = 1 Then
            If btn1To12Clicked = True Then
                picClicked(0) = randPic(num)
                pic1 = randPic(num)
                button1 = num
                btn(button1).Enabled = False
            ElseIf btn13To24Clicked = True Then
                picClicked(0) = randPic1(num)
                pic1 = randPic1(num)
                button1 = num + 12
                btn(button1).Enabled = False
            End If

        ElseIf count = 2 Then

            If btn1To12Clicked = True Then
                picClicked(1) = randPic(num)
                pic2 = randPic(num)
                button2 = num
                btn(button2).Enabled = False
            ElseIf btn13To24Clicked = True Then
                picClicked(1) = randPic1(num)
                pic2 = randPic1(num)
                button2 = num + 12
                btn(button2).Enabled = False
            End If
        End If

        If count = 2 Then
            If pic1 = pic2 Then
                MessageBox.Show("Correct")
                btn(button1).Enabled = False
                btn(button2).Enabled = False
                correct += 1
            Else
                Me.Refresh()
                System.Threading.Thread.Sleep(1000)
                totalCount += 1
                btn(button1).Enabled = True
                btn(button2).Enabled = True
                btn(button1).BackgroundImage = My.Resources.Pokeball
                btn(button2).BackgroundImage = My.Resources.Pokeball
            End If
            count = 0
        End If
        If correct = 12 Then
            MessageBox.Show("You have won")
            tmrTick.Stop()
            gameWin = True
            btnExit.PerformClick()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        tmrTransition.Start()

        If minigame = True Then

            minigame = False
            openForm = frmMinigames
        ElseIf win = True Then ' do i need win
            gameWin = True
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
            openForm = frmGarden
            frmGarden.picKohina.Location = New Point(197, 128)
        Else
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
            openForm = frmGarden
            frmGarden.picKohina.Location = New Point(197, 128)
        End If
    End Sub


    Private Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick
        seconds += 1
        lblSeconds.Text = seconds
        lblNumTries.Text = totalCount
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