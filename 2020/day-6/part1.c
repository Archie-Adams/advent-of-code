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

    int countOfUniqueChars = 0;

    char line[80];
    while (fgets(line, sizeof(line), inputFile) != NULL)
    {

        // If on a blank line, reset seen characters.
        if (line[0] == '\n')
        {

            printf("%s\nUn chars: %i\n", seenInGroup, countOfUniqueChars);

            seenInGroup[0] = '\0';
        }

        // If on a line containing letters.
        else
        {
            for (int i = 0; i < strlen(line); i++)
            {
                // If char has not been seen before.
                char *p = strchr(seenInGroup, line[i]);
                if (p == NULL && line[i] != '\n')
                {
                    countOfUniqueChars++;
                    strncat(seenInGroup, &line[i], 1);
                }
            }
        }
    }
    printf("%i", countOfUniqueChars);
}