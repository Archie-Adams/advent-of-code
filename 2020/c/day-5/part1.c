#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define INPUT_PATH "input.txt"
#define NUM_OF_SEATS 846

int main()
{
    // Variables.
    char input[NUM_OF_SEATS][10]; // Array of seat codes.
    int seatIDs[NUM_OF_SEATS];    // Array of seat IDs.
    int largestSeatID = -1;       // Largest seat ID.
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

        // Check if lager than largestSeatID.
        if (seatIDs[i] > largestSeatID)
            largestSeatID = seatIDs[i];
    }

    printf("Largest seat ID: %i\n", largestSeatID);

    // Closes puzzle input.
    fclose(inputFile);
}