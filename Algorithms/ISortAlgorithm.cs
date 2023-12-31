﻿using Spectre.Console;

namespace SortingAlgoritmVisualizer.Algorithms
{
    internal interface ISortAlgorithm
    {
        string Name { get; }
        public int SortWithVisualizer(SortableItem[] array, StatusContext ctx);

        public int SortWithoutVisualizer(int[] array);
    }
}
