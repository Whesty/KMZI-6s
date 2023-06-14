using System;
using System.IO;
using System.Linq;
using System.Text;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Lab2 func = new Lab2();
            Lab3 func1 = new Lab3();
            char[] russianAlphabet = 
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                'ы', 'ь', 'э', 'ю', 'я'
            };
            string rusA = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string enA = "abcdefghijklmnopqrstuvwxyz";
            char[] latinAlphabet = 
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            char[] binAlphabet = { '1', '0' };
            string filePathRus = @".\..\..\NewFile1.txt"; // здесь указывается путь к файлу
            string rusFileContents = File.ReadAllText(filePathRus);
                
            string filePathLat = @".\..\..\NewFile2.txt"; // здесь указывается путь к файлу
            string latFileContents = File.ReadAllText(filePathLat);

            Console.WriteLine("Задание1---------");
            Console.WriteLine("\nBase64 File1:");
            string file1base64 = func1.ConvertDocumentToBase64(filePathRus);
            Console.WriteLine(file1base64);
            Console.WriteLine("\nBase64 File2:");
            string file2base64 = func1.ConvertDocumentToBase64(filePathLat);
            Console.WriteLine(file2base64);
            Console.WriteLine("\nЗадание2-------");
            Console.WriteLine( "Энтропия Шеннона для русского алфавита: "+ func.ShannonЕntropy(rusFileContents, russianAlphabet));
            Console.WriteLine( "Энтропия Шеннона для латинского алфавита: "+ func.ShannonЕntropy(latFileContents, latinAlphabet));
            //избыточность алфавитов
            Console.WriteLine( "Избыточность алфовита en: " + func1.FindAlphabetRedundancy(rusA));
            Console.WriteLine( "Избыточность алфовита ru: " + func1.FindAlphabetRedundancy(enA));

            Console.WriteLine("\nЗадание3-------");
            string nam = "Diana";
            byte[] a = Encoding.ASCII.GetBytes(nam);
            string fam = "Mamaeva";
            byte[] b = Encoding.ASCII.GetBytes(fam);
            Console.WriteLine("В ASCII: \n" + Encoding.UTF8.GetString( func1.XorBuffers(a, b)));
            string filePathA = @".\..\..\Lastname.txt";
            string filePathB = @".\..\..\Name.txt";
            byte[] a64 = Convert.FromBase64String(func1.ConvertDocumentToBase64(filePathA));
            byte[] b64 = Convert.FromBase64String(func1.ConvertDocumentToBase64(filePathB));
            Console.WriteLine("В base64: \n" + Encoding.UTF8.GetString( func1.XorBuffers(a64, b64)));
            Console.WriteLine("В aXORbXORb: \n" + Encoding.UTF8.GetString( func1.XorBuffers(func1.XorBuffers(a, b), b64)));


            //string binRus = func.BinaryAlf(rusFileContents);
            //string binLat = func.BinaryAlf(latFileContents);
            //Console.WriteLine( "Энтропия Шеннона для русского алфавита  в бинарном виде: "+ func.ShannonЕntropy(binRus, binAlphabet));
            //Console.WriteLine( "Энтропия Шеннона для латинского алфавита  в бинарном виде: "+ func.ShannonЕntropy(binLat, binAlphabet));

            //string myFio = "Мамаева Диана Александровна";
            //string myFioEn = "Mamaeva Diana Alexandrovna";
            //string binRusFio = func.BinaryAlf(myFio);
            //string binLatFio = func.BinaryAlf(myFioEn);

            //Console.WriteLine( "Количество информации rus: "+ func.AmountOfInformation(myFio.Length, func.ShannonЕntropy(myFio, russianAlphabet)));
            //Console.WriteLine( "Количество информации lat: "+ func.AmountOfInformation(myFioEn.Length, func.ShannonЕntropy(myFioEn, latinAlphabet)));

            //Console.WriteLine( "Количество информации rus bin: "+ func.AmountOfInformation(binRusFio.Length, func.ShannonЕntropy(binRusFio, binAlphabet)));
            //Console.WriteLine( "Количество информации lat bin: "+ func.AmountOfInformation(binLatFio.Length, func.ShannonЕntropy(binLatFio, binAlphabet)));

            //Console.WriteLine( "Количество информации rus с ошибками 0.1: "+ func.AmountOfInformationWithMistake(myFio.Length,  0.1));
            //Console.WriteLine( "Количество информации rus с ошибками 0.5"+ func.AmountOfInformationWithMistake(myFio.Length, 0.5));
            //Console.WriteLine( "Количество информации rus с ошибками 1"+ func.AmountOfInformationWithMistake(myFio.Length,  1));
            //Console.WriteLine( "Количество информации lat с ошибками 0.1"+ func.AmountOfInformationWithMistake(myFioEn.Length,  0.1));
            //Console.WriteLine( "Количество информации lat с ошибками 0.5"+ func.AmountOfInformationWithMistake(myFioEn.Length, 0.5));
            //Console.WriteLine( "Количество информации lat с ошибками 1"+ func.AmountOfInformationWithMistake(myFioEn.Length, 1));
        }
    }
}