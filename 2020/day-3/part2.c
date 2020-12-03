#include <stdio.h>
#include <string.h>

long long findTrees(int dRow, int dCol);

char map[323][32];

void main()
{
    // Open puzzle input.
    FILE *inputFile;
    inputFile = fopen("input.txt", "r");

    // Get lines as strings from puzzle input.
    fread(map, 1, sizeof(map), inputFile);

    long long r1d1 = findTrees(1, 1);
    long long r3d1 = findTrees(1, 3);
    long long r5d1 = findTrees(1, 5);
    long long r7d1 = findTrees(1, 7);
    long long r1d2 = findTrees(2, 1);

    long long all = r1d1 * r3d1 * r5d1 * r7d1 * r1d2;

    printf("%lld", all);
}

long long findTrees(int dRow, int dCol)
{
    int tileWidth = 30;   // The width of each section. [0 - 30]
    int row = 0, col = 0; // Current position to check.
    int treesHit = 0;     // Counter for number of trees hit.

    while (1)
    {
        if (map[row][col] == '#')
            treesHit++;

        row += dRow;
        if (row > 322)
            return treesHit;

        col += dCol;
        if (col > tileWidth)
            col -= tileWidth + 1; // Account for 0 based start.
    }
}
