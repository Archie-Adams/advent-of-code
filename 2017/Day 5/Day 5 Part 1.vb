Module Module1

    Sub Main()

        FileOpen(1, My.Application.Info.DirectoryPath & "\input.txt", OpenMode.Input) ''Opens file
        Dim lstInput As New List(Of Integer) ''list for data in file
        Dim countOfFileLines As Integer = -1 'To counbt lines in file
        While Not EOF(1) ''loops through all of file
            lstInput.Add(LineInput(1))
            countOfFileLines += 1
        End While
        FileClose(1)

        Dim locationInList As Integer = 0
        Dim currentInstruction As Integer
        Dim countToGetOut As Integer = 0
        While Not locationInList > countOfFileLines
            currentInstruction = lstInput(locationInList) ''get instruction
            lstInput(locationInList) += 1 ''increment by 1
            locationInList = locationInList + currentInstruction ''use instruction
            countToGetOut += 1
            If locationInList > 1096 Then Exit While
            currentInstruction = lstInput(locationInList)
        End While

        MsgBox(countToGetOut)

    End Sub

End Module