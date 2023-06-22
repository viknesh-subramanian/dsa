using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.ds
{
    public class Node
    {
        public string key { get; set; }
        public int value { get; set; }

        public Node(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
    public class HashTables
    {
        private class Nodes : List<Node> { }
        private int length;
        private Nodes[] data;

        public HashTables(int size)
        {
            this.length = size;
            this.data = new Nodes[size];
        }

        // Hash functions are usually pretty fast
        // O(1)
        private int _hash(string key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i] * i) % this.length;
            }
            return hash;
        }

        // O(1)
        public void set(string key, int value)
        {
            int index = _hash(key);
            if (this.data[index] == null)
            {
                this.data[index] = new Nodes();
            }
            this.data[index].Add(new Node(key, value));
        }

        // O(1) in most of the cases
        // O(n) when there's a hash collision
        public int get(string key)
        {
            int index = _hash(key);
            if (this.data[index] == null)
            {
                return 0;
            }
            foreach (var node in this.data[index])
            {
                if (node.key.Equals(key))
                {
                    return node.value;
                }
            }
            return 0;
        }

        // O(n*n)
        public List<string> keys()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    for (int j = 0; j < length; j++)
                    {
                        result.Add(this.data[i][j].key);
                    }
                }
            }
            return result;
        }
    }
}
