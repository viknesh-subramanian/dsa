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
    // O(n)
    bfs() {
        let current_node = this.root;
        let list = [];
        let queue = [];
        // Queue at the beginning contains the current node aka the root 
        queue.push(current_node);

        while (queue.length > 0) { // As long as the queue has values inside, meaning as long as we reach a leaf node
            current_node = queue.shift(); // Move the first item on the queue to the current node
            list.push(current_node); // Output array - also shows the traversal history/pattern
            if (current_node.left) {
                queue.push(current_node.left); // Traversing. If the node has a left child, that is the next item on the queue
            }
            if (current_node.right) {
                queue.push(current_node.right); // Traversing. If the node has a right child, that is the next item on the queue
            }
        }
        return list;
    }
    // O(n)
    bfs_recursive(queue, list) {
        if (!queue.length) {
            return list;
        }
        let current_node = queue.shift();
        list.push(current_node.value);
        if (current_node.left) {
            queue.push(current_node.left); // Traversing. If the node has a left child, that is the next item on the queue
        }
        if (current_node.right) {
            queue.push(current_node.right); // Traversing. If the node has a right child, that is the next item on the queue
        }

        return this.bfs_recursive(queue, list);
    }
    //bfs_recursive([tree.root], []) - Initial call

    // O(h) where h = height of the tree - space complexity
    dfs_inorder() {
        traverse_inorder(this.root, []);
    }

    dfs_preorder() {
        traverse_preorder(this.root, []);
    }

    dfs_postorder() {
        traverse_postorder(this.root, []);
    }
}

function traverse(node) {
    const tree = { value: node.value };
    tree.left = node.left === null ? null : traverse(node.left);
    tree.right = node.left === null ? null : traverse(node.right);
    return tree;
}
// Consider binary tree
//        9
//    4       20
//  1   6   15  170

// Traversing by inorder
// Output => [1, 4, 6, 9, 15, 20, 170]
function traverse_inorder(node, list) {
    if (node.left) {
        traverse_inorder(node.left, list);
    }
    // Traversing till the end aka the leaf node
    list.push(node.value);
    if (node.right) {
        traverse_inorder(node.right, list);
    }
    return list;
}

// Traversing by preorder
// Output => [9, 4, 1, 6, 20, 15, 170]
function traverse_preorder(node, list) {
    // Inserting to the list at the beginning as it travels from the root and preference is given to the parent node
    list.push(node.value);
    if (node.left) {
        traverse_preorder(node.left, list);
    }
    if (node.right) {
        traverse_preorder(node.right, list);
    }
    return list;
}

// Traversing by postorder
// Output => [1, 6, 4, 15, 170, 20, 9]
function traverse_postorder(node, list) {
    if (node.left) {
        traverse_postorder(node.left, list);
    }
    if (node.right) {
        traverse_postorder(node.right, list);
    }
    // Inserting to the list at the last as it travels from the root and preference is given to the child/leaf node
    list.push(node.value);
    return list;
}