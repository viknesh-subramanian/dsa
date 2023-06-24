// Given a number N return the index value of the Fibonacci sequence, where the sequence is
// 0, 1, 1, 2, 3, 5, 8, 13,...

// Input = 6 (the index)
// Output = 8 

// O(n)
function fibonacci_iterative(n) {
    let arr = [0, 1];
    for (let i = 2; i <= n; i++) {
        arr.push(arr[i-2] + arr[i-1]);
    }
    return arr[n];
}
// O(2^n)
function fibonacci_recursive(n) {
    if (n < 2) {
        return n;
    }
    return fibonacci_recursive(n - 1) + fibonacci_recursive(n - 2);
}