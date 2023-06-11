using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 100, 5, 2, 8, 4, 55, 37, 4, 3, 2, 7, 32, 72 };
        int iterations = 0;
        //RenderOriginalArray(array);

        AnsiConsole.Status()
        .Start("Starting...", ctx =>
        {
            // Sort the array using Bubble Sort and visualize the process
            iterations = BubbleSort(array, ctx);
        });
        Console.WriteLine($"Bubble sort did {iterations} swaps !!!");
        Console.WriteLine("Done !!!");
    }

    public static int BubbleSort(int[] array, StatusContext ctx)
    {
        int swaps = 0;
        var arrayLength = array.Length;
        bool swapped;

        ctx.Status("Starting!");
        ctx.Spinner(Spinner.Known.Arrow);
        ctx.SpinnerStyle(Style.Parse("yellow"));

        for (var i = 0; i < arrayLength - 1; i++)
        {
            var table = new Table().RoundedBorder();
            Console.Clear();
            swapped = false;
            for (int j = 0; j < arrayLength - i - 1; j++)
            {
                var message = $"Comparing    | {array[j]} and {array[j + 1]}";
                UpdateConsole(ctx, Style.Parse("yellow"), message, array, table);
                if (array[j] > array[j + 1])
                {
                    message = $"Swapping     | {array[j]} and {array[j + 1]}";
                    UpdateConsole(ctx, Style.Parse("red"), message, array, table);

                    // Swap array[j] and array[j+1]
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    swapped = true;
                    swaps++;
                }
                else
                {
                    message = $"Not swapping | {array[j]} and {array[j + 1]}";
                    UpdateConsole(ctx, Style.Parse("green"), message, array, table);
                }
            }

            // If no two elements were swapped in the inner loop, the array is already sorted
            if (!swapped)
                break;

            UpdateTableAndPrint(array, table);
        }
        return swaps;
    }

    private static void UpdateConsole(StatusContext ctx, Style? style, string message, int[] array, Table table)
    {
        UpdateTableAndPrint(array, table);
        ctx.SpinnerStyle(style);
        ctx.Status(message);
        Thread.Sleep(50);
    }

    private static void UpdateTableAndPrint(int[] array, Table table)
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
