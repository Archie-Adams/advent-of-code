numbers = [int(line.strip()) for line in open('input.txt')]
# For each number after the first 25 preamble.
for index, number in enumerate(numbers[25:]):
    # List of previous 25 numbers.
    lst = [x for x in numbers[index: index + 25]]
    # If number is not present in the sum of any two previous 25 numbers.
    if number not in [x + y for x in lst for y in lst]:
        print(number)
        break
