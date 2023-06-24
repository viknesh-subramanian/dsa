// Reversing an array (or a string which in turn is an array of characters)
// Input - Hi! My name is Viki
// Output - ikiV si eman yM !iH

// Explicit looping
function reverse(str) {
    if(!str || typeof str != 'string' || str.length < 2 ) return str;
    let reversed = []
    let total_length = str.length - 1;
    for (i = total_length; i >= 0; i--) {
        reversed.push(str[i]);
    }
    return reversed.join('')
}

// Implicit looping - built in methods
function reverse2(str) {
    if(!str || typeof str != 'string' || str.length < 2 ) return str;
    return str.split('').reverse().join('')
}

// ES6 solution
const reverse3 = str => {
    if(!str || typeof str != 'string' || str.length < 2 ) return str;
    return str.split('').reverse().join('')
}

// ES6 solution - spread operator
const reverse4 = str => {
    if(!str || typeof str != 'string' || str.length < 2 ) return str;
    return [...str].reverse().join('')
}