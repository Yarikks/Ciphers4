using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADFGVX
{
    class Program
    {
        private static Random rnd = new Random();
        private static Dictionary<int, char> ADF = new Dictionary<int, char>()
        {
            {0, 'A' },
            {1, 'D' },
            {2, 'F' },
            {3, 'G' },
            {4, 'V' },
            {5, 'X' }           
        };
        private static Dictionary<char, string> pairs = new Dictionary<char, string>();

        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            string text = "he stole all your money";
            string key = "cipher";

            Console.WriteLine("Ciphered text:{0}",Encrypt(alphabet, text,key));

            Console.ReadLine();
        }

        static string Encrypt(string alpha, string text, string key)
        {
            // delete all spaces
            string[] textes = text.Split(' ');
            string newText = "";
            for (int i = 0; i < textes.Length; i++)
            {
                newText += textes[i];
            }

            int n = 6;
            char[,] arr = new char[n, n];

            for (int i = 0, k = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = alpha[k];
                    k++;
                }
            }

            Mix(arr);

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            string ciphered = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < newText.Length; k++)
                    {

                        if (newText[k] == arr[i,j])
                        {

                            Console.WriteLine("Char: " + arr[i, j]);
                            ciphered += ADF.Values.ElementAt(i);
                            ciphered += ADF.Values.ElementAt(j);
                            Console.WriteLine(text);
                            Console.WriteLine(ciphered);
                        }
                    }
                
                }
            }


            char[,] arr2 = new char[ciphered.Length / key.Length, key.Length];

            for (int i = 0,k=0; i < arr2.GetLength(0); i++)
            {
                for(int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = ciphered[k];
                    k++;
                    Console.Write(arr2[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            string val = " ";
            for(int i = 0; i < key.Length; i++)
            {
                val = " ";
                for(int j = 0; j < ciphered.Length / 6; j++)
                {
                    val += arr2[j, i];          
                }
                pairs.Add(key[i], val);
                Console.WriteLine(pairs.ElementAt(i));
            }
            char[] keys = new char[key.Length];

            for(int i = 0; i < key.Length; i++)
            {
                keys[i] = key[i];
            }

            Array.Sort(keys);
            
            Console.Write("Sorted key: ");
            Console.Write(keys);
            Console.WriteLine();

            val = " ";
            for(int i = 0; i < key.Length; i++)
            {
                val += pairs.Values.ElementAt(i);
            }

            return val;
        }

        static void Mix(char[,] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int r1 = rnd.Next(0, arr.GetLength(0));
                int r2 = rnd.Next(0, arr.GetLength(0));
                int c1 = rnd.Next(0, arr.GetLength(1));
                int c2 = rnd.Next(0, arr.GetLength(1));

                char temp = arr[r1, c1];
                arr[r1, c1] = arr[r2, c2];
                arr[r2, c2] = temp;
            }
        }
    }
}
