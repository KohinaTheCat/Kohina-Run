Imports System.IO
Public Class frmStore
    Dim chocolateObtained, unnpaidChoco As Boolean
    Dim itemBuy As String
    Dim walking As Integer = 1

    Private Sub frmStore_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
        Dim itemsObtained As String = itemsReader.ReadToEnd

        If itemsObtained.Contains("CHOCOLATE") Or currentItemsObtained.Contains("CHOCOLATE") Then
            chocolateObtained = True
        Else
            chocolateObtained = False
        End If

        If inuLocation Is Me Then
            picInu.Visible = True
            picInu.Location = New Point(368, 363)
        End If

        itemsReader.Close()
    End Sub

    Private Sub frmStore_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, Me, frmKitchen}

        If e.KeyCode = Keys.Escape Then
            currentForm = Me
            frmPauseMenu.Show()
        End If

        If e.KeyCode = Keys.S Then
            frmInventory.Show()
        End If

        If picKohina.Bounds.IntersectsWith(picBottomWall.Bounds) Or picKohina.Bounds.IntersectsWith(picLeftWall.Bounds) Or picKohina.Bounds.IntersectsWith(picRightWall.Bounds) Or picKohina.Bounds.IntersectsWith(picTopWall.Bounds) Or
            picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) Or picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) Or picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) Or
            picKohina.Bounds.IntersectsWith(picSign.Bounds) Or picKohina.Bounds.IntersectsWith(picCashier.Bounds) Or picKohina.Bounds.IntersectsWith(picExit.Bounds) Or picKohina.Bounds.IntersectsWith(picInu.Bounds) Then

            If picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) And picKohina.Bounds.Left < picShelfCupNoodles.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Left < picShelfChoco.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) And picKohina.Bounds.Left < picShelfSardines.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picRightWall.Bounds) Or picKohina.Bounds.IntersectsWith(picSign.Bounds) And picKohina.Bounds.Left < picSign.Bounds.Left Or
               picKohina.Bounds.IntersectsWith(picExit.Bounds) And picKohina.Bounds.Left < picExit.Bounds.Left Then

                If e.KeyCode = Keys.Left Then
                    GoLeft()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picBottomWall.Bounds) Or picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Top < picShelfChoco.Bounds.Top Or
               picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) And picKohina.Bounds.Top < picShelfCupNoodles.Bounds.Top Or picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) And picKohina.Bounds.Bottom > picShelfSardines.Bounds.Top Or
               picKohina.Bounds.IntersectsWith(picCashier.Bounds) And picKohina.Bounds.Bottom > picCashier.Bounds.Top Or picKohina.Bounds.IntersectsWith(picSign.Bounds) Or
               picKohina.Bounds.IntersectsWith(picCashier.Bounds) Then

                If e.KeyCode = Keys.Up Then
                    GoUp()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picTopWall.Bounds) Or picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Bottom > picShelfChoco.Bounds.Bottom Or
               picKohina.Bounds.IntersectsWith(picRightWall.Bounds) And picKohina.Bounds.Top < picRightWall.Bounds.Bottom Or picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) And picKohina.Bounds.Bottom > picShelfSardines.Bounds.Bottom Then

                If e.KeyCode = Keys.Down Then
                    GoDown()
                End If

            End If

            If picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) And picKohina.Bounds.Right > picShelfCupNoodles.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Right > picShelfChoco.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) And picKohina.Bounds.Right > picShelfSardines.Bounds.Right Or
               picKohina.Bounds.IntersectsWith(picLeftWall.Bounds) Then

                If e.KeyCode = Keys.Right Then
                    GoRight()
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
                    picInu.Location = New Point(368, 363)
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

        If picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Left < picShelfChoco.Bounds.Left Or picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) And picKohina.Bounds.Left < picShelfCupNoodles.Bounds.Left Or
            picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) Or picKohina.Bounds.IntersectsWith(picCashier.Bounds) Or picKohina.Bounds.IntersectsWith(picExit.Bounds) Or picKohina.Bounds.IntersectsWith(picinu.Bounds) Then

            lblSignal.Visible = True
            lblDescription.Visible = True


            If picKohina.Bounds.IntersectsWith(picShelfChoco.Bounds) And picKohina.Bounds.Left < picShelfChoco.Bounds.Left And itemBuy <> "choco" Then
                displayText = "Buy chocolate (¥30)"
                If e.KeyCode = Keys.A Then
                    If chocolateObtained = True Then
                        displayText = "nothing..."
                    ElseIf chocolateObtained = False And yen >= 30 Then
                        itemBuy = "choco"
                        displayText = "You took the chocolate off the shelf"
                        lblSignal.Visible = False
                    ElseIf yen < 30 Then
                        displayText = "Not enough money"
                    End If
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

            If picKohina.Bounds.IntersectsWith(picShelfSardines.Bounds) And picKohina.Bounds.Left < picShelfSardines.Bounds.Left Then
                displayText = "Disgusting. Sardines."
            End If

            If picKohina.Bounds.IntersectsWith(picShelfCupNoodles.Bounds) And picKohina.Bounds.Left < picShelfCupNoodles.Bounds.Left And itemBuy <> "cup" Then
                displayText = "Buy cup noodles (¥500)"

                If e.KeyCode = Keys.A Then

                    If yen < 500 Then
                        displayText = "ahhhhhhhhhhhhhhhhhhhhhhhhh. Not enough money"
                    ElseIf yen >= 500 Then
                        itemBuy = "cup"
                        displayText = "You took the cupnoodles off the shelf"
                        lblSignal.Visible = False
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picCashier.Bounds) And itemBuy <> "" Then
                displayText = "Pay"

                If e.KeyCode = Keys.A Then

                    If itemBuy = "choco" Then
                        yen -= 30
                        item = My.Resources.choco
                        currentItemsObtained(numberOfItems) = "CHOCOLATE"
                        numberOfItems += 1
                        chocolateObtained = True
                        frmItemsObtained.Show()
                        Me.Enabled = False
                        currentForm = Me
                        itemBuy = ""
                    End If

                End If

            End If

            If picKohina.Bounds.IntersectsWith(picExit.Bounds) And itemBuy <> "" Then
                displayText = "I have to pay"
                picKohina.Left -= 10
            ElseIf picKohina.Bounds.IntersectsWith(picExit.Bounds) And itemBuy = "" Then
                displayText = "Leave store"

                If e.KeyCode = Keys.A Then
                    tmrTransition.Start()
                    openForm = frmRightTown
                    frmRightTown.picKohina.Location = New Point(238, 200)
                    frmRightTown.picKohina.Image = My.Resources.kohina_front
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