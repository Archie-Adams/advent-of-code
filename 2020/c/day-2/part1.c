#include <stdio.h>
#include <string.h>

int main()
{
    // Open puzzle input.
    FILE *inputFile;
    inputFile = fopen("input.txt", "r");

    int count = 0;

    // Get numbers from puzzle input.
    for (int i = 0; i < 1000; i++)
    {
        // Get data from input string.
        int min, max, letterCount = 0;
        char letter, password[50];
        fscanf(inputFile, "%i-%i %c: %s", &min, &max, &letter, &password);

        // Count occurrences of letter in string.
        for (int k = 0; k < strlen(password); k++)
            if (password[k] == letter)
                letterCount++;

        // If occurrences within policy increment count.
        if (letterCount >= min && letterCount <= max)
            count++;
    }

    printf("%i", count);
}