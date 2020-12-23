' https://adventofcode.com/2017/day/8
' Archie Adams - 22/06/2020

Imports System.Collections.Generic
imports System.IO.File

Module Module1

    Sub Main()

        dim registers as new list(of string)
        dim registerValues as new list(of integer)
        dim largestValue as integer = -999999

        for each line in ReadAllLines("input.txt").ToList

            dim s as string() = line.split(" ") ' "b inc 5 if a > 1"
            ' s(0) is the register.
            ' s(1) is inc or dec.
            ' s(2) is the amount.
            ' s(3) is if.
            ' s(4) is condition register.
            ' s(5) is the operator.
            ' s(6) is the condition amount.

            ' If register has not been seen the add register to lists.
            if not registers.contains(s(0)) then
                registers.add(s(0))
                registerValues.add(0)
            end if
            if not registers.contains(s(4)) then
                registers.add(s(4))
                registerValues.add(0)
            end if

            ' If dec multiply amount by -1.
            if s(1) = "dec" then s(2) = cstr(cint(s(2)) * -1)

            ' Determine whether or not the condition is true.
            dim doOperation as boolean
            dim conditionRegisterValue as integer
            conditionRegisterValue = registerValues(registers.indexof(s(4)))
            select case s(5)
                case ">"
                    doOperation = conditionRegisterValue > cint(s(6))
                case ">="
                    doOperation = conditionRegisterValue >= cint(s(6))
                case "<"
                    doOperation = conditionRegisterValue < cint(s(6))
                case "<="
                    doOperation = conditionRegisterValue <= cint(s(6))
                case "=="
                    doOperation = conditionRegisterValue = cint(s(6))
                case "!="
                    doOperation = conditionRegisterValue <> cint(s(6))
            end select

            ' If the condition is true then change the registers value.
            if doOperation then
                registerValues(registers.indexof(s(0))) += cint(s(2))
                if registerValues(registers.indexof(s(0))) > largestValue then
                    largestValue = registerValues(registers.indexof(s(0)))
                end if
            end if

        next

        console.writeline(largestValue)

    End Sub

End Module