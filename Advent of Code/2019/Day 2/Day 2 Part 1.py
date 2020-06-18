from csv import reader

# Gets input as list of integers from the CSV input.txt.
with open('input.txt', newline='') as inputFile:
    lstInput = [list(map(int, rec)) for rec in reader(inputFile)][0]

# Initial values
lstInput[1] = 12
lstInput[2] = 2

# Variables
intOpcodeIndex = 0
intOpcode = lstInput[0]

intValueOne = None
intValueTwo = None

intOutputIndex = None

# Loop until halt program opcode is hit
while intOpcode != 99:

    intValueOne = lstInput[lstInput[intOpcodeIndex + 1]]
    intValueTwo = lstInput[lstInput[intOpcodeIndex + 2]]

    intOutputIndex = lstInput[intOpcodeIndex + 3]

    if intOpcode == 1:
        # Opcode 1 adds the two values
        lstInput[intOutputIndex] = intValueOne + intValueTwo

    elif intOpcode == 2:
        # Opcode 2 multiplies the two values
        lstInput[intOutputIndex] = intValueOne * intValueTwo

    # Step forward to next opcode
    intOpcodeIndex += 4
    intOpcode = lstInput[intOpcodeIndex]

# Puzzle answer
print(lstInput[0])
