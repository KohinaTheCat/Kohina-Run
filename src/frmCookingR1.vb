Public Class frmCookingR1
    Dim rand As New Random
    Dim movement, fail, win As Boolean
    Dim round As Integer
    Dim ingredients() As Bitmap = {My.Resources.leekCook, My.Resources.carrotCook, My.Resources.msgCook, My.Resources.mushroomsCook, My.Resources.seaweedCook, My.Resources.tofuCook, My.Resources.noodlesCook}

    Private Sub frmCookingR1_Load(sender As Object, e As EventArgs) Handles Me.Load

        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        End If

        fail = True
        lblMessage.Text = "I'm on a very wobbly stool. Press the exclaimation marks to keep me steady. Make sure to click them as fast as you can. Press W and SPACE to move the ingredients up." &
                           vbNewLine & "Press A to start"
    End Sub

    Private Sub NewRound()
        lblMessage.Text = ""
        picFood.Size = New Size(189, 111)

        If round >= 7 Then
            lblMessage.Text = "I did it! Press A to continue"
            win = True
            picFood.Visible = False
            tmrMoveBack.Stop()
            tmrFall.Stop()
        Else
            tmrMoveBack.Start()
            tmrFall.Start()
            picFood.Image = ingredients(round)
            picFood.Location = New Point(327, 292)
        End If

        round += 1
    End Sub

    Private Sub frmCookingR1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        tmrMoveBack.Start()

        If e.KeyCode = Keys.A And fail = True Then
            tmrMoveBack.Start()
            tmrFall.Start()
            round = 0
            newRound()
            fail = False
            picLeft.Visible = False
            picRight.Visible = False
            Me.BackgroundImage = My.Resources.stove
        ElseIf e.KeyCode = Keys.A And win = True Then
            tmrTransition.Start()
            openForm = frmCookingR2
        ElseIf fail = False Then

            If e.KeyCode = Keys.Space Then
                movement = True
            End If

            If e.KeyCode = Keys.W And movement = True Then
                picFood.Top -= 10
                movement = False
            End If

        End If

        If fail = False Then

            If picFood.Bounds.IntersectsWith(picClose.Bounds) Then
                tmrMoveBack.Interval = 300
                tmrFall.Interval = 1500
            Else
                tmrMoveBack.Interval = 500
                tmrFall.Interval = 3500
            End If

            If picFood.Bounds.IntersectsWith(picStove.Bounds) Then
                tmrShrink.Start()
            End If

        End If

    End Sub

    Private Sub picLeft_Click(sender As Object, e As EventArgs) Handles picLeft.Click
        picLeft.Visible = False
        Me.BackgroundImage = My.Resources.stove
    End Sub

    Private Sub picRight_Click(sender As Object, e As EventArgs) Handles picRight.Click
        picRight.Visible = False
        Me.BackgroundImage = My.Resources.stove
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click

        If minigame = True Then
            tmrTransition.Start()
            openForm = frmMinigames
        Else
            tmrTransition.Start()
            openForm = frmKitchen
            frmKitchen.picKohina.Location = New Point(231, 259)
            frmKitchen.picKohina.Image = My.Resources.kohina_left
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
        End If

    End Sub
    Private Sub tmrMoveBack_Tick(sender As Object, e As EventArgs) Handles tmrMoveBack.Tick

        If picFood.Location <> New Point(327, 292) Then

            If picFood.Location.Y < 292 Then
                picFood.Location = New Point(picFood.Location.X, picFood.Location.Y + 5)
            ElseIf picFood.Location.Y > 292 Then
                picFood.Location = New Point(picFood.Location.X, picFood.Location.Y - 5)
            End If

        Else
            tmrMoveBack.Stop()
        End If

    End Sub

    Private Sub tmrFall_Tick(sender As Object, e As EventArgs) Handles tmrFall.Tick

        If picRight.Visible = True And picLeft.Visible = True Then
            tmrMoveBack.Stop()
            tmrFall.Stop()
            lblMessage.Text = "You fell. Press A to try again"
            fail = True
        Else

            If picRight.Visible = True Then
                picLeft.Visible = True
                Me.BackgroundImage = My.Resources.stoveLeft
            ElseIf picLeft.Visible = True Then
                picRight.Visible = True
                Me.BackgroundImage = My.Resources.stoveRight
            Else

                If rand.Next(0, 2) = 0 Then
                    picRight.Visible = True
                    Me.BackgroundImage = My.Resources.stoveRight
                Else
                    picLeft.Visible = True
                    Me.BackgroundImage = My.Resources.stoveLeft
                End If

            End If

        End If
    End Sub

    Private Sub tmrShrink_Tick(sender As Object, e As EventArgs) Handles tmrShrink.Tick
        picFood.Size = New Size(picFood.Width - 10, picFood.Height - 10)

        If picFood.Width < 50 Then
            tmrShrink.Stop()
            newRound()
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