using Spectre.Console;

namespace SortingAlgoritmVisualizer
{
    internal class SelectionSort : ISortAlgorithm
    {
        public string Name => "Selection Sort";
        public int SortWithoutVisualizer(int[] array)
        {
            int swaps = 0;
            int arrayLength = array.Length;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arrayLength; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                    swaps++;
                }
            }

            return swaps;
        }

        public int SortWithVisualizer(SortableItem[] array, StatusContext ctx)
        {
            int swaps = 0;
            int arrayLength = array.Length;

            ctx.Status("Starting!");
            ctx.Spinner(Spinner.Known.Arrow);
            ctx.SpinnerStyle(Style.Parse("yellow"));

            for (int i = 0; i < arrayLength - 1; i++)
            {
                int minIndex = i;

                var table = new Table().RoundedBorder();
                Console.Clear();

                for (int j = i + 1; j < arrayLength; j++)
                {
                    string message;
                    Style messageStyle;

                    if (array[j].Value < array[minIndex].Value)
                    {
                        minIndex = j;
                    }

                    message = $"Comparing    | {array[j]} and {array[minIndex]}";
                    messageStyle = Style.Parse("yellow");

                    Program.UpdateConsole(ctx, messageStyle, message, array, table);
                }

                if (minIndex != i)
                {
                    string swapMessage = $"Swapping     | {array[i]} and {array[minIndex]}";
                    Style swapStyle = Style.Parse("red");

                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                    swaps++;

                    Program.UpdateConsole(ctx, swapStyle, swapMessage, array, table);
                }

                Program.UpdateTableAndPrint(array, table);
            }

            return swaps;
        }
    }
}
