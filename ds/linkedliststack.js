class LinkedListStack {
    constructor() {
        this.top = null;
        this.bottom = null;
        this.length = 0;
    }

    peek() {
        return this.top;
    }

    push(value) {
        const new_node = new LLNode(value);
        if (!this.length) {
            this.top = new_node;
            this.bottom = new_node;
        } else {
            const placeholder = this.top;
            this.top = new_node;
            this.top.next = placeholder;
        }
        this.length++;
        return this;
    }

    pop() {
        if (!this.top) {
            return null;
        }
        if (this.top === this.bottom) {
            this.bottom = null;
        }
        // In case we want to return the placeholder
        const placeholder = this.top;
        this.top = this.top.next;
        this.length--;
        return this;
    }

    isEmpty() {

    }
}