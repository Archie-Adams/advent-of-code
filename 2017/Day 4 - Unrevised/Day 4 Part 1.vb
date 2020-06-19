Module Module1

    Sub Main()

        Dim csvfile As String = My.Application.Info.DirectoryPath & "\input.txt" 'loaction of file
        Dim filecontents As List(Of String) = System.IO.File.ReadAllLines(csvfile).ToList 'Every line of text file in list
        Dim numberOfAcceptedPasscodes As Integer = 0 'var to count how many are accepted

        For Each item In filecontents 'loops for every line of file

            Dim boolNotAccepted As Boolean = False
            Dim noOfSpaces As Integer = CountCharacter(item, " ") 'finds out how man spaces are in that line
            Dim splitters As String() = item.Split(" ") 'char to split the string at
            Dim arrOfWordsInLine(noOfSpaces) As String 'array to store each word in the line

            For i = 0 To noOfSpaces
                arrOfWordsInLine(i) = splitters(i) 'places all of words on line into array
            Next

            For a = 0 To noOfSpaces 'loops the length of the array
                Dim wordToCheckAgainst As String = arrOfWordsInLine(a)
                Dim wordToCheckAgainstIndex As Integer = a

                For b = 0 To noOfSpaces
                    If wordToCheckAgainst = arrOfWordsInLine(b) And b <> wordToCheckAgainstIndex Then boolNotAccepted = True : Exit For
                Next
                If boolNotAccepted = True Then Exit For

            Next
            If boolNotAccepted = False Then numberOfAcceptedPasscodes += 1

        Next

        MsgBox(numberOfAcceptedPasscodes)

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