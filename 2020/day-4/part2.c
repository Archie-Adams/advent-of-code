#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

// Constants. -----------------------------------------------------------------
const int MAX_LINE_CHARS = 80;
const char PUZZLE_INPUT[] = "input.txt";

#define NUM_OF_FIELDS 8 // [0->n-1].
#define MAX_DATA_SIZE 20

// Globals. -------------------------------------------------------------------
// ----------------------------------------------------------------------------

// Structures for storing passports and their data. ---------------------------
typedef struct passportField
{
    char field[4];            // Three letter abbreviation.
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
int isNumeric(const char *s);
int validateYear(char *y, int min, int max);
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

    // Do part2 logic.
    int validPassports = 0;
    for (int i = 0; i <= numOfPassports; i++)
    {
        // If all fields are present.
        if (passports[i]->numOfValidFields == 7 || passports[i]->numOfValidFields == 8)
        {
            // printf("-----%i----\n", passports[i]->numOfValidFields);

            int fail = 0;
            for (int f = 0; f < passports[i]->numOfValidFields; f++)
            {
                char field[3];
                strcpy(field, passports[i]->fields[f]->field);
                // strcpy(field, "byr");
                char data[MAX_DATA_SIZE];
                strcpy(data, passports[i]->fields[f]->data);
                // strcpy(data, "2003");
                //remove
                // passports[i]->numOfValidFields = 8;
                //remove
                // printf("f: %s\nd: %s\n", field, data);

                // cid (Country ID) - ignored, missing or not.
                // TESTED
                if (strcmp(field, "cid") == 0 && passports[i]->numOfValidFields == 7)
                {
                    fail = 1;
                    break;
                }

                // byr (Birth Year) - four digits; at least 1920 and at most 2002.
                //TESTED
                if (strcmp(field, "byr") == 0)
                {
                    if (validateYear(data, 1920, 2002) == 0)
                    {
                        fail = 1;
                        break;
                    }
                }

                // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                // TESTED
                if (strcmp(field, "iyr") == 0)
                {
                    if (validateYear(data, 2010, 2020) == 0)
                    {
                        fail = 1;
                        break;
                    }
                }

                // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                if (strcmp(field, "eyr") == 0)
                {
                    if (validateYear(data, 2020, 2030) == 0)
                    {
                        fail = 1;
                        break;
                    }
                }

                // hgt (Height) - a number followed by either cm or in:
                //    If cm, the number must be at least 150 and at most 193.
                //    If in, the number must be at least 59 and at most 76.
                if (strcmp(field, "hgt") == 0)
                {
                    int end = strlen(data) - 1;
                    if (data[end] == 'm' && data[end - 1] == 'c')
                    {
                        data[end - 1] = '\0'; //COULD CHECK THIS IS CORRECT LENGTH STR
                        if (isNumeric(data) == 0)
                        {
                            fail = 1;
                            break;
                        }
                        int d = atoi(data);
                        if (d < 150 || d > 193)
                        {
                            fail = 1;
                            break;
                        }
                    }
                    else if (data[end] == 'n' && data[end - 1] == 'i')
                    {
                        data[end - 1] = '\0';
                        if (isNumeric(data) == 0)
                        {
                            fail = 1;
                            break;
                        }
                        int d = atoi(data);
                        if (d < 59 || d > 76)
                        {
                            fail = 1;
                            break;
                        }
                    }
                    else
                    {
                        fail = 1;
                        break;
                    }

                    // check last two digits for in or cm.
                    // change i or c to '\0'
                    // check isNumeric
                    // atoi, check ranges.
                }

                // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                if (strcmp(field, "hcl") == 0)
                {
                    // Check len
                    // check #
                    if (strlen(data) != 7 || data[0] != '#')
                    {
                        fail = 1;
                        break;
                    }
                    // change # to number // no need set x to 1
                    // check alphaNumeric

                    for (int x = 1; x < 7; x++)
                    {
                        if (isxdigit(data[x]) == 0) // a - f not is hex
                        {
                            fail = 1;
                            break;
                        }
                    }
                    if (fail == 1)
                    {
                        break;
                    }
                }

                // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                if (strcmp(field, "ecl") == 0)
                {
                    //strcmp to an hardcodeed array
                    // char colors[7][3] = {"amb",
                    //                      "blu",
                    //                      "brn",
                    //                      "gry",
                    //                      "grn",
                    //                      "hzl",
                    //                      "oth"};
                    // // int validColor = 0;
                    // // for (int c = 0; c < 7; c++)
                    // // {
                    // //     if (strcmp(data, colors[c]) == 0)
                    // //     {
                    // //         validColor = 1;
                    // //         break;
                    // //     }
                    // // }
                    // if (validColor == 0)
                    // {
                    //     fail = 1;
                    //     break;
                    // }
                    if (strcmp(data, "amb") == 0 || strcmp(data, "blu") == 0 || strcmp(data, "brn") == 0 || strcmp(data, "gry") == 0 || strcmp(data, "grn") == 0 || strcmp(data, "hzl") == 0 || strcmp(data, "oth") == 0)
                    {
                    }
                    else
                    {
                        fail = 1;
                        break;
                    }
                }
                // pid (Passport ID) - a nine-digit number, including leading zeroes.
                if (strcmp(field, "pid") == 0)
                {
                    // check strlen
                    // check isNumeric
                    if (strlen(data) != 9 || isNumeric(data) != 1)
                    {
                        fail = 1;
                        break;
                    }
                }
            }
            // printf("fail = %i\n****\n", fail);
            if (fail != 1)
                validPassports++;
        }
    }
    printf("Valid passports: %i\n", validPassports);
}

// Returns 1 for valid, 0 for invalid
int validateYear(char *y, int min, int max)
{
    if (isNumeric(y) == 1 && strlen(y) == 4)
    {
        int x = atoi(y);
        printf("%i\n", x);
        printf("min: %i, max: %i\n", min, max);
        if (x >= min && x <= max)
        {
            printf("Returning 1");
            return 1;
        }
        else
            return 0;
    }
    else
        return 0;
}

// Returns true (non-zero) if character-string parameter represents a signed or
// unsigned floating-point number. Otherwise returns false (zero).
// https://rosettacode.org/wiki/Determine_if_a_string_is_numeric#C
int isNumeric(const char *s)
{
    if (s == NULL || *s == '\0' || isspace(*s))
        return 0;
    char *p;
    strtod(s, &p);
    return *p == '\0';
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
                // printf("%s\n", s);
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
    for (int i = 0; i < count + 1; i++)
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