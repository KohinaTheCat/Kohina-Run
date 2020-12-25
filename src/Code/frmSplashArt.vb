'****************************************************************************************************
' PROGRAMME	:	Final Project: Kohina! Run
'  
' OUTLINE	: Kohina! Run is a RPG where the user plays as a little girl trying to find ingredients to
'             make cup noodles. The user has to travel around the town, beating mini-games to get ingredients.
'             While the user is searching for items, they have to beware Inugami. Inugame will randomly steal
'             one of user's items and hide somewhere in the town. In order to get back the item, you have to
'             find him. Once the user finds all the ingredients, the user will have to cook the food.   
' 
' PROGRAMMER:	Clara Chick, Jessica Bradley & Aparnna Hariharan
'
'  DATE		:	June 11, 2018
' **************************************************************************************************

Imports System.IO
Public Class frmSplashArt
    Private Sub frmSplashArt_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrLoad.Start()
    End Sub

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick

        If File.Exists("ENDING.txt") And File.Exists("INTRODUCTION.txt") And File.Exists("words.txt") And File.Exists("words.txt") Then
            progLoading.Increment(1)
        Else
            tmrLoad.Stop()
            MessageBox.Show("This game is missing important files. Please redownload the game at https://cluura.wordpress.com/", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

        If File.Exists("ITEMSTAKEN.txt") And File.Exists("SAVE.txt") And File.Exists("INVENTORY.txt") Then
            progLoading.Increment(1)
        Else
            'Kill("INVENTORY.txt")
            'Kill("ITEMSTAKEN.txt")
            'Kill("SAVE.txt")
            File.Create("INVENTORY.txt")
            File.Create("ITEMSTAKEN.txt")
            File.Create("SAVE.txt")
        End If

        If progLoading.Value = 100% Then
            frmStart.Show()
            Me.Close()
        End If
    End Sub
End Class