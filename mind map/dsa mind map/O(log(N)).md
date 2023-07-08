log(N) grows very slowly. Could be:
* Lookup by primary key in a relational database is log(N). Many mainstream relational databases like PostgreSQL use B-trees for indexing by default and searching in B-tree is log(N)
* Binary Search or variant
* Balanced binary search tree (BST) lookup
* Processing the digits of a number
* Typically for n > 10⁸