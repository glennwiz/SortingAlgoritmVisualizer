using Spectre.Console;

namespace SortingAlgoritmVisualizer
{
    internal class SelectionSort : ISortAlgorithm
    {
        /*
            Selection Sort is another comparison-based sorting algorithm. 
            It divides the input list into two portions: the sorted portion and the unsorted portion. 
            The algorithm repeatedly selects the smallest (or largest) element from the unsorted portion and swaps it
            with the leftmost unsorted element, growing the sorted portion. 
            This process continues until the entire list is sorted. 
            Selection Sort has an average and worst-case time complexity of O(n^2), making it inefficient for large lists.
            However, it performs fewer swaps compared to Bubble Sort, 
            making it more efficient in scenarios where swapping is costly.
        */
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

                array[minIndex].Style = new Style(foreground: Color.Maroon);
                var table = new Table().RoundedBorder();
                Console.Clear();

                for (int j = i + 1; j < arrayLength; j++)
                {
                    string message;

                    if (array[j].Value < array[minIndex].Value)
                    {
                        minIndex = j;
                    }

                    message = $"Comparing    | {array[j]} and {array[minIndex]}";
                    array[minIndex].Style = new Style(foreground: Color.Green);

                    Program.UpdateConsole(ctx, new Style(Color.Gold1), message, array, table);
                }

                if (minIndex != i)
                {
                    string swapMessage = $"Swapping     | {array[i]} and {array[minIndex]}";

                    array[i].Style = new Style(foreground: Color.Blue);
                    (array[i], array[minIndex]) = (array[minIndex], array[i]);
                    swaps++;

                    Program.UpdateConsole(ctx, new Style(foreground: Color.Grey), swapMessage, array, table);
                }

                Program.UpdateTableAndPrint(array, table);
            }

            return swaps;
        }
    }
}
