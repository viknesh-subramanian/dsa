class LLNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class SinglyLinkedList {
    constructor(value) {
        this.head = new LLNode(value);
        // Assigning reference of head to tail
        // So when tail.next is assigned a new value, it updates the reference head.next as well
        this.tail = this.head;
        this.length = 1;
    }
    // O(1)
    append(value) {
        const new_node = new LLNode(value);
        this.tail.next = new_node; // Refer lines 7 & 8
        this.tail = new_node; // Updating tail to the appended new_node
        this.length++;
        return this;
    }
    // O(1)
    prepend(value) {
        const new_node = new LLNode(value);
        new_node.next = this.head;
        this.length++;
        return this;
    }
    
    print() {
        const array = [];
        let current_node = this.head;
        while(current_node !== null) {
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
        const new_node = new LLNode(value);
        // Traverse to the index right before the target
        const leader = this.traverse_index(index - 1); // O(n)
        // Fetch the next value
        const pointer_hold = leader.next;
        // Break the chain and assign the new node
        leader.next = new_node;
        // Form the new chain with the new node
        new_node.next = pointer_hold;
        this.length++;
        return this.print()
    }

    // O(n)
    remove(index) {
        // Traverse to the index right before the target
        const leader = this.traverse_index(index - 1);
        // Fetch the next value
        const removed_node = leader.next;
        // Assign new relationship
        leader.next = removed_node.next;
        this.length--;
        return this.print();
    }

    // O(n)
    reverse() {
        if (!this.head.next) {
            return this.head;
        }
        let first = this.head;
        this.tail = this.head;
        let second = first.next;
        while (second) {
            const third = second.next;
            second.next = first;
            first = second;
            second = third;
        }
        this.head.next = null;
        this.head = first;

        return this.print();
    }
}