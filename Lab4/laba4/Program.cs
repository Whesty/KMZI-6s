using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Считывание текста с файла
            string text = System.IO.File.ReadAllText(@"../../Text.txt");
            Console.WriteLine("Шифр цезаря:");
            Console.WriteLine("Исходный текст: " + text);
            //Шифрование текста с помощью шифра Цезаря
            string key = "mamaeva";
            int shift = 24;
            int decshift = -24;
            string cipherText = CaesarCipher(text, key, shift);
            Console.WriteLine("Зашифрованный текст: " + cipherText);
            //Расшифровка текста с помощью шифра Цезаря
            string decipherText = CaesarCipher(cipherText, key, decshift);
            Console.WriteLine("Расшифрованный текст: " + decipherText);
            Console.WriteLine("\nТаблица Трисемуса, ключевое слово – собственное имя");
            //Таблица Трисемуса
            Console.WriteLine(text);
            string key2 = "diana";
            string TesiusText = TrithemiusCipher(text, key2);
            Console.WriteLine(TesiusText);
            string TesiusText2 = TrithemiusDecipher(TesiusText, key2);
            Console.WriteLine(TesiusText2);




        }

        //Шифр Цезаря с ключевым словом, ключевое слово – mamaeva, а = 24
        static string CaesarCipher(string inputText, string key, int shift)
        {
            // Convert the key to lowercase
            key = key.ToLower();

            // Create a string of the alphabet
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int positiveShift = ((shift % alphabet.Length) + alphabet.Length) % alphabet.Length;
            string shiftedAlphabet = alphabet.Substring(positiveShift) + alphabet.Substring(0, positiveShift);


            // Initialize the output string
            string outputText = "";

            // Loop through each character in the input text
            for (int i = 0; i < inputText.Length; i++)
            {
                char currentChar = inputText[i];

                // If the current character is a letter
                if (Char.IsLetter(currentChar))
                {
                    // Get the index of the current letter in the alphabet
                    int alphabetIndex = alphabet.IndexOf(Char.ToLower(currentChar));

                    // Get the corresponding letter from the shifted alphabet
                    char shiftedChar = shiftedAlphabet[alphabetIndex];

                    // If the current letter is uppercase, convert the shifted letter to uppercase
                    if (Char.IsUpper(currentChar))
                    {
                        shiftedChar = Char.ToUpper(shiftedChar);
                    }

                    // Add the shifted letter to the output string
                    outputText += shiftedChar;
                }
                else
                {
                    // If the current character is not a letter, add it to the output string unchanged
                    outputText += currentChar;
                }
            }

            // Return the output string
            return outputText;
        }
        static string TrithemiusCipher(string plainText, string key)
        {
            string cipherText = "";
            int keyIndex = 0;

            foreach (char c in plainText)
            {
                int shift = char.ToUpper(key[keyIndex]) - 64;
                cipherText += ShiftCharacter(c, shift);

                keyIndex++;
                if (keyIndex == key.Length)
                    keyIndex = 0;
            }

            return cipherText;
        }

        static char ShiftCharacter(char c, int shift)
        {
            if (!char.IsLetter(c))
                return c;
            
            char baseChar = char.IsUpper(c) ? 'A' : 'a';
            if(c-baseChar+shift<0)
            {
                char baseChar2 = char.IsUpper(c) ? 'Z' : 'z';
                shift = c - baseChar + shift;
                return (char)(((baseChar2 - baseChar + shift+1) % 26) + baseChar);
            }
            return (char)(((c + shift - baseChar) % 26) + baseChar);
        }

        static string TrithemiusDecipher(string cipherText, string key)
        {
            string plainText = "";
            int keyIndex = 0;

            foreach (char c in cipherText)
            {
                int shift = char.ToUpper(key[keyIndex]) - 64;
                plainText += ShiftCharacter(c, -shift);

                keyIndex++;
                if (keyIndex == key.Length)
                    keyIndex = 0;
            }

            return plainText;
        }




    }
}
