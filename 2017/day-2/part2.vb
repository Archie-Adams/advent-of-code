' https://adventofcode.com/2017/day/2
' Archie Adams - 20/06/2020

Imports System.IO.File
Imports System.Collections.Generic

Module Module1

    Sub Main()

        dim total as Integer = 0
        dim fileContents as List(of String) = ReadAllLines("input.csv").ToList

        for i = 0 To 15 ' For each line of the file.
            dim item as String() = fileContents(i).Split(",")

                for x = 0 to 15 ' For each item of the line.
                    dim foundLinesValue as Boolean = False

                    for z = 0 to 15 ' Compare to every other item.
                        if item(x) <> item(z) then
                            if item(x) Mod item(z) = 0 then
                                total += item(x) / item(z)
                                foundLinesValue = True
                                exit for
                            end if
                        end if
                    next

                    if foundLinesValue = True then exit for
                next
        next

        Console.WriteLine(total)

    End Sub

End Module