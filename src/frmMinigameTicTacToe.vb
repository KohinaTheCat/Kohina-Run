Public Class frmMinigameTicTacToe

    Private player, comp As Image
    Dim seconds As Integer
    Dim rand As New Random
    Dim num As Integer
    Dim round As Integer = 1
    Dim win As Integer = 0

    Private Sub pic1_Click(sender As Object, e As EventArgs) Handles pic1.Click
            Dim box() As PictureBox = {pic2, pic5, pic6}

            pic1.Image = player
            pic1.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic2.Enabled = True Or pic5.Enabled = True Or pic6.Enabled = True Then
                    Do
                        num = rand.Next(0, 3)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub



    Private Sub pic2_Click(sender As Object, e As EventArgs) Handles pic2.Click
            Dim box() As PictureBox = {pic1, pic3, pic5, pic6, pic7}

            pic2.Image = player
            pic2.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic1.Enabled = True Or pic3.Enabled = True Or pic5.Enabled = True Or pic6.Enabled = True Or
           pic7.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic3_Click(sender As Object, e As EventArgs) Handles pic3.Click
            Dim box() As PictureBox = {pic2, pic4, pic6, pic7, pic8}

            pic3.Image = player
            pic3.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic2.Enabled = True Or pic4.Enabled = True Or pic6.Enabled = True Or pic7.Enabled = True Or
           pic8.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic4_Click(sender As Object, e As EventArgs) Handles pic4.Click
            Dim box() As PictureBox = {pic3, pic7, pic8}

            pic4.Image = player
            pic4.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic3.Enabled = True Or pic7.Enabled = True Or pic8.Enabled = True Then
                    Do
                        num = rand.Next(0, 3)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic5_Click(sender As Object, e As EventArgs) Handles pic5.Click
            Dim box() As PictureBox = {pic1, pic2, pic5, pic9, pic10}

            pic5.Image = player
            pic5.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic1.Enabled = True Or pic2.Enabled = True Or pic5.Enabled = True Or pic9.Enabled = True Or
           pic10.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic6_Click(sender As Object, e As EventArgs) Handles pic6.Click
            Dim box() As PictureBox = {pic1, pic2, pic3, pic5, pic7, pic9, pic10, pic11}

            pic6.Image = player
            pic6.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic1.Enabled = True Or pic2.Enabled = True Or pic3.Enabled = True Or pic5.Enabled = True Or
           pic7.Enabled = True Or pic9.Enabled = True Or pic10.Enabled = True Or pic11.Enabled = True Then
                    Do
                        num = rand.Next(0, 8)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic7_Click(sender As Object, e As EventArgs) Handles pic7.Click
            Dim box() As PictureBox = {pic2, pic3, pic4, pic6, pic8, pic10, pic11, pic12}

            pic7.Image = player
            pic7.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic2.Enabled = True Or pic3.Enabled = True Or pic4.Enabled = True Or pic6.Enabled = True Or
           pic8.Enabled = True Or pic10.Enabled = True Or pic11.Enabled = True Or pic12.Enabled = True Then
                    Do
                        num = rand.Next(0, 8)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic8_Click(sender As Object, e As EventArgs) Handles pic8.Click
            Dim box() As PictureBox = {pic3, pic4, pic7, pic11, pic12}

            pic8.Image = player
            pic8.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic3.Enabled = True Or pic4.Enabled = True Or pic7.Enabled = True Or pic11.Enabled = True Or
           pic12.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic9_Click(sender As Object, e As EventArgs) Handles pic9.Click
            Dim box() As PictureBox = {pic5, pic6, pic10, pic13, pic14}

            pic9.Image = player
            pic9.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic5.Enabled = True Or pic6.Enabled = True Or pic10.Enabled = True Or pic13.Enabled = True Or
           pic14.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic10_Click(sender As Object, e As EventArgs) Handles pic10.Click
            Dim box() As PictureBox = {pic5, pic6, pic7, pic9, pic11, pic13, pic14, pic15}

            pic10.Image = player
            pic10.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic5.Enabled = True Or pic6.Enabled = True Or pic7.Enabled = True Or pic9.Enabled = True Or
           pic10.Enabled = True Or pic13.Enabled = True Or pic14.Enabled = True Or pic15.Enabled = True Then
                    Do
                        num = rand.Next(0, 8)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic11_Click(sender As Object, e As EventArgs) Handles pic11.Click
            Dim box() As PictureBox = {pic6, pic7, pic8, pic10, pic12, pic14, pic15, pic16}

            pic11.Image = player
            pic11.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic6.Enabled = True Or pic7.Enabled = True Or pic8.Enabled = True Or pic10.Enabled = True Or
           pic12.Enabled = True Or pic14.Enabled = True Or pic15.Enabled = True Or pic16.Enabled = True Then
                    Do
                        num = rand.Next(0, 8)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic12_Click(sender As Object, e As EventArgs) Handles pic12.Click
            Dim box() As PictureBox = {pic7, pic8, pic11, pic15, pic16}

            pic12.Image = player
            pic12.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic7.Enabled = True Or pic8.Enabled = True Or pic11.Enabled = True Or pic15.Enabled = True Or
           pic16.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic13_Click(sender As Object, e As EventArgs) Handles pic13.Click
            Dim box() As PictureBox = {pic9, pic10, pic14}

            pic13.Image = player
            pic13.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic9.Enabled = True Or pic10.Enabled = True Or pic14.Enabled = True Then
                    Do
                        num = rand.Next(0, 3)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic14_Click(sender As Object, e As EventArgs) Handles pic14.Click
            Dim box() As PictureBox = {pic9, pic10, pic11, pic13, pic15}

            pic14.Image = player
            pic14.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic9.Enabled = True Or pic10.Enabled = True Or pic11.Enabled = True Or pic13.Enabled = True Or
           pic15.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

        Private Sub pic15_Click(sender As Object, e As EventArgs) Handles pic15.Click
            Dim box() As PictureBox = {pic10, pic11, pic12, pic14, pic16}

            pic15.Image = player
            pic15.Enabled = False
            Check()
            Threading.Thread.Sleep(500)

            If Intercept() = False Then
                If pic10.Enabled = True Or pic11.Enabled = True Or pic12.Enabled = True Or pic14.Enabled = True Or
           pic16.Enabled = True Then
                    Do
                        num = rand.Next(0, 5)
                    Loop While box(num).Enabled = False

                    box(num).Image = comp
                    box(num).Enabled = False
                    Check()
                Else
                    CompMove()
                    Check()
                End If
            End If
        End Sub

    Private Sub pic16_Click(sender As Object, e As EventArgs) Handles pic16.Click
        Dim box() As PictureBox = {pic11, pic12, pic15}

        pic16.Image = player
        pic16.Enabled = False
        Check()
        Threading.Thread.Sleep(500)

        If Intercept() = False Then
            If pic11.Enabled = True Or pic12.Enabled = True Or pic15.Enabled = True Then
                Do
                    num = rand.Next(0, 3)
                Loop While box(num).Enabled = False

                box(num).Image = comp
                box(num).Enabled = False
                Check()
            Else
                CompMove()
                Check()
            End If
        End If
    End Sub

    'Selects a random spot for the computer to claim
    Private Sub CompMove()
            Dim box() As PictureBox = {pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16}

            Do
                num = rand.Next(0, 16)
            Loop While box(num).Enabled = False

            box(num).Image = comp
            box(num).Enabled = False
        End Sub

        'Computer moves to take the last spot in a row or column to prevent the user from winning
        Private Function Intercept()
            'horizontal
            If pic1.Image.Equals(player) And pic2.Image.Equals(player) And pic3.Image.Equals(player) Then
                If pic4.Enabled = True Then
                    pic4.Image = comp
                    pic4.Enabled = False
                    Return True
                End If
            ElseIf pic2.Image.Equals(player) And pic3.Image.Equals(player) And pic4.Image.Equals(player) Then
                If pic1.Enabled = True Then
                    pic1.Image = comp
                    pic1.Enabled = False
                    Return True
                End If

            ElseIf pic5.Image.Equals(player) And pic6.Image.Equals(player) And pic7.Image.Equals(player) Then
                If pic8.Enabled = True Then
                    pic8.Image = comp
                    pic8.Enabled = False
                    Return True
                End If
            ElseIf pic6.Image.Equals(player) And pic7.Image.Equals(player) And pic8.Image.Equals(player) Then
                If pic5.Enabled = True Then
                    pic5.Image = comp
                    pic5.Enabled = False
                    Return True
                End If

            ElseIf pic9.Image.Equals(player) And pic10.Image.Equals(player) And pic11.Image.Equals(player) Then
                If pic12.Enabled = True Then
                    pic12.Image = comp
                    pic12.Enabled = False
                    Return True
                End If
            ElseIf pic10.Image.Equals(player) And pic11.Image.Equals(player) And pic12.Image.Equals(player) Then
                If pic9.Enabled = True Then
                    pic9.Image = comp
                    pic9.Enabled = False
                    Return True
                End If

            ElseIf pic13.Image.Equals(player) And pic14.Image.Equals(player) And pic15.Image.Equals(player) Then
                If pic16.Enabled = True Then
                    pic16.Image = comp
                    pic16.Enabled = False
                    Return True
                End If
            ElseIf pic14.Image.Equals(player) And pic15.Image.Equals(player) And pic16.Image.Equals(player) Then
                If pic13.Enabled = True Then
                    pic13.Image = comp
                    pic13.Enabled = False
                    Return True
                End If

                'vertical
            ElseIf pic1.Image.Equals(player) And pic5.Image.Equals(player) And pic9.Image.Equals(player) Then
                If pic13.Enabled = True Then
                    pic13.Image = comp
                    pic13.Enabled = False
                    Return True
                End If
            ElseIf pic5.Image.Equals(player) And pic9.Image.Equals(player) And pic13.Image.Equals(player) Then
                If pic1.Enabled = True Then
                    pic1.Image = comp
                    pic1.Enabled = False
                    Return True
                End If

            ElseIf pic2.Image.Equals(player) And pic6.Image.Equals(player) And pic10.Image.Equals(player) Then
                If pic14.Enabled = True Then
                    pic14.Image = comp
                    pic14.Enabled = False
                    Return True
                End If
            ElseIf pic6.Image.Equals(player) And pic10.Image.Equals(player) And pic14.Image.Equals(player) Then
                If pic2.Enabled = True Then
                    pic2.Image = comp
                    pic2.Enabled = False
                    Return True
                End If

            ElseIf pic3.Image.Equals(player) And pic7.Image.Equals(player) And pic11.Image.Equals(player) Then
                If pic15.Enabled = True Then
                    pic15.Image = comp
                    pic15.Enabled = False
                    Return True
                End If
            ElseIf pic7.Image.Equals(player) And pic11.Image.Equals(player) And pic15.Image.Equals(player) Then
                If pic3.Enabled = True Then
                    pic3.Image = comp
                    pic3.Enabled = False
                    Return True
                End If

            ElseIf pic4.Image.Equals(player) And pic8.Image.Equals(player) And pic12.Image.Equals(player) Then
                If pic16.Enabled = True Then
                    pic16.Image = comp
                    pic16.Enabled = False
                    Return True
                End If
            ElseIf pic8.Image.Equals(player) And pic12.Image.Equals(player) And pic16.Image.Equals(player) Then
                If pic4.Enabled = True Then
                    pic4.Image = comp
                    pic4.Enabled = False
                    Return True
                End If

                'diagnal
            ElseIf pic1.Image.Equals(player) And pic6.Image.Equals(player) And pic11.Image.Equals(player) Then
                If pic16.Enabled = True Then
                    pic16.Image = comp
                    pic16.Enabled = False
                    Return True
                End If
            ElseIf pic6.Image.Equals(player) And pic11.Image.Equals(player) And pic16.Image.Equals(player) Then
                If pic1.Enabled = True Then
                    pic1.Image = comp
                    pic1.Enabled = False
                    Return True
                End If

            ElseIf pic4.Image.Equals(player) And pic7.Image.Equals(player) And pic10.Image.Equals(player) Then
                If pic13.Enabled = True Then
                    pic13.Image = comp
                    pic13.Enabled = False
                    Return True
                End If
            ElseIf pic7.Image.Equals(player) And pic10.Image.Equals(player) And pic13.Image.Equals(player) Then
                If pic4.Enabled = True Then
                    pic4.Image = comp
                    pic4.Enabled = False
                    Return True
                End If
            End If

            Return False
        End Function

        'Checks if the user or the computer has won the match
        Private Sub Check()

            If pic1.Image.Equals(player) And pic2.Image.Equals(player) And pic3.Image.Equals(player) And pic4.Image.Equals(player) Or
            pic5.Image.Equals(player) And pic6.Image.Equals(player) And pic7.Image.Equals(player) And pic8.Image.Equals(player) Or
            pic9.Image.Equals(player) And pic10.Image.Equals(player) And pic11.Image.Equals(player) And pic12.Image.Equals(player) Or
            pic13.Image.Equals(player) And pic14.Image.Equals(player) And pic15.Image.Equals(player) And pic16.Image.Equals(player) Or
            pic1.Image.Equals(player) And pic5.Image.Equals(player) And pic9.Image.Equals(player) And pic13.Image.Equals(player) Or
            pic2.Image.Equals(player) And pic6.Image.Equals(player) And pic10.Image.Equals(player) And pic14.Image.Equals(player) Or
            pic3.Image.Equals(player) And pic7.Image.Equals(player) And pic11.Image.Equals(player) And pic15.Image.Equals(player) Or
            pic4.Image.Equals(player) And pic8.Image.Equals(player) And pic12.Image.Equals(player) And pic16.Image.Equals(player) Or
            pic1.Image.Equals(player) And pic6.Image.Equals(player) And pic11.Image.Equals(player) And pic16.Image.Equals(player) Or
            pic4.Image.Equals(player) And pic7.Image.Equals(player) And pic10.Image.Equals(player) And pic13.Image.Equals(player) Then
                MessageBox.Show("You win!", "WINNER", MessageBoxButtons.OK)
                win += 1
                CheckRound()
            ElseIf pic1.Image.Equals(comp) And pic2.Image.Equals(comp) And pic3.Image.Equals(comp) And pic4.Image.Equals(comp) Or
            pic5.Image.Equals(comp) And pic6.Image.Equals(comp) And pic7.Image.Equals(comp) And pic8.Image.Equals(comp) Or
            pic9.Image.Equals(comp) And pic10.Image.Equals(comp) And pic11.Image.Equals(comp) And pic12.Image.Equals(comp) Or
            pic13.Image.Equals(comp) And pic14.Image.Equals(comp) And pic15.Image.Equals(comp) And pic16.Image.Equals(comp) Or
            pic1.Image.Equals(comp) And pic5.Image.Equals(comp) And pic9.Image.Equals(comp) And pic13.Image.Equals(comp) Or
            pic2.Image.Equals(comp) And pic6.Image.Equals(comp) And pic10.Image.Equals(comp) And pic14.Image.Equals(comp) Or
            pic3.Image.Equals(comp) And pic7.Image.Equals(comp) And pic11.Image.Equals(comp) And pic15.Image.Equals(comp) Or
            pic4.Image.Equals(comp) And pic8.Image.Equals(comp) And pic12.Image.Equals(comp) And pic16.Image.Equals(comp) Or
            pic1.Image.Equals(comp) And pic6.Image.Equals(comp) And pic11.Image.Equals(comp) And pic16.Image.Equals(comp) Or
            pic4.Image.Equals(comp) And pic7.Image.Equals(comp) And pic10.Image.Equals(comp) And pic13.Image.Equals(comp) Then
                MessageBox.Show("You lose!", "WOMP WOMP", MessageBoxButtons.OK)
                CheckRound()
            ElseIf pic1.Enabled = False And pic2.Enabled = False And pic3.Enabled = False And pic4.Enabled = False And
            pic5.Enabled = False And pic6.Enabled = False And pic7.Enabled = False And pic8.Enabled = False And
            pic9.Enabled = False And pic10.Enabled = False And pic11.Enabled = False And pic12.Enabled = False And
            pic13.Enabled = False And pic14.Enabled = False And pic15.Enabled = False And pic16.Enabled = False Then
                MessageBox.Show("It's a draw!", ". . .", MessageBoxButtons.OK)
                CheckRound()
            End If
        End Sub

        'Checks if game is over, starts new round and displays appropriate message box
        Private Sub CheckRound()



        '    If round >= 3 And win >= 2 Then
        '    MessageBox.Show("Wins: " & win & vbNewLine & vbNewLine & "You won " & win & " out of 3 times!", "...", MessageBoxButtons.OK)

        '    frmRightTown.Show()
        '    Me.Hide()
        '    frmRightTown.picKohina.Location = New Point(512, 156)
        '    frmRightTown.picKohina.Image = My.Resources.kohina_back
        '    frmRightTown.lblDescription.Visible = True
        '    frmRightTown.lblSignal.Visible = True
        '    frmRightTown.picJarrot.Visible = True
        '    gameWin = True
        'ElseIf round >= 3 And win <= 1 Then
        '    MessageBox.Show("Wins: " & win & vbNewLine & vbNewLine & "You only won " & win & " out of 3 times.", "YOU PEASENT", MessageBoxButtons.OK)
        '    frmRightTown.Show()
        '    Me.Hide()
        '    frmRightTown.picKohina.Location = New Point(512, 156)
        '    frmRightTown.picKohina.Image = My.Resources.kohina_back
        '    frmRightTown.lblDescription.Visible = True
        '    frmRightTown.lblDescription.Text = "I REMAIN ALMIGHTY"
        '    frmRightTown.lblSignal.Visible = True
        '    frmRightTown.picJarrot.Visible = True
        '    'Me.Hide()
        '    ' btnExit.PerformClick()
        'End If



        'If round < 3 Then
        '    MessageBox.Show("Round " & round & " start!", "Round " & round, MessageBoxButtons.OK)
        '    pic1.Image = My.Resources.soil
        '    pic2.Image = My.Resources.soil
        '    pic3.Image = My.Resources.soil
        '    pic4.Image = My.Resources.soil
        '    pic5.Image = My.Resources.soil
        '    pic6.Image = My.Resources.soil
        '    pic7.Image = My.Resources.soil
        '    pic8.Image = My.Resources.soil
        '    pic9.Image = My.Resources.soil
        '    pic10.Image = My.Resources.soil
        '    pic11.Image = My.Resources.soil
        '    pic12.Image = My.Resources.soil
        '    pic13.Image = My.Resources.soil
        '    pic14.Image = My.Resources.soil
        '    pic15.Image = My.Resources.soil
        '    pic16.Image = My.Resources.soil
        '    pic1.Enabled = True
        '    pic2.Enabled = True
        '    pic3.Enabled = True
        '    pic4.Enabled = True
        '    pic5.Enabled = True
        '    pic6.Enabled = True
        '    pic7.Enabled = True
        '    pic8.Enabled = True
        '    pic9.Enabled = True
        '    pic10.Enabled = True
        '    pic11.Enabled = True
        '    pic12.Enabled = True
        '    pic13.Enabled = True
        '    pic14.Enabled = True
        '    pic15.Enabled = True
        '    pic16.Enabled = True
        'End If

        If round = 3 Then
            btnExit.Enabled = True
            pic1.Enabled = False
            pic2.Enabled = False
            pic3.Enabled = False
            pic4.Enabled = False
            pic5.Enabled = False
            pic6.Enabled = False
            pic7.Enabled = False
            pic8.Enabled = False
            pic9.Enabled = False
            pic10.Enabled = False
            pic11.Enabled = False
            pic12.Enabled = False
            pic13.Enabled = False
            pic14.Enabled = False
            pic15.Enabled = False
            pic16.Enabled = False

            If win >= 2 Then
                MessageBox.Show("Wins: " & win & vbNewLine & vbNewLine & "You won " & win & " out of 3 times!", "...", MessageBoxButtons.OK)

                'frmRightTown.Show()
                'Me.Hide()
                'frmRightTown.picKohina.Location = New Point(512, 156)
                'frmRightTown.picKohina.Image = My.Resources.kohina_back
                'frmRightTown.lblDescription.Visible = True
                'frmRightTown.lblSignal.Visible = True
                'frmRightTown.picJarrot.Visible = True
                gameWin = True
                btnExit.PerformClick()

            ElseIf win <= 1 Then
                MessageBox.Show("Wins: " & win & vbNewLine & vbNewLine & "You only won " & win & " out of 3 times.", "YOU PEASENT", MessageBoxButtons.OK)
                'frmRightTown.Show()
                'Me.Hide()
                'frmRightTown.picKohina.Location = New Point(512, 156)
                'frmRightTown.picKohina.Image = My.Resources.kohina_back
                'frmRightTown.lblDescription.Visible = True
                'frmRightTown.lblDescription.Text = "I REMAIN ALMIGHTY"
                'frmRightTown.lblSignal.Visible = True
                'frmRightTown.picJarrot.Visible = True
                btnExit.PerformClick()
            End If
        End If

        'round += 1

        If round < 3 Then
            round += 1
            MessageBox.Show("Round " & round & " start!", "Round " & round, MessageBoxButtons.OK)
            pic1.Image = My.Resources.soil
            pic2.Image = My.Resources.soil
            pic3.Image = My.Resources.soil
            pic4.Image = My.Resources.soil
            pic5.Image = My.Resources.soil
            pic6.Image = My.Resources.soil
            pic7.Image = My.Resources.soil
            pic8.Image = My.Resources.soil
            pic9.Image = My.Resources.soil
            pic10.Image = My.Resources.soil
            pic11.Image = My.Resources.soil
            pic12.Image = My.Resources.soil
            pic13.Image = My.Resources.soil
            pic14.Image = My.Resources.soil
            pic15.Image = My.Resources.soil
            pic16.Image = My.Resources.soil
            pic1.Enabled = True
            pic2.Enabled = True
            pic3.Enabled = True
            pic4.Enabled = True
            pic5.Enabled = True
            pic6.Enabled = True
            pic7.Enabled = True
            pic8.Enabled = True
            pic9.Enabled = True
            pic10.Enabled = True
            pic11.Enabled = True
            pic12.Enabled = True
            pic13.Enabled = True
            pic14.Enabled = True
            pic15.Enabled = True
            pic16.Enabled = True
        End If
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            ' Turn on WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click


        pic1.Enabled = True
        pic2.Enabled = True
        pic3.Enabled = True
        pic4.Enabled = True
        pic5.Enabled = True
        pic6.Enabled = True
        pic7.Enabled = True
        pic8.Enabled = True
        pic9.Enabled = True
        pic10.Enabled = True
        pic11.Enabled = True
        pic12.Enabled = True
        pic13.Enabled = True
        pic14.Enabled = True
        pic15.Enabled = True
        pic16.Enabled = True

        'Application.Restart()

        If minigame = True Then
            minigame = False
            Me.Refresh()
            'Threading.Thread.Sleep(500)
            'Me.Refresh()
            frmMinigames.Show()
            frmMinigames.Refresh()
            'Threading.Thread.Sleep(2000)
            'Me.Refresh()
            Me.Close()
            'Threading.Thread.Sleep(1000)
            'Me.Refresh()
        Else

            frmRightTown.Show()

            frmRightTown.picKohina.Location = New Point(512, 156)
            frmRightTown.picKohina.Image = My.Resources.kohina_back
            Me.Refresh()
            frmRightTown.lblDescription.Text = "FEAR ME YOU PEASANT"
            frmRightTown.lblSignal.Visible = True
            frmRightTown.lblDescription.Visible = True

            frmRightTown.picJarrot.Visible = True
            Me.Close()

            'Me.Refresh()
            'If round < 3 Then
            '    frmRightTown.lblDescription.Text = "RUN AWAY LITTLE GIRL YOU ARE NO MATCH FOR ME"
            'ElseIf round = 3 And win <= 1 Then
            '    frmRightTown.lblDescription.Text = "I REMAIN ALMIGHTY"
            'ElseIf round = 3 And win >= 3 Then
            '    gameWin = True
            'End If

            ' frmMinigames.Show()
        End If


    End Sub

    Private Sub frmMinigameTicTacToe_Load(sender As Object, e As EventArgs) Handles Me.Load
        'you make me cry jessica
        Dim result As DialogResult
        Dim picture() As PictureBox = {pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16}

        result = MessageBox.Show("Orange (Yes) or purple (No)?", "Tic Tac Toe", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            player = My.Resources.orange_carrot
            comp = My.Resources.purple_carrot
        ElseIf result = DialogResult.No Then
            player = My.Resources.purple_carrot
            comp = My.Resources.orange_carrot
        End If

        MessageBox.Show("Make the first move...", "Round 1", MessageBoxButtons.OK)


        pic1.Enabled = True
        pic2.Enabled = True
        pic3.Enabled = True
        pic4.Enabled = True
        pic5.Enabled = True
        pic6.Enabled = True
        pic7.Enabled = True
        pic8.Enabled = True
        pic9.Enabled = True
        pic10.Enabled = True
        pic11.Enabled = True
        pic12.Enabled = True
        pic13.Enabled = True
        pic14.Enabled = True
        pic15.Enabled = True
        pic16.Enabled = True



        'Private Sub frmMinigameTicTacToe_Load(sender As Object, e As EventArgs) Handles Me.Load
        '    'you make me cry jessica
        '    Dim result As DialogResult
        '    Dim picture() As PictureBox = {pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16}

        '    result = MessageBox.Show("Orange (Yes) or purple (No)?", "Tic Tac Toe", MessageBoxButtons.YesNo)

        '    If result = DialogResult.Yes Then
        '        player = My.Resources.orange_carrot
        '        comp = My.Resources.purple_carrot
        '    ElseIf result = DialogResult.No Then
        '        player = My.Resources.purple_carrot
        '        comp = My.Resources.orange_carrot
        '    End If

        '    MessageBox.Show("Make the first move...", "Round 1", MessageBoxButtons.OK)


        '    pic1.Enabled = True
        '    pic2.Enabled = True
        '    pic3.Enabled = True
        '    pic4.Enabled = True
        '    pic5.Enabled = True
        '    pic6.Enabled = True
        '    pic7.Enabled = True
        '    pic8.Enabled = True
        '    pic9.Enabled = True
        '    pic10.Enabled = True
        '    pic11.Enabled = True
        '    pic12.Enabled = True
        '    pic13.Enabled = True
        '    pic14.Enabled = True
        '    pic15.Enabled = True
        '    pic16.Enabled = True
        'End Sub

        'Private Sub frmMinigameTicTacToe_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub frmMinigameTicTacToe_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub
End Class