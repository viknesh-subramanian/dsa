// Given an array [2,5,1,2,3,5,1,2,4]
// It should return 2 - the first recurring character

function recurring(input) {
    let map = {}; 
    for (let i = 0; i < input.length; i++) { // O(n) time complexity
        if (map[input[i]]) {
            return input[i]
        } else {
            map[input[i]] = true; // O(n) space complexity
        }
    }
    return undefined;
}