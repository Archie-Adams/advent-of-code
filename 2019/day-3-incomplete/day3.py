import csv
import operator


# Functions --------------------------------------------------------------------


def getWireCoordinates(lstInput):
    lstOutput = []
    currentCoord = (0, 0)  # (x, y)

    for pathSection in lstInput:

        # modifier is the change in the currentCoord based on the direction.
        d = {'U': (0, 1), 'D': (0, -1), 'L': (-1, 0), 'R': (1, 0)}
        modifier = d[pathSection[0]]

        # Loops for the distance of pathSection, adds all visited coordinates
        # to lstOutput.
        for _ in range(0, int(pathSection[1:])):
            currentCoord = tuple(map(operator.add, currentCoord, modifier))
            lstOutput.append(currentCoord)

    return lstOutput


# Main -------------------------------------------------------------------------


# Get two lists from CSV input.txt.
with open('input.txt', newline='') as inputFile:
    reader = csv.reader(inputFile)
    data = list(reader)
    # data[0] is list of the first wires paths.
    # data[1] is list of second wires paths.


# lstWireOneCoords and lstWireTwoCoords store the coordinates of every
# point each wire visits.
lstWireOneCoords = getWireCoordinates(data[0])
lstWireTwoCoords = getWireCoordinates(data[1])

# lstCrossovers stores all coordinates appearing in both wire lists.
lstCrossovers = []
for coord in lstWireOneCoords:
    if coord in lstWireTwoCoords:
        lstCrossovers.append(coord)


# Finds the shortest distance to (0, 0) from the coordinates in lstCrossovers.
counter = 0
shortestDistance = float('inf')
for i in range(0, len(lstCrossovers) - 1):
    dist = abs(0 - lstCrossovers[i][0]) + abs(0 - lstCrossovers[i][1])
    if dist < shortestDistance:
        shortestDistance = dist

print(shortestDistance)
