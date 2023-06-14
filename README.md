# SortingAlgoritmVisualizer


## <span style="color: green">Bubble Sort - done </span>

**Algorithm:**

1. Set `n` to the length of the list.
2. Repeat the following steps `n` times:
   1. Iterate through the list from index 0 to `n - 1`.
   2. Compare each pair of adjacent elements.
   3. If the elements are in the wrong order, swap them.
3. After `n` iterations, the list will be sorted.

**Time Complexity:**
- Best Case: O(n) (when the list is already sorted)
- Worst Case: O(n^2) (when the list is sorted in reverse order)

**Space Complexity:**
- O(1) (in-place sorting)



## Selection Sort - done

**Algorithm:**

1. Set `n` to the length of the list.
2. Repeat the following steps `n` times:
   1. Find the minimum element in the unsorted part of the list.
   2. Swap the minimum element with the first unsorted element.
   3. Move the boundary of the sorted part one element to the right.
3. After `n` iterations, the list will be sorted.

**Time Complexity:**
- Best Case: O(n^2)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Insertion Sort

**Algorithm:**

1. Set `n` to the length of the list.
2. Iterate through the list from index 1 to `n - 1`.
   1. Take the current element and insert it into the correct position in the sorted part of the list.
   2. Move all elements greater than the current element one position to the right.
3. After the iteration, the list will be sorted.

**Time Complexity:**
- Best Case: O(n) (when the list is already sorted)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Merge Sort

**Algorithm:**

1. If the list has fewer than two elements, return the list (base case).
2. Divide the list into two halves.
3. Recursively sort the left half.
4. Recursively sort the right half.
5. Merge the two sorted halves to obtain a sorted list.

**Time Complexity:**
- Best Case: O(n log n)
- Worst Case: O(n log n)

**Space Complexity:**
- O(n) (requires additional space for merging)


### Quick Sort

**Algorithm:**

1. If the list has fewer than two elements, return the list (base case).
2. Select a pivot element from the list.
3. Partition the list into two sublists: elements less than the pivot and elements greater than the pivot.
4. Recursively sort the sublists created in the previous step.
5. Concatenate the sorted sublists with the pivot to obtain a sorted list.

**Time Complexity:**
- Best Case: O(n log n)
- Worst Case: O(n^2) (rare, but can occur if the pivot selection is not optimal)

**Space Complexity:**
- O(log n) (recursive stack space)


### Heap Sort

**Algorithm:**

1. Build a max-heap from the list.
2. Swap the root (maximum element) with the last element of the heap and decrease the heap size.
3. Heapify the reduced heap to maintain the max-heap property.
4. Repeat steps 2 and 3 until the heap is empty.
5. The elements extracted in step 2 form a sorted list.

**Time Complexity:**
- Best Case: O(n log n)
- Worst Case: O(n log n)

**Space Complexity:**
- O(1) (in-place sorting)


### Counting Sort

**Algorithm:**

1. Find the maximum element in the list and determine the range of values.
2. Initialize a count array of size equal to the range, and set all elements to zero.
3. Count the number of occurrences of each unique element and store the count in the count array.
4. Modify the count array to contain the cumulative sum of the counts.
5. Create an output array of the same size as the input array.
6. Iterate through the input array from right to left:
   - Use the count array to determine the correct position of each element in the output array.
   - Decrease the count for each element.
7. The output array will contain the sorted elements.

**Time Complexity:**
- Best Case: O(n + k) (when the range of input values is small)
- Worst Case: O(n + k)

**Space Complexity:**
- O(n + k) (requires additional space for the count and output arrays)
 

### Radix Sort

**Algorithm:**

1. Find the maximum element in the list and determine the number of digits in it.
2. Initialize 10 buckets (0-9).
3. Iterate through each digit position from the least significant to the most significant:
   - Distribute the elements into the buckets based on the current digit.
   - Collect the elements from the buckets in the original order.
4. After processing all the digits, the list will be sorted.

**Time Complexity:**
- Best Case: O(d * (n + k)) (d is the number of digits, k is the range of input values)
- Worst Case: O(d * (n + k))

**Space Complexity:**
- O(n + k) (requires additional space for the buckets)


### Shell Sort

**Algorithm:**

1. Choose a gap sequence (e.g., Knuth's sequence or Hibbard's sequence).
2. Starting with the largest gap, divide the list into sublists of elements separated by the gap.
3. Sort each sublist using Insertion Sort.
4. Reduce the gap and repeat steps 2 and 3 until the gap becomes 1.
5. Perform a final pass of Insertion Sort to ensure the list is fully sorted.

**Time Complexity:**
- Best Case: O(n log n) (depends on the gap sequence)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Bucket Sort

**Algorithm:**

1. Create an array of empty buckets.
2. Iterate through the input list and distribute each element into the corresponding bucket based on its value.
3. Sort each bucket individually, either using a different sorting algorithm or recursively applying the bucket sort.
4. Concatenate the sorted elements from all the buckets to obtain the sorted list.

**Time Complexity:**
- Best Case: O(n + k), where n is the number of elements and k is the number of buckets.
- Worst Case: O(n^2) (if all the elements are placed in the same bucket and require additional sorting)

**Space Complexity:**
- O(n + k) (requires additional space for the buckets)


### Comb Sort

**Algorithm:**

