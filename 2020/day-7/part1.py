# LIST OF TUPLES: (BAG COLOUR, LIST OF TUPLES: (NUMBER, BAG COLOUR))
lstRules = []

with open('input.txt') as input_file:
    for lineCount, line in enumerate(input_file):
        line = line.replace(' bags', '').replace(' bag', '')
        words = line.replace(',', '').replace('.', '').strip().split(' ')

        lstRules.append(('{} {}'.format(words[0], words[1]), []))

        # If bag contains no others, don't try to add more.
        if words[3] == 'no':
            continue

        # wordCount is index of number of bags parent bag can carry in words.
        for wordCount, number in enumerate(words[3::3]):
            wordCount += 3
            # print(words)
            # print(wordCount)
            # print(number)
            colour = '{} {}'.format(words[wordCount + 1], words[wordCount + 2])
            print(colour)
            lstRules[lineCount][1].append((number, colour))

        # break
print(lstRules)
