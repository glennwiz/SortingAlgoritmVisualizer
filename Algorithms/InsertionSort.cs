using SortingAlgoritmVisualizer.Algorithms;
using Spectre.Console;

namespace SortingAlgoritmVisualizer.Algoriths
{
    internal class InsertionSort : ISortAlgorithm
    {
        public string Name => "Insertion Sort";

        public int SortWithoutVisualizer(int[] array)
        {
            int swaps = 0;
            int arrayLength = array.Length;

            for (int i = 1; i < arrayLength; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    swaps++;
                }

                array[j + 1] = key;
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

            for (int i = 1; i < arrayLength; i++)
            {
                int key = array[i].Value;
                int j = i - 1;

                var table = new Table().RoundedBorder();
                Console.Clear();

                while (j >= 0 && array[j].Value > key)
                {
                    string message = $"Moving       | {array[j].Value} to the right";
                    array[j + 1].Style = new Style(foreground: Color.Green);

                    array[j + 1].Value = array[j].Value;
                    array[j].Style = new Style(foreground: Color.Blue);

                    Program.UpdateConsole(ctx, new Style(foreground: Color.Grey), message, array, table, Name);

                    j--;
                    swaps++;
                }

                array[j + 1].Value = key;
                array[j + 1].Style = new Style(foreground: Color.Green);
                Program.UpdateTableAndPrint(array, table, Name);
            }

            return swaps;
        }
    }
}

