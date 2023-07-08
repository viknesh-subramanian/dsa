// Given the root of a binary tree, determine if it is a valid binary search tree (BST).

// A valid BST is defined as follows:

// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.

const isValidBST = (root, minimum, maximum) => {
    // Base case: root is null...
    if(root == null) return true;
    // If the value of root is less or equal to minimum...
    // Or If the value of root is greater or equal to maximum...
    if(root.val <= minimum || root.val >= maximum) return false;
    // Recursively call the function for the left and right subtree...
    return isValidBST(root.left, minimum, root.val) && isValidBST(root.right, root.val, maximum);
};

// Input: root = [2,1,3]
// Output: true

// Input: root = [5,1,4,null,null,3,6]
// Output: false
// Explanation: The root node's value is 5 but its right child's value is 4.