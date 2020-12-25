Imports System.IO
Public Class frmKitchen
    Dim scallionsObtained, chopsticksObtained, allItemsObtained As Boolean
    Dim walking As Integer = 1

    Private Sub frmKitchen_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("KITCHEN LEEK") Or currentItemsObtained.Contains("KITCHEN LEEK") Then
            scallionsObtained = True
        Else
            scallionsObtained = False
        End If

        If itemsObtained.Contains("KITCHEN CHOPSTICKS") Or currentItemsObtained.Contains("KITCHEN CHOPSTICKS") Then
            chopsticksObtained = True
        Else
            chopsticksObtained = False
        End If

        If (itemsObtained.Contains("KITCHEN LEEK") Or currentItemsObtained.Contains("KITCHEN LEEK")) And (itemsObtained.Contains("KITCHEN CHOPSTICKS") Or currentItemsObtained.Contains("KITCHEN CHOPSTICKS")) And
           (itemsObtained.Contains("OUTSIDE SHROOMS") Or currentItemsObtained.Contains("OUTSIDE SHROOMS")) And (itemsObtained.Contains("RIGHT CARROT") Or currentItemsObtained.Contains("RIGHT CARROT")) And
           (itemsObtained.Contains("GARDEN TOFU") Or currentItemsObtained.Contains("GARDEN TOFU")) And (itemsObtained.Contains("GARDEN SEAWEED") Or currentItemsObtained.Contains("GARDEN SEAWEED")) And
           (itemsObtained.Contains("NOODLES") Or currentItemsObtained.Contains("NOODLES")) And (itemsObtained.Contains("TENT PAPERS") Or currentItemsObtained.Contains("TENT PAPERS")) And
           (itemsObtained.Contains("MSG") Or currentItemsObtained.Contains("MSG")) And inuStole = False Then
            allItemsObtained = True
        Else
            allItemsObtained = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(543, 173)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmKitchen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, frmStore}

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then

            If inventoryOpen = False Then
                frmInventory.Show()
            Else
                frmInventory.Close()
            End If

        End If

        If picKohina.Bounds.IntersectsWith(picWallOne.Bounds) Or picKohina.Bounds.IntersectsWith(picWallThree.Bounds) Or
           picKohina.Bounds.IntersectsWith(picCupboard.Bounds) Or picKohina.Bounds.IntersectsWith(picToaster.Bounds) Or
           picKohina.Bounds.IntersectsWith(picFridge.Bounds) Or picKohina.Bounds.IntersectsWith(picStove.Bounds) Or
           picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or picKohina.Bounds.IntersectsWith(picRoom.Bounds) Or
           picKohina.Bounds.IntersectsWith(picWallFour.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picWallOne.Bounds) Or picKohina.Bounds.IntersectsWith(picStove.Bounds) Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWallThree.Bounds) Or picKohina.Bounds.IntersectsWith(picFridge.Bounds) Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCupboard.Bounds) Or picKohina.Bounds.IntersectsWith(picToaster.Bounds) Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRoom.Bounds) And picKohina.Bottom > picRoom.Top Or
                picKohina.Bounds.IntersectsWith(picOutside.Bounds) And picKohina.Bottom > picOutside.Top Or
                picKohina.Bounds.IntersectsWith(picWallFour.Bounds) Then

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
                    picInu.Location = New Point(543, 173)
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

        If picKohina.Bounds.IntersectsWith(picRoom.Bounds) Or picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or picKohina.Bounds.IntersectsWith(picStove.Bounds) Or
           picKohina.Bounds.IntersectsWith(picFridge.Bounds) Or picKohina.Bounds.IntersectsWith(picToaster.Bounds) Or picKohina.Bounds.IntersectsWith(picCupboard.Bounds) Or
           picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True


            If picKohina.Bounds.IntersectsWith(picRoom.Bounds) Then
                displayText = "Go to bedroom"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmBedroom
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picStove.Bounds) Then
                displayText = "Wow. A stove. I don't have enough ingredients to cook."

                If allItemsObtained = True Then
                    displayText = "TIME TO MAKE MY CUP NOODLES"

                    If e.KeyCode = Keys.A Then
                        tmrTransition.Start()
                        openForm = frmCookingR1
                    End If

                ElseIf allItemsObtained = False Then
                    displayText = "I am missing some ingredients"
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

            If picKohina.Bounds.IntersectsWith(picOutside.Bounds) Then
                displayText = "Go to town"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmOutsideHouse
                End If
            End If

            If picKohina.Bounds.IntersectsWith(picFridge.Bounds) Then
                displayText = "Open fridge"

                If e.KeyCode = Keys.A Then

                    If scallionsObtained = True Then
                        displayText = "empty..."
                    Else
                        frmInventory.TopMost = True
                        item = My.Resources.leek
                        displayText = "You obtained leek"
                        lblSignal.Visible = False
                        currentItemsObtained(numberOfItems) = "KITCHEN LEEK"
                        numberOfItems += 1
                        scallionsObtained = True
                        frmItemsObtained.Show()
                        Me.Enabled = False
                        currentForm = Me
                    End If

                End If
            End If

            If picKohina.Bounds.IntersectsWith(picCupboard.Bounds) Then
                displayText = "Search cupboard"

                If e.KeyCode = Keys.A Then

                    If chopsticksObtained = True Then
                        displayText = "empty..."
                    Else
                        item = My.Resources.chopsticks
                        displayText = "You obtained chopsticks"
                        lblSignal.Visible = False
                        currentItemsObtained(numberOfItems) = "KITCHEN CHOPSTICKS"
                        numberOfItems += 1
                        chopsticksObtained = True
                        frmItemsObtained.Show()
                        Me.Enabled = False
                        currentForm = Me
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picToaster.Bounds) Then
                displayText = "Oh no... I burnt my toast"
                lblSignal.Visible = False
            End If

            display()

        Else
            lblSignal.Visible = False
            lblDescription.Visible = False
            lblDescription.Text = ""
            displayText = ""
        End If
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

    Private Sub tmrDisplayText_Tick(sender As Object, e As EventArgs) Handles tmrDisplayText.Tick

        If lblDescription.Text = displayText Then
            tmrDisplayText.Stop()
        Else
            lblDescription.Text += displayText.Substring(lblDescription.Text.Length, 1)
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