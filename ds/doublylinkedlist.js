class DLLNode {
    constructor(value) {
        this.value = value;
        this.next = null;
        this.prev = null;
    }
}

class DoublyLinkedList {
    constructor(value) {
        this.head = new DLLNode(value);
        // Assigning reference of head to tail
        // So when tail.next is assigned a new value, it updates the reference head.next as well
        this.tail = this.head;
        this.length = 1;
    }
    // O(1)
    append(value) {
        const new_node = new DLLNode(value);
        new_node.prev = this.tail;
        this.tail.next = new_node; // Refer lines 7 & 8
        this.tail = new_node; // Updating tail to the appended new_node
        this.length++;
        return this;
    }
    // O(1)
    prepend(value) {
        const new_node = new DLLNode(value);
        new_node.next = this.head;
        this.head.prev = new_node;
        this.length++;
        return this;
    }

    print() {
        const array = [];
        let current_node = this.head;
        while (current_node !== null) {
            array.push(current_node.value);
            current_node = current_node.next;
        }
        return array;
    }

    // O(n)
    traverse_index(index) {
        let counter = 0;
        let current_node = this.head;
        while (counter !== index) {
            current_node = current_node.next;
            counter++;
        }
        return current_node;
    }

    // O(n)
    insert(index, value) {
        if (index >= this.length) {
            return this.append(value);
        }
        if (index === 0) {
            return this.prepend(value);
        }
        const new_node = new DLLNode(value);
        // Traverse to the index right before the target
        const leader = this.traverse_index(index - 1); // O(n)
        // Fetch the next value
        const follower = leader.next;
        // Break the chain and assign the new node
        leader.next = new_node;
        new_node.prev = leader;
        // Form the new chain with the new node
        new_node.next = follower;
        follower.prev = new_node;
        this.length++;
        return this.print()
    }
    // O(n)
    remove(index) {
        if (index >= this.length) return
        if (index === 0) {
            let newHead = this.traverse_index(1);
            this.head = newHead;
            this.head.prev = null;
            this.length--;
        }
        else {
            const leader = this.traverse_index(index - 1);
            const unwantedNode = leader.next;
            const follower = unwantedNode.next;
            leader.next = follower;
            follower.prev = leader;
            this.length--;
        }
        return this.print();
    }
}