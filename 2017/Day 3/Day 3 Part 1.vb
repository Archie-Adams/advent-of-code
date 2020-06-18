Module Module1

    Sub Main()





        Dim numOfSpirals As Integer = 1
        Dim countAtEOS As Integer = 1
        While Not countAtEOS >= 265194
            countAtEOS += 8 * numOfSpirals
            numOfSpirals += 1
        End While
        ''MsgBox(numOfSpirals) ''258 the spiral the number is in
        '' MsgBox(countAtEOS) '265225 bottom right of spiral
        ''  MsgBox(countAtEOS - 265149) ''76 how far number is from bottom right of spiral 77
        ''MsgBox((2 * 258) - 1) ''2n-1 515 ''how many are on one side of spirall
        ''MsgBox((2 * 515) + (2 * (515 - 2))) ''2n+2(n-2) 2056 numbers around spiral
        ''MsgBox((514 / 2) + 1) ''258 (centre parrelal to 1)(258 away from bottom right) 257
        MsgBox(257 - 77) ''180
        MsgBox(257 + 181) ''438








        'Dim numOfSpiralsOut As Integer = 0 ''does not cout 1 as spiral
        'Dim endOfCurrentSpiral As Integer
        'Dim currentInt As Integer = 1
        'Dim currentSpiralLengh As Integer = 0
        'While Not endOfCurrentSpiral >= 265149
        '    currentSpiralLengh += 8
        '    endOfCurrentSpiral += 8
        '    numOfSpiralsOut += 1
        'End While



        'MsgBox(numOfSpiralsOut) ''33144
        'MsgBox(currentSpiralLengh) ''265152

        'Dim numberAtNESWOfOneAtSameSpiral As Integer = 4 * (numOfSpiralsOut ^ 2) - (5 * numOfSpiralsOut) + 2
        'MsgBox(numberAtNESWOfOneAtSameSpiral)



    End Sub

End Module
