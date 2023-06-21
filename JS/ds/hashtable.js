class HashTable {
    constructor(size) {
        this.data = new Array(size);
    }


    // Hash functions are usually pretty fast
    // O(1)
    _hash(key) {
        let hash = 0;
        for (let i = 0; i < key.length; i++) {
            hash = (hash + key.charCodeAt(i) * i) % this.data.length;
        }
        return hash;
    }

    // O(1)
    set(key, value) {
        let address = this._hash(key);
        if (!this.data[address]) {
            this.data[address] = [];
        }
        this.data[address].push([key, value]);
        return this.data;
    }

    // O(1) in most of the cases
    // O(n) when there's a hash collision
    get(key) {
        let address = this._hash(key);
        const currentBucket = this.data[address];
        if (currentBucket) {
            for (let i = 0; i < currentBucket.length; i++) {
                // Consider the currentBucket to consist of ['name', 'Viki'], ['age', 30]
                if (currentBucket[i][0] === key) { // If 'name' === key or 'age' === key
                    return currentBucket[i][0] // return value
                }
            } 
        }
        return undefined
    }

    // O(n)
    // Extract just the keys
    keys() {
        if (!this.data.length) {
            return undefined;
        }
        const keys_array = [];
        for (let i = 0; i < this.data.length; i++) {
            if (this.data[i]) {
                keys_array.push(this.data[i][0][0]);
                // [i] - arrive at the array of arrays [0] - arrive at the array [0] - arrive at the key. 
                // This is because this.data[address] = [] everytime a new key value pair is set
            }
        }
        return keys_array;
    }

    // O(n*n)
    // Extract the keys even if there's hash collision
    keys_with_collision() {
        if (!this.data.length) {
            return undefined;
        }
        const keys_array = [];
        for (let i = 0; i < keys_array.length; i++) {
            if (this.data[i] && this.data[i].length) {
                // loop through all potential collisions
                if (this.data.length > 1) {
                  for (let j = 0; j < this.data[i].length; j++) {
                    keys_array.push(this.data[i][j][0])
                  }
                } else {
                    keys_array.push(this.data[i][0])
                } 
              }
        }
        return keys_array;
    }
}