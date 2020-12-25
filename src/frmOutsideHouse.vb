Imports System.IO
Public Class frmOutsideHouse
    Dim shroomsObtained, msgObtained As Boolean
    Dim walking As Integer = 1

    Private Sub frmOutsideHouse_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("MSG") Or currentItemsObtained.Contains("MSG") Then
            msgObtained = True
        Else
            msgObtained = False
        End If

        If gameWin = True And msgObtained = False Then
            gameWin = False
            lblDescription.Visible = True
            item = My.Resources.msg
            displayText = "Good job! You obtained MSG"
            currentItemsObtained(numberOfItems) = "MSG"

            numberOfItems += 1
            msgObtained = True
            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
        ElseIf gameWin = True And msgObtained = True Then
            gameWin = False
            lblDescription.Visible = True
            item = My.Resources.yen
            yen += 10
            displayText = "Good job! You obtained ¥10"
            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
        End If

        If itemsObtained.Contains("OUTSIDE SHROOMS") Or currentItemsObtained.Contains("OUTSIDE SHROOMS") Then
            shroomsObtained = True
        Else
            shroomsObtained = False
        End If

        If itemsObtained.Contains("GARDEN TOFU") Or currentItemsObtained.Contains("GARDEN TOFU") Then
            picGelina.Visible = True
            picGelina.Location = New Point(504, 101)
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(237, 149)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmOutsideHouse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, Me, frmGarden, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}

        lblSignal.Visible = False
        lblDescription.Visible = False
        lblDescription.Text = ""
        displayText = ""

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picBush.Bounds) Or picKohina.Bounds.IntersectsWith(picGelina.Bounds) Or
            picKohina.Bounds.IntersectsWith(picKitchen.Bounds) Or picKohina.Bounds.IntersectsWith(picTengu.Bounds) Or picKohina.Bounds.IntersectsWith(picGreenHouse.Bounds) Or
            picKohina.Bounds.IntersectsWith(picTent.Bounds) Or picKohina.Bounds.IntersectsWith(picShrooms.Bounds) Or
            picKohina.Bounds.IntersectsWith(picTownLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picTownRight.Bounds) Or picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or
             picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picBush.Bounds) Or picKohina.Bounds.IntersectsWith(picKitchen.Bounds) Or picKohina.Bounds.IntersectsWith(picTengu.Bounds) Or
               picKohina.Bounds.IntersectsWith(picGreenHouse.Bounds) And picKohina.Bounds.Top < picGreenHouse.Bounds.Bottom Or
               picKohina.Bounds.IntersectsWith(picGelina.Bounds) And picKohina.Bounds.Top < picGelina.Bounds.Bottom Or
               picKohina.Bounds.IntersectsWith(picTent.Bounds) And picKohina.Bounds.Top < picTent.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTownLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picTent.Bounds) And picKohina.Bounds.Left < picTent.Bounds.Right Then
                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If
            End If

            If picKohina.Bounds.IntersectsWith(picShrooms.Bounds) And picKohina.Bounds.Right > picShrooms.Bounds.Left Or picKohina.Bounds.IntersectsWith(picTownRight.Bounds) Then
                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or picKohina.Bounds.IntersectsWith(picShrooms.Bounds) And picKohina.Bounds.Bottom > picShrooms.Bounds.Top Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

        Else

            If stepCount >= inuSteps And inuStole = False Then
                inuStole = True
                showInu = True
                inuTake = rand.Next(0, inuItems + 1)

                currentForm = Me
                Me.Enabled = False
                item = My.Resources.inuStealing
                frmItemsObtained.Show()

                tmrWalking.Stop()
                showInu = False
                inuLocation = inuForm(rand.Next(0, inuForm.Length))


                If inuLocation Is Me Then
                    picInu.Visible = True
                    picInu.Location = New Point(237, 149)
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


        If picKohina.Bounds.IntersectsWith(picKitchen.Bounds) Or picKohina.Bounds.IntersectsWith(picTengu.Bounds) Or picKohina.Bounds.IntersectsWith(picGreenHouse.Bounds) Or
           picKohina.Bounds.IntersectsWith(picTent.Bounds) Or picKohina.Bounds.IntersectsWith(picShrooms.Bounds) Or
           picKohina.Bounds.IntersectsWith(picTownLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picTownRight.Bounds) Or picKohina.Bounds.IntersectsWith(picGelina.Bounds) Or picKohina.Bounds.IntersectsWith(picinu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picKitchen.Bounds) Then
                displayText = "Return to safety"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    frmKitchen.picKohina.Location = New Point(309, 314)
                    openForm = frmKitchen
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picInu.Bounds) Then
                displayText = "Inugami no swiping!"

                If e.KeyCode = Keys.A Then
                    picInu.Location = New Point(0, 0)
                    displayText = "My darling! I will be back!"
                    inuStole = False
                    inuLocation = Nothing
                    picInu.Visible = False
                    inuSteps = rand.Next(200, 300)
                    stepCount = 0
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picGreenHouse.Bounds) Then
                displayText = "Go inside the greenhouse"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmGarden
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTent.Bounds) Then
                displayText = "Go inside the tent"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmTent
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTownLeft.Bounds) Then
                displayText = "Go left"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmLeftTown
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTownRight.Bounds) Then
                displayText = "Go right"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmRightTown
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picGelina.Bounds) Then

                If msgObtained = True Then
                    displayText = "Nice doing buisness with you"
                Else
                    displayText = "I got some extra MSG packets... I'll give you one if you solve my riddles"

                    If e.KeyCode = Keys.A Then
                        tmrTransition.Start()
                        openForm = frmCrypt
                    End If
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTengu.Bounds) Then
                displayText = "A peeping Tengu"
                lblSignal.Visible = False
            End If

            If picKohina.Bounds.IntersectsWith(picShrooms.Bounds) Then
                displayText = "Some mushrooms are growing on the field"

                If e.KeyCode = Keys.A Then

                    If shroomsObtained = True Then
                        displayText = "I shouldn't pick more mushrooms..."
                    Else
                        item = My.Resources.mushrooms
                        displayText = "You obtained mushrooms"
                        currentItemsObtained(numberOfItems) = "OUTSIDE SHROOMS"
                        numberOfItems += 1
                        shroomsObtained = True
                        frmItemsObtained.Show()
                        Me.Enabled = False
                        currentForm = Me
                    End If

                End If

            End If

            display()
        Else
            lblSignal.Visible = False
            lblDescription.Visible = False
            lblDescription.Text = ""
            displayText = ""
        End If
    End Sub

    Private Sub Display()

        If displayText <> lblDescription.Text Then
            lblDescription.Text = ""
            tmrDisplayText.Start()
        End If

    End Sub

    Private Sub GoDown()
        picKohina.Top += walkingSpeed
        tmrWalking.Start()
        direction = "DOWN"
    End Sub

    Private Sub GoUp()
        picKohina.Top -= walkingSpeed
        tmrWalking.Start()
        direction = "UP"
    End Sub

    Private Sub GoRight()
        picKohina.Left += walkingSpeed
        tmrWalking.Start()
        direction = "RIGHT"
    End Sub

    Private Sub GoLeft()
        picKohina.Left -= walkingSpeed
        tmrWalking.Start()
        direction = "LEFT"
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
            Me.Dispose()
            tickFade = 0
        End If

        Me.Opacity -= 0.1
    End Sub


End Class