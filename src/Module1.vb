Imports System.IO
Module Module1
    Public currentForm, openForm, inuLocation As Form
    Public inuForm() As Form = {frmBedroom, frmOutsideHouse, frmGarden, frmTent, frmRightTown, frmLeftTown, frmTreeHouse, frmStore, frmKitchen}
    Public yen, numberOfItems, stepCount, inuSteps, inuTake, tickFade, inuItems As Integer
    Public Const walkingSpeed As Integer = 3.5
    Public currentItemsObtained(15), displayText, direction As String
    Public inventoryOpen, showInu, inuStole, gameWin, minigame, newGame As Boolean
    Public item As Bitmap
    Public rand As New Random
End Module
