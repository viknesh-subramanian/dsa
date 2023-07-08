// Input - Unsorted array
// Output - Sorted array

function quick_sort(array, first, last) {
    const length = array.length;
    let pivot, partition_index;
    if (first < last) {
        pivot = last;
        partition_index = partition(array, pivot, first, last);

        quick_sort(array, first, partition_index - 1);
        quick_sort(array, partition_index + 1, last);
    }
    return array;
}

function partition(array, pivot, first, last) {
    let pivot_val = array[pivot];
    let partition_index = first;

    for (let i = first; i < last; i++) {
        if (array[i] < pivot_val) {
            swap(array, i, partition_index);
            partition_index++;
        }
    }
    swap(array, last, partition_index);
    return partition_index
}

function swap(array, first_index, second_index) {
    let temp = array[first_index];
    array[first_index] = array[second_index];
    array[second_index] = temp;
}