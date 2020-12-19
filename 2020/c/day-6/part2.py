# Count the number of unanimously answered questions.
counter = 0

with open('input.txt') as input_file:

    # Track the answers of the specific group.
    answeredYes = []
    newGroup = True

    for line in input_file:

        # If on a newline then finish previous group.
        if line == "\n":
            counter += len(answeredYes)
            newGroup = True

        # If start of group add all first line.
        elif newGroup:
            answeredYes = list(line.strip())
            newGroup = False

        # Remove any questions that don't appear on subsequent lines.
        else:
            for char in answeredYes:
                if char not in line.strip():
                    answeredYes.remove(char)

    # Appends final groups count.
    counter += len(answeredYes)

print(counter)
