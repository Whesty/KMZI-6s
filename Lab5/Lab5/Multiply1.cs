using System;

namespace Lab5 { 

public class Multiply1
{
     static int[] ConvertToOrderedIndices(string key1)
    {
        char[] characters = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        int[] numKey1 = new int[key1.Length];

        
        
        for (int i = 0; i < key1.Length; i++)
        {
            for (int j = 0; j < characters.Length; j++)
            {
                if (key1[i] == characters[j])
                {
                    numKey1[i] = j;
                   
                }
                
            }
          
        }
        
       

        // Создаем копию исходного массива, который будем сортировать
        int[] sortedArr = (int[])numKey1.Clone();
        Array.Sort(sortedArr);

        // Создаем новый массив порядковых номеров
        int[] orderedIndices = new int[numKey1.Length];

        // Для каждого элемента исходного массива ищем его индекс в отсортированном массиве
        for (int i = 0; i < numKey1.Length; i++)
        {
            int index = Array.IndexOf(sortedArr, numKey1[i]);
            orderedIndices[i] = index;
        }

        return orderedIndices;
    }

   public static char[,] MessageToMatrix(string message, int key1Lenght, int key2Lenght)
   {
       char[,] matrix = new Char[key1Lenght,key2Lenght];

       int x = 0;
      

           for (int i = 0; i < key1Lenght; i++)
           {
               for (int j = 0; j < key2Lenght; j++)
               {
                  if(x < message.Length)
                   matrix[i, j] = message[x++];

               }
           }
       

       return matrix;
   }

   public static string MessToSubstrings(string message, string key1, string key2)
   {
       int[] NumKey1 = new int[key1.Length];
       int[] NumKey2 = new int[key2.Length];
      
       NumKey1 = ConvertToOrderedIndices(key1);
       NumKey2 = ConvertToOrderedIndices(key2);
       int index = 0;
String res = String.Empty;
            int nk = message.Length / (key1.Length * key2.Length);
            if (message.Length % (key1.Length * key2.Length) > 0) nk++;
            string[] matrix = new string[nk];

            for (int i = 0; i < nk; i++)
           {
               if (index < message.Length)
               {
                   matrix[i] = message.Substring(index,
                       Math.Min(key1.Length * key2.Length, message.Length - index));
                   index += key1.Length * key2.Length;

               }
           }

          
       
 foreach (var i in matrix)
           {
               
            res+=   Encript(NumKey1, NumKey2, i);

           }

 return res;
   }
   public static string MessToSubstringsDe(string message, string key1, string key2)
   {
       int[] NumKey1 = new int[key1.Length];
       int[] NumKey2 = new int[key2.Length];
      
       NumKey1 = ConvertToOrderedIndices(key1);
       NumKey2 = ConvertToOrderedIndices(key2);
       int index = 0;
       String res = String.Empty;
            int nk = message.Length /( key1.Length * key2.Length);
            if (message.Length % (key1.Length * key2.Length) > 0) nk++;
       string[] matrix = new string[nk];
      
       for (int i = 0; i < nk; i++)
       {
           if (index < message.Length)
           {
               matrix[i] = message.Substring(index,
                   Math.Min(key1.Length * key2.Length, message.Length - index));
               index += key1.Length * key2.Length;

           }
       }

          
       
       foreach (var i in matrix)
       {
                
                    res +=   Decript(NumKey1, NumKey2, i);

       }

       return res;
   }
   /*public static char[,] MessageToMatrixDecrypt(string message, int key1Lenght, int key2Lenght)
   {
       char[,] matrix = new char[key1Lenght,key2Lenght];

       int index = 0;

       for (int i = 0; i < key1Lenght; i++)
       {
           for (int j = 0; j < key2Lenght; j++)
           {
               if (index < message.Length)
               {
                   int y = message.Length % (message.Length / (key1Lenght * key2Lenght - 1));
                   if (i == 0 && j == 0)
                   {
                       matrix[i, j] = message.Substring(0, y);
                       index = y;
                   }

                   else
                   {
                       matrix[i, j] = message.Substring(index,
                           Math.Min(message.Length / (key1Lenght * key2Lenght - 1), message.Length - index));
                       index += message.Length / (key1Lenght * key2Lenght - 1);
                   }
               }
           }
       }

       return matrix;
   }*/

   static public string Encript(int[] NumKey1, int[] NumKey2, string massage)
   {
     
string res=String.Empty;
       
           char[,] matrix = MessageToMatrix(massage, NumKey1.Length, NumKey2.Length);
           char[,] result = new Char[NumKey1.Length, NumKey2.Length];

           for (int i = 0; i < NumKey1.Length; i++)
           {
               for (int j = 0; j < NumKey2.Length; j++)
               {
                   result[NumKey1[i], NumKey2[j]] = matrix[i,j];
               }
           }

           string resultString = String.Empty;
           for (int i = 0; i < NumKey1.Length; i++)
           for (int k = 0; k < NumKey2.Length; k++)
           {
               resultString += result[i, k];
           }
           resultString = resultString.Replace("\0", "");
           
         

       


       return resultString;
   }
   static public string Decript(int[] NumKey1, int[] NumKey2, string massage)
   {
      

       char[,] matrix = MessageToMatrix(massage, NumKey1.Length, NumKey2.Length);
       char[,] result = new Char[NumKey1.Length, NumKey2.Length];

       for (int i = 0; i < NumKey1.Length; i++)
       {
           for (int j = 0; j < NumKey2.Length; j++)
           {
               result[i,j] = matrix[NumKey1[i],NumKey2[j]];
           }
       }

       string resultString = String.Empty;
       for (int i = 0; i < NumKey1.Length; i++)
       for (int k = 0; k < NumKey2.Length; k++)
       {
           resultString += result[i, k];
       }
       resultString = resultString.Replace("\0", "");
       return resultString;
   }

}
    }