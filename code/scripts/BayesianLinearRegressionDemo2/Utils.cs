
using System;
using System.IO;

public class CSVReader
{
    public static double[] ReadCSVToVector(string filename)
    {
        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(filename);
        string[] values_str = lines[0].Split(',');

        // Determine the dimensions of the matrix
        int numElem = values_str.Length;

        // Create the double vector
        double[] values_double = new double[numElem];

        // Fill the matrix with the data from the CSV
        for (int i = 0; i < numElem; i++)
        {
            // Attempt to parse each value to double
            if (double.TryParse(values_str[i], out double result))
            {
                values_double[i] = result;
            }
            else
            {
                throw new FormatException($"Unable to parse '{values_str[i]}' as a double at element {i}.");
            }
        }

        return values_double;
    }

    public static double[,] ReadCSVToMatrix(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        string[] values_str = lines[0].Split(',');
        int nRows = lines.Length;
        var row0Elems = lines[0].Split(",");
        int nCols = row0Elems.Length;
        Console.WriteLine($"nRows={nRows}, nCols={nCols}");
        double[,] answer = new double[nRows, nCols];
        for (int i = 0; i < nRows; i++)
        {
            values_str = lines[i].Split(",");
            for (int j = 0; j < nCols; j++)
            {
                if(double.TryParse(values_str[j], out double result))
                {
                    answer[i, j] = result;
                }
                else
                {
                    throw new FormatException($"Unable to parse '{values_str[j]}' as a double at row {i} and col {j}.");
                }
            }
        }
        return answer;
    }
}

