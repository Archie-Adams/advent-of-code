instructions = [line.strip().split() for line in open('input.txt')]
seen_instructions = set()
current_instruction = 0
accumulator = 0

while current_instruction not in seen_instructions:
    seen_instructions.add(current_instruction)

    if instructions[current_instruction][0] == "acc":
        accumulator += int(instructions[current_instruction][1])
    elif instructions[current_instruction][0] == "jmp":
        current_instruction += int(instructions[current_instruction][1])
        continue

    current_instruction += 1

print(accumulator)
