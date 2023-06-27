function memoizedAddTo80() {
    let cache = {};
    // Using Closures to contain scope of cache
    return function(n) {
        if (n in cache) {
            return cache[n];
        } else {
            cache[n] = n + 80;
            return cache[n];
        }
    }
}

// Function call
// const memoize = memoizedAddTo80();
// memoize(5);