1. Set the gap value `gap` to the length of the list.
2. Repeat the following steps until the gap becomes 1:
   1. Set `gap` to the integer division of `gap` by a shrink factor (e.g., 1.3).
   2. Iterate through the list from index 0 to `n - gap - 1`.
   3. Compare each pair of elements that are `gap` positions apart.
   4. If the elements are in the wrong order, swap them.
3. Perform a final pass using the gap value of 1 (similar to Bubble Sort) to ensure the list is completely sorted.

**Time Complexity:**
- Best Case: O(n log n)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Cycle Sort

**Algorithm:**

1. Iterate through each element in the list.
2. For each element, do the following until the element is in its correct position:
   1. Find the correct position for the current element by counting the number of elements that are smaller than it.
   2. If there are no smaller elements, move to the next element.
   3. Otherwise, swap the current element with the element at its correct position.
3. Repeat step 2 for all remaining elements in the list.

**Time Complexity:**
- Best Case: O(n^2)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Gnome Sort

**Algorithm:**

1. Set the current position `pos` to 0.
2. Repeat the following steps until `pos` reaches the end of the list:
   1. If `pos` is 0, increment `pos`.
   2. If the element at position `pos` is greater than the previous element, increment `pos`.
   3. Otherwise, swap the current element with the previous element and decrement `pos`.
3. After reaching the end of the list, it will be sorted.

**Time Complexity:**
- Best Case: O(n) (when the list is already sorted)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Odd-Even Sort

**Algorithm:**

1. Repeat the following steps until the list is sorted:
   1. Perform a Bubble Sort pass on the odd-indexed elements (starting from index 1).
   2. Perform a Bubble Sort pass on the even-indexed elements (starting from index 0).
2. After the iterations, the list will be sorted.

**Time Complexity:**
- Best Case: O(n) (when the list is already sorted)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Cocktail Shaker Sort

**Algorithm:**

1. Set the `start` and `end` indices of the unsorted part of the list.
2. Repeat the following steps until the list is sorted:
   1. Perform a forward pass from `start` to `end`, swapping adjacent elements if they are in the wrong order.
   2. Decrement `end`.
   3. Perform a backward pass from `end` to `start`, swapping adjacent elements if they are in the wrong order.
   4. Increment `start`.
3. After the iterations, the list will be sorted.

**Time Complexity:**
- Best Case: O(n) (when the list is already sorted)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Pancake Sort

**Algorithm:**

1. Start with the entire list of elements.
2. Find the index of the maximum element in the current unsorted part of the list.
3. Flip the list from the start to the maximum element's index to bring the maximum element to the front.
4. Flip the entire list to move the maximum element to its correct position at the end.
5. Repeat steps 2-4 for the remaining unsorted part of the list.
6. After the iterations, the list will be sorted.

**Time Complexity:**
- Best Case: O(n^2)
- Worst Case: O(n^2)

**Space Complexity:**
- O(1) (in-place sorting)


### Bead Sort

**Algorithm:**

1. Create an array of empty "rails" equal to the maximum element in the list.
2. For each element in the list, add "beads" to the corresponding rail by incrementing the value at that position.
3. For each rail, let the beads fall under gravity and collect them in sorted order.
4. The collected beads represent the sorted list.

**Time Complexity:**
- Best Case: O(n)
- Worst Case: O(n^2)

**Space Complexity:**
- O(k) (requires additional space for the rails, where k is the maximum element in the list)


### Shell Merge Sort

**Algorithm:**

1. Define a sequence of gap values to be used for initial sorting.
2. For each gap value in the sequence:
   1. Perform Shell Sort with the current gap value to partially sort the list.
   2. Merge the partially sorted sublists using the regular merge operation of Merge Sort.
3. After merging all the sublists, the list will be sorted.

**Time Complexity:**
- Best Case: O(n log^2 n)
- Worst Case: O(n log^2 n)

**Space Complexity:**
- O(n) (requires additional space for merging)


### Smooth Sort

**Algorithm:**

1. Create a Leonardo heap data structure to represent the input list.
2. Build the Leonardo heap from the input list.
3. Repeat the following steps until the heap is empty:
   1. Extract the maximum element from the Leonardo heap.
   2. Recursively restore the heap property on the remaining elements.
4. The extracted elements form the sorted list.

**Time Complexity:**
- Best Case: O(n)
- Worst Case: O(n log n)

**Space Complexity:**
- O(1) (in-place sorting)


### Strand Sort

**Algorithm:**

1. If the input list is empty, return an empty list (base case).
2. Identify a sublist of elements that are in increasing order from the input list.
3. Remove the identified sublist from the input list.
4. Recursively repeat steps 2-4 with the remaining elements of the input list.
5. Merge the sorted sublists obtained from the recursive calls to obtain the sorted list.

**Time Complexity:**
- Best Case: O(n)
- Worst Case: O(n^2)

**Space Complexity:**
- O(n) (requires additional space for merging)


### Tim Sort

**Algorithm:**

1. Divide the input list into small sublists (called runs) using Insertion Sort or other sorting algorithms.
2. Merge the runs using a merging algorithm (such as the merging algorithm of Merge Sort).
3. Repeat steps 1-2 until a single sorted list is obtained.

**Time Complexity:**
- Best Case: O(n)
- Worst Case: O(n log n)

**Space Complexity:**
- O(n) (requires additional space for merging)

