adapters = sorted([int(line.strip()) for line in open('input.txt')])
adapters.insert(0, 0)  # Effective rating of outlet.
adapters.append(adapters[-1] + 3)  # Built in adapter.

one_jolt_differences = 0
three_jolt_differences = 0

for index in range(1, len(adapters)):
    if adapters[index] - adapters[index-1] == 1:
        one_jolt_differences += 1
    elif adapters[index] - adapters[index-1] == 3:
        three_jolt_differences += 1

print(one_jolt_differences * three_jolt_differences)
