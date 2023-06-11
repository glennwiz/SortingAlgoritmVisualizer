using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 2, 8, 4, 1 };

        // Display the original array
        var table = new Table().RoundedBorder();

        foreach (int num in array)
        {
            table.AddColumn(num.ToString());
        }

        AnsiConsole.WriteLine("Original Array");
        AnsiConsole.Write(table);

        AnsiConsole.WriteLine();

        // Sort the array using Bubble Sort and visualize the process
        BubbleSort(array);

        // Display the sorted array
        AnsiConsole.WriteLine("\nSorted Array");
        AnsiConsole.WriteLine(string.Join("  ", array));
    }

    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.WriteLine($"Comparing {array[j]} and {array[j + 1]}");
                if (array[j] > array[j + 1])
                {
                    Console.WriteLine($"Swapping {array[j]} and {array[j + 1]}");
                    // Swap array[j] and array[j+1]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    swapped = true;
                }
            }

            // If no two elements were swapped in the inner loop, the array is already sorted
            if (!swapped)
                break;

            var table = new Table().RoundedBorder();

            foreach (int num in array)
            {
                table.AddColumn(num.ToString());
            }

            AnsiConsole.Write(table);

            Thread.Sleep(500);
        }
    }


}
