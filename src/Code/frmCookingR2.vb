Public Class frmCookingR2
    Dim fail, win As Boolean
    Dim rand As New Random
    Dim fire, fireSlider, seconds As Integer

    Private Sub frmCookingR2_Load(sender As Object, e As EventArgs) Handles Me.Load

        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        End If

        fail = True
        lblMessage.Text = "The instructions tell me what times I must put the lid on the change the temperture of the heat. Click on the lid to put or remove the lid. Slide the slider to adjust the temperature." &
                           vbNewLine & "Click to continue"
    End Sub

    Private Sub tmrTimeLeft_Tick(sender As Object, e As EventArgs) Handles tmrTimeLeft.Tick
        seconds += 1

        If seconds >= 60 Then
            win = True
            lblMessage.Visible = True
            tmrHeatChange.Stop()
            tmrTimeLeft.Stop()
            tmrLidChange.Stop()
            lblMessage.Text = "I successfully cooked the noodles! Click to continue"
        End If

    End Sub

    Private Sub tmrLidChange_Tick(sender As Object, e As EventArgs) Handles tmrLidChange.Tick

        If (lblLidSignal.Text = "LID ON" And picCover.Location = New Point(241, -1)) Or (lblLidSignal.Text = "LID OFF" And picCover.Location = New Point(545, 150)) Then

            If rand.Next(0, 2) = 1 Then

                If rand.Next(0, 2) = 1 Then
                    lblLidSignal.Text = "LID ON"
                Else
                    lblLidSignal.Text = "LID OFF"

                End If

            End If

        Else
            lblLidSignal.Visible = False
            picCover.Location = New Point(241, -1)
            picFireSignal.Visible = False
            lblMessage.Visible = True
            fail = True
            seconds = 0
            tmrHeatChange.Stop()
            tmrLidChange.Stop()
            tmrTimeLeft.Stop()
            lblMessage.Text = "Oh no. I didn't move the lid fast enough. Click to try again."
        End If

    End Sub

    Private Sub tmrHeatChange_Tick(sender As Object, e As EventArgs) Handles tmrHeatChange.Tick

        If fire = fireSlider Then

            If rand.Next(0, 2) = 1 Then
                fire = rand.Next(0, 3)

                Select Case fire
                    Case 0
                        picFireSignal.Image = My.Resources.fireHot
                    Case 1
                        picFireSignal.Image = My.Resources.FireMedium
                    Case 2
                        picFireSignal.Image = My.Resources.FireWarm
                End Select

            End If
        Else
            lblLidSignal.Visible = False
            picCover.Location = New Point(241, -1)
            seconds = 0
            picFireSignal.Visible = False

            tmrHeatChange.Stop()
            tmrLidChange.Stop()
            tmrTimeLeft.Stop()

            lblMessage.Visible = True
            fail = True
            lblMessage.Text = "Oh no. I didn't change the heat fast enough. Click to try again."
        End If

    End Sub

    Private Sub picCover_Click(sender As Object, e As EventArgs) Handles picCover.Click

        If picCover.Location = New Point(241, -1) Then
            picCover.Location = New Point(545, 150)
        Else
            picCover.Location = New Point(241, -1)
        End If

    End Sub

    Private Sub trkHeat_Scroll(sender As Object, e As EventArgs) Handles trkHeat.Scroll

        If trkHeat.Value = 10 Or trkHeat.Value = 9 Or trkHeat.Value = 8 Then
            picFirePicture.Image = My.Resources.FireWarm
            fireSlider = 2
        ElseIf trkHeat.Value = 4 Or trkHeat.Value = 5 Or trkHeat.Value = 6 Then
            picFirePicture.Image = My.Resources.FireMedium
            fireSlider = 1
        ElseIf trkHeat.Value = 0 Or trkHeat.Value = 1 Or trkHeat.Value = 2 Then
            picFirePicture.Image = My.Resources.fireHot
            fireSlider = 0
        End If

    End Sub

    Private Sub lblMessage_Click(sender As Object, e As EventArgs) Handles lblMessage.Click

        If win = True Then
            tmrTransition.Start()
            openForm = frmCookingR3
        Else
            fail = False
            lblMessage.Visible = False
            picFireSignal.Visible = True
            lblLidSignal.Visible = True

            picFirePicture.Image = My.Resources.FireWarm
            picFireSignal.Image = My.Resources.FireWarm
            fire = 2
            fireSlider = 2
            seconds = 0
            trkHeat.Value = 10

            tmrHeatChange.Start()
            tmrLidChange.Start()
            tmrTimeLeft.Start()
        End If

    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click

        If MessageBox.Show("If you exit now, you will have to start from the beginning. Exit?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

            If minigame = True Then
                tmrTransition.Start()
                openForm = frmMinigames
                Me.Close()
            Else
                tmrTransition.Start()
                openForm = frmKitchen
                frmKitchen.picKohina.Location = New Point(231, 259)
                frmKitchen.picKohina.Image = My.Resources.kohina_left
                My.Computer.Audio.Stop()
                My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
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