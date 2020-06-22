' https://adventofcode.com/2017/day/4
' Archie Adams - 20/06/2020

imports System.IO.File
Imports System.Collections.Generic

Module Module1

    Sub Main()
        
        Dim acceptedPasscodes As Integer = 0

        For Each line In ReadAllLines("input.txt").ToList

            ' Split line on spaces to an array.
            dim words as string()
            words = line.split(new string() {" "}, stringsplitoptions.none)

            ' Check if all values in the array are unique.
            dim matchingWords as boolean = false
            for x = 0 to words.count - 1
                for i = 0 to words.count - 1
                    if words(x) = words(i) and x <> i then 
                        matchingWords = true
                        exit for
                    end if
                next
                if matchingWords then exit for
            next

            if matchingWords = false then acceptedPasscodes += 1            

        next  

        console.writeline(acceptedPasscodes)

    End Sub

End Module