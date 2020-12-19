def checkInstructions(instructions):
    accumulator = 0
    current_instruction = 0
    seen_instructions = set()

    try:
        while current_instruction not in seen_instructions:
            seen_instructions.add(current_instruction)

            if instructions[current_instruction][0] == "acc":
                accumulator += int(instructions[current_instruction][1])
            elif instructions[current_instruction][0] == "jmp":
                current_instruction += int(
                    instructions[current_instruction][1])
                continue

            current_instruction += 1

        return False

    except IndexError:
        print(accumulator)
        return True


instructions = [line.strip().split() for line in open('input.txt')]

for index, item in enumerate(instructions):
    if item[0] == "jmp":
        instructions[index][0] = "nop"
        if checkInstructions(instructions):
            break
        instructions[index][0] = "jmp"
    elif item[0] == "nop":
        instructions[index][0] = "jmp"
        if checkInstructions(instructions):
            break
        instructions[index][0] = "nop"
