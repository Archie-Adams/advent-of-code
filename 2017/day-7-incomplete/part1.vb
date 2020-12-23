' https://adventofcode.com/2017/day/7
' Archie Adams - 21/06/2020

Imports System.Collections.Generic
imports System.IO.File
Imports System.Text.RegularExpressions

Module Module1

    Sub Main()

    dim lstAllPrograms as new list(of string)
    dim lstHeldPrograms as new list(of string)
    
    for each line in ReadAllLines("input.txt").ToList

       dim s as string = regex.replace(line, "[^a-z]+", ", ")       
       dim programs as string() = s.split(", ")       

        ' For each program in the line.
        for i = 0 to programs.count - 1

            if not lstAllPrograms.contains(programs(i).trim) then 
                lstAllPrograms.add(programs(i).trim)
            end if

            ' If program is on its own it is being held.
            ' If program is not i = 0 it is being held.
            if programs.count() = 1 or i <> 0 then
                lstHeldPrograms.add(programs(i).trim)
            end if

        next
    next

    ' Find program that is not in lstHeldPrograms
    for each program in lstAllPrograms
        if not lstHeldPrograms.contains(program) then
            console.writeline(program)
        end if
    next

    End Sub

End Module