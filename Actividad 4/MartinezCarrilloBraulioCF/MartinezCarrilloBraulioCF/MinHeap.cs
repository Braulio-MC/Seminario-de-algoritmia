using System;


namespace MartinezCarrilloBraulioCF
{
    class MinHeap
    {
        private Edge[] _items;
        private int _index;

        public MinHeap()
        {
            _index = 0;
        }

        public void Init(int size)
        {
            _items = new Edge[size];
        }

        public bool IsEmpty()
        {
            return _index == 0;
        } 

        public bool IsFull()
        {
            return _index == _items.Length;
        }

        public void Add(Edge item)
        {
            if (!IsFull())
            {
                _items[_index++] = item;
                BubbleUp();
            }
        }

        public void AddRange(Edge[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public Edge Del()
        {
            if (!IsEmpty())
            {
                var first = _items[0];
                _items[0] = _items[_index - 1];
                _index--;
                BubbleDown();
                return first;
            }
            return null;
        }

        public void Heapify(Edge[] items)
        {
            _items = items;
            for (int i = LastParentWithChildren(); i > 0; i--)
            {
                BubbleDown(i);
            }
        } 

        private void BubbleUp()
        {
            var current = _index - 1;
            while (HasParent(current) && _items[ParentIndexOf(current)].Weight > _items[current].Weight)
            {
                Swap(ParentIndexOf(current), current);
                current = ParentIndexOf(current);
            }
        }

        private void BubbleDown(int optional_index=0)
        {
            var first = optional_index;
            while (HasLeftChild(first))
            {
                var smaller = LeftChildOf(first);
                if (HasRightChild(first) && RightValue(first).Weight < LeftValue(first).Weight)
                {
                    smaller = RightChildOf(first);
                }
                if (_items[first].Weight <= _items[smaller].Weight) break;
                Swap(first, smaller);
                first = smaller;
            }
        }

        private void Swap(int index1, int index2)
        {
            var tmp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = tmp;
        }

        private static int LeftChildOf(int parent_index)
        {
            return parent_index * 2 + 1;
        }

        private bool HasLeftChild(int parent_index)
        {
            return LeftChildOf(parent_index) < _index;
        }

        private Edge LeftValue(int parent_index)
        {
            return _items[LeftChildOf(parent_index)];
        }

        private static int RightChildOf(int parent_index)
        {
            return parent_index * 2 + 2;
        }

        private bool HasRightChild(int parent_index)
        {
            return RightChildOf(parent_index) < _index;
        }

        private Edge RightValue(int parent_index)
        {
            return _items[RightChildOf(parent_index)];
        }

        private static int ParentIndexOf(int child_index)
        {
            return (child_index - 1) / 2;
        }

        private static bool HasParent(int child_index)
        {
            return ParentIndexOf(child_index) >= 0;
        }

        private int LastParentWithChildren()
        {
            return (_index - 2) / 2;
        }

        public void Clear()
        {
            if (!IsEmpty())
            {
                Array.Clear(_items, 0, _index);
                _index = 0;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (var item in _items)
            {
                s += item + " | ";
            }
            return s;
        }

        public Edge this[int i]
        {
            get => _items[i];
        }
    }
}
