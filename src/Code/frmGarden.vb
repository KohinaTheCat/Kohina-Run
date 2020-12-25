Imports System.IO
Public Class frmGarden
    Dim tofuObtained, seaweedObtained As Boolean
    Dim walking As Integer = 1

    Private Sub frmGarden_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("GARDEN TOFU") Or currentItemsObtained.Contains("GARDEN TOFU") Then
            tofuObtained = True
        Else
            tofuObtained = False
        End If

        If itemsObtained.Contains("GARDEN SEAWEED") Or currentItemsObtained.Contains("GARDEN SEAWEED") Then
            seaweedObtained = True
        Else
            seaweedObtained = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(423, 139)
        End If

        If gameWin = True And tofuObtained = False Then
            gameWin = False
            lblDescription.Visible = True
            item = My.Resources.tofu
            displayText = "Wow! I obtained tofu"
            currentItemsObtained(numberOfItems) = "GARDEN TOFU"
            numberOfItems += 1
            tofuObtained = True
            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
        ElseIf gameWin = True And tofuObtained = True Then
            gameWin = False
            lblSignal.Visible = True
            lblDescription.Visible = True
            item = My.Resources.yen
            yen += 10
            displayText = "I obtained ¥10"
            lblSignal.Visible = False
            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(542, 159)
        End If

        display()
        itemsReader.Close()
    End Sub

    Private Sub frmGarden_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, Me, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}

        frmItemsObtained.Close()
        lblSignal.Visible = False
        lblDescription.Visible = False
        Me.Enabled = True

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picRight.Bounds) Or
           picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) Or
           picKohina.Bounds.IntersectsWith(picKoom.Bounds) Or picKohina.Bounds.IntersectsWith(picWateringCan.Bounds) Or
           picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or
               (picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) And picKohina.Bounds.Right > picSeaweed.Bounds.Right) Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRight.Bounds) Or
               (picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) And picKohina.Bounds.Left < picSeaweed.Bounds.Left) Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picKoom.Bounds) Or picKohina.Bounds.IntersectsWith(picWateringCan.Bounds) Or
               picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) And picKohina.Bounds.Bottom > picSeaweed.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picOutside.Bounds) Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

        Else

            If stepCount >= inuSteps And inuStole = False Then
                inuStole = True
                showInu = True
                inuTake = rand.Next(0, inuItems)

                currentForm = Me
                Me.Enabled = False
                item = My.Resources.inuStealing
                frmItemsObtained.Show()
                tmrWalking.Stop()

                showInu = False
                inuLocation = inuForm(rand.Next(0, inuForm.Length))

                If inuLocation Is Me Then
                    picInu.Visible = True
                    picInu.Location = New Point(542, 159)
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

        If picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) Or
           picKohina.Bounds.IntersectsWith(picKoom.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picOutside.Bounds) Then
                displayText = "Go outside"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmOutsideHouse
                    frmOutsideHouse.picKohina.Location = New Point(603, 217)
                End If

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

            If picKohina.Bounds.IntersectsWith(picSeaweed.Bounds) Then
                displayText = "Slimy, wet seaweed. Yum."

                If e.KeyCode = Keys.A Then

                    If seaweedObtained = True Then
                        displayText = "The old lady will be mad if I take more"
                    Else
                        item = My.Resources.seaweed
                        displayText = "You obtained seaweed"
                        lblSignal.Visible = False
                        currentItemsObtained(numberOfItems) = "GARDEN SEAWEED"
                        numberOfItems += 1
                        seaweedObtained = True
                        frmItemsObtained.Show()
                        Me.Enabled = False
                        currentForm = Me
                    End If

                End If
            End If

            If picKohina.Bounds.IntersectsWith(picKoom.Bounds) Then
                picKoom.Visible = False
                picKoomBig.Visible = True

                If tofuObtained = True Then
                    displayText = "You are back to play more?"
                ElseIf tofuObtained = False Then
                    displayText = "You are looking for food? Ah, kids these days play Pokémon right? I'll get you some tofu when you beat this game!"
                End If

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmMatching
                End If

            Else
                picKoomBig.Visible = False
                picKoom.Visible = True
            End If

            display()
        Else
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

    'this private sub starts tmrDisplayText which displays text in lblDescription one letter at a time
    Private Sub Display()
        If displayText <> lblDescription.Text Then
            lblDescription.Text = ""
            tmrDisplayText.Start()
        End If
    End Sub
End Class