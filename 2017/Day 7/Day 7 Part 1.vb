Module Module1

    Structure item
        Dim itemName As String
        Dim itemBelowName As String
        Dim itemAboveNames As List(Of String)
        Dim weight As Integer
    End Structure

    Dim lstStrucItems As New List(Of item)

    Sub Main()

        loadData()

        For i = 0 To lstStrucItems.Count - 1 ''Loops all items
            If lstStrucItems(i).itemAboveNames.Count <> 0 Then ''checks if array is empty so dosnt throw error
                For x = 0 To lstStrucItems(i).itemAboveNames.Count - 1 ''loops all item in array

                    Dim targetItemIndex As Integer = findItemIndex(lstStrucItems(i).itemAboveNames(x)) ''index of the target item in lstStrucItems
                    lstStrucItems(targetItemIndex).itemBelowName = lstStrucItems(i).itemName

                Next
            End If
        Next

        For Each item In lstStrucItems
            If item.itemBelowName = Nothing Then MsgBox(item.itemName) ''The bottom item of the tree
        Next

    End Sub

    Function findItemIndex(itemName As String)

        For i = 0 To lstStrucItems.Count - 1
            If lstStrucItems(i).itemName = itemName Then Return i
        Next

        Return -1 ''returns erronus valuue to remove error warning

    End Function

    Sub loadData()

        ''Gets all lines of file into lstOfAllFile
        Dim lstOfAllFile As New List(Of String)
        FileOpen(1, My.Application.Info.DirectoryPath & "\input.txt", OpenMode.Input)
        While Not EOF(1)
            lstOfAllFile.Add(LineInput(1))
        End While
        FileClose(1)


        For i = 0 To lstOfAllFile.Count - 1
            Dim chrArrCurrentLine() As Char = lstOfAllFile(i).ToCharArray
            Dim currentItem As New item
            currentItem.itemAboveNames = New List(Of String)
            ''Gets currentItem.itemName          
            For Each item In chrArrCurrentLine
                If item = " " Then
                    Exit For
                Else
                    currentItem.itemName += item
                End If
            Next

            ''Vars for getting after arrow string
            Dim boolPassedArrow As Boolean = False
            Dim lstAfterArrow As New List(Of Char)

            ''var for getting weight
            Dim strTempWeight As String = Nothing

            For Each item In chrArrCurrentLine

                ''Adds all items from(and including) then space after the ->
                If boolPassedArrow = True Then
                    lstAfterArrow.Add(item)
                End If
                If item = ">" Then boolPassedArrow = True

                ''Gets currentItem.weight
                If IsNumeric(item) = True Then
                    strTempWeight += item
                End If

            Next
            currentItem.weight = CInt(strTempWeight) ''Adds weight to structure

            For x = 0 To lstAfterArrow.Count - 1
                lstAfterArrow.Remove(" ") ''Gets rid of all spaces
            Next

            Dim strAfterArrow As String = Nothing ''Turns list into string
            For Each item In lstAfterArrow
                strAfterArrow += item
            Next

            ''splits list into individual items and adds all items to main structure
            If strAfterArrow <> Nothing Then
                Dim splitters As String() = strAfterArrow.Split(",")
                For x = 0 To CountCharacter(strAfterArrow, ",")
                    currentItem.itemAboveNames.Add(splitters(x))
                Next
            End If

            currentItem.itemBelowName = Nothing

            lstStrucItems.Add(currentItem) ''Adds information from this line to the big list
        Next

    End Sub

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer ''counts number of char occurances in a string
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = ch Then
                cnt += 1
            End If
        Next
        Return cnt
    End Function

End Module