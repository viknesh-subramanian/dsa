using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.ds
{
    public class CustomArray
    {
        public int length { get; set; }
        public Object[] data { get; set; }
        public CustomArray()
        {
            this.length = 0;
            this.data = new Object[] { };
        }

        // O(1)
        public Object Get(int index)
        {
            return this.data[index];
        }

        // O(1)
        public Object[] Push(Object item)
        {
            this.data[this.length] = item;
            this.length++;
            return this.data;
        }

        // O(1)
        public Object Pop()
        {
            Object popped = this.data[this.length - 1];
            this.data[this.length - 1] = null;
            this.length--;
            return popped;
        }

        // O(n)
        public Object Delete(int index)
        {
            Object deletedItem = this.data[index];
            Shift(index);
            return deletedItem;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.length - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.data[this.length - 1] = null;
            this.length--;
        }
    }
}
