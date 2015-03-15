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
            //duplicateRemove();
            stringTokenizer();

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

        static void stringTokenizer()
        {
            Console.WriteLine("String Tokenizer");
            Console.WriteLine("Enter input string:");
            string input = Console.ReadLine();
            Console.WriteLine("Enter delimiter char:");
            char delimiter = Console.ReadLine()[0];
            var myTokenizer = new StringTokenizer();
            var tokens = myTokenizer.strtok(delimiter, input);
            Console.WriteLine("Output: " + string.Join(",", tokens.Select(x => x)));
            stringTokenizer();
                
        }
    }

    class StringTokenizer
    {
        public string[] strtok(char delimiter, string input)
        {
            string currentToken ="";
            List<int> delimiterIndices = new List<int>();
            for (int i=0; i<input.Length; i++){
                if (input[i] == delimiter)
                    delimiterIndices.Add(i);
            }

            string[] ret = new string[delimiterIndices.Count + 1];
            for (int i=0; i<delimiterIndices.Count; i++){
                ret[i] = input.Substring((i == 0 ? 0 : delimiterIndices[i-1]+1), delimiterIndices[i]-(i == 0 ? 0 : delimiterIndices[i-1]+1));
                if (i == delimiterIndices.Count - 1)
                {
                    ret[i + 1] = input.Substring(delimiterIndices[i]+1);
                }
            }
            
            return ret;
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
 