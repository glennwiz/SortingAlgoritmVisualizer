using Spectre.Console;

public class SortableItem
{
    public int Id { get; set; }
    public int Value { get; set; }
    public Style Style { get; set; }

    public SortableItem(int id, int value, Style style = null)
    {
        Id = id;
        Value = value;
        Style = style ?? Style.Plain;
    }
}