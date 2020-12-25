Imports System.IO
Public Class frmHangman
    Private word, hint As String
    Private rand(36), location, guess, seconds, round, wordCount, wrong As Integer
    Private movement As Integer = 20

    Private Sub frmHangMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim outer, inner As Integer

        Randomize()
        For outer = 0 To 9
            rand(outer) = Int(Rnd() * 36) + 0

            For inner = 0 To outer
                If inner < outer Then
                    If rand(outer) = rand(inner) Then
                        outer = outer - 1
                        Exit For
                    End If
                End If
            Next inner
        Next outer

        round = 0
        NewGame()

    End Sub


    Private Sub btn(buttonClicked As String, button As Integer)
        Dim wordCount, letterCount, frequency As Integer
        Dim trimWord As String
        Dim btn() As Button = {btnA, btnB, btnC, btnD, btnE, btnF, btnG, btnH, btnI, btnJ, btnK, btnL, btnM, btnN, btnO, btnP, btnQ, btnR, btnS, btnT, btnU, btnV, btnW, btnX, btnY, btnZ}
        Dim lbl() As Label = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8}

        btn(button).Enabled = False

        If word.IndexOf(buttonClicked) >= 0 Then
            location = word.IndexOf(buttonClicked)

            If word.Length = 4 Then
                lbl(location + 2).Text = buttonClicked
            Else
                lbl(location).Text = buttonClicked
            End If

        ElseIf word.IndexOf(buttonClicked) = -1 Then
            guess += 1
            picKohinaWalking.Left -= movement
            If guess = 6 Then
                picKohinaWalking.Left -= movement
                lblWord.BackColor = Color.Red
                lblWord.Text = word
                tmrTick.Start()
                For i = 0 To 25
                    btn(i).Enabled = False
                Next
                picKohinaFalling4.Top += movement

                MessageBox.Show("You fell off the cliff", "Lose", MessageBoxButtons.OK)
                btnExit.PerformClick()
            End If
        End If

        frequency = word.Split(buttonClicked).Length - 1
        If frequency >= 2 Then
            Do
                location = word.IndexOf(buttonClicked)
                trimWord = word.Remove(0, location + 1)
                location += trimWord.IndexOf(buttonClicked)

                If word.Length = 4 Then
                    lbl(location + 1).Text = buttonClicked
                Else
                    lbl(location + 1).Text = buttonClicked
                End If
                letterCount += 1
            Loop Until frequency = letterCount
        End If

        If word.Length = 4 Then
            If word.Substring(0, 1) = lbl3.Text And word.Substring(1, 1) = lbl4.Text And word.Substring(2, 1) = lbl5.Text And word.Substring(3, 1) = lbl6.Text Then
                lblWord.Text = "You win"
                lblWord.BackColor = Color.LawnGreen
                Me.Refresh()
                System.Threading.Thread.Sleep(1000)
                NewGame()
            End If
        End If

        If word.Length = 8 Then
            If word.Substring(0, 1) = lbl1.Text And word.Substring(1, 1) = lbl2.Text And word.Substring(2, 1) = lbl3.Text And word.Substring(3, 1) = lbl4.Text And word.Substring(4, 1) = lbl5.Text And word.Substring(5, 1) = lbl6.Text And word.Substring(6, 1) = lbl7.Text And word.Substring(7, 1) = lbl8.Text Then
                lblWord.Text = "You win"
                lblWord.BackColor = Color.LawnGreen
                Me.Refresh()
                System.Threading.Thread.Sleep(1000)
                NewGame()
            End If
        End If

        wordCount += 1

    End Sub

    Private Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick
        seconds += 1

        picKohinaWalking.Visible = False
        If seconds = 2 Then
            picKohinaFalling1.Visible = True
            Me.Refresh()
            System.Threading.Thread.Sleep(200)
            picKohinaFalling1.Visible = False
            picKohinaFalling2.Visible = True
            Me.Refresh()
            System.Threading.Thread.Sleep(200)
            picKohinaFalling2.Visible = False
            picKohinaFalling3.Visible = True
            Me.Refresh()
            System.Threading.Thread.Sleep(200)
            picKohinaFalling3.Visible = False
            picKohinaFalling4.Visible = True
            For i = 0 To 5
                Me.Refresh()
                System.Threading.Thread.Sleep(100)
                picKohinaFalling4.Top += 40
            Next
            picKohinaFalling4.Visible = False
            System.Threading.Thread.Sleep(1000)
            NewGame()
        End If

    End Sub

    Private Sub NewGame()
        Dim wordFile As StreamReader
        Dim line As Integer
        Dim str(), result As String
        Dim lbl() As Label = {lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8}
        Dim btn() As Button = {btnA, btnB, btnC, btnD, btnE, btnF, btnG, btnH, btnI, btnJ, btnK, btnL, btnM, btnN, btnO, btnP, btnQ, btnR, btnS, btnT, btnU, btnV, btnW, btnX, btnY, btnZ}

        round += 1
        picKohinaWalking.Visible = True
        picKohinaWalking.Location = New Point(734, 92)
        picKohinaFalling4.Location = New Point(533, 184)
        If wrong = 4 Then
            result = MessageBox.Show("You have to play again", "Gavme over!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnExit.PerformClick()
        End If
        If wrong <> 4 Then
            If round = 5 Then
                MessageBox.Show("Wow! You didn't die!", "WIN", MessageBoxButtons.OK)
                gameWin = True
                btnExit.PerformClick()
            End If
        End If
        lblRound.Text = "Round: " & round
        seconds = 0
        tmrTick.Stop()
        hint = ""
        guess = 0
        location = 0
        lblWord.Text = ""
        lblWord.BackColor = Color.Transparent

        If File.Exists("words.txt") Then
            wordFile = File.OpenText("words.txt")
            Do Until wordFile.Peek = -1
                str = Split(wordFile.ReadLine(), " ")
                line += 1
                If rand(wordCount) = line Then
                    word = str(0).ToUpper
                    hint = str(1)
                    lblHint.Text = "Hint: " & hint
                    Select Case word.Length
                        Case 4
                            lbl1.Visible = False
                            lbl2.Visible = False
                            lbl7.Visible = False
                            lbl8.Visible = False
                        Case 8
                            For i = 0 To 7
                                lbl(i).Visible = True
                            Next
                    End Select
                End If
            Loop

            wordFile.Close()
        End If

        wordCount += 1

        For i = 0 To 7
            lbl(i).Text = "__"
        Next

        For i = 0 To 25
            btn(i).Enabled = True
        Next

    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        btn("Z", 25)
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        btn("Y", 24)
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        btn("X", 23)
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        btn("W", 22)
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        btn("V", 21)
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        btn("U", 20)
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        btn("T", 19)
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        btn("S", 18)
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        btn("R", 17)
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        btn("Q", 16)
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        btn("P", 15)
    End Sub

    Private Sub btnO_Clik(sender As Object, e As EventArgs) Handles btnO.Click
        btn("O", 14)
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        btn("N", 13)
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        btn("M", 12)
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        btn("L", 11)
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        btn("K", 10)
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        btn("J", 9)
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        btn("I", 8)
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        btn("H", 7)
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        btn("G", 6)
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        btn("F", 5)
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        btn("E", 4)
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        btn("D", 3)
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        btn("C", 2)
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        btn("B", 1)
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        btn("A", 0)
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        tmrTransition.Start()

        If minigame = True Then
            gameWin = False
            minigame = False 'MAKE IT DO IT IN OTHER FORM
            openForm = frmMinigames
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.BST8bit, AudioPlayMode.BackgroundLoop)
        Else
            openForm = frmBedroom
            frmBedroom.picKohina.Location = New Point(133, 137)
            frmBedroom.picKohina.Image = My.Resources.kohina_back
            'add location
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
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