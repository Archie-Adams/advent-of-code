' https://adventofcode.com/2017/day/10
' Archie Adams - 

Imports System.Collections.Generic

Module Module1
    
    Sub Main()

        dim strInput() as string = IO.File.ReadAllLines("input.txt")
        dim input() = array.convertall(strInput, Function(str) int32.parse(str))

        'dim lst as IEnumerable(of integer) = enumerable.Range(start:=0, count:=256)
        dim lst as new list(of integer)
        for i = 0 to 255
            lst.add(i)
        next

        dim currentPosition as integer = 0
        dim skipSize as integer = 0

        for each length in input

            dim reversed as new list(of integer)
            dim counter as integer = 0

            if currentPosition + length > 255 then
                ' Needs to wrap past start of list.

                dim endIndex as integer = currentPosition + length - 256
                'endIndex = (currentPosition + length) - (255 - currentPosition)

                for i = endIndex to 0 step - 1
                    reversed.add(lst(i))
                next
                for i = 255 to currentPosition step -1
                    reversed.add(lst(i))
                next
                
                for i = currentPosition to 255
                    lst(i) = reversed(counter)
                    counter += 1
                next
                for i = 0 to endIndex
                    lst(i) = reversed(counter)
                    counter += 1
                next

            else
                
                for i = currentPosition + length to currentPosition step -1
                    reversed.add(i)
                next

                for i = currentPosition to currentPosition + length
                    lst(i) = reversed(counter)
                    counter += 1
                next

            end if

            currentPosition += length + skipSize
            if currentPosition > 255 then currentPosition -= 256

            skipSize += 1

        next

        console.writeline(lst(0) * lst(1))

    End Sub

End Module