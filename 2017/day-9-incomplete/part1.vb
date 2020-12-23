' https://adventofcode.com/2017/day/9
' Archie Adams - 

imports System.IO.File
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Module Module1

    Sub Main()

        dim input as string = readalltext("input.txt")

        ' Removes all negated characters and garbage.
        input = regex.replace(input, "!.{1}", "")
        input = regex.replace(input, "<(.*?)>", "")
        
        console.writeline(input)
        
        dim score as integer = 1
        dim nestLevel as integer = 1                 
        for i = 1 to input.count - 2
            
            if input(i) = "{" then
                if input(i - 1) <> "," then nestLevel += 1
                score += nestLevel
            else if input(i) = "}" and input(i + 1) <> "," then
                nestLevel -= 1
            end if
        next

        console.writeline(score)

    End Sub

End Module