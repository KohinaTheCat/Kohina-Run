Public Class frmNoodleSortR1
    Dim isDragging As Boolean = False, isClick As Boolean = False
    Dim startPoint, firstPoint, lastPoint As Point
    Dim seconds, bowtiePoints, pennePoints As Integer

    Private Sub frmRound1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If minigame = False Then
            My.Computer.Audio.Stop()
            My.Computer.Audio.Play(My.Resources.FIRE8bit, AudioPlayMode.BackgroundLoop)
        End If
        Me.Controls.Clear()
        Me.InitializeComponent()
        MessageBox.Show("Get ready...", "Round 1", MessageBoxButtons.OK)
        tmrRound1.Start()
        seconds = 10
    End Sub

    Private Sub tmrRound1_Tick(sender As Object, e As EventArgs) Handles tmrRound1.Tick
        lblTime.Text = seconds
        seconds -= 1

        If picBowtie1.Visible = False And picBowtie2.Visible = False And picBowtie3.Visible = False And
        picBowtie4.Visible = False And picBowtie5.Visible = False And picPenne1.Visible = False And
        picPenne2.Visible = False And picPenne3.Visible = False And picPenne4.Visible = False And
        picPenne5.Visible = False Then
            lblTime.Text = seconds
            tmrRound1.Stop()
            MessageBox.Show("Round over" & vbNewLine & vbNewLine & "SUCCESS", "Round 1", MessageBoxButtons.OK)
            Me.Hide()
            frmNoodleSortR2.Show()
        End If

        If seconds = 0 Then
            lblTime.Text = seconds
            tmrRound1.Stop()
            MessageBox.Show("Round over" & vbNewLine & vbNewLine & "FAILED", "Round 1", MessageBoxButtons.OK)
            btnExit.PerformClick()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        tmrTransition.Start()
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


End Class