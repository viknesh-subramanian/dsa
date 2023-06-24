// Input - integer
// Output - Factorial of the said integer

// O(n)
function factorial_recursive(number) {
    if (number <= 2) {
        return number;
    }
    return number * factorial_recursive(number - 1);
}
// O(n)
function factorial_iterative(number) {
    let answer = number === 2 ? number : 1;
    for (let i = 2; i <= number; i++) {
        answer = answer * i;
    }
    return answer;
}