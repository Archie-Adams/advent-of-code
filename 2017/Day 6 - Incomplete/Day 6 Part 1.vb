Module Module1

    Structure Memory
        Dim locations As List(Of Integer)
    End Structure

    Structure ValueToChange
        Dim value As Integer
        Dim index As Integer
    End Structure

    Sub Main()

        Dim csvfile As String = My.Application.Info.DirectoryPath & "\input.txt"
        Dim filecontents As List(Of String) = System.IO.File.ReadAllLines(csvfile).ToList 'Every line of text file in list
        Dim splitters As String() = filecontents(0).Split(",")

        Dim lstMemorySaves As New List(Of String) ''list to save all memory configurations to check against fro infinate loop
        Dim currentMemory As Memory ''current form of memory
        currentMemory.locations = New List(Of Integer) ''declares list so no error

        For i = 0 To 15
            currentMemory.locations.Add(splitters(i)) ''loads input data from file
        Next

        'Dim lolRndVarName As Memory
        'lolRndVarName.locations = New List(Of Integer)
        'lolRndVarName.locations = currentMemory.locations
        'lstMemorySaves.Add(lolRndVarName) ''adds current memory locations

        Dim boolLoopStop As Boolean = False ''to stop after infinate loop is found
        Dim count As Integer = 0 ''for counting iterations of loop
        While boolLoopStop = False

            lstMemorySaves.Add(currentMemory.locations(0) & currentMemory.locations(1) & currentMemory.locations(2) & currentMemory.locations(3) & currentMemory.locations(4) & currentMemory.locations(5) & currentMemory.locations(6) & currentMemory.locations(7) & currentMemory.locations(8) & currentMemory.locations(9) & currentMemory.locations(10) & currentMemory.locations(11) & currentMemory.locations(12) & currentMemory.locations(13) & currentMemory.locations(14) & currentMemory.locations(15) & currentMemory.locations(15))
            ''MsgBox(lstMemorySaves(0))
            'currentMemory = New Memory
            'currentMemory.locations = lstMemorySaves(count).locations

            If currentMemory.locations(0) & currentMemory.locations(1) & currentMemory.locations(2) & currentMemory.locations(3) & currentMemory.locations(4) & currentMemory.locations(5) & currentMemory.locations(6) & currentMemory.locations(7) & currentMemory.locations(8) & currentMemory.locations(9) & currentMemory.locations(10) & currentMemory.locations(11) & currentMemory.locations(12) & currentMemory.locations(13) & currentMemory.locations(14) & currentMemory.locations(15) & currentMemory.locations(15) = "109876543110151413111212" Then

                MsgBox("do a breakpoint")

            End If



            ''Get value to change
            Dim valueToChange As ValueToChange
            For i = 0 To currentMemory.locations.Count - 1 ''all memory values
                If i = 0 Then valueToChange.value = currentMemory.locations(i) : valueToChange.index = i ''fills first time
                If currentMemory.locations(i) > valueToChange.value Then ''> not >= bc lower wins
                    valueToChange.value = currentMemory.locations(i)
                    valueToChange.index = i
                End If
            Next

            '' MsgBox(valueToChange.index)

            Dim toReDist As Integer = valueToChange.value
            currentMemory.locations(valueToChange.index) = 0
            Dim targetIndex As Integer = valueToChange.index + 1
            While toReDist <> 0

                If targetIndex = 16 Then targetIndex = 0
                currentMemory.locations(targetIndex) += 1

                targetIndex += 1
                toReDist -= 1

            End While
            count += 1

            If lstMemorySaves.Contains(currentMemory.locations(0) & currentMemory.locations(1) & currentMemory.locations(2) & currentMemory.locations(3) & currentMemory.locations(4) & currentMemory.locations(5) & currentMemory.locations(6) & currentMemory.locations(7) & currentMemory.locations(8) & currentMemory.locations(9) & currentMemory.locations(10) & currentMemory.locations(11) & currentMemory.locations(12) & currentMemory.locations(13) & currentMemory.locations(14) & currentMemory.locations(15) & currentMemory.locations(15)) Then boolLoopStop = True : MsgBox(currentMemory.locations(0) & currentMemory.locations(1) & currentMemory.locations(2) & currentMemory.locations(3) & currentMemory.locations(4) & currentMemory.locations(5) & currentMemory.locations(6) & currentMemory.locations(7) & currentMemory.locations(8) & currentMemory.locations(9) & currentMemory.locations(10) & currentMemory.locations(11) & currentMemory.locations(12) & currentMemory.locations(13) & currentMemory.locations(14) & currentMemory.locations(15) & currentMemory.locations(15))

            'For Each item In lstMemorySaves
            '    Dim noOfEqualDigits As Integer = 0
            '    For i = 0 To 3

            '        If item.locations(i) = currentMemory.locations(i) Then
            '            noOfEqualDigits += 1
            '        End If


            '    Next
            '    If noOfEqualDigits = 4 Then boolLoopStop = True
            'Next

            ''currentMemory.locations.Clear()
            ''currentMemory.locations = lstMemorySaves(count - 1).locations
        End While

        MsgBox(count)


    End Sub

End Module