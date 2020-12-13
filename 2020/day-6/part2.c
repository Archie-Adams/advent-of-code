#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINE_CHARS 80
#define PUZZLE_INPUT "input.txt"

void main()
{
    FILE *inputFile = fopen(PUZZLE_INPUT, "r");

    // Array to store all seen characters in a group.
    char seenInGroup[26];
    seenInGroup[0] = '\0';

    int countOfAllYes = 0;
    int firstLineOfGroup = 1; // 1 when on first line, 0 otherwise.

    char line[80];
    while (fgets(line, sizeof(line), inputFile) != NULL)
    {

        // If on a blank line.
        if (line[0] == '\n')
        {
            // Increment counter of previous group.
            // printf("Old Count: %d\n", countOfAllYes); // DEBUG
            countOfAllYes += strlen(seenInGroup);
            // printf("New Count: %d\n", countOfAllYes); // DEBUG

            // Reset vars for next group.
            seenInGroup[0] = '\0';
            firstLineOfGroup = 1;
        }

        // If on first line of a group.
        else if (firstLineOfGroup == 1)
        {
            // printf("First line: %s", line); //DEBUG

            // Reset flag.
            firstLineOfGroup = 0;

            // Put first line into all seen chars.
            strcpy(seenInGroup, line);
            // Replace new line with null pointer.
            seenInGroup[strlen(seenInGroup) - 1] = '\0';

            // printf("seen in group: %s\n", seenInGroup); //DEBUG
        }

        // If on other line in group.
        else
        {
            // For each char in seen group
            for (int x = 0; x < strlen(seenInGroup); x++)
            {
                // If char not in the line.
                char *p = strchr(line, seenInGroup[x]);
                if (p == NULL)
                {
                    // Not everyone answered yes, remove x from seenInGroup.
                    printf("Old seengroup: %s\n", seenInGroup);
                    memmove(&seenInGroup[x], &seenInGroup[x + 1], strlen(seenInGroup) - x);
                    printf("New seengroup: %s\n", seenInGroup);
                    // printf("Removed: %s\n", seenInGroup); // DEBUG
                }
            }
            // printf("Line: %s", line);                   // DEBUG
            // printf("seen in group: %s\n", seenInGroup); // DEBUG
        }
    }
    countOfAllYes += strlen(seenInGroup);
    printf("%i", countOfAllYes);
}