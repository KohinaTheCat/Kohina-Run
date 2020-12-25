Public Class frmStart
    Dim tickSlide, transparent As Integer
    Dim up As Boolean

    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrSlide.Start()
        My.Computer.Audio.Play(My.Resources.DOPE8bit, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub frmStart_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.A Then
            My.Computer.Audio.Play(My.Resources.confirm, AudioPlayMode.WaitToComplete)
            tmrTransition.Start()
        End If

    End Sub

    Private Sub tmrSlide_Tick(sender As Object, e As EventArgs) Handles tmrSlide.Tick
        tickSlide += 1

        If tickSlide = 60 Then
            tmrSlide.Stop()
            tmrFade.Start()
            lblCommand.Visible = True
        End If

        lblTitle.Left -= 9
        picStart.Left += 10
    End Sub

    Private Sub tmrFade_Tick(sender As Object, e As EventArgs) Handles tmrFade.Tick

        If transparent = 255 Then
            up = False
        ElseIf transparent = 0 Then
            up = True
        End If

        If up = False Then
            transparent -= 3
        Else up = True
            transparent += 3
        End If

        lblCommand.BackColor = Color.FromArgb(transparent, 51, 51, 51)
    End Sub

    Private Sub tmrTransition_Tick(sender As Object, e As EventArgs) Handles tmrTransition.Tick
        tickFade += 1

        If tickFade = 10 Then
            frmGameOption.Show()
            tmrTransition.Stop()
            Me.Close()
            tickFade = 0
        End If

        Me.Opacity -= 0.1
    End Sub
End Class
