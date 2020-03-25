using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex6
{
    class BitArray64 : IEnumerable<ulong>
    {
        private ulong _value;

        public BitArray64(ulong value = 0)
        {
            _value = value;
        }

        // Indexer declaration
        public ulong this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    // Check the bit at position index
                    return ((_value >> index) & 1);
                }
                else
                {
                    throw new IndexOutOfRangeException($"Index {index} is invalid!");
                }
            }
            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException($"Index {index} is invalid!");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException($"Value {value} is invalid!");
                }

                // Clear the bit at position index
                _value &= ~(1ul << index);
                // Set the bit at position index to value
                _value |= (1ul << index);
            }
        }


        public override bool Equals(object obj)
        {
            var arr = obj as BitArray64;

            if (arr != null)
            {
                for (int i = 0; i <= 63; i++)
                {
                    if (this[i] != arr[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 63; i >= 0; i--)
            {
                result.Append((_value >> i) & 1);
            }

            return result.ToString();
        }


        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !Equals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _value.GetHashCode();
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return ((_value >> i) & 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}