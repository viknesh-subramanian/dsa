class Queue {
    constructor() {
        this.first = null;
        this.last = null;
        this.length = 0;
    }

    peek() {
        return this.first;
    }

    enqueue(value) {
        const new_node = new LLNode(value);
        if (this.length === 0) {
            this.first = new_node;
            this.last = new_node;
        } else {
            this.last.next = new_node;
            this.last = new_node;
        }
        this.length++;
        return this;
    }

    dequeue() {
        if (!this.first) {
            return null;
        }
        if (this.first === this.last) {
            this.last = null;
        }
        // In case we want to return the placeholder
        const placeholder = this.top;
        this.first = this.first.next;
        this.length--;
        return this;
    }

    isEmpty() {

    }
}