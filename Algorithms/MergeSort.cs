using Spectre.Console;

namespace SortingAlgoritmVisualizer.Algorithms
{
    internal class MergeSort : ISortAlgorithm
    {
        public string Name => "Merge Sort";

        public int SortWithoutVisualizer(int[] array)
        {
            int swaps = 0;

            return swaps;
        }

        public int SortWithVisualizer(SortableItem[] array, StatusContext ctx)
        {
            int swaps = 0;
            var table = new Table().RoundedBorder();
            //Console.Clear();

            ctx.Status("Starting!");
            ctx.Spinner(Spinner.Known.Arrow);
            ctx.SpinnerStyle(Style.Parse("yellow"));

            table = new Table();

            foreach (SortableItem item in array)
            {
                table.AddColumn($"[{item.Style.Foreground}]{item.Value}[/]");
            }

            AnsiConsole.Write(table);
            Thread.Sleep(1000);

            SortMethod(array, 0, array.Length - 1, ctx);

            return swaps;
        }

        static public void MergeMethod(SortableItem[] numbers, int left, int mid, int right, StatusContext ctx)
        {
            ctx.Status(numbers.Length + " : Numbers.Len");
            Thread.Sleep(1000);

            int[] temp = new int[25];
            int i;
            int leftEnd;
            int numElements;
            int tempPos;

            AnsiConsole.MarkupLine($"[red]Left : {left} | Mid : {mid}  | Right : {right}[/]");
            AnsiConsole.MarkupLine($"[red]Numbers : {numbers.Length}[/]");

            leftEnd = (mid - 1);
            tempPos = left;
            numElements = (right - left + 1);
            while ((left <= leftEnd) && (mid <= right))
            {
                if (numbers[left].Value <= numbers[mid].Value)
                    temp[tempPos++] = numbers[left++].Value;
                else
                    temp[tempPos++] = numbers[mid++].Value;
            }
            while (left <= leftEnd)
                temp[tempPos++] = numbers[left++].Value;
            while (mid <= right)
                temp[tempPos++] = numbers[mid++].Value;
            for (i = 0; i < numElements; i++)
            {
                numbers[right].Value = temp[right];
                right--;
            }
        }
        static int recursionDepth = 0;

        static public void SortMethod(SortableItem[] numbers, int left, int right, StatusContext ctx)
        {
            int mid;
            recursionDepth++;

            AnsiConsole.MarkupLine($"[blue]recursionDepth = {recursionDepth}[/]");

            //If right is greater than left
            //Meaning there are at least two elements to sort, it continues
            //Otherwise it just returns without doing anything as a single
            //element or an empty set is already sorted.
            if (right > left)
            {
                Thread.Sleep(1000);
                var table = new Table();
                //Console.Clear();
                foreach (SortableItem item in numbers)
                {
                    table.AddColumn($"[{item.Style.Foreground}]{item.Value}[/]");
                }

                AnsiConsole.Write(table);


                mid = (right + left) / 2;
                AnsiConsole.MarkupLine($"[yellow]left : {left} >  right : {right}[/]");
                AnsiConsole.MarkupLine($"[cyan]mid : {mid}[/]");

                AnsiConsole.MarkupLine($"Calling s1, {left} to {mid}");
                SortMethod(numbers, left, mid, ctx);
                AnsiConsole.MarkupLine($"Calling s2, {mid + 1} to {right}");
                SortMethod(numbers, (mid + 1), right, ctx);
                AnsiConsole.MarkupLine($"[Magenta]Starting Merge ({left},{mid + 1}, {right})[/]");
                MergeMethod(numbers, left, (mid + 1), right, ctx);
                AnsiConsole.MarkupLine($"[green]After Merge: {String.Join(", ", numbers.Select(n => n.Value.ToString()).ToArray())}[/]");
            }
        }
    }
}
