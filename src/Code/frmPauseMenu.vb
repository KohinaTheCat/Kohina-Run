Imports System.IO
Public Class frmPauseMenu
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        If btnSave.Enabled = True Then

            If MessageBox.Show("Are you sure you want to EXIT without saving?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                My.Computer.Audio.Stop()
                frmStart.Show()
                currentForm.Close()
                Me.Close()
            End If

        Else
            My.Computer.Audio.Stop()
            frmStart.Show()
            currentForm.Close()
            Me.Close()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim saveLocation As StreamWriter = File.CreateText("SAVE.txt")
        Dim saveItems As StreamWriter = File.AppendText("ITEMSTAKEN.txt")
        Dim saveYen As StreamWriter = File.CreateText("INVENTORY.txt")

        If currentForm.Equals(frmBedroom) Then
            saveLocation.WriteLine("BEDROOM")
        ElseIf currentForm.Equals(frmKitchen) Then
            saveLocation.WriteLine("KITCHEN")
        ElseIf currentForm.Equals(frmOutsideHouse) Then
            saveLocation.WriteLine("OUTSIDEHOUSE")
        ElseIf currentForm.Equals(frmTent) Then
            saveLocation.WriteLine("TENT")
        ElseIf currentForm.Equals(frmLeftTown) Then
            saveLocation.WriteLine("LEFTTOWN")
        ElseIf currentForm.Equals(frmrightTown) Then
            saveLocation.WriteLine("RIGHTTOWN")
        ElseIf currentform.Equals(frmStore) Then
            saveLocation.WriteLine("STORE")
        ElseIf currentForm.Equals(frmGarden) Then
            saveLocation.WriteLine("GARDEN")
        ElseIf currentForm.Equals(frmTreeHouse) Then
            saveLocation.WriteLine("TREEHOUSE")
        End If

        If currentItemsObtained.Length <= 1 Then
            saveItems.WriteLine(currentItemsObtained(0))
        Else

            For i = 0 To currentItemsObtained.Length - 1

                If currentItemsObtained(i) <> "" Then
                    saveItems.WriteLine(currentItemsObtained(i))
                End If

            Next

        End If

        saveYen.WriteLine(yen)

        saveYen.Close()
        saveLocation.Close()
        saveItems.Close()

        btnSave.Enabled = False
        MessageBox.Show("Your progress have been saved.", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Close()
    End Sub
End Class