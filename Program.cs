using Newtonsoft.Json;
using SortingAlgoritmVisualizer;
using Spectre.Console;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ISortAlgorithm sortAlgorithm;
        List<SortingResult> results = new List<SortingResult>();

        sortAlgorithm = new BubbleSort();

        int[] array = { 100, 91, 12, 22, 11, 90, 1, 77, 32, 18, 46, 85, 37 };
        int swaps = 0;
        //RenderOriginalArray(array);

        AnsiConsole.Status()
        .Start("Starting...", ctx =>
        {
            // Sort the array using Bubble Sort and visualize the process
            swaps = sortAlgorithm.SortWithVisualizer(array, ctx);

        });

        Console.WriteLine($"{sortAlgorithm.Name} did {swaps} swaps !!!");

        int count = 50000;
        Console.WriteLine($"Running without visualization {count} large random array...");

        //Write 100000 random ints wit seed 369 in to array
        array = new int[50000];
        var threeSixNine = new Random(369);
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = threeSixNine.Next();
        }
        swaps = sortAlgorithm.SortWithoutVisualizer(array);
        stopwatch.Stop();

        // Create a new sorting result object
        var result = new SortingResult
        {
            Algorithm = sortAlgorithm.Name,
            Swaps = swaps,
            ElapsedTime = stopwatch.Elapsed
        };

        // Add the result to the list
        results.Add(result);

        // Serialize the results list to JSON
        string json = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);

        // Append the serialized results to the file
        File.AppendAllText("result.json", json);


        var elapsedTime = stopwatch.Elapsed;
        string elapsedTimeString = $"{elapsedTime.Hours:D2}h:{elapsedTime.Minutes:D2}m:{elapsedTime.Seconds:D2}s:{elapsedTime.Milliseconds:D3}ms";

        string swapsString = swaps >= 1000000 ? swaps.ToString("N0") : swaps.ToString();

        Console.WriteLine($"Sorting the array without visualizations completed in {elapsedTimeString}.");
        Console.WriteLine($"Number of swaps: {swapsString}");

        Console.WriteLine("Done !!!");
    }

    public static void UpdateConsole(StatusContext spectreContext, Style? style, string message, int[] array, Table table)
    {
        UpdateTableAndPrint(array, table);
        spectreContext.SpinnerStyle(style);
        spectreContext.Status(message);
        Thread.Sleep(100);
    }

    public static void UpdateTableAndPrint(int[] array, Table table)
    {
        Console.Clear();
        // Clear existing columns from the table
        table = new Table();

        // Add back columns for the updated array
        foreach (int num in array)
        {
            table.AddColumn(num.ToString());
        }

        AnsiConsole.Write(table);
    }
}
