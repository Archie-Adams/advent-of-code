#include <stdio.h>

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
        int firstPos, secondPos, flag1 = 0, flag2 = 0;
        char letter, password[50];
        fscanf(inputFile, "%i-%i %c: %s", &firstPos, &secondPos, &letter, &password);

        if (password[firstPos - 1] == letter)
            flag1 = 1;

        if (password[secondPos - 1] == letter)
            flag2 = 1;

        if ((flag1 == 1 && flag2 == 0) || (flag1 == 0 && flag2 == 1))
            count++;
    }
    printf("%i", count);
}