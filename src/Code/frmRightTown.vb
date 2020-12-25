Imports System.IO
Public Class frmRightTown
    Dim carrotObtained, storeOpened As Boolean
    Dim page As Integer
    Dim walking As Integer = 1

    Private Sub frmRightTown_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("RIGHT CARROT") Or currentItemsObtained.Contains("RIGHT CARROT") Then
            carrotObtained = True
        Else
            carrotObtained = False
        End If

        If carrotObtained = False And gameWin = True Then
            lblDescription.Visible = True
            lblDescription.Text = "Jarrot: I LOST!! Here's a carrot"
            Me.Refresh()
            item = My.Resources.orange_carrot
            currentItemsObtained(numberOfItems) = "RIGHT CARROT"
            numberOfItems += 1
            currentForm = Me
            frmItemsObtained.Show()
            Me.Enabled = False
            Me.Refresh()
        ElseIf carrotObtained = True And gameWin = True Then
            lblDescription.Visible = True
            lblDescription.Text = "Jarrot: I LOST AGAIN!! You obtained ¥5"
            Me.Refresh()
            item = My.Resources.yen
            yen += 5
            currentForm = Me
            frmItemsObtained.Show()
            Me.Enabled = False
            Me.Refresh()
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(401, 156)
        End If

        gameWin = False
        itemsReader.Close()
    End Sub

    Private Sub frmRightTown_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, Me, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}

        frmItemsObtained.Close()
        lblSignal.Visible = False
        lblDescription.Visible = False

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picRight.Bounds) Or picKohina.Bounds.IntersectsWith(picBackground.Bounds) Or picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or
           picKohina.Bounds.IntersectsWith(picStore.Bounds) Or picKohina.Bounds.IntersectsWith(picCarrots.Bounds) Or picKohina.Bounds.IntersectsWith(picTurtle.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picBackground.Bounds) Or picKohina.Bounds.IntersectsWith(picStore.Bounds) Or picKohina.Bounds.IntersectsWith(picCarrots.Bounds) Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or picKohina.Bounds.IntersectsWith(picTurtle.Bounds) And picKohina.Bounds.Bottom > picTurtle.Bounds.Top Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picTurtle.Bounds) And picKohina.Bounds.Left < picTurtle.Bounds.Right Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRight.Bounds) Or picKohina.Bounds.IntersectsWith(picTurtle.Bounds) And picKohina.Bounds.Left > picTurtle.Bounds.Right Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
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
                    picInu.Location = New Point(401, 156)
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

        If picKohina.Bounds.IntersectsWith(picStore.Bounds) Or picKohina.Bounds.IntersectsWith(picTurtle.Bounds) Or picKohina.Bounds.IntersectsWith(picCarrots.Bounds) Or
           picKohina.Bounds.IntersectsWith(picRight.Bounds) Or picKohina.Bounds.IntersectsWith(picStore.Bounds) Or picKohina.Bounds.IntersectsWith(picLeft.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picStore.Bounds) Then
                displayText = "Go inside the store"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmStore
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

            If picKohina.Bounds.IntersectsWith(picTurtle.Bounds) Then
                lblDescription.Font = New Font("Tw Cen MT Condensed", 10)
                displayText = "Turtles are diapsids of the order Testudines (or Chelonii) characterized by a special bony or cartilaginous shell developed from their ribs and acting as a shield."

                If e.KeyCode = Keys.A And page = 0 Then
                    displayText = "Turtle may refer to the order as a whole (American English) or to fresh-water and sea-dwelling testudines (British English)."
                    page += 1
                ElseIf e.KeyCode = Keys.A And page = 1 Then
                    displayText = "The order Testudines includes both extant (living) and extinct species."
                    page += 1
                ElseIf e.KeyCode = Keys.A And page = 2 Then
                    displayText = "The earliest known members of this group date from 220 million years ago, making turtles one of the oldest reptile groups and a more ancient group than snakes or crocodilians."
                    page += 1
                ElseIf e.KeyCode = Keys.A And page = 3 Then
                    displayText = "Of the 356 known species alive today, some are highly endangered."
                    lblSignal.Visible = False
                End If

            Else
                page = 0
                lblDescription.Font = New Font("Tw Cen MT Condensed", 14.25)
            End If

            If picKohina.Bounds.IntersectsWith(picCarrots.Bounds) Then
                displayText = "Wow. A perfectly normal purple carrot bush."

                If e.KeyCode = Keys.A Then
                    Threading.Thread.Sleep(100)
                    If carrotObtained = True Then
                        frmMinigameTicTacToe.Show()
                        Me.Close()
                    ElseIf carrotObtained = False Then
                        frmMinigameTicTacToe.Show()
                        Me.Close()
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRight.Bounds) Then
                displayText = "This path leads to nothing. It is almost like someone didn't have enough time to continue this path."
                lblSignal.Visible = False
            End If

            If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Then
                displayText = "Go left"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    frmOutsideHouse.picKohina.Location = New Point(617, 259)
                    frmOutsideHouse.picKohina.Image = My.Resources.kohina_left
                    openForm = frmOutsideHouse
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
            Me.Close()
            tickFade = 0
        End If

        Me.Opacity -= 0.1
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
        lblDescription.Text = ""
        If displayText <> lblDescription.Text Then
            lblDescription.Text = ""
            tmrDisplayText.Start()
        End If
    End Sub
End Class