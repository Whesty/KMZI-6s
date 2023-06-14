using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Lab3
    {
        public string ConvertDocumentToBase64(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);

            string base64String = Convert.ToBase64String(fileBytes);


            return base64String;
        }

        public int FindAlphabetRedundancy(string alphabet)
        {
            int length = alphabet.Length;

            // Initialize the array to store the frequency of each character in the alphabet
            int[] frequency = new int[length+1];

            // Calculate the frequency of each character in the alphabet
            for (int i = 0; i < length; i++)
            {
                char c = alphabet[i];
                int index = char.ToLower(c) - alphabet[0];
                frequency[index]++;
            }

            // Calculate the sum of the squares of the frequencies
            int sumOfSquares = 0;
            for (int i = 0; i < length; i++)
            {
                sumOfSquares += frequency[i] * frequency[i];
            }

            // Calculate the redundancy
            int redundancy = sumOfSquares - length;

            return redundancy;
        }
        public byte[] XorBuffers(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                if (a.Length < b.Length)
                {
                    Array.Resize(ref a, b.Length);
                }
                else
                {
                    Array.Resize(ref b, a.Length);
                }
            }

            byte[] result = new byte[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = (byte)(a[i] ^ b[i]);
            }

            return result;
        }


    }
}
