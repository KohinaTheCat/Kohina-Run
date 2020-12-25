Imports System.IO
Public Class frmBedroom
    Dim moneyObtained, closet As Boolean
    Dim walking As Integer = 1

    Private Sub frmBedroom_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd
        Dim saveItems As StreamWriter

        If itemsObtained.Contains("BEDROOM 10 YEN") Or currentItemsObtained.Contains("BEDROOM 10 YEN") Then
            moneyObtained = True
        Else
            moneyObtained = False
        End If

        If itemsObtained.Contains("CLOSET 20 YEN") Or currentItemsObtained.Contains("CLOSET 20 YEN") Then
            closet = True
        Else
            closet = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(81, 137)
        End If

        If gameWin = True And closet = False Then
            gameWin = False
            lblDescription.Visible = True
            closet = True

            yen += 20
            item = My.Resources.yen
            displayText = "I obtained ¥20"
            currentItemsObtained(numberOfItems) = "CLOSET 20 YEN"
            numberOfItems += 1

            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
        End If

        If newGame = True Then
            itemsReader.Close()
            saveItems = File.AppendText("ITEMSTAKEN.txt")
            saveItems.WriteLine("LIST")
            numberOfItems += 1

            lblDescription.Visible = True
            lblSignal.Visible = True
            displayText = "A list of ingredients! Press S to see inventory"
            newGame = False

            saveItems.Close()
        End If

        display()
        itemsReader.Close()
    End Sub

    Private Sub frmBedroom_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {Me, frmOutsideHouse, frmGarden, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}

        lblDescription.Visible = False
        lblSignal.Visible = False

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picStairs.Bounds) Or picKohina.Bounds.IntersectsWith(picWall1.Bounds) Or picKohina.Bounds.IntersectsWith(picWall2.Bounds) Or
           picKohina.Bounds.IntersectsWith(picWall3.Bounds) Or picKohina.Bounds.IntersectsWith(picWall4.Bounds) Or picKohina.Bounds.IntersectsWith(picCloset.Bounds) Or
           picKohina.Bounds.IntersectsWith(picStairs.Bounds) Or picKohina.Bounds.IntersectsWith(picBed.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picWall3.Bounds) Or picKohina.Bounds.IntersectsWith(picBed.Bounds) And picKohina.Bounds.Bottom > picBed.Bounds.Top Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall1.Bounds) Or picKohina.Bounds.IntersectsWith(picCloset.Bounds) Or picKohina.Bounds.IntersectsWith(picCloset.Bounds) Or
               picKohina.Bounds.IntersectsWith(picStairs.Bounds) And picKohina.Bounds.Top < picStairs.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall4.Bounds) Or
               picKohina.Bounds.IntersectsWith(picBed.Bounds) And picKohina.Bounds.Left < picBed.Bounds.Right Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall2.Bounds) Or
               picKohina.Bounds.IntersectsWith(picStairs.Bounds) And picKohina.Bounds.Right > picStairs.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picBed.Bounds) And picKohina.Bounds.Left > picBed.Bounds.Right Then

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
                    picInu.Location = New Point(81, 137)
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

        If picKohina.Bounds.IntersectsWith(picStairs.Bounds) Or picKohina.Bounds.IntersectsWith(picBed.Bounds) Or picKohina.Bounds.IntersectsWith(picCloset.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then
            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picBed.Bounds) Then
                displayText = "Search the bed"

                If e.KeyCode = Keys.A Then

                    If moneyObtained = True Then
                        displayText = "Nothing but bed bugs"
                    Else
                        lblSignal.Visible = False
                        yen += 10
                        item = My.Resources.yen
                        displayText = "You obtained ¥10"
                        currentItemsObtained(numberOfItems) = "BEDROOM 10 YEN"

                        frmItemsObtained.Show()
                        numberOfItems += 1
                        moneyObtained = True
                        Me.Enabled = False
                        currentForm = Me
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCloset.Bounds) Then

                If closet = False Then
                    displayText = "Go into the closet"

                    If e.KeyCode = Keys.A Then
                        tmrTransition.Start()
                        openForm = frmHangman
                    End If

                Else
                    displayText = "I do not want to re-live that traumatizing experience again"
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

            If picKohina.Bounds.IntersectsWith(picStairs.Bounds) Then
                displayText = "Go to the kitchen"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmKitchen
                    frmKitchen.picKohina.Location = New Point(427, 323)
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