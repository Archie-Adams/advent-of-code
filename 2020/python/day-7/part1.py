import re

rules = []
contains_gold = set()


def canContainShinyGold(colour):

    # If already seen this colour don't do more work.
    if colour in contains_gold or colour == "shiny gold":
        return True

    # For each sub-colour the given colour can hold.
    for sub_colour in rules[[item[0] for item in rules].index(colour)][1:]:
        if canContainShinyGold(sub_colour[2:]):
            contains_gold.add(sub_colour[2:])
            return True


# Parse input to a list of lists; [[colour, digit colour, digit colour,..],..].
rgx = r'(^(?:\w+\s\w+){1,2}|\d+\s\w+\s\w+)'
rules = [re.findall(rgx, line) for line in open('input.txt')]

for rule in rules:
    if canContainShinyGold(rule[0]):
        contains_gold.add(rule[0])

# -1 due to shiny gold bag not being in a shiny gold bag.
print(len(contains_gold) - 1)
