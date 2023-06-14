using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab5
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите размерность таблицы: ");
            int n = int.Parse(Console.ReadLine());

            string str = ZigZagCipher("This a big massage",n);
            Console.WriteLine(str);
            string str2 = ZigZagDecrypt(str, n);
            Console.WriteLine(str2);

            // string str3 = DoublePermutationEncrypt(str2, "mamaeva", "diana");
            //Console.WriteLine(str3);
            str2 = "Banana is the common name for herbaceous plants of the genus Musa and for the fruit they produce. Bananas come in a variety of sizes and colors when ripe, including yellow, purple, and red.Almost all modern edible parthenocarpic bananas come from the two wild species Musa acuminata and Musa balbisiana. The scientific names of bananas are Musa acuminata, Musa balbisiana or hybrids Musa acuminata x balbisiana, depending on their genomic constitution. The old scientific names Musa sapientum and Musa paradisiaca are no longer used.Banana is also used to describe Enset and Fe'i bananas, neither of which belong to the Musa genus. Enset bananas belong to the genus Ensete while the taxonomy of Fe'i-type cultivars is uncertain.The edible banana is usually associated with tasty pulp, which is hard at first, but becomes soft as it ripens. Bananas are one of the favorite fruits on the planet. It is eaten most in Ecuador - an average of almost 80 kilograms per person per year.They are native to tropical South and Southeast Asia, and are likely to have been first domesticated in Papua New Guinea. Today, they are cultivated throughout the tropics. They are grown in at least 107 countries, primarily for their fruit, and to a lesser exte";
            Console.WriteLine("Исходный текст");
            Console.WriteLine(str2);
            string str3 = Multiply1.MessToSubstrings(str2, "maev", "dzian");
            string str4 = Multiply1.MessToSubstringsDe(str3, "maev", "dzian");
            Console.WriteLine("ЗАшфр:" +str3);
            Console.WriteLine("Расшифр:" + str4);

            Console.ReadLine();
        }

        static string ZigZagCipher(string message, int n)
        {
            char[,] matrix = new char[n, message.Length];
            int row = 0;
            int col = 0;
            bool down = true;
            int index = 0;
            string result = "";

            // зашифровка/расшифровка сообщения
            while (index < message.Length)
            {
                if (down)
                {
                    matrix[row, col] = message[index++];
                    if (row == n - 1)
                    {
                        down = false;
                        row--;
                        col++;
                    }
                    else
                    {
                        row++;
                    }
                }
                else
                {
                    matrix[row, col] = message[index++];
                    if (row == 0)
                    {
                        down = true;
                        row++;
                        col++;
                    }
                    else
                    {
                        row--;
                    }
                }
            }

            // сборка результата
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < message.Length; j++)
                {
                    if (matrix[i, j] != '\0')
                    {
                        result += matrix[i, j];
                    }
                }
            }

            return result;
        }
        static string ZigZagDecrypt(string message, int n)
        {
            char[,] matrix = new char[n, message.Length];
            int row = 0;
            int col = 0;
            bool down = true;
            int index = 0;
            string result = "";

            // заполнение таблицы
            for (int i = 0; i < message.Length; i++)
            {
                if (down)
                {
                    matrix[row, col] = '*';
                    if (row == n - 1)
                    {
                        down = false;
                        row--;
                        col++;
                    }
                    else
                    {
                        row++;
                    }
                }
                else
                {
                    matrix[row, col] = '*';
                    if (row == 0)
                    {
                        down = true;
                        row++;
                        col++;
                    }
                    else
                    {
                        row--;
                    }
                }
            }

            // чтение зашифрованного сообщения
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < message.Length; j++)
                {
                    if (matrix[i, j] == '*' && index < message.Length)
                    {
                        matrix[i, j] = message[index++];
                    }
                }
            }

            // сборка результата
            row = 0;
            col = 0;
            down = true;
            for (int i = 0; i < message.Length; i++)
            {
                result += matrix[row, col];
                if (down)
                {
                    if (row == n - 1)
                    {
                        down = false;
                        row--;
                        col++;
                    }
                    else
                    {
                        row++;
                    }
                }
                else
                {
                    if (row == 0)
                    {
                        down = true;
                        row++;
                        col++;
                    }
                    else
                    {
                        row--;
                    }
                }
            }

            return result;
        }

    



}
}
