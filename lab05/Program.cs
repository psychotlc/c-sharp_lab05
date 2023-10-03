using System;
using System.Collections;
using System.Collections.Generic;

namespace lab05{
    class task1{
        class MyMatrix
        {
            private int[,] data;
            private int rows;
            private int columns;
            private Random random = new Random();

            public MyMatrix(int m, int n)
            {
                rows = m;
                columns = n;
                data = new int[rows, columns];
                Fill();
            }

            public void Fill()
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        data[i, j] = random.Next(1, 101); 
                    }
                }
            }

            public void ChangeSize(int newRows, int newColumns)
            {
                int[,] newData = new int[newRows, newColumns];
                int minRows = Math.Min(rows, newRows);
                int minCols = Math.Min(columns, newColumns);

                for (int i = 0; i < minRows; i++)
                {
                    for (int j = 0; j < minCols; j++)
                    {
                        newData[i, j] = data[i, j];
                    }
                }

                for (int i = minRows; i < newRows; i++)
                {
                    for (int j = minCols; j < newColumns; j++)
                    {
                        newData[i, j] = random.Next(1, 101);
                    }
                }

                data = newData;
                rows = newRows;
                columns = newColumns;
            }

            public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
            {
                if (startRow < 0 || startRow >= rows || endRow < 0 || endRow >= rows ||
                    startColumn < 0 || startColumn >= columns || endColumn < 0 || endColumn >= columns)
                {
                    Console.WriteLine("Некорректные значения начальных и/или конечных индексов.");
                    return;
                }

                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startColumn; j <= endColumn; j++)
                    {
                        Console.Write(data[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            public void Show()
            {
                ShowPartialy(0, rows - 1, 0, columns - 1);
            }

            public int this[int index1, int index2]
            {
                get
                {
                    if (index1 < 0 || index1 >= rows || index2 < 0 || index2 >= columns)
                    {
                        throw new IndexOutOfRangeException("Индекс за пределами матрицы");
                    }
                    return data[index1, index2];
                }
                set
                {
                    if (index1 < 0 || index1 >= rows || index2 < 0 || index2 >= columns)
                    {
                        throw new IndexOutOfRangeException("Индекс за пределами матрицы");
                    }
                    data[index1, index2] = value;
                }
            }
        }
    }

    class task2{

        class MyList<T>
        {
            private T[] items;
            private int count;

            public MyList()
            {
                items = new T[4];
                count = 0;
            }

            public int Count => count;

            public void Add(T item)
            {
                if (count == items.Length)
                {
                
                    T[] newItems = new T[items.Length * 2];
                    Array.Copy(items, newItems, items.Length);
                    items = newItems;
                }

                items[count] = item;
                count++;
            }

            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                    {
                        throw new IndexOutOfRangeException("Индекс за пределами списка");
                    }
                    return items[index];
                }
            }
        }

    }

    class task3{
        class MyDictionary<TKey, TValue>:IEnumerable<KeyValuePair<TKey, TValue>>{
            KeyValuePair<TKey, TValue>[] items;

            MyDictionary(){
                items = new KeyValuePair<TKey, TValue>[0];
            }

            public TValue this[TKey key]{
                get{
                    for (int i = 0; i< items.Length; i++){
                        if (Equals(items[i].Key, key)){
                            return items[i].Value;
                        }
                    }
                    throw new Exception("Key is not found");
                }
                set{
                    for (int i = 0; i< items.Length; i++){
                        if (Equals(items[i].Key, key)){
                            items[i] = new KeyValuePair<TKey, TValue>(key, value);
                            return;
                        }
                        Array.Resize(ref items, items.Length+1);
                        items[items.Length-1] = new KeyValuePair<TKey, TValue>(key, value);
                    }
                    
                }
            }

            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                for (int i = 0; i < items.Length; i++)
                {
                    yield return items[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}