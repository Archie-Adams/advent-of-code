#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define INPUT_PATH "input.txt"
#define NUM_OF_SEATS 846

int intcmp(const void *aa, const void *bb);

int main()
{
    // Variables.
    char input[NUM_OF_SEATS][10]; // Array of seat codes.
    int seatIDs[NUM_OF_SEATS];    // Array of seat IDs.
    int row;                      // Row number.
    int seat;                     // Seat number.

    // Open puzzle input.
    FILE *inputFile = fopen(INPUT_PATH, "r");
    for (int i = 0; i < NUM_OF_SEATS; i++)
    {
        // Get seat code from puzzle input.
        fscanf(inputFile, "%s", &input[i]);

        row = 0, seat = 0; // Reset row and seat counter each time.
        int *p = &row;     // Pointer to row or seat.

        for (int n = 7, x = 0; x < 10; n--, x++)
        {
            // If into the seat section point to the seat and reset n.
            if (x == 7)
                n = 3, p = &seat;

            // If 1, add denary equivalent.
            if (input[i][x] == 'B' || input[i][x] == 'R')
                *p += pow(2, n) / 2;
        }
        seatIDs[i] = row * 8 + seat;
    }
    // Closes puzzle input.
    fclose(inputFile);

    // Sorts seatIDs.
    qsort(seatIDs, NUM_OF_SEATS, sizeof(int), intcmp);

    // If the seat above isn't seat + 1, return what the seat above should be.
    for (int i = 1; i < NUM_OF_SEATS - 1; i++)
        if (seatIDs[i] + 1 != seatIDs[i + 1])
        {
            printf("%i\n", seatIDs[i] + 1);
            break;
        }
}

// https://rosettacode.org/wiki/Sort_an_integer_array#C
int intcmp(const void *aa, const void *bb)
{
    const int *a = aa, *b = bb;
    return (*a < *b) ? -1 : (*a > *b);
}