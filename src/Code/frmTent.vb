Imports System.IO

Public Class frmTent
    Dim moneyObtained, papersObtained, keyObtained, firstOpen As Boolean
    Dim walking As Integer = 1

    Private Sub frmTent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("TENT PAPERS") Or currentItemsObtained.Contains("TENT PAPERS") Then
            papersObtained = True
            Me.BackgroundImage = My.Resources.tentNoPapers
        Else
            papersObtained = False
            Me.BackgroundImage = My.Resources.tentPapers
        End If

        If itemsObtained.Contains("TENT 20 YEN") Or currentItemsObtained.Contains("TENT 20 YEN") Then
            moneyObtained = True
        Else
            moneyObtained = False
        End If

        If itemsObtained.Contains("KEY") Or currentItemsObtained.Contains("KEY") Then
            keyObtained = True
        Else
            keyObtained = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(431, 71)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmTent_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, Me, frmRightTown, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picWall.Bounds) Or picKohina.Bounds.IntersectsWith(picWall2.Bounds) Or picKohina.Bounds.IntersectsWith(picWall3.Bounds) Or
           picKohina.Bounds.IntersectsWith(picWall4.Bounds) Or picKohina.Bounds.IntersectsWith(picWall5.Bounds) Or
           picKohina.Bounds.IntersectsWith(picLamp.Bounds) Or picKohina.Bounds.IntersectsWith(picSuitCase.Bounds) Or
           picKohina.Bounds.IntersectsWith(picChest.Bounds) Or picKohina.Bounds.IntersectsWith(picDude.Bounds) Or picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picWall2.Bounds) Or picKohina.Bounds.IntersectsWith(picLamp.Bounds) Or
               picKohina.Bounds.IntersectsWith(picDude.Bounds) And picKohina.Bounds.Top < picDude.Bounds.Bottom Or
               picKohina.Bounds.IntersectsWith(picChest.Bounds) And picKohina.Bounds.Top < picChest.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall4.Bounds) Or picKohina.Bounds.IntersectsWith(picWall5.Bounds) Or picKohina.Bounds.IntersectsWith(picOutside.Bounds) Or
               picKohina.Bounds.IntersectsWith(picSuitCase.Bounds) And picKohina.Bounds.Bottom > picSuitCase.Bounds.Top Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall.Bounds) Or picKohina.Bounds.IntersectsWith(picDude.Bounds) And picKohina.Bounds.Left < picDude.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picLamp.Bounds) And picKohina.Bounds.Left < picLamp.Bounds.Right Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picWall3.Bounds) Or picKohina.Bounds.IntersectsWith(picChest.Bounds) And picKohina.Bounds.Left < picChest.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picSuitCase.Bounds) And picKohina.Bounds.Left < picSuitCase.Bounds.Right Then

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
                    picInu.Location = New Point(431, 71)
                End If

            Else
                stepCount += 1
            End If

            lblSignal.Visible = False
            lblDescription.Visible = False
            lblDescription.Text = ""
            displayText = ""

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

        If picKohina.Bounds.IntersectsWith(picLamp.Bounds) Or picKohina.Bounds.IntersectsWith(picSuitCase.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Or
           picKohina.Bounds.IntersectsWith(picChest.Bounds) Or picKohina.Bounds.IntersectsWith(picDude.Bounds) Or picKohina.Bounds.IntersectsWith(picInstructions.Bounds) Or
           picKohina.Bounds.IntersectsWith(picRock.Bounds) Or picKohina.Bounds.IntersectsWith(picOutside.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True

            If picKohina.Bounds.IntersectsWith(picLamp.Bounds) Then
                displayText = "A fire hazard"
                lblSignal.Visible = False
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

            If picKohina.Bounds.IntersectsWith(picSuitCase.Bounds) Then
                displayText = "This suitcase is bigger than me"
                lblSignal.Visible = False
            End If

            If picKohina.Bounds.IntersectsWith(picDude.Bounds) Then
                displayText = "A caterpillar man"
                lblSignal.Visible = False
            End If

            If picKohina.Bounds.IntersectsWith(picOutside.Bounds) Then
                displayText = "Go outside"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    frmOutsideHouse.picKohina.Location = New Point(132, 217)
                    frmOutsideHouse.picKohina.Image = My.Resources.kohina_front
                    openForm = frmOutsideHouse
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picChest.Bounds) Then
                displayText = "A treasure chest in a tent"

                If e.KeyCode = Keys.A Then
                    displayText = "Open chest"

                    If keyObtained = True Then
                        tmrTransition.Start()
                        openForm = frmRhythm
                    Else
                        displayText = "Locked..."
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picInstructions.Bounds) Then

                If papersObtained = False Then
                    lblSignal.Visible = True
                    lblDescription.Visible = True
                    displayText = "Wow! A picture of my stove"

                    If e.KeyCode = Keys.A Then
                        displayText = "You obtained stove instructions"
                        lblSignal.Visible = False
                        currentItemsObtained(numberOfItems) = "TENT PAPERS"
                        numberOfItems += 1
                        papersObtained = True
                        Me.BackgroundImage = My.Resources.tentNoPapers
                    End If

                Else
                    lblSignal.Visible = False
                    lblDescription.Visible = False
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picRock.Bounds) Then
                lblSignal.Visible = True
                lblDescription.Visible = True
                displayText = "A mysterious dark pile"

                If e.KeyCode = Keys.A Then

                    If moneyObtained = True Then
                        displayText = "I shouldn't touch this anymore"
                    Else
                        yen += 20
                        item = My.Resources.yen
                        displayText = "You obtained ¥20"
                        lblSignal.Visible = False
                        currentItemsObtained(numberOfItems) = "TENT 20 YEN"
                        numberOfItems += 1
                        moneyObtained = True
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
        If displayText <> lblDescription.Text Then
            lblDescription.Text = ""
            tmrDisplayText.Start()
        End If
    End Sub
End Class