Imports System.Collections.Generic

Module Module1

    Sub Main()

        dim input() as string = IO.File.ReadAllLines("input.txt")

        dim instructionIndex as integer = 0
        dim instruction as integer
        dim steps as integer = 0

        while true
            instruction = input(instructionIndex)
            input(instructionIndex) += 1
            instructionIndex += instruction
            steps += 1
            if instructionIndex > input.count() - 1 then exit while
            instruction = input(instructionIndex)
        end while

        console.writeline(steps)

    End Sub

End Module