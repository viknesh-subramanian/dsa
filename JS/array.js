class customArray {
    constructor() {
        this.length = 0;
        this.data = {};
    }

    // O(1)
    get(index) {
        return this.data[index];
    }

    // O(1)
    push(item) {
        this.data[this.length] = item;
        this.length++;
        return this.data;
    }

    // O(1)
    pop() {
        const lastItem = this.data[this.length - 1];
        delete this.data[this.length - 1];
        this.length--;
        return lastItem;
    }

    // O(n)
    delete(index) {
        const item = this.data[index];
        this.shift(index);
        return item;
    }

    shift(index) {
        for(let i = index; i < this.length - 1; i++) {
            this.data[i] = this.data[i + 1];
        }
        delete this.data[this.length - 1];
        this.length--;
    }
}