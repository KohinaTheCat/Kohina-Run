Public Class frmNoodleSortR2
    Dim isDragging As Boolean = False, isClick As Boolean = False
    Dim startPoint, firstPoint, lastPoint As Point
    Dim bowtiePoints, pennePoints, shellPoints, spiralPoints As Integer
    Dim seconds As Integer = 18

    Private Sub tmrRound2_Tick(sender As Object, e As EventArgs) Handles tmrRound2.Tick
        lblTime.Text = seconds
        seconds -= 1

        If picBowtie1.Visible = False And picBowtie2.Visible = False And
        picBowtie3.Visible = False And picBowtie4.Visible = False And picBowtie5.Visible = False And
        picPenne1.Visible = False And picPenne2.Visible = False And picPenne3.Visible = False And
        picPenne4.Visible = False And picPenne5.Visible = False And picShell1.Visible = False And
        picShell2.Visible = False And picShell3.Visible = False And picShell4.Visible = False And
        picShell5.Visible = False And picSpiral1.Visible = False And picSpiral2.Visible = False And
        picSpiral3.Visible = False And picSpiral4.Visible = False And picSpiral5.Visible = False Then
            lblTime.Text = seconds
            tmrRound2.Stop()
            MessageBox.Show("Round over" & vbNewLine & vbNewLine & "SUCCESS", "Round 2", MessageBoxButtons.OK)
            Me.Hide()
            frmNoodleSortR3.Show()
        End If

        If seconds = 0 Then
            lblTime.Text = seconds
            tmrRound2.Stop()
            MessageBox.Show("Round over" & vbNewLine & vbNewLine & "FAILED", "Round 3", MessageBoxButtons.OK)
            btnExit.PerformClick()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        tmrTransition.Start()
        frmNoodleSortR1.Close()

        If minigame = True Then
            openForm = frmMinigames
        Else
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.INEEDU8bit, AudioPlayMode.BackgroundLoop)
            openForm = frmTreeHouse
            frmTreeHouse.picKohina.Location = New Point(347, 140)
        End If

    End Sub

    'Mouse down
    Private Sub MouseDownProc(pointer As Point)
        firstPoint = pointer
        isDragging = True
    End Sub

    'Mouse movements
    Private Sub MouseMoveProc(picNoodle As PictureBox, pointer As Point)
        isClick = False
        picNoodle.Left += (pointer.X - startPoint.X)
        picNoodle.Top += (pointer.Y - startPoint.Y)
        startPoint = pointer
        lastPoint = pointer
    End Sub

    'Mouse up
    Private Sub MouseUpProc(picNoodle As PictureBox, lblNoodle As Label, ByRef points As Integer, lblPoints As Label, pointer As Point)
        isDragging = False

        If picNoodle.Bounds.IntersectsWith(lblNoodle.Bounds) Then
            picNoodle.Hide()
            points += 1
            lblPoints.Text = points
        End If

        If lastPoint = pointer Then
            isClick = True
        Else isClick = False
        End If
    End Sub

    'picBowtie1
    Private Sub picBowtie1_Click(sender As Object, e As EventArgs) Handles picBowtie1.Click
        isClick = True
    End Sub

    Private Sub picBowtie1_MouseDown(sender As Object, e As MouseEventArgs) Handles picBowtie1.MouseDown
        startPoint = picBowtie1.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picBowtie1_MouseMove(sender As Object, e As MouseEventArgs) Handles picBowtie1.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picBowtie1.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picBowtie1, EndPoint)
        End If
    End Sub

    Private Sub picBowtie1_MouseUp(sender As Object, e As MouseEventArgs) Handles picBowtie1.MouseUp
        MouseUpProc(picBowtie1, lblBowtie, bowtiePoints, lblBowtiePoints, startPoint)
    End Sub

    'picBowtie2
    Private Sub picBowtie2_Click(sender As Object, e As EventArgs) Handles picBowtie2.Click
        isClick = True
    End Sub

    Private Sub picBowtie2_MouseDown(sender As Object, e As MouseEventArgs) Handles picBowtie2.MouseDown
        startPoint = picBowtie2.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picBowtie2_MouseMove(sender As Object, e As MouseEventArgs) Handles picBowtie2.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picBowtie2.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picBowtie2, EndPoint)
        End If
    End Sub

    Private Sub picBowtie2_MouseUp(sender As Object, e As MouseEventArgs) Handles picBowtie2.MouseUp
        MouseUpProc(picBowtie2, lblBowtie, bowtiePoints, lblBowtiePoints, startPoint)
    End Sub

    'picBowtie3
    Private Sub picBowtie3_Click(sender As Object, e As EventArgs) Handles picBowtie3.Click
        isClick = True
    End Sub

    Private Sub picBowtie3_MouseDown(sender As Object, e As MouseEventArgs) Handles picBowtie3.MouseDown
        startPoint = picBowtie3.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picBowtie3_MouseMove(sender As Object, e As MouseEventArgs) Handles picBowtie3.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picBowtie3.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picBowtie3, EndPoint)
        End If
    End Sub

    Private Sub picBowtie3_MouseUp(sender As Object, e As MouseEventArgs) Handles picBowtie3.MouseUp
        MouseUpProc(picBowtie3, lblBowtie, bowtiePoints, lblBowtiePoints, startPoint)
    End Sub

    'picBowtie4
    Private Sub picBowtie4_Click(sender As Object, e As EventArgs) Handles picBowtie4.Click
        isClick = True
    End Sub

    Private Sub picBowtie4_MouseDown(sender As Object, e As MouseEventArgs) Handles picBowtie4.MouseDown
        startPoint = picBowtie4.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picBowtie4_MouseMove(sender As Object, e As MouseEventArgs) Handles picBowtie4.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picBowtie4.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picBowtie4, EndPoint)
        End If
    End Sub

    Private Sub picBowtie4_MouseUp(sender As Object, e As MouseEventArgs) Handles picBowtie4.MouseUp
        MouseUpProc(picBowtie4, lblBowtie, bowtiePoints, lblBowtiePoints, startPoint)
    End Sub

    'picBowtie5
    Private Sub picBowtie5_Click(sender As Object, e As EventArgs) Handles picBowtie5.Click
        isClick = True
    End Sub

    Private Sub picBowtie5_MouseDown(sender As Object, e As MouseEventArgs) Handles picBowtie5.MouseDown
        startPoint = picBowtie5.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picBowtie5_MouseMove(sender As Object, e As MouseEventArgs) Handles picBowtie5.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picBowtie5.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picBowtie5, EndPoint)
        End If
    End Sub

    Private Sub picBowtie5_MouseUp(sender As Object, e As MouseEventArgs) Handles picBowtie5.MouseUp
        MouseUpProc(picBowtie5, lblBowtie, bowtiePoints, lblBowtiePoints, startPoint)
    End Sub

    'picPenne1
    Private Sub picPenne1_Click(sender As Object, e As EventArgs) Handles picPenne1.Click
        isClick = True
    End Sub

    Private Sub picPenne1_MouseDown(sender As Object, e As MouseEventArgs) Handles picPenne1.MouseDown
        startPoint = picPenne1.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picPenne1_MouseMove(sender As Object, e As MouseEventArgs) Handles picPenne1.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picPenne1.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picPenne1, EndPoint)
        End If
    End Sub

    Private Sub picPenne1_MouseUp(sender As Object, e As MouseEventArgs) Handles picPenne1.MouseUp
        MouseUpProc(picPenne1, lblPenne, pennePoints, lblPennePoints, startPoint)
    End Sub

    'picPenne2
    Private Sub picPenne2_Click(sender As Object, e As EventArgs) Handles picPenne2.Click
        isClick = True
    End Sub

    Private Sub picPenne2_MouseDown(sender As Object, e As MouseEventArgs) Handles picPenne2.MouseDown
        startPoint = picPenne2.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picPenne2_MouseMove(sender As Object, e As MouseEventArgs) Handles picPenne2.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picPenne2.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picPenne2, EndPoint)
        End If
    End Sub

    Private Sub picPenne2_MouseUp(sender As Object, e As MouseEventArgs) Handles picPenne2.MouseUp
        MouseUpProc(picPenne2, lblPenne, pennePoints, lblPennePoints, startPoint)
    End Sub

    'picPenne3
    Private Sub picPenne3_Click(sender As Object, e As EventArgs) Handles picPenne3.Click
        isClick = True
    End Sub

    Private Sub picPenne3_MouseDown(sender As Object, e As MouseEventArgs) Handles picPenne3.MouseDown
        startPoint = picPenne3.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picPenne3_MouseMove(sender As Object, e As MouseEventArgs) Handles picPenne3.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picPenne3.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picPenne3, EndPoint)
        End If
    End Sub

    Private Sub picPenne3_MouseUp(sender As Object, e As MouseEventArgs) Handles picPenne3.MouseUp
        MouseUpProc(picPenne3, lblPenne, pennePoints, lblPennePoints, startPoint)
    End Sub

    'picPenne4
    Private Sub picPenne4_Click(sender As Object, e As EventArgs) Handles picPenne4.Click
        isClick = True
    End Sub

    Private Sub picPenne4_MouseDown(sender As Object, e As MouseEventArgs) Handles picPenne4.MouseDown
        startPoint = picPenne4.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picPenne4_MouseMove(sender As Object, e As MouseEventArgs) Handles picPenne4.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picPenne4.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picPenne4, EndPoint)
        End If
    End Sub

    Private Sub picPenne4_MouseUp(sender As Object, e As MouseEventArgs) Handles picPenne4.MouseUp
        MouseUpProc(picPenne4, lblPenne, pennePoints, lblPennePoints, startPoint)
    End Sub

    'picPenne5
    Private Sub picPenne5_Click(sender As Object, e As EventArgs) Handles picPenne5.Click
        isClick = True
    End Sub

    Private Sub picPenne5_MouseDown(sender As Object, e As MouseEventArgs) Handles picPenne5.MouseDown
        startPoint = picPenne5.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picPenne5_MouseMove(sender As Object, e As MouseEventArgs) Handles picPenne5.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picPenne5.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picPenne5, EndPoint)
        End If
    End Sub

    Private Sub picPenne5_MouseUp(sender As Object, e As MouseEventArgs) Handles picPenne5.MouseUp
        MouseUpProc(picPenne5, lblPenne, pennePoints, lblPennePoints, startPoint)
    End Sub

    'picShell1
    Private Sub picShell1_Click(sender As Object, e As EventArgs) Handles picShell1.Click
        isClick = True
    End Sub

    Private Sub picShell1_MouseDown(sender As Object, e As MouseEventArgs) Handles picShell1.MouseDown
        startPoint = picShell1.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picShell1_MouseMove(sender As Object, e As MouseEventArgs) Handles picShell1.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picShell1.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picShell1, EndPoint)
        End If
    End Sub

    Private Sub picShell1_MouseUp(sender As Object, e As MouseEventArgs) Handles picShell1.MouseUp
        MouseUpProc(picShell1, lblShell, shellPoints, lblShellPoints, startPoint)
    End Sub

    'picShell2
    Private Sub picShell2_Click(sender As Object, e As EventArgs) Handles picShell2.Click
        isClick = True
    End Sub

    Private Sub picShell2_MouseDown(sender As Object, e As MouseEventArgs) Handles picShell2.MouseDown
        startPoint = picShell2.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picShell2_MouseMove(sender As Object, e As MouseEventArgs) Handles picShell2.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picShell2.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picShell2, EndPoint)
        End If
    End Sub

    Private Sub picShell2_MouseUp(sender As Object, e As MouseEventArgs) Handles picShell2.MouseUp
        MouseUpProc(picShell2, lblShell, shellPoints, lblShellPoints, startPoint)
    End Sub

    'picShell3
    Private Sub picShell3_Click(sender As Object, e As EventArgs) Handles picShell3.Click
        isClick = True
    End Sub

    Private Sub picShell3_MouseDown(sender As Object, e As MouseEventArgs) Handles picShell3.MouseDown
        startPoint = picShell3.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picShell3_MouseMove(sender As Object, e As MouseEventArgs) Handles picShell3.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picShell3.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picShell3, EndPoint)
        End If
    End Sub

    Private Sub picShell3_MouseUp(sender As Object, e As MouseEventArgs) Handles picShell3.MouseUp
        MouseUpProc(picShell3, lblShell, shellPoints, lblShellPoints, startPoint)
    End Sub

    'picShell4
    Private Sub picShell4_Click(sender As Object, e As EventArgs) Handles picShell4.Click
        isClick = True
    End Sub

    Private Sub picShell4_MouseDown(sender As Object, e As MouseEventArgs) Handles picShell4.MouseDown
        startPoint = picShell4.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picShell4_MouseMove(sender As Object, e As MouseEventArgs) Handles picShell4.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picShell4.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picShell4, EndPoint)
        End If
    End Sub

    Private Sub picShell4_MouseUp(sender As Object, e As MouseEventArgs) Handles picShell4.MouseUp
        MouseUpProc(picShell4, lblShell, shellPoints, lblShellPoints, startPoint)
    End Sub

    'picShell5
    Private Sub picShell5_Click(sender As Object, e As EventArgs) Handles picShell5.Click
        isClick = True
    End Sub

    Private Sub picShell5_MouseDown(sender As Object, e As MouseEventArgs) Handles picShell5.MouseDown
        startPoint = picShell5.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picShell5_MouseMove(sender As Object, e As MouseEventArgs) Handles picShell5.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picShell5.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picShell5, EndPoint)
        End If
    End Sub

    Private Sub picShell5_MouseUp(sender As Object, e As MouseEventArgs) Handles picShell5.MouseUp
        MouseUpProc(picShell5, lblShell, shellPoints, lblShellPoints, startPoint)
    End Sub

    'picSpiral1
    Private Sub picSpiral1_Click(sender As Object, e As EventArgs) Handles picSpiral1.Click
        isClick = True
    End Sub

    Private Sub picSpiral1_MouseDown(sender As Object, e As MouseEventArgs) Handles picSpiral1.MouseDown
        startPoint = picSpiral1.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picSpiral1_MouseMove(sender As Object, e As MouseEventArgs) Handles picSpiral1.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picSpiral1.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picSpiral1, EndPoint)
        End If
    End Sub

    Private Sub picSpiral1_MouseUp(sender As Object, e As MouseEventArgs) Handles picSpiral1.MouseUp
        MouseUpProc(picSpiral1, lblSpiral, spiralPoints, lblSpiralPoints, startPoint)
    End Sub

    'picSpiral2
    Private Sub picSpiral2_Click(sender As Object, e As EventArgs) Handles picSpiral2.Click
        isClick = True
    End Sub

    Private Sub picSpiral2_MouseDown(sender As Object, e As MouseEventArgs) Handles picSpiral2.MouseDown
        startPoint = picSpiral2.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picSpiral2_MouseMove(sender As Object, e As MouseEventArgs) Handles picSpiral2.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picSpiral2.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picSpiral2, EndPoint)
        End If
    End Sub

    Private Sub picSpiral2_MouseUp(sender As Object, e As MouseEventArgs) Handles picSpiral2.MouseUp
        MouseUpProc(picSpiral2, lblSpiral, spiralPoints, lblSpiralPoints, startPoint)
    End Sub

    'picSpiral3
    Private Sub picSpiral3_Click(sender As Object, e As EventArgs) Handles picSpiral3.Click
        isClick = True
    End Sub

    Private Sub picSpiral3_MouseDown(sender As Object, e As MouseEventArgs) Handles picSpiral3.MouseDown
        startPoint = picSpiral3.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picSpiral3_MouseMove(sender As Object, e As MouseEventArgs) Handles picSpiral3.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picSpiral3.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picSpiral3, EndPoint)
        End If
    End Sub

    Private Sub picSpiral3_MouseUp(sender As Object, e As MouseEventArgs) Handles picSpiral3.MouseUp
        MouseUpProc(picSpiral3, lblSpiral, spiralPoints, lblSpiralPoints, startPoint)
    End Sub

    'picSpiral4
    Private Sub picSpiral4_Click(sender As Object, e As EventArgs) Handles picSpiral4.Click
        isClick = True
    End Sub

    Private Sub picSpiral4_MouseDown(sender As Object, e As MouseEventArgs) Handles picSpiral4.MouseDown
        startPoint = picSpiral4.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picSpiral4_MouseMove(sender As Object, e As MouseEventArgs) Handles picSpiral4.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picSpiral4.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picSpiral4, EndPoint)
        End If
    End Sub

    Private Sub picSpiral4_MouseUp(sender As Object, e As MouseEventArgs) Handles picSpiral4.MouseUp
        MouseUpProc(picSpiral4, lblSpiral, spiralPoints, lblSpiralPoints, startPoint)
    End Sub

    'picSpiral5
    Private Sub picSpiral5_Click(sender As Object, e As EventArgs) Handles picSpiral5.Click
        isClick = True
    End Sub

    Private Sub picSpiral5_MouseDown(sender As Object, e As MouseEventArgs) Handles picSpiral5.MouseDown
        startPoint = picSpiral5.PointToScreen(New Point(e.X, e.Y))
        MouseDownProc(startPoint)
    End Sub

    Private Sub picSpiral5_MouseMove(sender As Object, e As MouseEventArgs) Handles picSpiral5.MouseMove
        If isDragging Then
            Dim EndPoint As Point = picSpiral5.PointToScreen(New Point(e.X, e.Y))
            MouseMoveProc(picSpiral5, EndPoint)
        End If
    End Sub

    Private Sub picSpiral5_MouseUp(sender As Object, e As MouseEventArgs) Handles picSpiral5.MouseUp
        MouseUpProc(picSpiral5, lblSpiral, spiralPoints, lblSpiralPoints, startPoint)
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

    Private Sub frmNoodleSortR2_Load(sender As Object, e As EventArgs) Handles Me.Load
        MessageBox.Show("Get ready...", "Round 2", MessageBoxButtons.OK)
        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        End If
        tmrRound2.Start()
        seconds = 18
    End Sub
End Class