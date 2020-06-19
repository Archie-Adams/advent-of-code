# Input range: 359282-820401
acceptablePasswordCount = 0
doubles = ['11', '22', '33', '44', '55', '66', '77', '88', '99']
for password in range(359282, 820401):

    # If no item in doubles exists as a substring of password, continue.
    if any(x in str(password) for x in doubles):

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
