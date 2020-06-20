Imports System.IO.File
Imports System.Collections.Generic

Module Module1

    Sub Main()

        dim fileContents as List(of String) = ReadAllLines("input.csv").ToList
        dim checkSum as Integer = 0

        for i = 0 To 15 ' For each line of the file.
            dim item as String() = fileContents(i).Split(",")
            dim largest as Integer = 0
            dim smallest as Integer = 99999
                for x = 0 to 15 ' For each number in the line.
                    if item(x) > largest then largest = item(x)
                    if item(x) < smallest then smallest = item(x)
                next
                checkSum += largest - smallest
        next

        Console.WriteLine(checkSum)

    End Sub

End Module