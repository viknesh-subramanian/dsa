class TreeNode {
    constructor(value) {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

class BinarySearchTree {
    constructor() {
        this.root = null;
    }

    // O(log n)
    insert(value) {
        const new_node = TreeNode(value);
        if (this.root === null) {
            this.root = new_node;
        } else {
            let current_node = this.root;
            while (true) {
                if (value < current_node.value) {
                    if (!current_node.left) {
                        current_node.left = new_node;
                        return this;
                    }
                    current_node = current_node.left;
                } else {
                    if (!current_node.right) {
                        current_node.right = new_node;
                        return this;
                    }
                    current_node = current_node.right;
                }
            }
        }
    }
    // O(log n)
    lookup(value) {
        if (!this.root) {
            return false;
        }
        let current_node = this.root;
        while (current_node) {
            if (value < current_node.value) {
                current_node = current_node.left;
            } else if (value > current_node.value) {
                current_node = current_node.right;
            } else if (value === current_node.value) {
                return current_node;
            }
        }
        return false;
    }
    // O(log n)
    remove(value) {
        if (!this.root) {
            return false;
        }
        let current_node = this.root;
        let parent_node = null;
        while (current_node) {
            if (value < current_node.value) {
                parent_node = current_node;
                current_node = current_node.left;
            } else if (value > current_node.value) {
                parent_node = current_node;
                current_node = current_node.right;
            } else if (current_node.value === value) {
                //We have a match, get to work!

                //Option 1: No right child: 
                if (current_node.right === null) {
                    if (parent_node === null) {
                        this.root = current_node.left;
                    } else {
                        //if parent > current value, make current left child a child of parent
                        if (current_node.value < parent_node.value) {
                            parent_node.left = current_node.left;

                            //if parent < current value, make left child a right child of parent
                        } else if (current_node.value > parent_node.value) {
                            parent_node.right = current_node.left;
                        }
                    }
                } else if (current_node.right.left === null) { //Option 2: Right child which doesnt have a left child
                    current_node.right.left = current_node.left;
                    if (parent_node === null) {
                        this.root = current_node.right;
                    } else {

                        //if parent > current, make right child of the left the parent
                        if (current_node.value < parent_node.value) {
                            parent_node.left = current_node.right;

                            //if parent < current, make right child a right child of the parent
                        } else if (current_node.value > parent_node.value) {
                            parent_node.right = current_node.right;
                        }
                    }
                    //Option 3: Right child that has a left child
                } else {
                    //find the Right child's left most child
                    let leftmost = current_node.right.left;
                    let leftmost_parent = current_node.right;
                    while (leftmost.left !== null) {
                        leftmost_parent = leftmost;
                        leftmost = leftmost.left;
                    }
                    //Parent's left subtree is now leftmost's right subtree
                    leftmost_parent.left = leftmost.right;
                    leftmost.left = current_node.left;
                    leftmost.right = current_node.right;

                    if (parent_node === null) {
                        this.root = leftmost;
                    } else {
                        if (current_node.value < parent_node.value) {
                            parent_node.left = leftmost;
                        } else if (current_node.value > parent_node.value) {
                            parent_node.right = leftmost;
                        }
                    }
                }
                return true;
            }
        }
    }
}

function traverse(node) {
    const tree = { value: node.value };
    tree.left = node.left === null ? null : traverse(node.left);
    tree.right = node.left === null ? null : traverse(node.right);
    return tree;
}