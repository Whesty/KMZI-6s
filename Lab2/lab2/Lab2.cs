using System;
using System.Linq;

namespace lab2
{
    public class Lab2
    {
        public double ShannonЕntropy(String message, char[] alf)
        {
            int[] countOfSymbols = new int[alf.Length];
            double[] frequencyOfOccurrence = new double[alf.Length];
            double shannonЕntropy = 0;
            for (int i = 0; i < alf.Length; i++)
            {
                countOfSymbols[i] = message.ToLower().Count(symb => alf[i] == symb);
                if (countOfSymbols[i] > 0)
                {
                   //Console.WriteLine(alf[i]+ "--" + countOfSymbols[i] );
                }
            }

            for (int i = 0; i < alf.Length; i++)
            {
                // ReSharper disable once PossibleLossOfFraction
                if (countOfSymbols[i] != 0)
                {
                    frequencyOfOccurrence[i] = (double)countOfSymbols[i] / message.Length;
                    shannonЕntropy += frequencyOfOccurrence[i] * Math.Log(frequencyOfOccurrence[i], 2);
                }

            }

            return -shannonЕntropy;
        }

       public String BinaryAlf(String message)
        {
            String strB = "";
            for (int i = 0; i < message.Length; i++)
            {
                strB += Convert.ToString((int)message[i], 2) + " ";
            }

            return strB;
        }

        public double AmountOfInformation(int countOfSymbols, double entropy)
        {
            return entropy * (double)countOfSymbols;

        }

       public double AmountOfInformationWithMistake(int countOfSymbols, double p)
        {
            double q = 1 - p;
            return (1 - (-p * Math.Log(p, 2) - q * Math.Log(q, 2))) * countOfSymbols;
        }
        
    }
}