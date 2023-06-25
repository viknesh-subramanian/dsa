// Input - Unsorted array
// Output - Sorted array

function selection_sort(array) {
    const length = array.length; // O(1) space complexity 
    for (let i = 0; i < length; i++) { // O(n*n) time complexity
        // Set current index as minimum
        let min = i;
        let temp = array[i];
        for (let j = i + 1; j < length; j++) {
            if (array[j] < array[min]) {
                // Update min in case its lower than current min value
                min = j;
            }
        }
        array[i] = array[min];
        array[min] = temp;
    }
    return array;
}