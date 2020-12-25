Imports System.IO

Public Class frmInventory
    Dim totalItems, itemsShown, numSlide As Integer
    Dim picture, inventoryPic(20) As Bitmap
    Dim showed(20), itemName, inventory(20) As String
    Dim itemsReader As StreamReader = File.OpenText("ITEMSTAKEN.txt")
    Dim itemsObtained As String = itemsReader.ReadToEnd
    Dim currentSlide As Integer = 1

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles Me.Load

        If itemsObtained.Contains("LIST") Or currentItemsObtained.Contains("LIST") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("KITCHEN LEEK") Or currentItemsObtained.Contains("KITCHEN LEEK") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("KITCHEN CHOPSTICKS") Or currentItemsObtained.Contains("KITCHEN CHOPSTICKS") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("OUTSIDE SHROOMS") Or currentItemsObtained.Contains("OUTSIDE SHROOMS") Then
            totalItems += 1
        End If

        If yen >= 1 Then
            totalItems += 1
        End If

        If itemsObtained.Contains("TENT PAPERS") Or currentItemsObtained.Contains("TENT PAPERS") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("RIGHT CARROT") Or currentItemsObtained.Contains("RIGHT CARROT") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("CHOCOLATE") Or currentItemsObtained.Contains("CHOCOLATE") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("MSG") Or currentItemsObtained.Contains("MSG") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("GARDEN TOFU") Or currentItemsObtained.Contains("GARDEN TOFU") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("GARDEN SEAWEED") Or currentItemsObtained.Contains("GARDEN SEAWEED") Then
            totalItems += 1
        End If

        If itemsObtained.Contains("NOODLES") Or currentItemsObtained.Contains("NOODLES") Then
            totalItems += 1
        End If

        numSlide = Math.Ceiling(totalItems / 4)

        slots()

        For i = 0 To 3
            itemName = inventory(i)
            picture = inventoryPic(i)
            display(itemName, picture, i)
        Next

        If totalItems >= 5 Then
            picRight.Visible = True
        End If

        If totalItems = 0 Then
            lblNothingPrompt.Visible = True
            lblSlides.Visible = False
        Else
            lblSlides.Visible = True
            lblNothingPrompt.Visible = False
        End If

        itemsReader.Close()
    End Sub

    Private Sub picLeft_Click(sender As Object, e As EventArgs) Handles picLeft.Click
        currentSlide -= 1

        If currentSlide = 1 Then

            For i = 0 To 3
                itemName = inventory(i)
                picture = inventoryPic(i)
                display(itemName, picture, i)
            Next

        End If

        If currentSlide = 2 Then

            For i = 4 To 7
                itemName = inventory(i)
                picture = inventoryPic(i)
                display(itemName, picture, i)
            Next

        End If

        picRight.Visible = True

        If currentSlide = 1 Then
            picItem1.SizeMode = PictureBoxSizeMode.StretchImage
            picLeft.Visible = False
            picRight.Visible = True
        Else
            picItem1.SizeMode = PictureBoxSizeMode.CenterImage
            picLeft.Visible = True
        End If

    End Sub

    Private Sub picRight_Click(sender As Object, e As EventArgs) Handles picRight.Click
        currentSlide += 1
        picItem1.SizeMode = PictureBoxSizeMode.CenterImage
        picLeft.Visible = True

        If currentSlide = 2 Then

            For i = 4 To 7
                itemName = inventory(i)
                picture = inventoryPic(i)
                display(itemName, picture, i)
            Next

        ElseIf currentSlide = 3 Then

            For i = 8 To 11
                itemName = inventory(i)
                picture = inventoryPic(i)
                display(itemName, picture, i)
            Next

        End If

        If currentSlide < numSlide Then
            picRight.Visible = True
        Else
            picRight.Visible = False
        End If

    End Sub

    Private Sub frmInventory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        inuItems = totalItems
        Me.Close()
        Array.Clear(showed, 0, showed.Length)
        totalItems = 0
    End Sub

    'this private sub displays the respective items in each slot
    Private Sub Display(itemname, picture, i)
        lblSlides.Text = currentSlide & "/" & numSlide

        If i = 0 Or i = 4 Or i = 8 Then
            picSlot1.Visible = True
            picItem1.Visible = True
            picItem1.Image = picture
            lblItem.Visible = True
            lblItem.Text = itemname
        End If
        If i = 1 Or i = 5 Or i = 9 Then
            lblItem2.Visible = True
            picItem2.Visible = True
            picSlot2.Visible = True
            picItem2.Image = picture
            lblItem2.Text = itemname
        End If
        If i = 2 Or i = 6 Or i = 10 Then
            lblItem3.Visible = True
            picItem3.Visible = True
            picSlot3.Visible = True
            picItem3.Image = picture
            lblItem3.Text = itemname
        End If
        If i = 3 Or i = 7 Or i = 11 Then
            lblItem4.Visible = True
            picItem4.Visible = True
            picSlot4.Visible = True
            picItem4.Image = picture
            lblItem4.Text = itemname
        End If

    End Sub

    'this private sub calls on the private sub call() and places the items the user has obtained into an array
    Private Sub Slots()

        For i = 0 To totalItems - 1
            check()
            inventory(i) = itemName
            inventoryPic(i) = picture
        Next

    End Sub

    'this private sub checks if the obtainable item was shown or not. If it was not it places it in an array to be displayed
    Private Sub Check()

        If (itemsObtained.Contains("LIST") Or currentItemsObtained.Contains("LIST")) And (showed.Contains("LIST")) = False Then
            picture = My.Resources.ingredients
            showed(itemsShown) = "LIST"
            itemName = "List of Ingriendents from Guugle"
        ElseIf (yen >= 1) And (showed.Contains("YEN") = False) Then
            picture = My.Resources.yen
            showed(itemsShown) = "YEN"
            itemName = "¥" & yen
        ElseIf (itemsObtained.Contains("KITCHEN LEEK") Or currentItemsObtained.Contains("KITCHEN LEEK")) And (showed.Contains("KITCHEN LEEK")) = False Then
            picture = My.Resources.leek
            showed(itemsShown) = "KITCHEN LEEK"
            itemName = "Leek"
        ElseIf (itemsObtained.Contains("KITCHEN CHOPSTICKS") Or currentItemsObtained.Contains("KITCHEN CHOPSTICKS")) And (showed.Contains("KITCHEN CHOPSTICKS")) = False Then
            picture = My.Resources.chopsticks
            showed(itemsShown) = "KITCHEN CHOPSTICKS"
            itemName = "Chopsticks"
        ElseIf (itemsObtained.Contains("OUTSIDE SHROOMS") Or currentItemsObtained.Contains("OUTSIDE SHROOMS")) And (showed.Contains("OUTSIDE SHROOMS")) = False Then
            picture = My.Resources.mushrooms
            showed(itemsShown) = "OUTSIDE SHROOMS"
            itemName = "Mushrooms"
        ElseIf (itemsObtained.Contains("TENT PAPERS") Or currentItemsObtained.Contains("TENT PAPERS")) And (showed.Contains("TENT PAPERS")) = False Then
            picture = My.Resources.iconkohina
            showed(itemsShown) = "TENT PAPERS"
            itemName = "Instructions"
        ElseIf (itemsObtained.Contains("RIGHT CARROT") Or currentItemsObtained.Contains("RIGHT CARROT")) And (showed.Contains("RIGHT CARROT")) = False Then
            picture = My.Resources.orange_carrot
            showed(itemsShown) = "RIGHT CARROT"
            itemName = "Carrots"
        ElseIf (itemsObtained.Contains("GARDEN TOFU") Or currentItemsObtained.Contains("GARDEN TOFU")) And (showed.Contains("GARDEN TOFU")) = False Then
            picture = My.Resources.tofu
            showed(itemsShown) = "GARDEN TOFU"
            itemName = "Tofu"
        ElseIf (itemsObtained.Contains("MSG") Or currentItemsObtained.Contains("MSG")) And (showed.Contains("MSG")) = False Then
            picture = My.Resources.msg
            showed(itemsShown) = "MSG"
            itemName = "MSG"
        ElseIf (itemsObtained.Contains("GARDEN SEAWEED") Or currentItemsObtained.Contains("GARDEN SEAWEED")) And (showed.Contains("GARDEN SEAWEED")) = False Then
            picture = My.Resources.seaweed
            showed(itemsShown) = "GARDEN SEAWEED"
            itemName = "Seaweed"
        ElseIf (itemsObtained.Contains("MSG") Or currentItemsObtained.Contains("MSG")) And (showed.Contains("MSG")) = False Then
            picture = My.Resources.msg
            showed(itemsShown) = "MSG"
            itemName = "Holy Flavour"
        ElseIf (itemsObtained.Contains("NOODLES") Or currentItemsObtained.Contains("NOODLES")) And (showed.Contains("NOODLES")) = False Then
            picture = My.Resources.noodles
            showed(itemsShown) = "NOODLES"
            itemName = "Noodles"
        ElseIf (itemsObtained.Contains("CHOCOLATE") Or currentItemsObtained.Contains("CHOCOLATE")) And (showed.Contains("CHOCOLATE")) = False Then
            If (itemsObtained.Contains("KEY") Or currentItemsObtained.Contains("KEY")) Then
                picture = My.Resources.key
                showed(itemsShown) = "KEY"
                itemName = "Key"
            Else
                picture = My.Resources.choco
                showed(itemsShown) = "CHOCOLATE"
                itemName = "Chocolate"
            End If
        End If

        itemsShown += 1

        If inuStole = True Then
            inventoryPic(inuTake) = My.Resources.creepyInuMeme
        End If

    End Sub

End Class