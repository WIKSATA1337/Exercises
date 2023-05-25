namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float LoadFactor = 0.75f;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        public int Count { get; private set; }

        public int Capacity => slots.Length;

        public HashTable(int capacity = DEFAULT_CAPACITY)
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        private HashTable(int capacity, IEnumerable<KeyValue<TKey, TValue>> kvp)
            : this(capacity)
        {
            foreach (var element in kvp)
            {
                Add(element.Key, element.Value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            ResizeNeedCheck();

            int index = Math.Abs(key.GetHashCode()) % Capacity;

            if (slots[index] is null)
            {
                slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (KeyValue<TKey, TValue> element in slots[index])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException("Duplicate key.", key.ToString());
                }
            }

            KeyValue<TKey, TValue> newElement = new KeyValue<TKey, TValue>(key, value);
            slots[index].AddLast(newElement);
            Count++;
        }

        private void ResizeNeedCheck()
        {
            if ((float)(Count + 1) / Capacity >= LoadFactor)
            {
                HashTable<TKey, TValue> newTable = new HashTable<TKey, TValue>(Capacity * 2, this);

                slots = newTable.slots;
            }
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                Add(key, value);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.ToLower().Contains("duplicate key"))
                {
                    int index = Math.Abs(key.GetHashCode()) % Capacity;
                    var keyValue = slots[index].FirstOrDefault(kvp => kvp.Key.Equals(key));

                    keyValue.Value = value;
                    return true;
                }

                throw;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            var returnValue = Find(key);

            return returnValue is null ? throw new KeyNotFoundException() : returnValue.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var result = Find(key);

            if (result is null)
            {
                value = default;
                return false;
            }

            value = result.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var index = Math.Abs(key.GetHashCode()) % Capacity;

            if (!(slots[index] is null))
            {
                foreach (var element in slots[index])
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return !(Find(key) is null);
        }

        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % Capacity;

            if (!(slots[index] is null))
            {
                var node = slots[index].First;

                while (!(node is null))
                {
                    if (node.Value.Key.Equals(key))
                    {
                        slots[index].Remove(node);
                        Count--;
                        return true;
                    }

                    node = node.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            slots = new LinkedList<KeyValue<TKey, TValue>>[DEFAULT_CAPACITY];
            Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values => this.Select(kvp => kvp.Value);

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in slots)
            {
                if (!(slot is null))
                {
                    foreach (var element in slot)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}