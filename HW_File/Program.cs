using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_File
{
    class Program
    {
        /*Тема: Взаимодействие с файловой системой.

1.	В файле записана непустая последовательность целых чисел, являющихся числами Фибоначчи. Приписать еще столько же чисел этой последовательности.
2.	Сложить два целых числа А и В.
Входные данные
В единственной строке входного файла INPUT.TXT записано два натуральных числа через пробел.
Выходные данные
В единственную строку выходного файла OUTPUT.TXT нужно вывести одно целое число — сумму чисел А и В.

1.	Написать программу, читающую побайтно заданный файл и подсчитывающую число появлений каждого из 256 возможных знаков.
2.	С помощью класса StreamWriter записать в текстовый файл свое имя, фамилию и возраст. Каждая запись должна начинаться с новой строки.
*/

        static void Main(string[] args)
        {
            WriteNum();
            ReadNum();
        }
        static string path = @"C:\Users\AVassilyev\Documents\visual studio 2017\Projects\HW_File\INPUT.txt";

        public static void WriteNum()
        {
            FileInfo fi = new FileInfo(path);

            Console.WriteLine("Enter first number");
            int n1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int n2 = Int32.Parse(Console.ReadLine());

            using (FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write)) // using заменяет открытие и зикрытие скобками
            { // открытие потока

                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.ASCII))
                {
                    sw.Write(n1);
                    sw.Write(" ");
                    sw.Write(n2);
                    Console.WriteLine("Numbers was write in INPUT.TXT");
                }
            } // закрытие потока      
        }

        public static void ReadNum()
        {

            int summ = 0;

            FileInfo fi = new FileInfo(path);

            using (FileStream fss = fi.Open(FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fss, System.Text.Encoding.ASCII))
                {
                    string t = sr.ReadLine();
                    Console.WriteLine("File was read:  " + t);
                    var m = t.Split(' ');
                    int n01 = int.Parse(m[0]);
                    int n02 = int.Parse(m[1]);
                    summ = n01 + n02;
                    Console.WriteLine("Amount received " + summ);
                }
            }

            FileInfo fii = new FileInfo(@"C:\Users\AVassilyev\Documents\visual studio 2017\Projects\HW_File\OUTPUT.txt");
            using (FileStream fs = fii.Open(FileMode.OpenOrCreate, FileAccess.Write)) // using заменяет открытие и зикрытие скобками
            { // открытие потока

                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.ASCII))
                {
                    sw.Write(summ);
                    Console.WriteLine("Sum was write in OUTPUT.TXT");
                }
            } // закрытие потока

        }
    }
}
