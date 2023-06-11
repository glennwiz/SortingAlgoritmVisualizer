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
        int arrayLength = array.Length;

        ctx.Status("Starting!");
        ctx.Spinner(Spinner.Known.Arrow);
        ctx.SpinnerStyle(Style.Parse("yellow"));

        for (int i = 0; i < arrayLength - 1; i++)
        {
            bool swapped = false;

            var table = new Table().RoundedBorder();
            Console.Clear();

            for (int j = 0; j < arrayLength - i - 1; j++)
            {
                string message;
                Style messageStyle;

                if (array[j] > array[j + 1])
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    swapped = true;
                    swaps++;

                    message = $"Swapping     | {array[j + 1]} and {array[j]}";
                    messageStyle = Style.Parse("red");
                }
                else
                {
                    message = $"Not swapping | {array[j]} and {array[j + 1]}";
                    messageStyle = Style.Parse("green");
                }

                UpdateConsole(ctx, messageStyle, message, array, table);
            }

            if (!swapped)
                break;

            UpdateTableAndPrint(array, table);
        }

        return swaps;
    }


    private static void UpdateConsole(StatusContext spectreContext, Style? style, string message, int[] array, Table table)
    {
        UpdateTableAndPrint(array, table);
        spectreContext.SpinnerStyle(style);
        spectreContext.Status(message);
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
