import re


def getNumberOfContainingBags(index_of_rule, rules, count=0):

    # For each sub-colour bag the given colour bag can hold.
    for sub_colour in rules[index_of_rule][1:]:
        sub_colour_index = [item[0] for item in rules].index(sub_colour[2:])
        # Add how many bags of that subcolour there are.
        count += int(sub_colour[0])
        # Add how many bags that subcolour contains, multiplied by how many
        # bags of that subcolour there are.
        count += int(sub_colour[0]) * \
            int(getNumberOfContainingBags(sub_colour_index, rules))

    return int(count)


# Parse input to a list of lists; [[colour, digit colour, digit colour,..],..].
rgx = r'(^(?:\w+\s\w+){1,2}|\d+\s\w+\s\w+)'
rules = [re.findall(rgx, line) for line in open('input.txt')]

# Find start point (index of the shiny gold bag).
gold_index = [item[0] for item in rules].index("shiny gold")

print(getNumberOfContainingBags(gold_index, rules))
