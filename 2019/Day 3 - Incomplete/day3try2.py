import csv
import operator


# Functions --------------------------------------------------------------------
def getWireCoordinates(lstInput):
    lstOutput = [(0, 0)]
    currentCoord = (0, 0)  # (X, Y)

    for pathSection in lstInput:

        # Number of units for this instruction.
        dist = int(pathSection[1:])

        # modifier is the change to add to the currentCoord.
        d = {'U': (0, 1), 'D': (0, -1), 'L': (-1, 0), 'R': (1, 0)}
        modifier = (d[pathSection[0]][0] * dist, d[pathSection[0]][1] * dist)

        # Adds the modifier to current coord to get the next position.
        currentCoord = tuple(map(operator.add, currentCoord, modifier))
        lstOutput.append(currentCoord)

    print(lstOutput)
    return lstOutput


def getLstOfCoordsBetween(pointA, pointB):
    # input as (X, Y), (X, Y)

    lstOutput = []

    if pointA[0] == pointB[0]:
        # The Y value changes.
        changeVal = 1
        unchange = 0 
    else:
        # The X value changes.
        changeVal = 0
        unchange = 1

    if pointA[changeVal] > pointB[changeVal]:
        # loop from b to a
        step = -1
    else:
        # loop from a to b
        step = 1

    for i in range(pointA[changeVal], pointB[changeVal] + 1, step):
        lstOutput.append((,))

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

for i in range(0, len(lstWireOneCoords - 2)):
    # check between i and i + 1
    first = lstWireOneCoords[i]
    second = lstWireOneCoords[i + 1]

    # for all pairs in lstWireTwoCoords
    for x in range(0, len(lstWireTwoCoords - 2)):
        # check all i and i + 1 pairs for intersections
        # between first and second.

        # Finds the shortest distance to (0, 0) from the coordinates
        # in lstCrossovers.
        pass


counter = 0
shortestDistance = float('inf')
for i in range(0, len(lstCrossovers) - 1):
    dist = abs(0 - lstCrossovers[i][0]) + abs(0 - lstCrossovers[i][1])
    if dist < shortestDistance:
        shortestDistance = dist


print(shortestDistance)
