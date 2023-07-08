// Input - Unsorted array
// Output - Sorted array


function merge_sort(array) {
    const length = array.length;
    if (length === 1) {
        return array;
    }
    // Split Array in into right and left
    const middle = Math.floor(length/2);
    const left = array.slice(0, middle);
    const right = array.slice(middle);

    return merge(merge_sort(left), merge_sort(right)); // O(n logn) Time complexity
}

function merge(left, right) {
    const result = []; // O(n) Space complexity
    let left_index = 0;
    let right_index = 0;
    while (left_index < left.length && right_index < right.length) {
        if (left[left_index] < right[right_index]) {
            result.push(left[left_index]);
            left_index++;
        } else {
            result.push(right[right_index]);
            right_index++;
        }
    }
    // console.log("Left -> ", left, "Right -> ", right);
    return result.concat(left.slice(left_index)).concat(right.slice(right_index));
}