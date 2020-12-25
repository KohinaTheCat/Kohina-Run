Public Class frmItemsObtained
    Private Sub frmItemsObtained_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        If showInu = True Then
            Me.TransparencyKey = Color.Magenta
            lblInu.Visible = True
        Else
            Me.TransparencyKey = Color.White
        End If

        Me.TopMost = True
        picItem.Image = item
    End Sub

    Private Sub frmItemsObtained_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If inuStole = True Then
            If e.KeyCode = Keys.A Then
                currentForm.Enabled = True
                picItem.Image = Nothing
                Me.Close()
                currentForm = Nothing
            End If
        Else
            currentForm.Enabled = True
            picItem.Image = Nothing
            Me.Close()
        End If

    End Sub
End Class