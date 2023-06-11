using Newtonsoft.Json;
using SortingAlgoritmVisualizer;
using Spectre.Console;
using System.Data.SqlTypes;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var results = new List<SortingResult>();
        Table table = new Table();
        Type interfaceType = typeof(ISortAlgorithm);
        var sortingAlgorithmTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var sortingAlgorithmType in sortingAlgorithmTypes)
        {
            int[] array = { 100, 91, 12, 22, 11, 90, 1, 77, 32, 18, 46, 85, 37 };
            int swaps = 0;

            if (Activator.CreateInstance(sortingAlgorithmType) is not ISortAlgorithm sortingAlgorithm) { throw new SqlNullValueException(); }

            AnsiConsole.Status().Start("Starting...", ctx =>
            {
                Console.WriteLine($"Running {sortingAlgorithm.Name}");
                swaps = sortingAlgorithm.SortWithVisualizer(array, ctx);
            });

            Console.WriteLine($"{sortingAlgorithm.Name} did {swaps} swaps !!!");
            int count = 20000;
            Console.WriteLine($"Running without visualization {count} large random array...");

            array = new int[count];
            var threeSixNine = new Random(369);
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = threeSixNine.Next();
            }
            swaps = sortingAlgorithm.SortWithoutVisualizer(array);
            stopwatch.Stop();

            // Create a new sorting result object
            var result = new SortingResult
            {
                RandomCount = array.Length,
                Algorithm = sortingAlgorithm.Name,
                Swaps = swaps,
                ElapsedTime = stopwatch.Elapsed
            };

            // Add the result to the list
            results.Add(result);

            // Serialize the results list to JSON
            string json = JsonConvert.SerializeObject(results, Formatting.Indented);

            // Append the serialized results to the file
            File.AppendAllText("result.json", json);

            var elapsedTime = stopwatch.Elapsed;
            string elapsedTimeString = $"{elapsedTime.Hours:D2}h:{elapsedTime.Minutes:D2}m:{elapsedTime.Seconds:D2}s:{elapsedTime.Milliseconds:D3}ms";

            string swapsString = swaps >= 1000000 ? swaps.ToString("N0") : swaps.ToString();

            Console.WriteLine($"Sorting the array without visualizations completed in {elapsedTimeString}.");
            Console.WriteLine($"Number of swaps: {swapsString}");
        }
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
