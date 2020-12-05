#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Constants. -----------------------------------------------------------------
const int MAX_LINE_CHARS = 80;
const char PUZZLE_INPUT[] = "input.txt";

#define NUM_OF_FIELDS 7 // [0->n-1].
#define MAX_DATA_SIZE 20

// Globals. -------------------------------------------------------------------
// ----------------------------------------------------------------------------

// Structures for storing passports and their data. ---------------------------
typedef struct passportField
{
    char field[3];            // Three letter abbreviation.
    int present;              // Flag set to 1 if field is present.
    char data[MAX_DATA_SIZE]; // Value of the field.

} PassportField;

typedef struct passport
{
    PassportField *fields[NUM_OF_FIELDS]; // Array of fields the passport has.
    int numOfValidFields;                 // Count of passports fields [1->n].

} Passport;
// ----------------------------------------------------------------------------

// Prototype functions. -------------------------------------------------------
int getNumberOfPassports();
void readPassportDataToArray(Passport *passports[]);
void addPassport(Passport *passports[], PassportField *fieldHolder[],
                 int count, int passportCount);
// ----------------------------------------------------------------------------

void main()
{
    // Initialize array for storing passports.
    int numOfPassports = getNumberOfPassports();
    if (numOfPassports == -1)
        return;
    Passport *passports[numOfPassports];

    // Populate array of passports.
    readPassportDataToArray(passports);

    // Do part1 logic.
    int validPassports = 0;
    for (int i = 0; i <= numOfPassports; i++)
    {
        // If all fields are present.
        if (passports[i]->numOfValidFields == 8)
        {
            validPassports++;
        }
        else if (passports[i]->numOfValidFields == 7)
        {
            int fail = 0;
            for (int f = 0; f < 7; f++)
            {
                if (strcmp(passports[i]->fields[f]->field, "cid") == 0)
                { //fail
                    fail = 1;
                    break;
                }
                if (fail != 1)
                {
                    validPassports++;
                }
            }
        }
    }
    printf("valid passports: %i\n", validPassports);
}

// Populates the passport array with data from PUZZLE_INPUT[].
void readPassportDataToArray(Passport *passports[])
{
    // Open puzzle input.
    FILE *inputFile = fopen(PUZZLE_INPUT, "r");

    char line[80];
    int count = -1, passportCount = 0;
    PassportField *fieldHolder[NUM_OF_FIELDS];

    while (fgets(line, sizeof(line), inputFile) != NULL)
    {
        // If on a blank line, add read data to new passport.
        if (line[0] == '\n')
        {
            addPassport(passports, fieldHolder, count, passportCount);
            passportCount++; // Increment the number of passports.
            count = -1;      // Reset field count.
        }
        // If on a line containing fields.
        else
        {
            // Splits the line into fields.
            char *s = strtok(line, ": \n");
            do
            {
                // Create new field struct to store data.
                PassportField *f =
                    (PassportField *)malloc(sizeof(PassportField));

                // Add data to new field struct.
                strcpy(f->field, s);
                s = strtok(NULL, ": \n");
                strcpy(f->data, s);
                s = strtok(NULL, ": \n");
                f->present = 1;

                // Add field struct to temporary storage until all fields read.
                fieldHolder[++count] = f;
            } while (s != NULL);
        }
    }
    // Add final passport after reading last line.
    addPassport(passports, fieldHolder, count, passportCount);
}

// Function to add the passport to the passport array.
void addPassport(Passport *passports[], PassportField *fieldHolder[],
                 int count, int passportCount)
{
    // Create new passport to be added to array.
    Passport *p = (Passport *)malloc(sizeof(Passport));

    // Assign collected data to new passport.
    p->numOfValidFields = count + 1; // Var is 1->n.
    for (int i = 0; i < count; i++)
        p->fields[i] = fieldHolder[i];

    // Add passport to the array.
    passports[passportCount] = p;
}

// Returns number of passports by counting number of blank lines.
int getNumberOfPassports()
{
    FILE *inputFile = fopen(PUZZLE_INPUT, "r");

    int numberOfPassports = 0;
    char c, previousC;
    while ((c = fgetc(inputFile)) != EOF)
    {
        if (c == '\n' && previousC == '\n')
            numberOfPassports++;

        previousC = c;
    }

    fclose(inputFile);
    return numberOfPassports;
}

// DEBUG CODE -----------------------------------------------------------------

// for (int i = 0; i <= numOfPassports; i++)
// {
//     printf("Passport %i\n", i);
//     printf("Num of valid fields %i\n", passports[i]->numOfValidFields);
//     printf("first field: %s:%s\n", passports[i]->fields[0]->field, passports[i]->fields[0]->data);
// }