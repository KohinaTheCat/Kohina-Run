Public Class frmCookingR3
    Dim moveTime As Integer
    Dim scoops, seconds, limit As Integer
    Dim ladleFull, newGame, win As Boolean

    'from the internet to reduce lag
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Private Sub frmCookingR3_Load(sender As Object, e As EventArgs) Handles Me.Load
        '    Cursor.Hide()

        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
        End If

        lblMessage.Text = "Kokkuri-san might come soon. I better scoop the noodles into the bowl fast so I can eat! Click the pot to scoop some noodles and click the bowl to drop the noodles. Beware Inugami. He may jump and contaminate everything!" & vbNewLine &
                          "Click to start, or ESC to exit."
        newGame = True
    End Sub

    Private Sub frmCookingR3_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        picLadle.Location = New Point((MousePosition.X - Me.Left - picLadle.Width / 2), (MousePosition.Y - Me.Top))
    End Sub

    Private Sub frmCookingR3_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

        If picLadle.Bounds.IntersectsWith(picPot.Bounds) And ladleFull = False Then
            picLadle.Image = My.Resources.ladlefull
            ladleFull = True

            If scoops >= 20 Then
                Me.BackgroundImage = My.Resources.potemptybowlfull
            End If

        End If

        If picLadle.Bounds.IntersectsWith(picBowl.Bounds) And ladleFull = True Then
            picLadle.Image = My.Resources.ladleempty
            ladleFull = False
            scoops += 1

            If scoops = 1 Then
                Me.BackgroundImage = My.Resources.potfullbowlfull
            End If

            If scoops >= 21 Then
                lblMessage.Visible = True
                lblMessage.Text = "You transferred all the noodles to your bowl!! FINALLY TIME TO EAT. Click to continue"
                win = True
            End If

        End If

    End Sub

    Private Sub lblMessage_Click(sender As Object, e As EventArgs) Handles lblMessage.Click

        If newGame = True Then
            newGame = False
            Me.BackgroundImage = My.Resources.potfulllbowlempty
            picLadle.Image = My.Resources.ladleempty
            ladleFull = False

            picInu.Location = New Point(398, -109)
            picInu.Visible = False
            lblMessage.Visible = False

            newGame = False
            scoops = 0
            seconds = 0
            tmrInu.Start()
            limit = 4
        ElseIf win = True Then
            tmrInu.Stop()
            tmrTransition.Start()

            If minigame = True Then
                minigame = False
                openForm = frmMinigames
            Else
                openForm = frmEnding

            End If

        End If
    End Sub

    Private Sub tmrInu_Tick(sender As Object, e As EventArgs) Handles tmrInu.Tick
        Dim rand As New Random
        seconds += 1

        If seconds = limit Then
            limit = rand.Next(1, 4)
            moveTime = 0
            picInu.Visible = True
            tmrInuMove.Start()
            tmrInu.Stop()
        End If

    End Sub

    Private Sub tmrInuMove_Tick(sender As Object, e As EventArgs) Handles tmrInuMove.Tick

        If moveTime = 9 Then
            picInu.Visible = False
            picInu.Location = New Point(398, -109)
            seconds = 0
            tmrInuMove.Stop()
            tmrInu.Start()
        End If

        moveTime += 1
        picInu.Top += 50

        If picLadle.Bounds.IntersectsWith(picInu.Bounds) Then
            tmrInuMove.Stop()
            lblMessage.Visible = True
            lblMessage.Text = "Inugami ruined your cup noodles! Click to try again"
            newGame = True
        End If

    End Sub

    Private Sub frmCookingR3_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            Cursor.Show()
            tmrTransition.Start()

            If minigame = True Then
                minigame = False
                tmrTransition.Start()
                openForm = frmMinigames
            Else
                My.Computer.Audio.Stop()
                My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)

                openForm = frmKitchen
                frmKitchen.picKohina.Location = New Point(231, 259)
                frmKitchen.picKohina.Image = My.Resources.kohina_left
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