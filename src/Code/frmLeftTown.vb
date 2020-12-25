Imports System.IO
Public Class frmLeftTown
    Dim chocolateObtained, gaveChocolate As Boolean
    Dim walking As Integer = 1

    Private Sub frmLeftTown_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("NO CHOCOLATE") Or currentItemsObtained.Contains("NO CHOCOLATE") Then
            gaveChocolate = True
        Else
            gaveChocolate = False
        End If

        If itemsObtained.Contains("CHOCOLATE") Or currentItemsObtained.Contains("CHOCOLATE") Then
            chocolateObtained = True
        Else
            chocolateObtained = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(128, 330)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmLeftTown_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, frmRightTown, Me, frmTreeHouse, frmStore, frmKitchen}

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picWall.Bounds) Or picKohina.Bounds.IntersectsWith(picTree.Bounds) Or
           picKohina.Bounds.IntersectsWith(picInu.Bounds) Or picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or
           picKohina.Bounds.IntersectsWith(picCenterTown.Bounds) Or picKohina.Bounds.IntersectsWith(picCkara.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picBottom.Bounds) Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCkara.Bounds) Or picKohina.Bounds.IntersectsWith(picTree.Bounds) And picKohina.Bounds.Top < picTree.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall.Bounds) Or picKohina.Bounds.IntersectsWith(picTree.Bounds) And picKohina.Bounds.Left < picTree.Bounds.Right Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCenterTown.Bounds) Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

        Else

            If stepCount >= inuSteps And inuStole = False Then
                inuStole = True
                showInu = True
                inuTake = rand.Next(0, inuItems + 1)

                item = My.Resources.inuStealing
                currentForm = Me
                Me.Enabled = False
                frmItemsObtained.Show()

                tmrWalking.Stop()
                showInu = False
                inuLocation = inuForm(rand.Next(0, inuForm.Length))

                If inuLocation Is Me Then
                    picInu.Visible = True
                    picInu.Location = New Point(128, 330)
                End If

            Else
                stepCount += 1
            End If

            If e.KeyCode = Keys.Down Then
                GoDown()
            End If

            If e.KeyCode = Keys.Up Then
                GoUp()
            End If

            If e.KeyCode = Keys.Right Then
                GoRight()
            End If

            If e.KeyCode = Keys.Left Then
                GoLeft()
            End If
        End If

    End Sub

    Private Sub frmBedroom_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        tmrWalking.Stop()

        If direction = "UP" Then
            picKohina.Image = My.Resources.kohina_back
        ElseIf direction = "DOWN" Then
            picKohina.Image = My.Resources.kohina_front
        ElseIf direction = "RIGHT" Then
            picKohina.Image = My.Resources.kohina_right
        ElseIf direction = "LEFT" Then
            picKohina.Image = My.Resources.kohina_left
        End If

        If picKohina.Bounds.IntersectsWith(picCenterTown.Bounds) Or picKohina.Bounds.IntersectsWith(picTree.Bounds) And picKohina.Bounds.Top < picTree.Bounds.Bottom Or
           picKohina.Bounds.IntersectsWith(picCkara.Bounds) Or picKohina.Bounds.IntersectsWith(picinu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picTree.Bounds) And picKohina.Bounds.Top < picTree.Bounds.Bottom Then
                lblSignal.Visible = False
                displayText = "The ladder is broken"
            End If

            If picKohina.Bounds.IntersectsWith(picInu.Bounds) Then
                displayText = "Inugami no swiping!"

                If e.KeyCode = Keys.A Then
                    picInu.Location = New Point(0, 0)
                    displayText = "Inugami: My darling! I will be back!"
                    inuStole = False
                    inuLocation = Nothing
                    picInu.Visible = False
                    inuSteps = rand.Next(200, 300)
                    stepCount = 0
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCkara.Bounds) Then

                picCkaraBig.Visible = True
                displayText = "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH SUUUUUGARRRR"

                If gaveChocolate = False Then

                    If e.KeyCode = Keys.A Then

                        If chocolateObtained = True Then
                            displayText = "w0w! Is that chocolate? I'll trade you for this key"
                            currentItemsObtained(numberOfItems) = "NO CHOCOLATE"
                            numberOfItems += 1
                            currentItemsObtained(numberOfItems) = "KEY"
                            numberOfItems += 1
                            chocolateObtained = False
                            gaveChocolate = True
                            item = My.Resources.key
                            frmItemsObtained.Show()
                            Me.Enabled = False
                            currentForm = Me
                        ElseIf chocolateObtained = False Then
                            displayText = "Could you give me something sweet?"
                        End If

                    End If

                ElseIf gaveChocolate = True Then
                    displayText = "NOM NOM NOM NOM"
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCenterTown.Bounds) Then
                displayText = "Go right"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmOutsideHouse
                    frmOutsideHouse.picKohina.Location = New Point(118, 262)
                    frmOutsideHouse.picKohina.Image = My.Resources.kohina_right
                End If

            End If

            display()
        Else
            picCkaraBig.Visible = False
            lblSignal.Visible = False
            lblDescription.Visible = False
            lblDescription.Text = ""
            displayText = ""
        End If

    End Sub

    Private Sub tmrDisplayText_Tick(sender As Object, e As EventArgs) Handles tmrDisplayText.Tick

        If lblDescription.Text = displayText Then
            tmrDisplayText.Stop()
        Else

            lblDescription.Text += displayText.Substring(lblDescription.Text.Length, 1)
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


    Private Sub tmrWalking_Tick(sender As Object, e As EventArgs) Handles tmrWalking.Tick
        If direction = "DOWN" Then

            Select Case walking
                Case 1
                    picKohina.Image = My.Resources.kohina_front__left
                    walking = 2
                Case 2
                    picKohina.Image = My.Resources.kohina_front__right
                    walking = 3
                Case 3
                    picKohina.Image = My.Resources.kohina_front
                    walking = 1
            End Select

        End If

        If direction = "UP" Then

            Select Case walking
                Case 1
                    picKohina.Image = My.Resources.kohina_back__left
                    walking = 2
                Case 2
                    picKohina.Image = My.Resources.kohina_back__right
                    walking = 3
                Case 3
                    picKohina.Image = My.Resources.kohina_back
                    walking = 1
            End Select

        End If

        If direction = "RIGHT" Then

            Select Case walking
                Case 1
                    picKohina.Image = My.Resources.kohina_right_walking
                    walking = 2
                Case 2
                    picKohina.Image = My.Resources.kohina_right
                    walking = 3
                Case 3
                    picKohina.Image = My.Resources.kohina_right_walking2
                    walking = 1
            End Select

        End If

        If direction = "LEFT" Then

            Select Case walking
                Case 1
                    picKohina.Image = My.Resources.kohina_left_walking
                    walking = 2
                Case 2
                    picKohina.Image = My.Resources.kohina_left
                    walking = 3
                Case 3
                    picKohina.Image = My.Resources.kohina_left_walking2
                    walking = 1
            End Select

        End If
    End Sub

    'this private sub starts tmrDisplayText which displays text in lblDescription one letter at a time
    Private Sub Display()

        If displayText <> lblDescription.Text Then
            lblDescription.Text = ""
            tmrDisplayText.Start()
        End If

    End Sub

    'this private sub animates and move Kohina downwards
    Private Sub GoDown()
        picKohina.Top += walkingSpeed
        tmrWalking.Start()
        direction = "DOWN"
    End Sub

    'this private sub animates and move Kohina upwards
    Private Sub GoUp()
        picKohina.Top -= walkingSpeed
        tmrWalking.Start()
        direction = "UP"
    End Sub

    'this private sub animates and move Kohina to the right
    Private Sub GoRight()
        picKohina.Left += walkingSpeed
        tmrWalking.Start()
        direction = "RIGHT"
    End Sub

    'this private sub animates and move Kohina to the left
    Private Sub GoLeft()
        picKohina.Left -= walkingSpeed
        tmrWalking.Start()
        direction = "LEFT"
    End Sub
End Class