Imports System.IO
Public Class frmTreeHouse
    Dim noodlesObtained As Boolean
    Dim walking As Integer = 1

    Private Sub frmTreeHouse_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("NOODLES") Or currentItemsObtained.Contains("NOODLES") Then
            noodlesObtained = True
        Else
            noodlesObtained = False
        End If

        If gameWin = True And noodlesObtained = False Then
            gameWin = False
            lblDescription.Visible = True
            item = My.Resources.noodles
            lblDescription.Text = "Wow. I am surprised you won. Here are your noodles."
            currentItemsObtained(numberOfItems) = "NOODLES"
            numberOfItems += 1
            noodlesObtained = True
            frmItemsObtained.Show()
            Me.Enabled = False
            currentForm = Me
            picKallawenBig.Visible = True
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(630, 217)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmTreeHouse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, frmRightTown, frmLeftTown, Me, frmStore, frmKitchen}

        frmItemsObtained.Close()
        lblSignal.Visible = False
        lblDescription.Visible = False
        Me.Enabled = True
        picKallawenBig.Visible = False

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or picKohina.Bounds.IntersectsWith(picRight.Bounds) Or picKohina.Bounds.IntersectsWith(picTop.Bounds) Or picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or
           picKohina.Bounds.IntersectsWith(picBed.Bounds) Or picKohina.Bounds.IntersectsWith(picChocolate.Bounds) Or picKohina.Bounds.IntersectsWith(picBird.Bounds) Or
           picKohina.Bounds.IntersectsWith(picExit.Bounds) Or picKohina.Bounds.IntersectsWith(picKallawen.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picBottom.Bounds) Or picKohina.Bounds.IntersectsWith(picExit.Bounds) And picKohina.Bounds.Top < picExit.Bounds.Top Or
               picKohina.Bounds.IntersectsWith(picBed.Bounds) And picKohina.Bounds.Top > picBed.Bounds.Top Or picKohina.Bounds.IntersectsWith(picBird.Bounds) And picKohina.Bounds.Top > picBird.Bounds.Top Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picLeft.Bounds) Or
               picKohina.Bounds.IntersectsWith(picBird.Bounds) And picKohina.Bounds.Right > picBird.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picExit.Bounds) And picKohina.Bounds.Right > picExit.Bounds.Right Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRight.Bounds) Or picKohina.Bounds.IntersectsWith(picBed.Bounds) And picKohina.Bounds.Left < picBed.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picExit.Bounds) And picKohina.Bounds.Left < picExit.Bounds.Left Or picKohina.Bounds.IntersectsWith(picChocolate.Bounds) And picKohina.Bounds.Left < picChocolate.Bounds.Left Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTop.Bounds) Or picKohina.Bounds.IntersectsWith(picKallawen.Bounds) Or picKohina.Bounds.IntersectsWith(picChocolate.Bounds) And picKohina.Bounds.Bottom > picChocolate.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
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
                    picInu.Location = New Point(630, 217)
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

        If picKohina.Bounds.IntersectsWith(picBed.Bounds) Or picKohina.Bounds.IntersectsWith(picChocolate.Bounds) Or picKohina.Bounds.IntersectsWith(picBird.Bounds) Or
           picKohina.Bounds.IntersectsWith(picExit.Bounds) Or picKohina.Bounds.IntersectsWith(picKallawen.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picBed.Bounds) Then
                displayText = "Doesn't seem like a comfy bed."
            End If

            If picKohina.Bounds.IntersectsWith(picChocolate.Bounds) Then
                displayText = "Whould chocolate taste good in cup noodles?"
            End If

            If picKohina.Bounds.IntersectsWith(picBird.Bounds) Then
                displayText = "Pidgeon broth would be good with cup noodles."
            End If

            If picKohina.Bounds.IntersectsWith(picKallawen.Bounds) Then

                If noodlesObtained = False Then
                    displayText = "You are looking for some noodles? Well nothing in life is free! But if you beat my challenge, I will give you a bowl."

                    If e.KeyCode = Keys.A Then
                        tmrTransition.Start()
                        openForm = frmNoodleSortR1
                    End If

                Else
                    displayText = "Such a smart little girl."
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

            If picKohina.Bounds.IntersectsWith(picExit.Bounds) Then
                displayText = "Leave"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmTent
                    frmTent.picKohina.Location = New Point(546, 140)
                    frmTent.picKohina.Image = My.Resources.kohina_front
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