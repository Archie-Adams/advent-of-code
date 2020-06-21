Imports System.Collections.Generic

Module Module1
    
    Sub Main()
        
        dim m as string() = "0,5,10,0,11,14,13,4,11,8,8,7,1,4,12,11".split(",")
        dim memory = array.convertall(m, Function(str) Int32.Parse(str))
        
        dim oldMemory as new list(of string)
        dim redistCycles as integer = 0

        while true
            
            ' Find first largest index.
            dim largestIndex as integer = 0
            for i = 0 to memory.count() - 1
                if memory(i) > memory(largestIndex) then largestIndex = i
            next

            dim memoryToDistribute as integer = memory(largestIndex)
            memory(largestIndex) = 0

            ' Distribute the memory block. 
            largestIndex += 1 ' To start the distribution at the next index. 
            for i = memoryToDistribute to 1 step -1
                if largestIndex = memory.count() then largestIndex = 0
                memory(largestIndex) += 1
                largestIndex += 1
            next

            redistCycles += 1

            ' Check if memory is in old memory            
            if oldMemory.contains(string.join(",", memory)) then
                console.writeline(redistCycles)
                exit while
            end if

            ' Adds memory state to list that can be checked for same states.
            oldMemory.add(string.join(",", memory))

        end while

    End Sub 

End Module