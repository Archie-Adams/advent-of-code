numbers = [int(line.strip()) for line in open('input.txt')]
invalid_number = 0
# For each number after the first 25 preamble.
for index, number in enumerate(numbers[25:]):
    # List of previous 25 numbers.
    lst = [x for x in numbers[index: index + 25]]
    # If number is not present in the sum of any two previous 25 numbers.
    if number not in [x + y for x in lst for y in lst]:
        invalid_number = number
        break

for start, number in enumerate(numbers):
    total_sum = 0
    counter = -1
    while not total_sum >= invalid_number:
        counter += 1
        total_sum += numbers[start + counter]

    if total_sum == invalid_number:
        contiguous_list = numbers[start:start + counter]
        print(max(contiguous_list) + min(contiguous_list))
        break
