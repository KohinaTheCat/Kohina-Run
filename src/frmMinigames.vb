Public Class frmMinigames
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.BST8bit, AudioPlayMode.BackgroundLoop)
        tmrTransition.Start()
        openForm = frmGameOption
    End Sub

    Private Sub picTicTacToe_Click(sender As Object, e As EventArgs) Handles picTicTacToe.Click
        tmrTransition.Start()
        openForm = frmMinigameTicTacToe
        minigame = True
    End Sub

    Private Sub picMatching_Click(sender As Object, e As EventArgs) Handles picMatching.Click
        tmrTransition.Start()
        openForm = frmMatching
        minigame = True
    End Sub

    Private Sub picCooking_Click(sender As Object, e As EventArgs) Handles picCooking.Click
        tmrTransition.Start()
        openForm = frmCookingR1
        minigame = True
    End Sub

    Private Sub picHangman_Click(sender As Object, e As EventArgs) Handles picHangman.Click
        tmrTransition.Start()
        openForm = frmHangman
        minigame = True
    End Sub

    Private Sub picCryptography_Click(sender As Object, e As EventArgs) Handles picCryptography.Click
        tmrTransition.Start()
        openForm = frmCrypt
        minigame = True
    End Sub

    Private Sub picRythm_Click(sender As Object, e As EventArgs) Handles picRythm.Click
        tmrTransition.Start()
        openForm = frmRhythm
        minigame = True
    End Sub

    Private Sub picNoodle_Click(sender As Object, e As EventArgs) Handles picNoodle.Click
        tmrTransition.Start()
        openForm = frmNoodleSortR1
        minigame = True
    End Sub

    Private Sub frmMinigames_Click(sender As Object, e As EventArgs) Handles Me.Click
        Cursor.Show()
        gameWin = False
        Me.Refresh()
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