' https://adventofcode.com/2017/day/7
' Archie Adams - 

Imports System.Collections.Generic
imports System.IO.File
Imports System.Text.RegularExpressions

Module Module1

    structure program
        dim name as string
        dim weight as integer
    end structure

    Sub Main()

    dim lstAllPrograms as new list(of program)
    dim lstHeldProgramGroups as new list(of list(of program))
    
    for each line in ReadAllLines("input.txt").ToList

       dim s as string = regex.replace(line, "[^a-z0-9]+", ",")       
       dim programs as string() = s.split(",")       

       ' Add program and it weight to lstAllPrograms.
       dim p as program
       p.name = programs(0)
       p.weight = programs(1)
       lstAllPrograms.add(p)
       if programs(2) = "" then continue for

       ' List to store all the programs being held on this line.
       dim tempProgramGroup as new list(of program)

        ' For each program in the line after the weight.
        for i = 2 to programs.count - 1
            dim tempProgram as program
            tempProgram.name = programs(i)            
            tempProgramGroup.add(tempProgram)
        next

        lstHeldProgramGroups.add(tempProgramGroup)
    next

    'msgbox(lstAllPrograms(0).name)
    'msgbox(lstAllPrograms(0).weight)

    ' Find out which program in lstHeldProgramGroups dosn't have the same
    ' weight as the ones in its group, return the other programs weight.
    for i = 0 to lstHeldProgramGroups.count - 1
        for x = 0 to lstHeldProgramGroups(i).count - 1
            'msgbox(lstHeldProgramGroups(i)(x).name)
            msgbox(lstAllPrograms().name.find(lstHeldProgramGroups(i)(x).name))
        next
    next

    End Sub

End Module