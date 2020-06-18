Imports System.IO
Module Module1

    '16

    Sub Main()

        Dim arrData(15, 15)

        Dim csvFile As String = My.Application.Info.DirectoryPath & "\INPUT.csv"
        Dim fileContents As List(Of String) = File.ReadAllLines(csvFile).ToList
        For i = 0 To 15
            Dim splitters As String() = fileContents(i).Split(",")
            arrData(i, 0) = splitters(0)
            arrData(i, 1) = splitters(1)
            arrData(i, 2) = splitters(2)
            arrData(i, 3) = splitters(3)
            arrData(i, 4) = splitters(4)
            arrData(i, 5) = splitters(5)
            arrData(i, 6) = splitters(6)
            arrData(i, 7) = splitters(7)
            arrData(i, 8) = splitters(8)
            arrData(i, 9) = splitters(9)
            arrData(i, 10) = splitters(10)
            arrData(i, 11) = splitters(11)
            arrData(i, 12) = splitters(12)
            arrData(i, 13) = splitters(13)
            arrData(i, 14) = splitters(14)
            arrData(i, 15) = splitters(15)
        Next

        Dim total As Integer = 0
        ''Dim checkSum As Integer = 0
        For i = 0 To 15 'Y 
            'Dim largest As Integer
            'Dim smallest As Integer
            Dim XToDivide As Integer
            Dim toggleExitFor As Boolean = False
            For b = 0 To 15 'X need to store which x i am dividing
                XToDivide = arrData(i, b)
                For c = 0 To 15 'each X 'need to divide by that x
                    If IsInteger(XToDivide / arrData(i, c)) = True And XToDivide / arrData(i, c) <> 1 Then
                        ''MsgBox("is an integer")
                        total += XToDivide / arrData(i, c)
                        toggleExitFor = True
                        Exit For
                    Else
                        ''MsgBox("is not an integer")
                    End If
                Next
                If toggleExitFor = True Then Exit For
                'If b = 0 Then largest = arrData(i, b) : smallest = arrData(i, b)
                'If largest < arrData(i, b) Then largest = arrData(i, b)
                'If smallest > arrData(i, b) Then smallest = arrData(i, b)
            Next
            'Dim difference As Integer = largest - smallest
            'checkSum += difference
        Next

        Console.WriteLine(total)
        Console.ReadLine()

    End Sub

    Public Function IsInteger(value As Object) As Boolean
        Dim output As Integer ' I am not using this by intent it is needed by the TryParse Method
        If (Integer.TryParse(value.ToString(), output)) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
