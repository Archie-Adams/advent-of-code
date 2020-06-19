import regex
# Input range: 359282-820401
acceptablePasswordCount = 0
for password in range(359282, 820401):

    # Check for two identical digits not part of a larger group.
    if regex.search(r'(\d)\1{2,}(*SKIP)(*F)|(\d)\2', str(password)):

        # Check if all digits are in ascending order.
        prevDigit = 0
        ascensionCheck = True
        for digit in str(password):
            if int(digit) < prevDigit:
                ascensionCheck = False
                break
            else:
                prevDigit = int(digit)

        if ascensionCheck:
            acceptablePasswordCount += 1

print(acceptablePasswordCount)
