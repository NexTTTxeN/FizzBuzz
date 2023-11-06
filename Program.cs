using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите массив (1, 2, 3, 4):");
            //Полученная строка
            string str = Console.ReadLine();
            ConvertToArray convertToArray = new ConvertToArray();
            ConvertArrToString convertArrToString = new ConvertArrToString();

            Console.WriteLine("Задача 1:");
            List<IIntToWord> words = new List<IIntToWord>();
            //Добавляем необходимы для замены значения
            words.Add(new Fizz());
            words.Add(new Buzz());
            //Определяем объект для преобразования массивов и передаем ему значение которые нужно заменить
            ReplaceToWord rtw = new ReplaceToWord(words);
            //Преобразование массивов
            string[] resultArr = rtw.IntArrToWordArr(convertToArray.ConvertToIntArray(str));
            Console.WriteLine(convertArrToString.ReplaceStrArr(resultArr));

            Console.WriteLine("Задача 2:");
            //Добавляем необходимы для замены значения
            words.Add(new Muzz());
            words.Add(new Guzz());
            //Определяем объект для преобразования массивов и передаем ему значение которые нужно заменить
            resultArr = rtw.IntArrToWordArr(convertToArray.ConvertToIntArray(str));
            //Преобразование массивов
            Console.WriteLine(convertArrToString.ReplaceStrArr(resultArr));

            Console.WriteLine("Задача 3:");
            //Добавляем необходимы для замены значения
            words.Clear();
            words.Add(new GodBoy());
            words.Add(new Muzz());
            words.Add(new Guzz());
            //Определяем объект для преобразования массивов и передаем ему значение которые нужно заменить
            resultArr = rtw.IntArrToWordArr(convertToArray.ConvertToIntArray(str));
            //Преобразование массивов
            Console.WriteLine(convertArrToString.ReplaceStrArr(resultArr));
            Console.ReadKey();
        }
    }
}
