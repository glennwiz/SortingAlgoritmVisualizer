using Spectre.Console;

namespace SortingAlgoritmVisualizer
{
    internal class BubbleSort : ISortAlgorithm
    {
        /*
            Bubble Sort is a simple comparison-based sorting algorithm. 
            It repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. 
            The process is repeated until the entire list is sorted. 
            The algorithm gets its name from the way smaller elements "bubble" to the top of the list in each iteration. 
            Bubble Sort has an average and worst-case time complexity of O(n^2), making it inefficient for large lists. 
            However, it is easy to understand and implement
        */
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

                        message = $"Swapping     | {array[j + 1]} and {array[j]}";
                        ;
                        array[j + 1].Style = new Style(foreground: Color.Green);

                    }
                    else
                    {
                        message = $"Not swapping | {array[j]} and {array[j + 1]}";

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
