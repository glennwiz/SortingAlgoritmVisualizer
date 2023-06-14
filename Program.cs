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
            var sortableItems = GetDefaultSortableItems();

            int swaps = 0;

            if (Activator.CreateInstance(sortingAlgorithmType) is not ISortAlgorithm sortingAlgorithm) { throw new SqlNullValueException(); }

            AnsiConsole.Status().Start("Starting...", ctx =>
            {
                Console.WriteLine($"Running {sortingAlgorithm.Name}");
                swaps = sortingAlgorithm.SortWithVisualizer(sortableItems, ctx);
            });

            Console.WriteLine($"{sortingAlgorithm.Name} did {swaps} swaps !!!");
            int count = 20000;
            Console.WriteLine($"Running without visualization {count} large random array...");

            var array = new int[count];
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

    private static SortableItem[] GetDefaultSortableItems()
    {
        Style style = Style.Parse("yellow");

        SortableItem[] sortableArray = {
                new SortableItem(0, 100, style),
                new SortableItem(1, 91,style),
                new SortableItem(2, 12, style),
                new SortableItem(3, 22, style),
                new SortableItem(4, 11, style),
                new SortableItem(5, 90, style),
                new SortableItem(6, 1, style),
                new SortableItem(7, 77, style),
                new SortableItem(8, 32, style),
                new SortableItem(9, 18, style),
                new SortableItem(10, 46, style),
                new SortableItem(11, 85, style),
                new SortableItem(12, 37, style)
            };

        return sortableArray;
    }

    public static void UpdateConsole(StatusContext spectreContext, Style? style, string message, SortableItem[] array, Table table, string name)
    {

        UpdateTableAndPrint(array, table, name);
        spectreContext.SpinnerStyle(style);
        spectreContext.Status(message);
        Thread.Sleep(100);
    }

    public static void UpdateTableAndPrint(SortableItem[] array, Table table, string Name)
    {
        Console.Clear();
        AnsiConsole.WriteLine($"{Name}");
        AnsiConsole.WriteLine("");

        // Clear existing columns from the table
        table = new Table();

        foreach (SortableItem item in array)
        {
            table.AddColumn($"[{item.Style.Foreground}]{item.Value}[/]");
        }

        AnsiConsole.Write(table);
    }
}
