' https://adventofcode.com/2017/day/1
' Archie Adams - 19/06/2020

Imports System.IO.File

Module Module1

    Sub Main()
        
        dim input() as Char = readalltext("input.txt").ToCharArray
        dim totalSum as Integer = 0

        ' Sums all identical adjacent numbers in input().
        for i = 0 to input.Count - 2            
            if input(i) = input(i + 1) then totalSum += CInt(CStr(input(i)))
        next

        ' Circular list so checks first and last numbers.
        if input(0) = input(input.Count - 1) then 
            totalSum += CInt(CStr(input(0)))
        end if

        Console.WriteLine(totalSum)

    End Sub

End Module