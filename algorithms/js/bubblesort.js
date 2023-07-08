// Input - Unsorted array
// Output - Sorted array

function bubble_sort(array) {
    const length = array.length; // O(1) Space complexity
    for (let i = 0; i < length; i++) {
        for (let j = 0; j < length; j++) { // O(n*n) Time complexity
            if (array[j] > array[j + 1]) {
                let temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}