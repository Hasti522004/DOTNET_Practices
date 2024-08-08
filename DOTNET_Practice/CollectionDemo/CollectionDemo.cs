using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DOTNET_Practice.CollectionDemo
{
    internal class CollectionDemo
    {
        static void Main(string[] args)
        {
            
            //1. Array - Fixed Length and Zero Indexed
            Console.WriteLine("Array : ");
            string[] cars = new string[3]
            {
                "Volvo",
                "BMW",
                "Ford"
            };
           
            string[] car =
            {
                "Volvo",
                "BMW",
                "Ford"
            };
            foreach (string s in cars)
            {
                Console.WriteLine(s);
            }
            Array.Reverse(cars);
            foreach (string s in cars)
            {
                Console.WriteLine(s); ;
            }
            Array.Sort(cars);
            foreach(string s in cars)
            {
                Console.WriteLine(s); 
            }

            // 2D array
            int[,] arr = new int[3,3];
            arr[0, 0] = 1; arr[1,0] = 2; arr[2,0]   = 3;
            arr[0,1] = 4; arr[1,1] = 5; arr[2, 1] = 6;
            Console.WriteLine(arr[2,1]);

            // Jagged Array 
            int[][] jaggedarray = new int[3][];
            jaggedarray[0] = new int[5];
            jaggedarray[1] = new int[2];
            jaggedarray[2] = new int[6];

            int num = 0;
            for(int i = 0; i < jaggedarray.GetLength(0); i++)
            {
                for(int j = 0;j < jaggedarray[i].Length; j++)
                {
                    num++;
                    jaggedarray[i][j] = num;
                }
            }

            for (int i = 0; i < jaggedarray.GetLength(0); i++)
            {
                for (int j = 0; j < jaggedarray[i].Length; j++)
                {
                    Console.Write($"{jaggedarray[i][j]} ");
                }
                Console.WriteLine();
            }

            // Non - generic Collections
            // 3. ArrayList
            Console.WriteLine("\nArrayList : ");
            ArrayList arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add("Hasti");
            arrList.Add(true);
            arrList.Add(false);
            arrList.Add(1.23);
            arrList.AddRange(arrList);
            arrList.Insert(1, "1st Index");
            arrList.Remove(1);
            // arrList.Clear();

            foreach( var s in arrList)
            {
                Console.WriteLine(s); ;
            }

            int totalItems = arrList.Count;
            Console.Write("Total items is : ");
            Console.WriteLine(totalItems);

            // 4. HashTable
            Console.WriteLine("\nHashTable");
            Hashtable ht = new Hashtable();
            ht.Add(1, "Hasti");
            ht.Add("1", "Jatan");

            foreach(DictionaryEntry s in ht)
            {
                Console.WriteLine($"{s.Key} {s.Value}");
            }
            Console.WriteLine(ht["1"]);
            Console.WriteLine(ht.Contains(1));

            //5. Stack
            Console.WriteLine("\nStack Implementation : ");
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push("Hasti");
            stack.Push(true);
            stack.Push(1.22f);
            stack.Pop();
            var temp1 = stack.IsSynchronized;
            Console.WriteLine($"temp1 {temp1}");
            var temp = stack.Peek();
            Console.WriteLine($"peek from stack {temp}");
            foreach (object o in stack)
            {
                Console.WriteLine(o);
            }

            // Generic Collections 
            // 1. List
            Console.WriteLine("\nList : ");
            List<string> list = new List<string>();
            list.Add("Hasti");
            list.Add("Hajipara");
            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);

            foreach( int i in list2)
            {
                Console.WriteLine(i); 
            }
           
            list.ForEach(s => Console.WriteLine(s));

            //2. Dictionary
            Console.WriteLine("\nDictionary");
            Dictionary<int,string> keyValuePairs = new Dictionary<int,string>();
            keyValuePairs.Add(1, "Hasti");
            keyValuePairs.Add(2, "Dhara");
            foreach(KeyValuePair<int,string> a in keyValuePairs)
            {
                Console.WriteLine(a.Key);
                Console.WriteLine(a.Value);
            }

            // 3. Hashset
            Console.WriteLine("\nHashset");
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(1);
            set.Add(3);
            set.Add(4);
            set.Add(3);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

    }
    //concept of const and readonly
    class ReadOnlyTest
    {
        int a = 10;
        const int b = 20;
        readonly int c;
        
        public ReadOnlyTest()
        {
            c = 30;  
        }
    }
}
