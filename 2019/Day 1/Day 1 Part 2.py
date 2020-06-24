# https://adventofcode.com/2019/day/1
# Archie Adams - 24/06/2020

def calculateFuel(ammount, total):
    if ammount // 3 - 2 > 0:
        return calculateFuel(ammount // 3 - 2, total + ammount // 3 - 2)
    else:
        return total


with open('input.txt') as inputFile:
    print(sum([calculateFuel(int(line.rstrip()), 0) for line in inputFile]))
