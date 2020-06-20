imports System.IO.File
Imports System.Collections.Generic

Module Module1

    Sub Main()
        
        Dim input As List(Of String) = ReadAllLines("input.txt").ToList
        Dim acceptedPasscodes As Integer = 0

        For Each line In input

            ' Split line on spaces to an array.
            dim words as string() = line.split(new string() {" "}, stringsplitoptions.none)

            ' Check if all values in the array are unique.
            dim matchingWords as boolean = false
            for x = 0 to words.count - 1
                for i = 0 to words.count - 1
                    if words(x) = words(i) and x <> i then 
                        matchingWords = true
                        exit for
                    end if
                next
                if matchingWords = true then exit for
            next

            if matchingWords = false then acceptedPasscodes += 1            

        next  

        console.writeline(acceptedPasscodes)

    End Sub

End Module