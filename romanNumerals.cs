using System.Collections;
using System.Globalization;
using System.Windows.Markup;

var numbersMap = new Dictionary<int, string>() { 
    { 1, "I" },
    { 5, "V"},
    { 10, "X"},
    { 50, "L"},
    { 100, "C"},
    { 500, "D"},
    { 1000, "M"}
};

var keys = numbersMap.Keys.ToList();
var values = numbersMap.Values.ToList();

string ConvertToRomanNumerals(int input)
{
    // Base case: 0 has no equivalence
    if (input == 0)
    {
        return string.Empty;
    }

    // Base case: number contained in map
    if (numbersMap.ContainsKey(input))
    {
        return numbersMap[input];
    }

    // Base case: can express the number as 2X or 3X any base number
    // Example: 20 = 2*10 = XX, 30 = 3*10 = XXX
    for (int i = 0; i < numbersMap.Count; i++)
    {
        if (input == 2 * keys[i])
        {
            var value = values[i];
            return $"{value}{value}";
        }
        if (input == 3 * keys[i])
        {
            var value = values[i];
            return $"{value}{value}{value}";
        }
    }

    // Base case: can express the number by subtracting a smaller number one time
    // Example: 9 = 10 - 1 = IX
    for (int i = numbersMap.Count - 1; i > 1; i--)
    {
        for (int j = i - 1; j >= 0; j--)
        {
            if (keys[i] - keys[j] == input)
            {
                return $"{values[j]}{values[i]}";
            }
        }
    }

    // Base case: can express the number by adding a smaller number 1, 2 or 3 times
    // Example: 60 = 50+10 = LX
    // 80 = 50 + 10 + 10 + 10 = LXXX
    for (int i = numbersMap.Count - 1; i > 1; i--)
    {
        for (int j = i - 1; j >= 0; j--)
        {
            // 1 time
            if (keys[i] + keys[j] == input)
            {
                return $"{values[i]}{values[j]}";
            }

            // 2 times
            if (keys[i] + 2* keys[j] == input)
            {
                return $"{values[i]}{values[j]}{values[j]}";
            }

            // 3 times
            if (keys[i] + 3* keys[j] == input)
            {
                return $"{values[i]}{values[j]}{values[j]}{values[j]}";
            }
        }
    }


    // Break down the number using powers of 10, for example 1995 = 1000+900+90+5, and convert each of those parts
    int power = 1;
    string result = string.Empty;
    do
    {
        power = power * 10;
        if (input % power == 0)
        {
            // There is no number 0 in roman numerals, so group to the next power
            continue;
        }

        var n = input % power;
        input = input - n;
        result = ConvertToRomanNumerals(n) + result;
    } while (input >= power);

    return result;
}

Console.WriteLine("Enter the number:");
var input = Console.ReadLine();
int number;
if (int.TryParse(input, out number))
{
    Console.WriteLine($"Roman numerals {ConvertToRomanNumerals(number)}");
}

// interesting test cases
// 0, 1, 2, 3, 2475, 2550