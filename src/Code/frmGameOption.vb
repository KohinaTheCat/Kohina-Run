Imports System.IO

Public Class frmGameOption
    Private Sub frmGameOption_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim saveFile As StreamReader = File.OpenText("ITEMSTAKEN.txt")

        My.Computer.Audio.Play(My.Resources.BST8bit, AudioPlayMode.BackgroundLoop)

        If saveFile.ReadLine <> "LIST" Then
            btnContinue.Enabled = False
        Else
            btnContinue.Enabled = True
        End If

        saveFile.Close()
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        minigame = False

        If MessageBox.Show("Starting a new game will delete all save files, new game?", "NEW GAME", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Kill("INVENTORY.txt")
            Kill("ITEMSTAKEN.txt")
            Kill("SAVE.txt")
            File.Create("INVENTORY.txt")
            File.Create("ITEMSTAKEN.txt")
            File.Create("SAVE.txt")

            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)

            inuSteps = rand.Next(200, 300)
            tmrTransition.Start()
            yen = 0
            newGame = True
            openForm = frmIntro
        End If

    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Dim reader As StreamReader = File.OpenText("SAVE.txt")
        Dim location As String = reader.ReadLine
        Dim inventory As StreamReader = File.OpenText("INVENTORY.txt")

        yen = CInt(inventory.ReadLine)

        If location <> Nothing Then
            If location.Contains("BEDROOM") Then 'specific kohina location
                openForm = frmBedroom
            ElseIf location.Contains("KITCHEN") Then
                openForm = frmKitchen
            ElseIf location.Contains("OUTSIDEHOUSE") Then
                openForm = frmOutsideHouse
            ElseIf location.Contains("TENT") Then
                openForm = frmTent
            ElseIf location.Contains("LEFTTOWN") Then
                openForm = frmLeftTown
            ElseIf location.Contains("RIGHTTOWN") Then
                openForm = frmRightTown
            ElseIf location.Contains("STORE") Then
                openForm = frmStore
            ElseIf location.Contains("GARDEN") Then
                openForm = frmGarden
            ElseIf location.Contains("TREEHOUSE") Then
                openForm = frmTreeHouse
            End If
        Else
            openForm = frmBedroom
        End If

        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)

        inuSteps = rand.Next(200, 300)

        tmrTransition.Start()
        reader.Close()
        inventory.Close()
    End Sub

    Private Sub btnMiniGames_Click(sender As Object, e As EventArgs) Handles btnMiniGames.Click
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        tmrTransition.Start()
        openForm = frmMinigames
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub tmrTransition_Tick(sender As Object, e As EventArgs) Handles tmrTransition.Tick
        tickFade += 1

        If tickFade = 10 Then
            openForm.Show()
            tmrTransition.Stop()
            Me.Close()
            openForm = Nothing
            inuLocation = New frmOutsideHouse
            tickFade = 0
        End If

        Me.Opacity -= 0.1
    End Sub
End Class