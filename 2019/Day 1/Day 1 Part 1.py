# https://adventofcode.com/2019/day/1
# Archie Adams - 24/06/2020

with open('input.txt') as inputFile:
    print(sum([int(line.rstrip()) // 3 - 2 for line in inputFile]))
