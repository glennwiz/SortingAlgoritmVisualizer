using SortingAlgoritmVisualizer.Algorithms;
using Spectre.Console;

namespace SortingAlgoritmVisualizer.Algoriths
{
    internal class BubbleSort : ISortAlgorithm
    {
        public string Name => "Bubble Sort";

        public int SortWithoutVisualizer(int[] array)
        {
            int swaps = 0;
            int arrayLength = array.Length;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < arrayLength - i - 1; j++)
                {

                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        swapped = true;
                        swaps++;
                    }
                }

                if (!swapped)
                    break;
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
                bool swapped = false;

                var table = new Table().RoundedBorder();
                Console.Clear();

                for (int j = 0; j < arrayLength - i - 1; j++)
                {
                    string message;
                    Style style;

                    if (array[j].Value > array[j + 1].Value)
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        swapped = true;
                        swaps++;

                        message = $"Swapping     | {array[j + 1].Value} and {array[j].Value}";

                        array[j + 1].Style = new Style(foreground: Color.Green);

                    }
                    else
                    {
                        message = $"Not swapping | {array[j].Value} and {array[j + 1].Value}";

                        array[j].Style = new Style(foreground: Color.Blue);
                    }

                    Program.UpdateConsole(ctx, new Style(foreground: Color.Grey), message, array, table, Name);
                }

                if (!swapped)
                    break;

                Program.UpdateTableAndPrint(array, table, Name);
            }

            return swaps;
        }
    }
}
