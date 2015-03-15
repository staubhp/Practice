using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misc_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            duplicateRemove();

        }

        static void duplicateRemove()
        {
            Console.WriteLine("Duplicate Remover");
            Console.WriteLine("Enter comma-separated elements:");
            string input = Console.ReadLine();
            var myElements = input.Split(',');
            var myDupeRemover = new DuplicateRemover<string>();
            var removed = myDupeRemover.removeDuplicates(myElements);
            Console.WriteLine("Output: " + string.Join(", ", removed.Select(x => x.ToString())));
            duplicateRemove();

        }
    }

    class DuplicateRemover<T>
    {
        public T[] removeDuplicates(T[] arr){
            HashSet<T> myHashset = new HashSet<T>();
            List<int> removeAts = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (myHashset.Any(x => x.Equals(arr[i])))
                {
                    removeAts.Add(i);
                    continue;
                }

                myHashset.Add(arr[i]);
            }

            T[] ret = new T[arr.Length-removeAts.Count];
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (removeAts.Contains(i))
                    continue;

                ret[index] = arr[i];
                index++;
            }

            return ret;
        }
    }
}
