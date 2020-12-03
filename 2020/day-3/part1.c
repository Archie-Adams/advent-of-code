#include <stdio.h>
#include <string.h>

void main()
{
    // Open puzzle input.
    FILE *inputFile;
    inputFile = fopen("input.txt", "r");

    // Get lines as strings from puzzle input.
    char map[323][32];
    fread(map, 1, sizeof(map), inputFile);

    int tileWidth = 30;   // The width of each section. [0 - 30]
    int row = 0, col = 0; // Current position to check.
    int treesHit = 0;     // Counter for number of trees hit.

    while (1)
    {
        if (map[row][col] == '#')
            treesHit++;

        row++;
        if (row > 322)
            break;

        col += 3;
        if (col > tileWidth)
            col -= tileWidth + 1; // Account for 0 based start.
    }

    printf("%i", treesHit);
}
